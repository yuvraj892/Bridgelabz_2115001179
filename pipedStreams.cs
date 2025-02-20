using System;
using System.IO;
using System.IO.Pipes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PipeStreamCommunication
{
    class Program
    {
        // Create cancellation token source for synchronization
        static CancellationTokenSource cts = new CancellationTokenSource();
        // Create a ManualResetEvent to signal when server is ready
        static ManualResetEvent serverReadyEvent = new ManualResetEvent(false);
        // Pipe name
        static string pipeName = "csharp_pipe_demo";

        static void Main(string[] args)
        {
            try
            {
                // Start server task (reader)
                Task serverTask = Task.Run(() => RunServerAsync(cts.Token));
               
                // Wait until server is ready
                serverReadyEvent.WaitOne();
               
                // Give the server a moment to initialize
                Thread.Sleep(500);
               
                // Start client task (writer)
                Task clientTask = Task.Run(() => RunClientAsync(cts.Token));
               
                // Display instructions to the user
                Console.WriteLine("Inter-thread communication using PipeStream");
                Console.WriteLine("Press Enter to stop...");
                Console.ReadLine();
               
                // Signal cancellation to stop both threads
                cts.Cancel();
               
                // Wait for both tasks to complete
                Task.WaitAll(new Task[] { serverTask, clientTask }, 2000);
               
                // Display completion message
                Console.WriteLine("Communication finished.");
            }
            catch (Exception ex)
            {
                // Handle general exceptions
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                // Ensure resources are disposed
                cts.Dispose();
                serverReadyEvent.Dispose();
            }

            // Wait for user to press a key before closing
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        // Server method (reader)
        static async Task RunServerAsync(CancellationToken token)
        {
            try
            {
                // Create named pipe server stream
                using (NamedPipeServerStream pipeServer = new NamedPipeServerStream(pipeName, PipeDirection.In))
                {
                    // Signal that the server is ready
                    serverReadyEvent.Set();
                   
                    // Display server starting message
                    Console.WriteLine("Server thread started. Waiting for connection...");
                   
                    // Wait for client connection
                    pipeServer.WaitForConnection();
                    Console.WriteLine("Client connected to server.");
                   
                    // Create stream reader from pipe
                    using (StreamReader reader = new StreamReader(pipeServer, Encoding.UTF8))
                    {
                        // Read until cancellation is requested
                        while (!token.IsCancellationRequested)
                        {
                            try
                            {
                                // Read a line from the pipe
                                string message = await reader.ReadLineAsync();
                               
                                // Check if message is valid
                                if (message != null)
                                {
                                    // Display received message
                                    Console.WriteLine("Server received: " + message);
                                }
                                else
                                {
                                    // Break if end of stream
                                    break;
                                }
                               
                                // Simulate processing time
                                await Task.Delay(100, token);
                            }
                            catch (IOException)
                            {
                                // Handle broken pipe
                                Console.WriteLine("Pipe connection broken.");
                                break;
                            }
                            catch (OperationCanceledException)
                            {
                                // Handle cancellation
                                break;
                            }
                        }
                    }
                }
               
                // Display server shutdown message
                Console.WriteLine("Server thread finished.");
            }
            catch (Exception ex)
            {
                // Handle server exceptions
                Console.WriteLine("Server error: " + ex.Message);
            }
        }

        // Client method (writer)
        static async Task RunClientAsync(CancellationToken token)
        {
            try
            {
                // Create named pipe client stream
                using (NamedPipeClientStream pipeClient = new NamedPipeClientStream(".", pipeName, PipeDirection.Out))
                {
                    try
                    {
                        // Connect to the pipe server with timeout
                        Console.WriteLine("Client thread started. Connecting to server...");
                        pipeClient.Connect(3000);
                        Console.WriteLine("Client connected to server.");
                       
                        // Create stream writer
                        using (StreamWriter writer = new StreamWriter(pipeClient, Encoding.UTF8) { AutoFlush = true })
                        {
                            // Counter for messages
                            int messageCount = 1;
                           
                            // Send messages until cancellation is requested
                            while (!token.IsCancellationRequested)
                            {
                                try
                                {
                                    // Create message with timestamp
                                    string message = "Message #" + messageCount + " - Time: " + DateTime.Now.ToString("HH:mm:ss.fff");
                                   
                                    // Write message to pipe
                                    await writer.WriteLineAsync(message);
                                   
                                    // Display sent message
                                    Console.WriteLine("Client sent: " + message);
                                   
                                    // Increment message counter
                                    messageCount++;
                                   
                                    // Wait before sending next message
                                    await Task.Delay(1000, token);
                                }
                                catch (OperationCanceledException)
                                {
                                    // Handle cancellation
                                    break;
                                }
                            }
                        }
                    }
                    catch (TimeoutException)
                    {
                        // Handle connection timeout
                        Console.WriteLine("Connection timed out.");
                    }
                }
               
                // Display client shutdown message
                Console.WriteLine("Client thread finished.");
            }
            catch (Exception ex)
            {
                // Handle client exceptions
                Console.WriteLine("Client error: " + ex.Message);
            }
        }
    }
}

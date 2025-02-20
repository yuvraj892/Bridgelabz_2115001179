using System;
using System.IO;

namespace ImageByteArrayConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define source and destination image paths
            string sourceImagePath = "source_image.jpg";
            string destinationImagePath = "destination_image.jpg";

            try
            {
                // Check if source image exists
                if (!File.Exists(sourceImagePath))
                {
                    // Display error if source image does not exist
                    Console.WriteLine("Source image does not exist: " + sourceImagePath);
                    return;
                }

                // Convert image to byte array
                byte[] imageBytes = ConvertImageToByteArray(sourceImagePath);
               
                // Display byte array size
                Console.WriteLine("Image converted to byte array. Size: " + imageBytes.Length + " bytes");
               
                // Convert byte array back to image
                ConvertByteArrayToImage(imageBytes, destinationImagePath);
               
                // Verify the files are identical
                bool areIdentical = CompareFiles(sourceImagePath, destinationImagePath);
               
                // Display verification result
                Console.WriteLine("Files are identical: " + areIdentical);
            }
            catch (IOException ex)
            {
                // Handle IO exceptions
                Console.WriteLine("An IO error occurred: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                Console.WriteLine("An error occurred: " + ex.Message);
            }

            // Wait for user to press a key before closing
            Console.ReadKey();
        }

        // Method to convert image to byte array
        static byte[] ConvertImageToByteArray(string imagePath)
        {
            try
            {
                // Read all bytes from the image file
                byte[] imageData = File.ReadAllBytes(imagePath);
               
                // Create a memory stream to process the byte array
                using (MemoryStream ms = new MemoryStream())
                {
                    // Write image data to memory stream
                    ms.Write(imageData, 0, imageData.Length);
                   
                    // Return the byte array from memory stream
                    return ms.ToArray();
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine("Error converting image to byte array: " + ex.Message);
                throw;
            }
        }

        // Method to convert byte array back to image
        static void ConvertByteArrayToImage(byte[] imageBytes, string outputPath)
        {
            try
            {
                // Create a memory stream from the byte array
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    // Create a file stream to write the new image
                    using (FileStream fs = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                    {
                        // Copy the memory stream to the file stream
                        ms.CopyTo(fs);
                    }
                }
               
                // Display success message
                Console.WriteLine("Image successfully written to: " + outputPath);
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine("Error converting byte array to image: " + ex.Message);
                throw;
            }
        }

        // Method to compare two files to verify they are identical
        static bool CompareFiles(string file1, string file2)
        {
            try
            {
                // Get file info for both files
                FileInfo fileInfo1 = new FileInfo(file1);
                FileInfo fileInfo2 = new FileInfo(file2);
               
                // Compare file sizes
                if (fileInfo1.Length != fileInfo2.Length)
                {
                    // Files have different sizes, cannot be identical
                    return false;
                }
               
                // Read and compare files byte by byte
                using (FileStream fs1 = new FileStream(file1, FileMode.Open, FileAccess.Read))
                using (FileStream fs2 = new FileStream(file2, FileMode.Open, FileAccess.Read))
                {
                    // Read one byte at a time from each file
                    int byte1, byte2;
                    do
                    {
                        // Read next byte from each file
                        byte1 = fs1.ReadByte();
                        byte2 = fs2.ReadByte();
                       
                        // Compare bytes
                        if (byte1 != byte2)
                        {
                            // Found a difference
                            return false;
                        }
                    } while (byte1 != -1 && byte2 != -1); // Continue until end of file
                   
                    // If we got here, files are identical
                    return true;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine("Error comparing files: " + ex.Message);
                return false;
            }
        }
    }
}

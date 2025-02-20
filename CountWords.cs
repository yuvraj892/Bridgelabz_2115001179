using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define file path
            string filePath = "sample_text.txt";

            try
            {
                // Check if file exists
                if (!File.Exists(filePath))
                {
                    // Create sample text file
                    CreateSampleTextFile(filePath);
                }

                // Count words in the file
                Dictionary<string, int> wordCounts = CountWordsInFile(filePath);
               
                // Get total word count
                int totalWords = wordCounts.Values.Sum();

                // Display results
                Console.WriteLine("Word Count Analysis");
                Console.WriteLine("------------------");
                Console.WriteLine("Total words found: " + totalWords);
               
                // Get top 5 words
                var topWords = GetTopWords(wordCounts, 5);
               
                // Display top words
                Console.WriteLine("\nTop 5 most frequent words:");
                Console.WriteLine("-------------------------");
               
                // Create display format
                string format = "{0,-15} {1,-10} {2,-10}";
               
                // Display header
                Console.WriteLine(format, "Word", "Count", "Frequency");
                Console.WriteLine(format, "---------------", "----------", "----------");
               
                // Display each top word
                foreach (var word in topWords)
                {
                    // Calculate frequency percentage
                    double frequency = (double)word.Value / totalWords * 100;
                   
                    // Display word, count and frequency
                    Console.WriteLine(format, word.Key, word.Value, frequency.ToString("F2") + "%");
                }
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
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        // Method to count words in a file
        static Dictionary<string, int> CountWordsInFile(string filePath)
        {
            // Create dictionary to store word counts
            Dictionary<string, int> wordCounts = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
           
            try
            {
                // Open the file using StreamReader
                using (StreamReader reader = new StreamReader(filePath))
                {
                    // Read the entire file content
                    string content = reader.ReadToEnd();
                   
                    // Split into words using regex
                    string[] words = Regex.Split(content, @"\W+")
                                         .Where(w => !string.IsNullOrWhiteSpace(w))
                                         .ToArray();
                   
                    // Count each word
                    foreach (string word in words)
                    {
                        // Normalize to lowercase
                        string normalizedWord = word.ToLower();
                       
                        // Increment word count in dictionary
                        if (wordCounts.ContainsKey(normalizedWord))
                        {
                            // Increment existing word
                            wordCounts[normalizedWord]++;
                        }
                        else
                        {
                            // Add new word
                            wordCounts[normalizedWord] = 1;
                        }
                    }
                }
               
                // Display success message
                Console.WriteLine("Successfully analyzed " + filePath);
               
                // Return the word counts
                return wordCounts;
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine("Error counting words: " + ex.Message);
                throw;
            }
        }

        // Method to get top N most frequent words
        static Dictionary<string, int> GetTopWords(Dictionary<string, int> wordCounts, int topCount)
        {
            try
            {
                // Sort the dictionary by value (count) descending
                var sortedWords = wordCounts
                    .OrderByDescending(pair => pair.Value)
                    .Take(topCount)
                    .ToDictionary(pair => pair.Key, pair => pair.Value);
               
                // Return sorted dictionary
                return sortedWords;
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine("Error getting top words: " + ex.Message);
                throw;
            }
        }

        // Method to create a sample text file
        static void CreateSampleTextFile(string filePath)
        {
            try
            {
                // Sample text (excerpt from a public domain text)
                string sampleText = @"
The Project Gutenberg eBook of Pride and Prejudice, by Jane Austen

This eBook is for the use of anyone anywhere in the United States and
most other parts of the world at no cost and with almost no restrictions
whatsoever. You may copy it, give it away or re-use it under the terms
of the Project Gutenberg License included with this eBook or online at
www.gutenberg.org. If you are not located in the United States, you
will have to check the laws of the country where you are located before
using this eBook.

Title: Pride and Prejudice

Author: Jane Austen

Release Date: June, 1998 [eBook #1342]
[Most recently updated: November 12, 2020]

Language: English

Character set encoding: UTF-8

Produced by: Anonymous Volunteers

*** START OF THE PROJECT GUTENBERG EBOOK PRIDE AND PREJUDICE ***

PRIDE AND PREJUDICE

By Jane Austen

Chapter 1

It is a truth universally acknowledged, that a single man in possession
of a good fortune, must be in want of a wife.

However little known the feelings or views of such a man may be on his
first entering a neighbourhood, this truth is so well fixed in the minds
of the surrounding families, that he is considered the rightful property
of some one or other of their daughters.

'My dear Mr. Bennet,' said his lady to him one day, 'have you heard that
Netherfield Park is let at last?'

Mr. Bennet replied that he had not.

'But it is,' returned she; 'for Mrs. Long has just been here, and she
told me all about it.'

Mr. Bennet made no answer.

'Do you not want to know who has taken it?' cried his wife impatiently.

'_You_ want to tell me, and I have no objection to hearing it.'

This was invitation enough.

'Why, my dear, you must know, Mrs. Long says that Netherfield is taken
by a young man of large fortune from the north of England; that he came
down on Monday in a chaise and four to see the place, and was so much
delighted with it, that he agreed with Mr. Morris immediately; that he
is to take possession before Michaelmas, and some of his servants are to
be in the house by the end of next week.'

'What is his name?'

'Bingley.'

'Is he married or single?'

'Oh! Single, my dear, to be sure! A single man of large fortune; four or
five thousand a year. What a fine thing for our girls!'

'How so? How can it affect them?'

'My dear Mr. Bennet,' replied his wife, 'how can you be so tiresome! You
must know that I am thinking of his marrying one of them.'

'Is that his design in settling here?'

'Design! Nonsense, how can you talk so! But it is very likely that he
_may_ fall in love with one of them, and therefore you must visit him as
soon as he comes.'
";

                // Write sample text to file
                File.WriteAllText(filePath, sampleText);
               
                // Display success message
                Console.WriteLine("Sample text file created: " + filePath);
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine("Error creating sample text file: " + ex.Message);
                throw;
            }
        }
    }
}

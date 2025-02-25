using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;

class EncryptDecryptCSV
{
    public static void Main(string[] args)
    {
        // Define encryption key and IV (initialization vector)
        string encryptionKey = "ThisIsA32ByteKeyForAES256Encryption";

        // Encrypt and write data to CSV
        EncryptAndWriteCSV(encryptionKey);

        // Read and decrypt data from CSV
        ReadAndDecryptCSV(encryptionKey);
    }

    // Method to encrypt and write data to CSV
    private static void EncryptAndWriteCSV(string key)
    {
        // Sample employee data
        List<Employee> employees = new List<Employee>
        {
            new Employee { ID = 1, Name = "John Doe", Email = "john.doe@example.com", Salary = 75000 },
            new Employee { ID = 2, Name = "Jane Smith", Email = "jane.smith@example.com", Salary = 82000 },
            new Employee { ID = 3, Name = "Robert Johnson", Email = "robert.johnson@example.com", Salary = 68000 },
            new Employee { ID = 4, Name = "Emily Davis", Email = "emily.davis@example.com", Salary = 92000 },
            new Employee { ID = 5, Name = "Michael Wilson", Email = "michael.wilson@example.com", Salary = 78500 }
        };

        // Create configuration for custom CSV mapping
        var config = new CsvConfiguration(CultureInfo.InvariantCulture);

        // Write to encrypted CSV file
        using (var writer = new StreamWriter("D:\\AVS\\BridgeLabz\\assignment\\25 feb\\employees_encrypted.csv"))
        using (var csv = new CsvWriter(writer, config))
        {
            // Register class map for encryption
            csv.Context.RegisterClassMap<EncryptedEmployeeMap>();

            // Set encryption key in the context
            csv.Context.Items["EncryptionKey"] = key;

            // Write all records to the file
            csv.WriteRecords(employees);
        }

        // Display success message
        Console.WriteLine("Employee data encrypted and saved to CSV successfully.");
    }

    // Method to read and decrypt data from CSV
    private static void ReadAndDecryptCSV(string key)
    {
        try
        {
            // Create configuration for custom CSV mapping
            var config = new CsvConfiguration(CultureInfo.InvariantCulture);

            // Read from encrypted CSV file
            using (var reader = new StreamReader("D:\\AVS\\BridgeLabz\\assignment\\25 feb\\employees_encrypted.csv"))
            using (var csv = new CsvReader(reader, config))
            {
                // Register class map for decryption
                csv.Context.RegisterClassMap<EncryptedEmployeeMap>();

                // Set encryption key in the context
                csv.Context.Items["EncryptionKey"] = key;

                // Read and decrypt all records
                var records = csv.GetRecords<Employee>().ToList();

                // Display decrypted data
                Console.WriteLine("\nDecrypted Employee Data:");
                foreach (var employee in records)
                {
                    Console.WriteLine("ID: " + employee.ID +
                                    ", Name: " + employee.Name +
                                    ", Email: " + employee.Email +
                                    ", Salary: " + employee.Salary);
                }
            }
        }
        catch (Exception ex)
        {
            // Display error message
            Console.WriteLine("Error reading/decrypting CSV: " + ex.Message);
        }
    }

    // Method to encrypt a string
    private static string Encrypt(string plainText, string key)
    {
        if (string.IsNullOrEmpty(plainText))
            return plainText;

        try
        {
            // Convert key to bytes
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] iv = new byte[16]; // AES block size is 16 bytes

            // Create an AES instance
            using (Aes aes = Aes.Create())
            {
                // Use first 32 bytes of key for AES-256
                byte[] actualKey = new byte[32];
                Array.Copy(keyBytes, actualKey, Math.Min(keyBytes.Length, 32));

                // Set key and IV
                aes.Key = actualKey;
                aes.IV = iv;

                // Create encryptor
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                // Encrypt the data
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                        {
                            sw.Write(plainText);
                        }
                    }

                    // Convert to Base64 string
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }
        catch
        {
            // Return original text if encryption fails
            return plainText;
        }
    }

    // Method to decrypt a string
    private static string Decrypt(string cipherText, string key)
    {
        if (string.IsNullOrEmpty(cipherText))
            return cipherText;

        try
        {
            // Convert cipher text from Base64
            byte[] cipherBytes = Convert.FromBase64String(cipherText);

            // Convert key to bytes
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] iv = new byte[16]; // AES block size is 16 bytes

            // Create an AES instance
            using (Aes aes = Aes.Create())
            {
                // Use first 32 bytes of key for AES-256
                byte[] actualKey = new byte[32];
                Array.Copy(keyBytes, actualKey, Math.Min(keyBytes.Length, 32));

                // Set key and IV
                aes.Key = actualKey;
                aes.IV = iv;

                // Create decryptor
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                // Decrypt the data
                using (MemoryStream ms = new MemoryStream(cipherBytes))
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader sr = new StreamReader(cs))
                        {
                            return sr.ReadToEnd();
                        }
                    }
                }
            }
        }
        catch
        {
            // Return original text if decryption fails
            return cipherText;
        }
    }
}

// Class to represent an employee record
class Employee
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public decimal Salary { get; set; }
}

// Custom class map for encrypting/decrypting sensitive fields
class EncryptedEmployeeMap : ClassMap<Employee>
{
    public EncryptedEmployeeMap()
    {
        // Map ID field (not encrypted)
        Map(m => m.ID);

        // Map Name field (not encrypted)
        Map(m => m.Name);

        // Map Email field with encryption/decryption
        Map(m => m.Email).Convert(row =>
        {
            // Get the encryption key from context
            string key = (string)row.Context.Items["EncryptionKey"];

            // Handle reading (decryption)
            if (row.Context.ReaderRow != null && row.Context.ReaderRow.TryGetField<string>("Email", out var value))
            {
                return EncryptDecryptCSV.Decrypt(value, key);
            }

            // Handle writing (encryption)
            return EncryptDecryptCSV.Encrypt(row.Value.Email, key);
        });

        // Map Salary field with encryption/decryption
        Map(m => m.Salary).Convert(row =>
        {
            // Get the encryption key from context
            string key = (string)row.Context.Items["EncryptionKey"];

            // Handle reading (decryption)
            if (row.Context.ReaderRow != null && row.Context.ReaderRow.TryGetField<string>("Salary", out var value))
            {
                string decrypted = EncryptDecryptCSV.Decrypt(value, key);
                if (decimal.TryParse(decrypted, out decimal result))
                {
                    return result;
                }
                return 0M;
            }

            // Handle writing (encryption)
            return EncryptDecryptCSV.Encrypt(row.Value.Salary.ToString(), key);
        });
    }
}
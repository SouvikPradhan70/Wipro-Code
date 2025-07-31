
//need to include following packages
using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Xml.Schema;


class program
{
    static void Main(string[] args)
    {
        //a menu that shows option to started
        while (true)
        {
            Console.WriteLine("\nSSecure message app -General feature");
            Console.WriteLine("1. Encrypt a message");
            Console.WriteLine("2. Decrypt a message");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option: ");
            string ? choose = Console.ReadLine();

            switch (choose)
            {
                case "1":
                    Console.WriteLine("Enter your message to encrypt:");
                    string ? pt = Console.ReadLine();
                    Console.WriteLine("Enter a 16 digit key");
                    string ? key = Console.ReadLine();
                    string encrypted = Encrypt(pt, key);
                    Console.WriteLine($"Encrypted message : {encrypted}");
                    break;

                case "2":
                    Console.WriteLine("Enter the encrypted message:");
                    string ? ct = Console.ReadLine();
                    Console.WriteLine("Enter the 16 digit key used for encryption:");
                    string ? decryptionKey = Console.ReadLine();
                    string decrypted = Decrypt(ct, decryptionKey);
                    Console.WriteLine($"Decrypted message: {decrypted}");
                    break;

                case "3":
                    Console.WriteLine("Exiting the application...");
                    return; // Exit the application


                default:
                    Console.WriteLine("Invalif choice");
                    break;
            }

        }

    }

    static string Encrypt(string plaintext,string key)
    {
        //here we can use any algorithm
        //step 1: Create an AES object
        //step 2:setting up the encyption key
        //step 3:Generate aNd Store IV(Initialization Vector)
        //step 4:Create an encryptor
        //step 5:Create a memory stream to hold the encrypted data
        //step 6:Write plain text through crypto system
        //step 7:Converting enrypted bytes to Base64 string
        using Aes aes = Aes.Create();
        aes.Key = Encoding.UTF8.GetBytes(key); //encoading all char in a sequence of Bytes 
        aes.GenerateIV(); //performing encryption

        var iv = aes.IV;

        using var encyptor= aes.CreateEncryptor();
        using var ms = new MemoryStream();
        ms.Write(iv, 0, iv.Length); //store IV in output
        using (var cs = new CryptoStream(ms, encyptor, CryptoStreamMode.Write))
        using (var sw = new StreamWriter(cs))
        {
            sw.Write(plaintext); //write the plaintext to the stream
        }
        return Convert.ToBase64String(ms.ToArray()); //return the encrypted message as a base64 string
    }

    static string Decrypt(string encryptedMessage, string key)
    {
        //using the encrypted text to make it readable again
        //step 1: convert the encrypted base 64 text to bytes
        var fullBytes = Convert.FromBase64String(encryptedMessage);
        using Aes aes = Aes.Create();
        aes.Key=Encoding.UTF8.GetBytes(key); //set the key for decryption

        //step 2:create ES object and set the key
        byte[] iv = new byte[16];
        Array.Copy(fullBytes,0, iv,0,16); 
        aes.IV = iv; 
        //step 3:Extract and set initialization vector(IV)

        using var decriptor = aes.CreateDecryptor();
        //step 4:Create a decryptor object

        using var ms=new MemoryStream(fullBytes, 16, fullBytes.Length - 16);
        //step 5:Craeate a memory stream for the enrypted data
        using var cs =new CryptoStream(ms, decriptor, CryptoStreamMode.Read);
        using var sr = new StreamReader(cs);
        

        //step 6:Wrap crypto stream and read the decrypt data 
        return sr.ReadToEnd();
        //step 7:Return the decrypted message as a string

    }
}

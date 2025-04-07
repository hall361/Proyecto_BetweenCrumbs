using BC.Repositories.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BC.Repositories.Utilities.Services
{
    public class Secural : ISecural
    {
        public string CreateConnectionKey(string valor)
        {
            string original = valor;
            Aes aesAlg2 = Aes.Create();
            string key2 = Convert.ToBase64String(aesAlg2.Key);
            string IV2 = Convert.ToBase64String(aesAlg2.IV);
            // Create a new instance of the Aes
            // class.  This generates a new key and initialization
            // vector (IV).
            using (Aes myAes = Aes.Create())
            {
                string valueKey = "SE99KOTLeCos7sBmMFw60FLgec9xXBLS+SljQKIPYQs=";
                string valueIV = "r5lukxD8ldC2fddGomAkVg==";
                myAes.Key = Convert.FromBase64String(valueKey);
                myAes.IV = Convert.FromBase64String(valueIV);

                //Encrypt the string to an array of bytes.
                byte[] encrypted = EncryptStringToBytes_Aes(original, myAes.Key, myAes.IV);

                // Decrypt the bytes to a string.
                //string roundtrip = DecryptStringFromBytes_Aes(valorEnc, myAes.Key, myAes.IV);

                return Convert.ToBase64String(encrypted);

                //Display the original data and the decrypted data.
                //Console.WriteLine("Original:   {0}", original);
                //Console.WriteLine("Round Trip: {0}", roundtrip);
            }
        }
        public string ConnectionKey(string valor)
        {
            string original = valor;
            Aes aesAlg2 = Aes.Create();
            string key2 = Convert.ToBase64String(aesAlg2.Key);
            string IV2 = Convert.ToBase64String(aesAlg2.IV);
            // Create a new instance of the Aes
            // class.  This generates a new key and initialization
            // vector (IV).
            using (Aes myAes = Aes.Create())
            {
                string valueKey = "SE99KOTLeCos7sBmMFw60FLgec9xXBLS+SljQKIPYQs=";
                string valueIV = "r5lukxD8ldC2fddGomAkVg==";
                myAes.Key = Convert.FromBase64String(valueKey);
                myAes.IV = Convert.FromBase64String(valueIV);
                byte[] valorEnc = Convert.FromBase64String(valor);

                // Encrypt the string to an array of bytes.
                //byte[] encrypted = EncryptStringToBytes_Aes(original, myAes.Key, myAes.IV);

                // Decrypt the bytes to a string.
                string roundtrip = DecryptStringFromBytes_Aes(valorEnc, myAes.Key, myAes.IV);

                return roundtrip;

                //Display the original data and the decrypted data.
                //Console.WriteLine("Original:   {0}", original);
                //Console.WriteLine("Round Trip: {0}", roundtrip);
            }
        }

        public string CreateKey(string valor)
        {
            string original = valor;
            Aes aesAlg2 = Aes.Create();
            string key2 = Convert.ToBase64String(aesAlg2.Key);
            string IV2 = Convert.ToBase64String(aesAlg2.IV);
            // Create a new instance of the Aes
            // class.  This generates a new key and initialization
            // vector (IV).
            using (Aes myAes = Aes.Create())
            {
                string valueKey = "hLMKExCkXIzbv1mNcm/psXecEBNRFTWpjnMp/VoUCEY=";
                string valueIV = "qKjgpNLLORowDAGuHJTjTQ==";
                myAes.Key = Convert.FromBase64String(valueKey);
                myAes.IV = Convert.FromBase64String(valueIV);

                // Encrypt the string to an array of bytes.
                byte[] encrypted = EncryptStringToBytes_Aes(original, myAes.Key, myAes.IV);

                // Decrypt the bytes to a string.
                //string roundtrip = DecryptStringFromBytes_Aes(encrypted, myAes.Key, myAes.IV);

                return Convert.ToBase64String(encrypted);

                //Display the original data and the decrypted data.
                //Console.WriteLine("Original:   {0}", original);
                //Console.WriteLine("Round Trip: {0}", roundtrip);
            }
        }

        public string DecryptKey(string valor)
        {
            string original = valor;
            Aes aesAlg2 = Aes.Create();
            // Create a new instance of the Aes
            // class.  This generates a new key and initialization
            // vector (IV).
            using (Aes myAes = Aes.Create())
            {
                string valueKey = "hLMKExCkXIzbv1mNcm/psXecEBNRFTWpjnMp/VoUCEY=";
                string valueIV = "qKjgpNLLORowDAGuHJTjTQ==";
                byte[] valorEnc = Convert.FromBase64String(valor);
                myAes.Key = Convert.FromBase64String(valueKey);
                myAes.IV = Convert.FromBase64String(valueIV);

                // Encrypt the string to an array of bytes.
                //byte[] encrypted = EncryptStringToBytes_Aes(original, myAes.Key, myAes.IV);

                // Decrypt the bytes to a string.
                string roundtrip = DecryptStringFromBytes_Aes(valorEnc, myAes.Key, myAes.IV);

                return roundtrip;

                //Display the original data and the decrypted data.
                //Console.WriteLine("Original:   {0}", original);
                //Console.WriteLine("Round Trip: {0}", roundtrip);
            }
        }
        static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;



            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }

        static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;
            Aes aesAlg2 = Aes.Create();

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }
    }
}

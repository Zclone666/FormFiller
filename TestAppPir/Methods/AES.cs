using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TestAppPir.Methods
{
    internal class AES
    {
        public byte[] Encrypt(byte[] BytesToBeEncrypted, string Password)
        {

            return Encrypt(BytesToBeEncrypted, Encoding.UTF8.GetBytes(Password));
        }
        public byte[] Encrypt(byte[] BytesToBeEncrypted, byte[] PasswordBytes)
        {
            return Encrypt(BytesToBeEncrypted, PasswordBytes);
        }

        public byte[] Encrypt(byte[] BytesToBeEncrypted, byte[] PasswordBytes, byte[] IV)
        {
            byte[] encryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            if (IV == null)
            {
                IV = new byte[] { 101, 111, 67, 85, 13, 1, 217, 99 };
            }
            if (PasswordBytes == null)
            {
                SHA256 mySHA256 = SHA256Managed.Create();
                PasswordBytes = mySHA256.ComputeHash(Encoding.UTF8.GetBytes("Двадцать тысяч обезьян в жопу сунули банан"));
                //byte[] byteMsg = new byte[15] { 67, 111, 110, 110, 101, 99, 116, 32, 84, 101, 115, 116, 105, 110, 103 };
            }
            using (MemoryStream ms = new MemoryStream())
            {
                using (Aes aes = Aes.Create())
                {
                    aes.KeySize = 256;
                    aes.BlockSize = 128;
                    aes.Mode = CipherMode.CBC;
                    aes.Key = PasswordBytes;
                    aes.IV = IV;
                    ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                    using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Write))
                    {
                        cs.Write(BytesToBeEncrypted, 0, BytesToBeEncrypted.Length);
                    }
                    encryptedBytes = ms.ToArray();
                }
            }

            return encryptedBytes;
        }

        public byte[] Decrypt(byte[] BytesToBeDecrypted, byte[] PasswordBytes, byte[] IV)
        {
            byte[] decryptedBytes = null;

            if (IV == null)
            {
                IV = new byte[] { 101, 111, 67, 85, 13, 1, 217, 99 };
            }

            if (PasswordBytes == null)
            {
                SHA256 mySHA256 = SHA256.Create();
                PasswordBytes = mySHA256.ComputeHash(Encoding.UTF8.GetBytes("Двадцать тысяч обезьян в жопу сунули банан"));
            }
            using (MemoryStream ms = new MemoryStream())
            {
                using (Aes aes = Aes.Create())
                {
                    aes.KeySize = 256;
                    aes.BlockSize = 128;
                    aes.Mode = CipherMode.CBC;
                    aes.Key = PasswordBytes;
                    aes.IV = IV;
                    ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                    try
                    {
                        using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Write))
                        {
                            cs.Write(BytesToBeDecrypted, 0, BytesToBeDecrypted.Length);
                        }
                        decryptedBytes = ms.ToArray();
                        return decryptedBytes;
                    }
                    catch
                    {
                        return null;
                    }

                }
            }
        }
    }
}

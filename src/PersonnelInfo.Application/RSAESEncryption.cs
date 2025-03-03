using System.Security.Cryptography;

public class RSAESEncryption
{
    // Public method to encrypt data with AES and RSA hybrid encryption
    public string EncryptWithHybrid(string data)
    {
        string aesKey = GenerateAESKey();
        string encryptedData = EncryptWithAES(data, aesKey);

        string encryptedAesKey = EncryptAESKeyWithRSA(aesKey);
        return $"{encryptedAesKey}:{encryptedData}";
    }

    // Public method to decrypt data using RSA hybrid decryption
    public string DecryptWithHybrid(string encryptedDataWithAesKey)
    {
        var parts = encryptedDataWithAesKey.Split(':');
        string encryptedAesKey = parts[0];
        string encryptedData = parts[1];

        string aesKey = DecryptAESKeyWithRSA(encryptedAesKey);

        return DecryptWithAES(encryptedData, aesKey);
    }

    // Private method to generate a random AES key
    private static string GenerateAESKey()
    {
        using (var aes = Aes.Create())
        {
            aes.GenerateKey();
            return Convert.ToBase64String(aes.Key);
        }
    }

    // Private method to encrypt data using AES
    private static string EncryptWithAES(string data, string aesKey)
    {
        using (var aes = Aes.Create())
        {
            aes.Key = Convert.FromBase64String(aesKey);
            aes.GenerateIV();
            using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
            {
                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (var writer = new StreamWriter(cs))
                        {
                            writer.Write(data);
                        }
                    }
                    byte[] iv = aes.IV;
                    byte[] encrypted = ms.ToArray();
                    return Convert.ToBase64String(iv.Concat(encrypted).ToArray());
                }
            }
        }
    }

    // Private method to decrypt data using AES
    private static string DecryptWithAES(string encryptedData, string aesKey)
    {
        using (var aes = Aes.Create())
        {
            aes.Key = Convert.FromBase64String(aesKey);
            byte[] fullCipher = Convert.FromBase64String(encryptedData);
            byte[] iv = fullCipher.Take(aes.BlockSize / 8).ToArray();
            byte[] cipher = fullCipher.Skip(aes.BlockSize / 8).ToArray();
            aes.IV = iv;

            using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
            {
                using (var ms = new MemoryStream(cipher))
                {
                    using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (var reader = new StreamReader(cs))
                        {
                            return reader.ReadToEnd();
                        }
                    }
                }
            }
        }
    }

    // Private method to encrypt the AES key with RSA public key
    private static string EncryptAESKeyWithRSA(string aesKey)
    {
        using (RSA rsa = RSA.Create())
        {
            rsa.ImportRSAPublicKey(Convert.FromBase64String("<YourPublicKey>"), out _);
            byte[] encryptedAesKey = rsa.Encrypt(Convert.FromBase64String(aesKey), RSAEncryptionPadding.Pkcs1);
            return Convert.ToBase64String(encryptedAesKey);
        }
    }

    // Private method to decrypt the AES key with RSA private key
    private static string DecryptAESKeyWithRSA(string encryptedAesKey)
    {
        using (RSA rsa = RSA.Create())
        {
            rsa.ImportRSAPrivateKey(Convert.FromBase64String("<YourPrivateKey>"), out _);
            byte[] decryptedAesKey = rsa.Decrypt(Convert.FromBase64String(encryptedAesKey), RSAEncryptionPadding.Pkcs1);
            return Convert.ToBase64String(decryptedAesKey);
        }
    }
}

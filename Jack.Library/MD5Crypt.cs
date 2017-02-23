using System;
using System.Security.Cryptography;
namespace Jack.Library
{
    public class Md5Crypt
    {
        const string SENHA = "12345";

        public static string Criptografar(string message)
        {
            byte[] results;
            System.Text.UTF8Encoding textUtf8 = new System.Text.UTF8Encoding();
            MD5CryptoServiceProvider hashProvider = new MD5CryptoServiceProvider();
            byte[] byteTdesKey = hashProvider.ComputeHash(textUtf8.GetBytes(SENHA));
            TripleDESCryptoServiceProvider oTdesAlgorithm = new TripleDESCryptoServiceProvider();
            oTdesAlgorithm.Key = byteTdesKey;
            oTdesAlgorithm.Mode = CipherMode.ECB;
            oTdesAlgorithm.Padding = PaddingMode.PKCS7;
            byte[] dataToEncrypt = textUtf8.GetBytes(message);
            try
            {
                ICryptoTransform encryptor = oTdesAlgorithm.CreateEncryptor();
                results = encryptor.TransformFinalBlock(dataToEncrypt, 0, dataToEncrypt.Length);
            }
            finally
            {
                oTdesAlgorithm.Clear();
                hashProvider.Clear();
            }
            return Convert.ToBase64String(results);
        }

        public static string Descriptografar(string Message)
        {
            byte[] results;
            System.Text.UTF8Encoding textUtf8 = new System.Text.UTF8Encoding();
            MD5CryptoServiceProvider hashProvider = new MD5CryptoServiceProvider();
            byte[] byteTdesKey = hashProvider.ComputeHash(textUtf8.GetBytes(SENHA));
            TripleDESCryptoServiceProvider tdesAlgorithm = new TripleDESCryptoServiceProvider();
            tdesAlgorithm.Key = byteTdesKey;
            tdesAlgorithm.Mode = CipherMode.ECB;
            tdesAlgorithm.Padding = PaddingMode.PKCS7;
            byte[] dataToDecrypt = Convert.FromBase64String(Message);
            try
            {
                ICryptoTransform decryptor = tdesAlgorithm.CreateDecryptor();
                results = decryptor.TransformFinalBlock(dataToDecrypt, 0, dataToDecrypt.Length);
            }
            finally
            {
                tdesAlgorithm.Clear();
                hashProvider.Clear();
            }
            return textUtf8.GetString(results);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using Incremental.Kick.Helpers;
using System.Security.Cryptography;
using Obviex.CipherLite;
using Incremental.Kick.Caching;

namespace Incremental.Kick.Security {
    public class Cipher {
        private const char COMPRESSED = 'C';
        private const char NOTCOMPRESSED = 'P';
        private const int MINIMUM_LENGTH_FOR_COMPRESSION = 512;
        private const string HASH_ALGORITHM = "SHA1";
        private const int PASSWORD_ITERATIONS = 2;
        private const int KEY_SIZE = 256;


        public static string EncryptToBase64(string plaintext) {
            byte[] plainBytes = CompressonHelper.StringToBytes(plaintext);
            byte[] cipherBytes = Encrypt(plainBytes);
            return Convert.ToBase64String(cipherBytes);
        }

        public static string GenerateSalt() {
            byte[] bytes = new byte[0x10];
            new RNGCryptoServiceProvider().GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }

        public static byte[] Hash(byte[] value, byte[] salt) {
            byte[] bytes = new byte[value.Length + salt.Length];
            Buffer.BlockCopy(salt, 0, bytes, 0, salt.Length);
            Buffer.BlockCopy(value, 0, bytes, salt.Length, value.Length);
            return (new SHA1CryptoServiceProvider()).ComputeHash(bytes);
        }

        public static string Hash(string value, string salt) {
            byte[] valueBytes = Encoding.Unicode.GetBytes(value);
            byte[] saltBytes = Convert.FromBase64String(salt);
            return Convert.ToBase64String(Hash(valueBytes, saltBytes));
        }

        public static string Encrypt(string plaintext) {
            return Encrypt(plaintext, true);
        }

        public static byte[] Encrypt(byte[] plainbytes) {
            return Encrypt(plainbytes, true);
        }

        public static string Encrypt(string plaintext, bool compress) {
            return CompressonHelper.BytesToString(Encrypt(CompressonHelper.StringToBytes(plaintext), compress));
        }

        public static byte[] Encrypt(byte[] plainbytes, bool compress) {

            byte[] buffer;
            byte compressFlag;
            if (plainbytes.Length > MINIMUM_LENGTH_FOR_COMPRESSION) {
                compressFlag = Convert.ToByte(COMPRESSED);
                buffer = CompressonHelper.Deflate(plainbytes);
            } else {
                compressFlag = Convert.ToByte(NOTCOMPRESSED);
                buffer = plainbytes;
            }

            byte[] encryptedBytes = Obviex.CipherLite.Rijndael.Encrypt(CompressonHelper.BytesToString(buffer),
                SettingsCache.GetSetting("Security.Cipher.PassPhrase"), SettingsCache.GetSetting("Security.Cipher.InitVector"), KEY_SIZE, PASSWORD_ITERATIONS, SettingsCache.GetSetting("Security.Cipher.Salt"), HASH_ALGORITHM);
            byte[] toReturn = new byte[encryptedBytes.Length + 1];

            int index = 0;
            toReturn[index++] = compressFlag;
            for (int i = 0; i < encryptedBytes.Length; i++) {
                toReturn[index++] = encryptedBytes[i];
            }

            return toReturn;
        }

        public static string DecryptFromBase64(string ciphertext) {
            byte[] cipherBytes = Convert.FromBase64String(ciphertext);
            return Decrypt(cipherBytes);
        }

        public static string Decrypt(string ciphertext) {
            return Decrypt(ciphertext, true);
        }

        public static string Decrypt(byte[] cipherbytes) {
            return Decrypt(cipherbytes, true);
        }

        public static string Decrypt(string ciphertext, bool compress) {
            return Decrypt(CompressonHelper.StringToBytes(ciphertext), compress);
        }

        public static string Decrypt(byte[] cipherbytes, bool compress) {

            byte[] buffer = new byte[cipherbytes.Length - 1];
            int index = 0;
            for (int i = 1; i < cipherbytes.Length; i++) {
                buffer[index++] = cipherbytes[i];
            }

            string decrypted = Obviex.CipherLite.Rijndael.Decrypt(buffer, SettingsCache.GetSetting("Security.Cipher.PassPhrase"), SettingsCache.GetSetting("Security.Cipher.InitVector"), KEY_SIZE, PASSWORD_ITERATIONS, SettingsCache.GetSetting("Security.Cipher.Salt"), HASH_ALGORITHM);

            if (cipherbytes[0] == COMPRESSED) {
                return CompressonHelper.Inflate(decrypted);
            } else {
                return decrypted;
            }
        }
    }
}

using System;
using System.Security.Cryptography;

namespace Game
{
    public class KeyGenerator
    {
        public static byte[] GenerateKey()
        {
            var key = new byte[128];

            using (var random = RandomNumberGenerator.Create())
            {
                random.GetBytes(key);
            }

            return key;
        }
    }
}


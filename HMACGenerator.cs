using System;
using System.Security.Cryptography;
using System.Text;

namespace Game
{
    public class HMACGenerator
    {
        public static (string, string, string) GenerateHMAC(byte[] keyByte, string[] message)
        {
            var computerMove = message[RandomNumberGenerator.GetInt32(0, message.Length)];
            var encoding = new ASCIIEncoding();
            HMACSHA512 hmacsha512 = new HMACSHA512(keyByte);
            byte[] hashMessage = hmacsha512.ComputeHash(encoding.GetBytes(computerMove));
            return (BitConverter.ToString(hashMessage).Replace("-", ""), BitConverter.ToString(hmacsha512.Key).Replace("-", ""), computerMove);
        }

    }
}
 

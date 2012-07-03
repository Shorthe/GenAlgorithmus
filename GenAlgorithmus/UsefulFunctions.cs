using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace GenAlgorithmus
{
    class UsefulFunctions
    {
        public static int GenerateRandomNumber(int min, int max)
        {    
            RNGCryptoServiceProvider csProvider = new RNGCryptoServiceProvider();    
            byte[] randomNumber = new byte[4];       
            csProvider.GetBytes(randomNumber);    
            int result = Math.Abs(BitConverter.ToInt32(randomNumber, 0));    
            return result % max + min;
        }
    }
}

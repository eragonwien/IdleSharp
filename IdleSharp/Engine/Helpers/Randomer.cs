using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public static class Randomer
    {
        private static readonly RNGCryptoServiceProvider RngProvider = new RNGCryptoServiceProvider();

        public static int RandomInt(int min, int max)
        {
            // uses 4 random bytes
            byte[] randomBytes = new byte[4];
            RngProvider.GetBytes(randomBytes);

            // converts bytes into Uint32
            UInt32 scale = BitConverter.ToUInt32(randomBytes, 0);

            return (int)(min + (max - min) * (scale / (uint.MaxValue + 1.0)));
        }
    }
}

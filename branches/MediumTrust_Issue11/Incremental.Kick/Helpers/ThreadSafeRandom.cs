using System;
using System.Collections.Generic;
using System.Text;

namespace Incremental.Kick.Helpers
{
    public class ThreadSafeRandom
    {
        private static Random random = new Random();

        public static int Next()
        {
            lock (random)
            {
                return random.Next();
            }
        }

        public static int Next(int maxValue)
        {
            lock (random)
            {
                return random.Next(maxValue);
            }
        }

        public static int Next(int minValue, int maxValue)
        {
            lock (random)
            {
                return random.Next(minValue, maxValue);
            }
        }
    }
}

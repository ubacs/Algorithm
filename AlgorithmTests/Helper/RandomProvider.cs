using System;
using System.Collections.Generic;
using System.Text;

namespace ubacs.AlgorithmTests.Helper
{
    internal class RandomProvider
    {
        private static readonly Lazy<RandomProvider> _instance = new Lazy<RandomProvider>(() => new RandomProvider());

        public Random Random { get; }

        public static RandomProvider Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        private RandomProvider()
        {
            Random = new Random(1234);
        }
    }
}

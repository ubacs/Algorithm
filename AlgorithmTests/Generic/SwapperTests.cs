using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

using ubacs.Algorithm.Generic;

namespace ubacs.AlgorithmTests.Generic
{
    public class SwapperTests
    {
        //The following test will throw an exception because of a bug introduced (?) in XUnit 2.4:
        //https://github.com/xunit/xunit/issues/1781
        //Use the nongeneric test methods instead!

        //[Theory]
        //[InlineData(-1, 2)]
        //[InlineData("abab", "cdcd")]
        //[InlineData("abab", null)]
        public void Swap_Correct<T>(T a, T b)
        {
            T expectedA = b;
            T expectedB = a;
            Swapper.Swap(ref a, ref b);

            Assert.Equal(expectedA, a);
            Assert.Equal(expectedB, b);
        }

        [Theory]
        [InlineData(-1, 2)]
        public void Swap_Int_Correct(int a, int b)
        {
            int expectedA = b;
            int expectedB = a;
            Swapper.Swap(ref a, ref b);

            Assert.Equal(expectedA, a);
            Assert.Equal(expectedB, b);
        }

        [Theory]
        [InlineData("abab", "cdcd")]
        [InlineData("abab", null)]
        public void Swap_String_Correct(string a, string b)
        {
            string expectedA = b;
            string expectedB = a;
            Swapper.Swap(ref a, ref b);

            Assert.Equal(expectedA, a);
            Assert.Equal(expectedB, b);
        }

        [Fact]
        public void SwapElements_ThrowsOnNullList()
        {
            List<int> list = null;
            int i = 0;
            int j = 0;
            Assert.Throws<ArgumentNullException>(() => Swapper.SwapElements(list, i, j));
        }

        [Theory]
        [InlineData(1, -1, 0)]
        [InlineData(1, 0, -1)]
        [InlineData(0, 0, 0)]
        [InlineData(3, 3, 0)]
        [InlineData(3, 0, 12)]
        public void SwapElements_ThrowsOnIndexOutOfRange(int size, int i, int j)
        {
            List<int> list = Enumerable.Range(0, size).ToList();
            Assert.Throws<ArgumentOutOfRangeException>(() => Swapper.SwapElements(list, i, j));
        }

        [Fact]
        public void SwapElements_Correct()
        {

            List<int> list = Enumerable.Range(1, 10).ToList();
            List<int> expected = list;
            expected.Reverse();

            int i = 0;
            int j = list.Count - 1;
            while (i < j)
            {
                Swapper.SwapElements(list, i, j);
                i++;
                j--;
            }

            Assert.Equal(expected, list);
        }
    }
}


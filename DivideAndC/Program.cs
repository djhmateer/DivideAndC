using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DivideAndC
{
    public class Program
    {
        static void Main()
        {
            // generate numbers with a Divide and Conquer approach
            // but not using recursive.  It is possible:
            // http://stackoverflow.com/questions/29974792/does-any-divide-and-conquer-algorithm-use-recursion
        }

        private List<int> DivideUp(int maxInt)
        {
            // http://yangliucsharp.blogspot.co.uk/2013/02/divide-and-conquer-algorithm.html
            var result = new List<int>();
            var list = Enumerable.Range(1, maxInt).ToList();

            int minIndex = 0;
            int maxIndex = list.Count - 1;
            //while (minIndex <= maxIndex)
            //{
            //    int midIndex = (minIndex + maxIndex) / 2;
            //    if (list.ElementAt(midIndex).CompareTo(value) > 0) maxIndex = midIndex - 1;
            //    //else if (list.ElementAt(midIndex).CompareTo(value) < 0) minIndex = midIndex + 1;
            //    //else return midIndex;
            //}
            ////return -1;//value not found  

            return result;
        }

        [Fact]
        public void OneToSeven_ShouldReturn()
        {
            var result = DivideUp(7);
            // if 1,2,3,4,5,6,7 then 1,7,4,5,2,6,3
            Assert.Equal(new List<int> { 1, 7, 4, 5, 2, 6, 3 }, result);
        }

        [Fact]
        public void OneToEight_ShouldReturn()
        {
            var result = DivideUp(8);
            // if 1,2,3,4,5,6,7,8 then 1,8,4,6,2,7,5,3
            Assert.Equal(new List<int> { 1, 8, 4, 6, 2, 7, 5, 3 }, result);
        }


    }
}

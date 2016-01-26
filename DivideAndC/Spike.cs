using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DivideAndC.Spike
{
    public class Program
    {
        static List<int> _result;

        static void Main()
        {
            var result = GetAnswer(8);
            foreach (var number in result) Console.Write($"{number}, ");
        }

        public static List<int> GetAnswer(int max)
        {
            _result = new List<int>();
            var rangeOfInts = new RangeOfInts { Left = 1, Right = max };
            _result.Add(rangeOfInts.Left);
            _result.Add(rangeOfInts.Right);

            var rangeOfIntsList = new List<RangeOfInts> { rangeOfInts };
            DivConq(rangeOfIntsList);
            return _result;
        }

        public static List<RangeOfInts> DivConq(List<RangeOfInts> nodeList)
        {
            if (nodeList.Count > 0)
            {
                RangeOfInts currentRangeOfInts = nodeList.Last();
                nodeList.Remove(nodeList.Last());

                var midway = currentRangeOfInts.Midway();
                _result.Add(midway);

                if (midway < currentRangeOfInts.Right - 1)
                {
                    var n = new RangeOfInts { Left = midway, Right = currentRangeOfInts.Right };
                    nodeList.Insert(0, n); // add to beginning of list
                }

                if (currentRangeOfInts.Left < midway - 1)
                {
                    var n = new RangeOfInts { Left = currentRangeOfInts.Left, Right = midway };
                    nodeList.Insert(0, n);
                }

                if (currentRangeOfInts.Left < midway) return DivConq(nodeList);
                if (midway < currentRangeOfInts.Right) return DivConq(nodeList);
            }
            return null; 
        }

        public class RangeOfInts
        {
            public int Left { get; set; }
            public int Right { get; set; }

            public int Midway()
            {
                return (Right - Left) / 2 + Left;
            }
        }


        [Fact]
        public void OneToFive()
        {
            var result = GetAnswer(5);
            // if 1,2,3,4,5
            Assert.Equal(new List<int> { 1, 5, 3, 4, 2 }, result);
        }

        [Fact]
        public void OneToSeven()
        {
            var result = GetAnswer(7);
            // if 1,2,3,4,5,6,7 
            Assert.Equal(new List<int> { 1, 7, 4, 5, 2, 6, 3 }, result);
        }

        [Fact]
        public void OneToEight()
        {
            var result = GetAnswer(8);
            // if 1,2,3,4,5,6,7,8 
            Assert.Equal(new List<int> { 1, 8, 4, 6, 2, 7, 5, 3 }, result);
        }

        [Fact]
        public void OneToNine()
        {
            var result = GetAnswer(9);
            // if 1,2,3,4,5,6,7,8,9 
            Assert.Equal(new List<int> { 1, 9, 5, 7, 3, 8, 6, 4, 2 }, result);
        }

        [Fact]
        public void OneToEleven()
        {
            var result = GetAnswer(11);
            // if 1,2,3,4,5,6,7,8,9,10,11
            Assert.Equal(new List<int> { 1, 11, 6, 8, 3, 9, 7, 4, 2, 10, 5 }, result);
        }
    }
}

using System;
using System.Collections.Generic;
using Xunit;

namespace DivideAndC.Spike
{
    public class Program
    {
        static List<int> _result;

        static void Main()
        {
            var result = GetAnswer(1000);
            foreach (var n in result) Console.Write($"{n}, ");
        }

        // Want to take a range of numbers and split if up in a specific way
        // eg 1..8 should return 1, 8, 4, 6, 2, 7, 5, 3

        public static List<int> GetAnswer(int max)
        {
            _result = new List<int>();
            var n = new Node(left: 1, right: max);

            // start and end values are special cases, and the rest are simply midway points
            // eg 1,2,3,4,5,6,7,8 should return 1, 8, 4, 6, 2, 7, 5, 3 
            // so _result is now 1, 8
            _result.Add(n.Left);
            _result.Add(n.Right);

            // add a starting Node ie 1, 4, 8 (midway is 4)
            var nodes = new Queue<Node>();
            nodes.Enqueue(n);
            DivConq(nodes: nodes, iteration: 1);
            return _result;
        }

        public static Queue<Node> DivConq(Queue<Node> nodes, int iteration)
        {
            if (nodes.Count > 0)
            {
                //Console.WriteLine($"iteration: {iteration}");
                //foreach (var n in nodes) Console.WriteLine($"{n.Left}, {n.Midway}, {n.Right}");

                Node currentNode = nodes.Dequeue(); // take the oldest in the queue

                var midway = currentNode.Midway;
                _result.Add(midway);
                Console.WriteLine($"midway: {midway}");
                //Console.WriteLine();

                // take RHS
                if (midway < currentNode.Right - 1)
                {
                    var n = new Node(midway, currentNode.Right);
                    nodes.Enqueue(n); // add to start of queue
                }

                // take LHS
                if (currentNode.Left < midway - 1)
                {
                    var n = new Node(currentNode.Left, midway);
                    nodes.Enqueue(n); // add to start of queue
                }

                if (nodes.Count != 0) return DivConq(nodes, iteration + 1);
                //if (currentNode.Left < midway) return DivConq(nodes, iteration + 1);
                //if (midway < currentNode.Right) return DivConq(nodes, iteration + 1);
            }
            return null;
        }

        public class Node
        {
            public int Left { get; }
            public int Right { get; }
            public int Midway { get; }

            public Node(int left, int right)
            {
                Left = left;
                Right = right;
                Midway = (Right - Left) / 2 + Left;
            }
        }

        [Fact]
        public void OneToEight()
        {
            var result = GetAnswer(8);
            // if 1,2,3,4,5,6,7,8 
            Assert.Equal(new List<int> { 1, 8, 4, 6, 2, 7, 5, 3 }, result);
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

        [Fact]
        public void OneToTwenty()
        {
            var result = GetAnswer(20);
            Assert.Equal(new List<int> { 1, 20, 10, 15, 5, 17, 12, 7, 3, 18, 16, 13, 11, 8, 6, 4, 2, 19, 14, 9 }, result);
        }

        [Fact]
        public void OneToOneHundred()
        {
            var result = GetAnswer(100);
            Assert.Equal(new List<int> { 1, 100, 50, 75, 25, 87, 62, 37, 13, 93, 81, 68, 56, 43, 31, 19, 7, 96, 90, 84, 78, 71, 65, 59, 53, 46, 40, 34, 28, 22, 16, 10, 4, 98, 94, 91, 88, 85, 82, 79, 76, 73, 69, 66, 63, 60, 57, 54, 51, 48, 44, 41, 38, 35, 32, 29, 26, 23, 20, 17, 14, 11, 8, 5, 2, 99, 97, 95, 92, 89, 86, 83, 80, 77, 74, 72, 70, 67, 64, 61, 58, 55, 52, 49, 47, 45, 42, 39, 36, 33, 30, 27, 24, 21, 18, 15, 12, 9, 6, 3 }, result);
        }
    }
}

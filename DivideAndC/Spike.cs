using System;
using System.Collections.Generic;
using Xunit;

namespace DivideAndC.Spike
{
    public class Program
    {
        static void Main()
        {
            var result = GetAnswer(8);
            foreach (var number in result) Console.Write($"{number}, ");
        }

        public static List<int> GetAnswer(int max)
        {
            // reset global static _result!!
            _result = new List<int>();
            var node = new Node {Left = 1, Right = max};
            _result.Add(node.Left);
            _result.Add(node.Right);

            var nodelist = new Queue<Node>();
            nodelist.Enqueue(node);
            DivConq(nodelist);
            return _result;
        }

        static List<int> _result; 

        public static Queue<Node> DivConq(Queue<Node> nodeList)
        {
            if (nodeList.Count > 0)
            {
                Node currentNode = nodeList.Dequeue();
                var midway = currentNode.Midway();
                _result.Add(midway);

                if (midway < currentNode.Right - 1)
                {
                    var n = new Node { Left = midway, Right = currentNode.Right };
                    nodeList.Enqueue(n);
                }

                if (currentNode.Left < midway - 1)
                {
                    var n = new Node { Left = currentNode.Left, Right = midway };
                    nodeList.Enqueue(n);
                }

                if (currentNode.Left < midway) return DivConq(nodeList);
                if (midway < currentNode.Right) return DivConq(nodeList);
            }
            // done!
            return null;
        }

        public class Node
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

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

        // problem - want to take a range of numbers eg 1..8
        // and split if up in a specific way

        // eg 1,2,3,4,5,6,7,8
        // add to results the first number (1)
        // add to results the last number (8)
        // add to results the midway (4)
        // look at RHS if there is one (4,6,8)
        // add to list
        // look at LHS if there is one (1,2,4)
        // add to beginning of list

        // take the last on the list (was the RHS 4,6,8)
        // take RHS 
        // add to beginning of list 6,7,8
        // take LHS
        // add to beginning of list 4,5,6

        // take the last on the list (was original LHS 1,2,4)
        // take RHS (2,3,4)
        // add to list
        // try LHS.. none!


        public static List<int> GetAnswer(int max)
        {
            _result = new List<int>();
            var n = new Node(1, max);

            _result.Add(n.Left);
            _result.Add(n.Right);

            // add a Node eg 1, 8 (midway 4)
            var nodes = new List<Node> { n };
            DivConq(nodes);
            return _result;
        }

        public static List<Node> DivConq(List<Node> nodes)
        {
            if (nodes.Count > 0)
            {
                Node currentNode = nodes.Last();
                nodes.Remove(nodes.Last());

                var midway = currentNode.Midway;
                _result.Add(midway);

                // take RHS
                if (midway < currentNode.Right - 1)
                {
                    var n = new Node(midway, currentNode.Right);
                    nodes.Insert(0, n); // add to beginning of list
                }

                // take LHS
                if (currentNode.Left < midway - 1)
                {
                    var n = new Node(currentNode.Left, midway);
                    nodes.Insert(0, n);
                }

                if (nodes.Count != 0) return DivConq(nodes);
                //if (currentNode.Left < midway) return DivConq(nodes);
                //if (midway < currentNode.Right) return DivConq(nodes);
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
                Midway = (Right - Left)/2 + Left;
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
    }
}

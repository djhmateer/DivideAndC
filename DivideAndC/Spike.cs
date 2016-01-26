using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DivideAndC.Spike
{
    // lift and shift of Phils code
    public class Program
    {
        static void Main()
        {
            int tar_dist = 8;
            var n = new Node(1, tar_dist);
            Console.WriteLine(n.left);
            Console.WriteLine(n.right);
            Queue nodelist = new Queue();
            nodelist.Enqueue(n);
            var result = div_conq(nodelist);
        }

        public static Queue div_conq(Queue nodelist)
        {
            if (nodelist.Count > 0)
            {
                Node current_node = (Node)nodelist.Dequeue();
                var midway = current_node.midway();
                Console.WriteLine(midway);

                if (midway < current_node.right - 1)
                {
                    var n = new Node(midway, current_node.right);
                    nodelist.Enqueue(n);
                }

                if (current_node.left < midway - 1)
                {
                    var n = new Node(current_node.left, midway);
                    nodelist.Enqueue(n);
                }

                if (current_node.left < midway) return div_conq(nodelist);
                if (midway < current_node.right) return div_conq(nodelist);
            }
            // never gets here?
            return null;
        }

        public class Node
        {
            public int left { get; set; }
            public int right { get; set; }

            public Node(int l, int r)
            {
                this.left = l;
                this.right = r;
            }

            public int midway()
            {
                return (this.right - this.left) / 2 + this.left;
            }
        }


        //[Fact]
        //public void OneToFive()
        //{
        //    var result = DivideUp(7);
        //    // if 1,2,3,4,5
        //    Assert.Equal(new List<int> { 1, 5, 3, 4, 2 }, result);
        //}

        //[Fact]
        //public void OneToSeven()
        //{
        //    var result = DivideUp(7);
        //    // if 1,2,3,4,5,6,7 
        //    Assert.Equal(new List<int> { 1, 7, 4, 5, 2, 6, 3 }, result);
        //}

        //[Fact]
        //public void OneToEight()
        //{
        //    var result = DivideUp(8);
        //    // if 1,2,3,4,5,6,7,8 
        //    Assert.Equal(new List<int> { 1, 8, 4, 6, 2, 7, 5, 3 }, result);
        //}

        //[Fact]
        //public void OneToNine()
        //{
        //    var result = DivideUp(9);
        //    // if 1,2,3,4,5,6,7,8,9 
        //    Assert.Equal(new List<int> { 1, 9, 5, 7, 3, 8, 6, 4, 2 }, result);
        //}

        //[Fact]
        //public void OneToEleven()
        //{
        //    var result = DivideUp(11);
        //    // if 1,2,3,4,5,6,7,8,9,10,11
        //    Assert.Equal(new List<int> { 1, 11, 6, 8, 3, 9, 7, 4, 2, 10, 5 }, result);
        //}
    }
}

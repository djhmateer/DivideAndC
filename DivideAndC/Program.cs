//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Xunit;

//namespace DivideAndC
//{
//    public class Program
//    {
//        static void Main2()
//        {
//            // generate numbers with a Divide and Conquer approach
//            // but not using recursive.  It is possible:
//            // http://stackoverflow.com/questions/29974792/does-any-divide-and-conquer-algorithm-use-recursion

//            //int[] input3 = { 22, 4, 6, 0, 9, 12, 156, 86, 99 };
//            //MergeSort(input3, 0, input3.Length - 1);
//            //for (int i = 0; i < input3.Length; i++)
//            //    Console.Write(input3[i] + ", ");
//            //Console.WriteLine("");
//        }

//        private List<int> DivideUp(int maxInt)
//        {
//            // http://yangliucsharp.blogspot.co.uk/2013/02/divide-and-conquer-algorithm.html
//            var result = new List<int>();
//            var list = Enumerable.Range(1, maxInt).ToList();

//            int minIndex = 0;
//            int maxIndex = list.Count - 1;
//            result.Add(list[0]); // the list.first is always the first
//            result.Add(list[maxIndex]); // the list.last is always second

//            // try recursive
//            return result;
//        }

//        //public static void MergeSort(int[] input, int startIndex, int endIndex)
//        //{
//        //    int mid;

//        //    if (endIndex > startIndex)
//        //    {
//        //        mid = (endIndex + startIndex) / 2;
//        //        MergeSort(input, startIndex, mid);
//        //        MergeSort(input, (mid + 1), endIndex);
//        //        var x = input[mid];
//        //        //Merge(input, startIndex, (mid + 1), endIndex);
//        //    }
//        //}

//        ////http://www.codeproject.com/Articles/79040/Sorting-Algorithms-Codes-in-C-NET
//        //public List<int> mergesort(List<int> m)
//        //{
//        //    List<int> result = new List<int>();
//        //    List<int> left = new List<int>();
//        //    List<int> right = new List<int>();
//        //    if (m.Count <= 1)
//        //        return m;

//        //    int middle = m.Count / 2;
//        //    for (int i = 0; i < middle; i++)
//        //        left.Add(m[i]);
//        //    for (int i = middle; i < m.Count; i++)
//        //        right.Add(m[i]);
//        //    left = mergesort(left);
//        //    right = mergesort(right);
//        //    if (left[left.Count - 1] <= right[0])
//        //        return append(left, right);
//        //    //result = merge(left, right);
//        //    return result;
//        //}

//        //public List<int> merge(List<int> a, List<int> b)
//        //{
//        //    List<int> s = new List<int>();
//        //    while (a.Count > 0 && b.Count > 0)
//        //    {

//        //        if (a[0] < b[0])

//        //        {
//        //            s.Add(a[0]);
//        //            a.RemoveAt(0);
//        //        }
//        //        else
//        //        {
//        //            s.Add(b[0]);
//        //            b.RemoveAt(0);
//        //        }
//        //    }
//        //}


//        //public List<int> append(List<int> a, List<int> b)
//        //{
//        //    List<int> result = new List<int>(a);
//        //    foreach (int x in b)
//        //        result.Add(x);
//        //    return result;
//        //}

//        [Fact]
//        public void OneToFive()
//        {
//            var result = DivideUp(7);
//            // if 1,2,3,4,5
//            Assert.Equal(new List<int> { 1, 5, 3, 4, 2 }, result);
//        }

//        [Fact]
//        public void OneToSeven()
//        {
//            var result = DivideUp(7);
//            // if 1,2,3,4,5,6,7 
//            Assert.Equal(new List<int> { 1, 7, 4, 5, 2, 6, 3 }, result);
//        }

//        [Fact]
//        public void OneToEight()
//        {
//            var result = DivideUp(8);
//            // if 1,2,3,4,5,6,7,8 
//            Assert.Equal(new List<int> { 1, 8, 4, 6, 2, 7, 5, 3 }, result);
//        }

//        [Fact]
//        public void OneToNine()
//        {
//            var result = DivideUp(9);
//            // if 1,2,3,4,5,6,7,8,9 
//            Assert.Equal(new List<int> { 1, 9, 5, 7, 3, 8, 6, 4, 2 }, result);
//        }

//        [Fact]
//        public void OneToEleven()
//        {
//            var result = DivideUp(11);
//            // if 1,2,3,4,5,6,7,8,9,10,11
//            Assert.Equal(new List<int> { 1, 11, 6, 8, 3, 9, 7, 4, 2, 10, 5 }, result);
//        }
//    }
//}

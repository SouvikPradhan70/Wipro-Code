using System;

namespace jaggedArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //jagged array sintax and implementation(int[][] jaggedArray=new int[3][])
            int[][] jaggedArray = new int[3][];
            jaggedArray[0] = new int[] { 1, 2, 3 };
            jaggedArray[1] = new int[] { 4, 5 };
            jaggedArray[2] = new int[] { 6, 7, 8, 9 };
            Console.WriteLine("Jagged Array-");
            foreach (var subArray in jaggedArray)
            {
                Console.WriteLine(String.Join(" ", subArray));
            }


        }
    }
}

//we can categorise collection in c# into two main category
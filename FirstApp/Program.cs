using System;
using System.Xml.Linq;

namespace FirstApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 5, 6, 9, 1, 2, 3, 4 };

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i]<=arr[j]) continue;

                    int oldIndexValue = arr[i];
                    arr[i] = arr[j];
                    arr[j] = oldIndexValue;
                }
                    
            }

            foreach (var item in arr)
            {
                Console.Write(item);
            }
        }
    }
    enum Semaphore : int
    {
        Red = 100,
        Yellow = 200,
        Green = 300,
    }
}

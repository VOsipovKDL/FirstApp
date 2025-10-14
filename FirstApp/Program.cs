using System;
using System.Xml.Linq;

namespace FirstApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] arr = { { -5, 6, 9, 1, 2, -3 }, { -8, 8, 1, 1, 2, -3 } };

            for (int i = 0; i <= arr.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= arr.GetUpperBound(1); j++)
                {
                    for (int k = j + 1; k <= arr.GetUpperBound(1); k++)
                    {
                        if (arr[i, j]<=arr[i, k]) continue;

                        int oldIndexValue = arr[i, j];
                        arr[i, j] = arr[i, k];
                        arr[i, k] = oldIndexValue;
                    }

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

using System;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FirstApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            int[] numberArr = GetArrayFromConsole();
            SortArray(in numberArr, out int[] sortedasc, out int[] sorteddesc);

            Console.WriteLine("***");

            ShowArray(sortedasc);
            ShowArray(sorteddesc);
        }

        static string GetColorAndShow(string userName, int age)
        {
            Console.WriteLine("{0}, возраст: {1} \n Напишите какой нибудь цвет, который вам нравится на английском языке с маленькой буквы", userName, age);
            var color = Console.ReadLine();

            switch (color)
            {
                case "red":
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.WriteLine("Your color is red!");
                    break;

                case "green":
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.WriteLine("Your color is green!");
                    break;
                case "cyan":
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.WriteLine("Your color is cyan!");
                    break;
                default:
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("Your color is yellow!");
                    break;
            }

            return color;
        }

        static void ShowColors(params string[] favcolors)
        {
            Console.WriteLine("Ваши любимые цвета:");
            foreach (var color in favcolors)
            {
                Console.WriteLine(color);
            }
        }

        static int[] GetArrayFromConsole(int num = 3)
        {
            var result = new int[num];

            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine("Введите элемент массива номер {0}", i + 1);
                result[i] = int.Parse(Console.ReadLine());
            }

            return result;
        }

        static void SortArray(in int[] array, out int[] sortedasc, out int[] sorteddesc)
        {
            int[] cloneAsc = (int[]) array.Clone();
            sortedasc   = SortArrayAsc(cloneAsc);
            ShowArray(sortedasc);

            sorteddesc  = SortArrayDesc(array);
            ShowArray(sorteddesc);
        }

        static int[] SortArrayAsc(int[] array)
        {
            int temp = 0;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i]>array[j])
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }

            return array;
        }

        static int[] SortArrayDesc(int[] array)
        {
            int temp = 0;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i]<array[j])
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }

            return array;
        }

        static void ShowArray(int[] arr, bool isSort = false)
        {
            //if (isSort) arr = SortArrayAsc(arr);

            foreach (var item in arr) Console.WriteLine(item);
        }

        static void GetName(out string name)
        {
            Console.Write("Введите имя: ");
            name = Console.ReadLine();

        }

        static void GetAge(ref int age)
        {
            Console.Write("Введите ваш возраст: ");
            age = Convert.ToInt32(Console.ReadLine());

        }

        static void BigDataOperation(int[] arr)
        {
            arr[0] = 4;
        }

        enum Semaphore : int
        {
            Red = 100,
            Yellow = 200,
            Green = 300,
        }
    }
}

using System;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FirstApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            (string name, string lastName, byte age, bool hasPet, byte petCount, string[] petNameArray, byte favColorCount, string[] favColorArray) User;
            GetUserInfo(out User);

            Console.WriteLine("Вас зовут: {0} {1}, ваш возраст: {2}", User.name, User.lastName, User.age);
            if (User.hasPet)
            {
                Console.WriteLine("У вас есть питомцы: {0} шт", User.petCount);
                foreach (var item in User.petNameArray) Console.WriteLine(item);
            }

            Console.WriteLine("Вы указали цвета, которые вам нравятся: {0} шт", User.favColorCount);
            foreach (var item in User.favColorArray) Console.WriteLine(item);
        }

        static void GetUserInfo(out (string name, string lastName, byte age, bool hasPet, byte petCount, string[] petNameArray, byte favColorCount, string[] favColorArray) User)
        {
            Console.Write("Укажите ваше имя: ");
            User.name = Console.ReadLine();

            Console.Write("Укажите вашу фамилию: ");
            User.lastName = Console.ReadLine();

            User.age = (byte)GuarantedAnswerFromConsole("Укажите ваш возраст: ", false);
            User.hasPet = GuarantedAnswerFromConsole("Есть ли у вас питомцы? Да/Нет: ");

            User.petCount = 0;
            User.petNameArray = new string[User.petCount];
            if (User.hasPet) {
                User.petCount = (byte)GuarantedAnswerFromConsole("Сколько у вас питомцев?: ", false);
                User.petNameArray = GetPetNameArray(User.petCount);
            }

            User.favColorCount = 0;
            User.favColorCount = (byte)GuarantedAnswerFromConsole("Сколько цветов вам нравится?: ", true);
            User.favColorArray = GetFavColorArray(User.favColorCount);
        }

        static string[] GetPetNameArray(byte petCount)
        {
            string[] petNameArray = new string[petCount];

            if (petCount==0) return petNameArray;

            for (int i = 0; i<petNameArray.Length; i++)
            {
                Console.Write("Введите имя вашего питомца #{0}: ",i+1);
                petNameArray[i] = Console.ReadLine();
            }

            return petNameArray;
        }

        static string[] GetFavColorArray(byte favColorCount)
        {
            string[] favColorArray = new string[favColorCount];

            if (favColorCount==0) return favColorArray;

            for (int i = 0; i<favColorArray.Length; i++)
            {
                Console.Write("Введите цвет #{0}: ", i+1);
                favColorArray[i] = Console.ReadLine();
            }

            return favColorArray;
        }

        static bool GetIsCorrectNumberFromConsole(out int correctNumber)
        {
            return int.TryParse(Console.ReadLine(), out correctNumber);
        }

        static bool GuarantedAnswerFromConsole(string question)
        {
            bool answer;

            while (true)
            {
                Console.Write(question);
                string tempPet = Console.ReadLine().ToUpper();

                if (tempPet=="ДА")
                {
                    answer = true;
                    break;
                }
                else if (tempPet=="НЕТ")
                {
                    answer = false;
                    break;
                }
            }

            return answer;
        }

        static int GuarantedAnswerFromConsole(string question, bool hasZero)
        {
            int answer;

            while (true)
            {
                Console.Write(question);
                int temp;
                bool isNumeric = GetIsCorrectNumberFromConsole(out temp);

                if ((isNumeric)&&(temp>0))
                {
                    answer = temp;
                    break;
                }
                else if ((isNumeric)&&(temp==0))
                {
                    if (hasZero)
                    {
                        answer = temp;
                        break;
                    }
                }
            }

            return answer;
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

        static void Echo(string phrase, int deep)
        {
            var modif = phrase;

            Console.BackgroundColor = (ConsoleColor)deep;
            Console.WriteLine(modif);

            if (modif.Length > 2) modif = modif.Remove(0, 2);

            if (deep > 1) Echo(modif, deep - 1);
        }

        static decimal Factorial(int x)
        {
            if (x == 0)
            {
                return 1;
            }
            else
            {
                return x * Factorial(x - 1);
            }
        }

        private static int PowerUp(int N, byte pow)
        {
            if (pow==0)
            {
                return 1;
            }
            else if (pow==1)
            {
                return N;
            }

            return N * PowerUp(N, --pow);
        }

        enum consoleAnswerType : int
        {
            Int,
            Bool,
        }
    }
}

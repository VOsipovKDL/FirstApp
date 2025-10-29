using System;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using UtilityLibraries;

namespace FirstApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            var department = GetCurrentDepartment();

            Console.WriteLine(department.Company?.Name.StartsWithUpper());
            /*if ((department?.Company?.Type == "Банк")&&(department?.City?.Name == "Санкт-Петербург"))
            {
                string companyName = department.Company?.Name ?? "Неизвестная компания";
                Console.WriteLine("У банка {0} есть отделение в Санкт-Петербурге", companyName);
            }*/

        }

        static Department GetCurrentDepartment()
        {
            Company company = new Company { Type = "Банк" , Name = "igh"};
            City city = new City { Name = "Санкт-Петербург" };
            Department department = new Department { Company = company, City = city };

            return department;
        }

        public static void Questionnaire(string[] args)
        {
            var User = GetUserInfo();

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine();
            Console.WriteLine("Вас зовут: {0} {1}, ваш возраст: {2}", User.name, User.lastName, User.age);

            if (User.hasPet)
            {
                if (User.petCount==1)
                {
                    Console.WriteLine("У вас есть питомец. Его зовут: {1}", User.petCount, User.petNameArray.First());
                } else
                {
                    Console.WriteLine("У вас есть несколько питомцев: {0} шт. Вот их клички: ", User.petCount);
                    foreach (var item in User.petNameArray) Console.WriteLine(item);
                }
            }

            if (User.favColorArray.Length>0)
            {
                if (User.favColorArray.Length==1)
                {
                    Console.WriteLine("У вас есть любимый цвет: {0}", User.favColorArray.First());
                }
                else
                {
                    Console.WriteLine("Вам нравится несколько цветов: {0} шт. Вот они: ", User.favColorCount);
                    foreach (var item in User.favColorArray) Console.WriteLine(item);
                }
            }

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        static (string name, string lastName, byte age, bool hasPet, byte petCount, string[] petNameArray, byte favColorCount, string[] favColorArray) GetUserInfo()
        {
            string name;
            GuarantedAnswerFromConsole("Укажите ваше имя: ", out name);
            string lastName;
            GuarantedAnswerFromConsole("Укажите вашу фамилию: ", out lastName);

            byte age;
            GuarantedAnswerFromConsole("Укажите ваш возраст: ", false, 200, out age);
            bool hasPet = false;
            GuarantedAnswerFromConsole("Есть ли у вас питомцы? Да/Нет: ", out hasPet);

            byte petCount = 0;
            string[] petNameArray = new string[petCount];
            if (hasPet)
            {
                GuarantedAnswerFromConsole("Сколько у вас питомцев?: ", false, 10, out petCount);
                petNameArray = GetPetNameArray(petCount);
            }

            byte favColorCount = 0;
            GuarantedAnswerFromConsole("Сколько цветов вам нравится?: ", true, 10, out favColorCount);
            string[] favColorArray = GetFavColorArray(favColorCount);

            return (name, lastName, age, hasPet, petCount, petNameArray, favColorCount, favColorArray);
        }

        static string[] GetPetNameArray(byte petCount)
        {
            string[] petNameArray = new string[petCount];

            if (petCount==0) return petNameArray;

            for (int i = 0; i<petNameArray.Length; i++)
                GuarantedAnswerFromConsole("Введите имя вашего питомца #"+(i+1)+" ", out petNameArray[i]);

            return petNameArray;
        }

        static string[] GetFavColorArray(byte favColorCount)
        {
            string[] favColorArray = new string[favColorCount];

            if (favColorCount==0) return favColorArray;

            for (int i = 0; i<favColorArray.Length; i++)
                GuarantedAnswerFromConsole("Введите цвет #"+(i+1)+" ", out favColorArray[i]);

            return favColorArray;
        }

        static bool GetIsCorrectNumberFromConsole(out int correctNumber)
        {
            return int.TryParse(Console.ReadLine(), out correctNumber);
        }

        static void GuarantedAnswerFromConsole(string question, out bool answer)
        {
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
        }

        static void GuarantedAnswerFromConsole(string question, bool hasZero, byte maxValue, out byte answer)
        {
            while (true)
            {
                Console.Write(question);
                int temp;
                bool isNumeric = GetIsCorrectNumberFromConsole(out temp);

                if ((isNumeric)&&((temp>0)&&(temp<maxValue)))
                {
                    answer = (byte)temp;
                    break;
                }
                else if ((isNumeric)&&(temp==0))
                {
                    if (hasZero)
                    {
                        answer = (byte)temp;
                        break;
                    }
                }
            }
        }

        static void GuarantedAnswerFromConsole(string question, out string answer)
        {
            while (true)
            {
                Console.Write(question);
                answer = Console.ReadLine();

                if (Regex.IsMatch(answer, "^[а-яА-яЁё]+$")) break;
            }
        }
    }

    class Pen
    {
        public string color;
        public int cost;

        public Pen()
        {
            color   = "Черынй";
            cost    = 100;
        }

        public Pen(string penColor, int penCost)
        {
            color   = penColor;
            cost    = penCost;
        }
    }

    class Rectangle
    {
        public int a;
        public int b;

        public Rectangle()
        {
            a = 6;
            b = 4;
        }

        public Rectangle(int side)
        {
            a = side;
            b = side;
        }

        public Rectangle(int sideA, int sideB)
        {
            a = sideA;
            b = sideB;
        }

        public int Square()
        {
            return a * b;
        }
    }

    class Company
    {
        public string Type;
        public string Name;
    }

    class Department
    {
        public Company Company;
        public City City;
        public int Load;
    }

    class City
    {
        public string Name;
    }
}
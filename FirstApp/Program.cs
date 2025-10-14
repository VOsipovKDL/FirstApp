using System;
using System.Xml.Linq;

namespace FirstApp
{
    class Program
    {
        static void Main(string[] args)
        {
            (string name, string lastName, string login, byte loginLength, bool hasPet, byte age, string[] favcolor) User;

            for (int k = 0; k < 3; k++)
            {
                Console.WriteLine("Ваше имя:");
                User.name = Console.ReadLine();

                Console.WriteLine("Ваша фамилия:");
                User.lastName = Console.ReadLine();

                Console.WriteLine("Придумайте логин:");
                User.login = Console.ReadLine();
                User.loginLength = (byte)User.login.Length;

                Console.WriteLine("У вас есть животные?");
                User.hasPet = (Console.ReadLine().ToUpper()=="ДА") ? true : false;

                Console.WriteLine("Ваш возраст:");
                User.age = (byte)Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Напишите три любимых цвета:");

                User.favcolor = new string[3];
                for (int i = 0; i< User.favcolor.Length; i++)
                {
                    User.favcolor[i] = Console.ReadLine();
                }
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

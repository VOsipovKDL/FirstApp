using System;
using System.Xml.Linq;

namespace FirstApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите имя: ");
            var name = Console.ReadLine();
            Console.Write("Введите возраст: ");
            var age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите дату рождения: ");
            var birthdate = Console.ReadLine();
            Console.WriteLine("Вас зовут: {0}, ваш возраст: {1}, дата вашего рождения: {2}", name, age, birthdate);
        }
    }
    enum Semaphore : int
    {
        Red = 100,
        Yellow = 200,
        Green = 300,
    }
}

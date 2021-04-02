using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Здравствуйте, представтесь пожалуйста");
            string name_user = Console.ReadLine();
            Console.WriteLine($"Привет {name_user}, текущая дата {DateTime.Now.ToShortDateString()}");

            Console.ReadLine();


            /* Дополнительная функция не входящая в основное ДЗ
            Console.WriteLine("Напишите слово 'Time' что бы узнать текущее время или 'Exit' что бы выйти из программы");
            string user_response = Console.ReadLine();
            if (user_response == "Time")
            {
                Console.WriteLine($"Текущее время: {DateTime.Now.ToShortTimeString()} ");
                Console.WriteLine($"{name_user} cпасибо за использование нашего сервиса, программа закроется через 10 секунд.");
                System.Threading.Thread.Sleep(10000);
            }
            else if (user_response == "Exit")
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine($"{name_user}, вы ввели неправильные данные, консоль закроется через 5 секунд");
                System.Threading.Thread.Sleep(5000);
            }
            */
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Greeting;


namespace Lesson_8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите свое имя");
            InteractionUser.HelloUser(Console.ReadLine());
            Console.ReadLine();
        }
    }
}
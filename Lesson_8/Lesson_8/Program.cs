﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using InteractionUser;

namespace Lesson_8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите свое имя");
            Greating.HelloUser(Console.ReadLine());

            Console.ReadLine();
        }
    }
}

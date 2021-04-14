using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lesson5
{
    class Program
    {
        static void Main(string[] args)
        {
            string writePath = @"C:\Users\Pavel\Desktop\HomeWork\";
            //Задание №1
            Console.WriteLine("Введите текст который будет сохранен в файл");
            Program.AddTextOfFile(Console.ReadLine(), writePath);

            //Задание №2
            Program.AddDateTimeFile(writePath);

            //Задание №3
            //Ввод только через 1 пробел т.к. "StringSplitOptions.RemoveEmptyEntries" отказывается у меня работать(44 строка кода).
            Console.WriteLine("Введине числа от 0 до 255 разделенные пробелом, после нажатия клавиши Enter они будут добавленны в бинарный файл");
            Program.CreateBinaryFile(Console.ReadLine(), writePath);

            //Задание №4
            //Можно ли сделать вывод на экран не используя перечисления всех переменных?
            Console.WriteLine("Введите возраст старше которого вы хотите увидеть сотрудников");
            VisionEmployeeOfAge(Convert.ToInt32(Console.ReadLine()));
            Console.ReadLine();
        }

        //Задание №1
        static void AddTextOfFile (string text, string path)
        {
            File.WriteAllText(path + "test.txt", text + "\n");
        }

        //Задание №2
        static void AddDateTimeFile(string path)
        {
            string dateTime = DateTime.Now.ToShortTimeString() + "\n";
            File.AppendAllText(path + "test.txt", dateTime);
        }

        //Задание №3
        static void CreateBinaryFile(string strInput, string path)
        {
            // Я не понимаю почему я не могу применить "StringSplitOptions.RemoveEmptyEntries" т.к. VS ругается на него 
            //string[] numbers = strInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            byte[] ByteArray = strInput.Split(' ').Select(s => Convert.ToByte(s, 10)).ToArray();
            File.WriteAllBytes(path + "bytes.bin", ByteArray);
        }

        //Задание №4
        static void VisionEmployeeOfAge (int age)
        {
            Employee[] persArray = new Employee[5];
            persArray[0] = new Employee("Иванов Иван Иванович", "Инженер", "ivanov@mail.ru", "+7-111-111-11-11", 10000, 23);
            persArray[1] = new Employee("Петров Петр Петрович", "Старший инженер", "petrov@mail.ru", "+7-222-222-22-22", 20000, 27);
            persArray[2] = new Employee("Сергеев Сергей Сергеевич", "Старший инженер", "sergeev@gmail.ru", "+7-333-333-33-33", 20000, 33);
            persArray[3] = new Employee("Федоров Федор Федорович", "Начальникама", "fedor@yandex.ru", "+7-444-444-44-44", 70000, 45);
            persArray[4] = new Employee("Павлов Павел Павлович", "Старший инженер", "pavel@gmail.ru", "+7-555-555-55-55", 20000, 35);

            Employee.WriteConsole(persArray, 30);
        }
    }
}

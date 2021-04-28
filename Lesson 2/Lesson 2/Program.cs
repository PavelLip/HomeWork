using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_2
{
    /*
        Не совсем понятно как работать с бинарными масками, можете дать дополнительное задание на маски (более расширенное и сложное).
    */

    class Program
    {
        static void Main(string[] args)
        {

            List<String> ComandConsole = new List<String>
            {
                "Список команд используемых в программе:",
                " ",
                "TemMonth - среднемесячная температура",
                "EvenNumber - проверка числа на четность",
                "Check - вывести чек" ,
                "BinaryMask - бинарная маска",
                "ListComand - вывести список команд",
                " ",
                "Введите необходимую команду:"
            };

            ListComand();
            string InsertUser = Console.ReadLine();

            switch (InsertUser)
            {
                case "TemMonth":
                    TemperatureMonth();
                    Console.ReadLine();
                    break;
                case "EvenNumber":
                    EvenNumber();
                    Console.ReadLine();
                    break;
                case "Check":
                    Check();
                    Console.ReadLine();
                    break;
                case "ListComand":
                    ListComand();
                    Console.ReadLine();
                    break;
                case "BinaryMask":
                    BinaryMask();
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Вы ввели неправильную команду");
                    Console.ReadLine();
                    break;
            }

            void ListComand()
            {
                for (int i = 0; i < ComandConsole.Count; i++)
                {
                    Console.WriteLine(ComandConsole[i]);
                }
            }
            void TemperatureMonth()
            {
                List<String> MessengeOfTerminal = new List<String>();
                MessengeOfTerminal.Add("Здравствуйте, представтесь пожалуйста");

                Console.WriteLine(MessengeOfTerminal[0]);
                string name_user = Console.ReadLine();
                MessengeOfTerminal.Add($"Здравствуйте, { name_user }. Пожалуйста введите максимальную температуту за сутки:");

                Console.WriteLine($"{ MessengeOfTerminal[1] }");
                float maxTemperature = float.Parse(Console.ReadLine());
                MessengeOfTerminal.Add("а теперь минимальную температуту: ");

                Console.WriteLine($"{ MessengeOfTerminal[2] }");
                float minTemperature = float.Parse(Console.ReadLine());

                MessengeOfTerminal.Add($"Максимальная температура { maxTemperature }, минимальная температура { minTemperature }, средняя температура { Math.Round((maxTemperature + minTemperature) / 2, 2)}");
                Console.WriteLine($"{ MessengeOfTerminal[3] }");




                List<String> Month = new List<String> { "Пьянварь", "Фигвраль", "Кошмарт", "Сопрель", "Сымай", "Теплюнь", "Жарюль", "Авгрусть", "Слюнтябрь", "Моктябрь", "Гноябрь", "Дубабрь" };
                Console.WriteLine("Введите номер текущего месяца"); //добавить проверку на введение числа от 1 до 12
                Byte numberMonth = Byte.Parse(Console.ReadLine());
                if (numberMonth <= 12)
                {
                    if ((numberMonth == 12 || numberMonth == 1 || numberMonth == 2) && (Math.Round((maxTemperature + minTemperature) / 2) >= 0))
                        Console.WriteLine(Month[numberMonth - 1] + ", дождливая зима");
                    else
                        Console.WriteLine(Month[numberMonth - 1]);
                }
                else Console.WriteLine("Вы ввели число больше чем количество месяцев на нашей планете");
            }
            void EvenNumber()
            {
                Console.WriteLine("Введите число");
                int number = int.Parse(Console.ReadLine());
                if (number % 2 == 0) Console.WriteLine("Вы ввчели четное число");
                else Console.WriteLine("Вы ввчели нечетное число");
            }
            void Check()
            {
                Console.Clear();
                List<String> NameProduction = new List<String> { "Песок", "Щебень", "Керамзит", "Грунт", "test1", "test2", "test3", "test4", "test5", "test6" };
                List<Double> PriceProduction = new List<Double> { 300, 650.99, 233.5, 1200, 1235, 545.67, 654, 8334, 5462.32, 43632 };
                List<Double> CountProduction = new List<Double> { 4, 4, 0.5, 2.5, 4, 65, 23, 74, 6, 1 };

                /*
                List<String> NameProduction = new List<String> { "Песок", "Щебень", "Керамзит", "Грунт"};
                List<Double> PriceProduction = new List<Double> {300.34, 650, 233.9, 1200};
                List<Double> CountProduction = new List<Double> { 4, 4, 0.5, 2.5};

                List<String> NameProduction = new List<String> { "Песок" };
                List<Double> PriceProduction = new List<Double> { 300.65 };
                List<Double> CountProduction = new List<Double> { 4.6};
                */

                int receiptHeight = 30;
                int receiptWight = NameProduction.Count + 10;
                char sym = '.';

                Check_Frame check_Frame = new Check_Frame(receiptHeight, receiptWight);

                for (int p = 0; p < NameProduction.Count(); p++)
                {
                    check_Frame.AddProduct(NameProduction[p], Math.Round(CountProduction[p], 1), PriceProduction[p], receiptHeight, receiptWight, sym, 6 + p); //вынести число 6 в переменную
                }
            }
            void BinaryMask()
            {

                //Дни когда человек может придти в офис
                int FreeDay = 0b0000100;

                //работа офисов
                int FirstOfficeWork = 0b0111100;
                int SecondOfficeWork = 0b1111011;

                int ScheduleUser1 = FreeDay & FirstOfficeWork;
                int ScheduleUser2 = FreeDay & SecondOfficeWork;

                //подходящий офис
                Console.WriteLine((ScheduleUser1 == FreeDay) + " первый офис");
                Console.WriteLine((ScheduleUser2 == FreeDay) + " Второй офис");
            }


        }
    }
}

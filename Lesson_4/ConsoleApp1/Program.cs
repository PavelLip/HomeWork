using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {
            ////Задание № 1
            ////Генерируются случайные ФИО из трех массивов расположенных в методе ShowConsoleFullName
            ////Колличество сгенерированных ФИО не ограниченно
            //Console.Write("Введите колличество ФИО которое будет отображено: ");
            //ShowConsoleFullName(Int32.Parse(Console.ReadLine()));
            //Console.ReadLine();

            ////Задание № 2
            ////Что то я перемудрил с бесполезным преобразованием строки в Char, если нужно переделаю) 
            //Console.WriteLine("Введите числа которые требуется сложить через пробел:");
            //Console.WriteLine($"Сумма всех введенных чисел = {SummEnteredNumbers(Console.ReadLine())}");
            //Console.ReadLine();

            ////Задание № 3
            //Console.WriteLine("Введите номер месяца что бы узнать время года");
            //OutputMounth(int.Parse(Console.ReadLine()));
            //Console.ReadLine();

            //Задание № 4
            Console.WriteLine("Введите порядковый номер числа Фибоначчи что бы узнать его значение");
            Console.WriteLine($"Значение числа Фибоначчи равняется: {FibonacciNumbers(int.Parse(Console.ReadLine()))}");
            Console.ReadLine();

            ////Задание № 5
            ////На вебинаре мы разбирали как сделать короче, но я захотел довести программу до конца по уже выбранному пути
            ////Получилось очень много костылей и плохо читаемый код, но она работает.
            //string str = "    Предложение         один    Теперь        предложение           два         Предложение         три         ";
            //DotPlacment(str);
            //Console.ReadLine();
        }
        

        //Задание № 1
        public static void ShowConsoleFullName(int Count)
        {
            string[] FirstName = new string[10] {"Ардаков","Донченко","Кулагин","Бирюков","Васильев","Дылдин","Девин","Угаров","Демчук","Зюлькин"};
            string[] LastName = new string[10] {"Игорь","Иван","Павел","Евгений","Валерий","Алексей","Сергей","Виктор","Алексей","Григорий"};
            string[] Patronymic = new string[10] {"Герасимович","Андреевич","Анатольевич","Евгеньевич","Валентинович","Валерьевич","Владимирович","Михайлович","Павлович","Александрович"};
            
            for (int i = 1; i <= Count; i++)
            {
                string StrFirstName = RndElementArray(FirstName);
                string StrLastName = RndElementArray(LastName);
                string StrPatronymic = RndElementArray(Patronymic);
                GetFullName(StrFirstName, StrLastName, StrPatronymic);
            }
        }
        public static void GetFullName(string FirstName, string LastName, string Patronymic)
        {
            Console.WriteLine(FirstName + " " + LastName + " " + Patronymic);
        }
        public static Random RandomNubmer = new Random(DateTime.Now.Millisecond);
        public static string RndElementArray (string[] Array)
        {
            return Array[RandomNubmer.Next(0, Array.Length)];
        }
        //Задание № 2
        public static int SummEnteredNumbers(string StringUsers)
        {
            char[] CharString = new char[StringUsers.Length]; // не понял на какую ошибку/недочет ругается VS
            CharString = StringUsers.ToCharArray();
            Char Buffer;
            string StringBuffer = "";
            int itogNumbers = 0;

            for (int i = 0; i < CharString.Length; i++)
            {
                Buffer = CharString[i];
                if (CharString[i] != ' ')
                {
                    StringBuffer += Buffer.ToString();
                }
                else
                {
                    itogNumbers += Int32.Parse(StringBuffer);
                    StringBuffer = "0";
                }

                if (i == (CharString.Length - 1))
                {
                    itogNumbers += Int32.Parse(StringBuffer);
                }
            }
            return itogNumbers;
        }
        //Задание № 3
        public static void OutputMounth(int NumberMounth)
        {
            bool ValidationNumber = NumberValidation(NumberMounth, 1, 12);
            if (ValidationNumber)
            {
                //TranslationMounth(DefinitionMounth(NumberMounth));
                Console.WriteLine($"Текущее время года - { TranslationMounth(DefinitionMounth(NumberMounth)) }");
            }
            else return;
            //Console.WriteLine("Вы ввели неправильное число");
        }
        public static string TranslationMounth(ListMonth Month)
        {
            if (Month == ListMonth.Winter) return "Зима";
            else if (Month == ListMonth.Spring) return "Весна";
            else if (Month == ListMonth.Summer) return "Лето";
            else return "Осень";
        }
        public static bool NumberValidation(int InputNumber, int DounNumber, int UpNumber)
        {
            if (InputNumber >= DounNumber && InputNumber <= UpNumber)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Введено не правильное число");
                return false;
            }
        }
        public static ListMonth DefinitionMounth(int NumberMounth)
        {
            if (NumberMounth == 1 || NumberMounth == 2 || NumberMounth == 12) return ListMonth.Winter;
            else if (NumberMounth == 3 || NumberMounth == 4 || NumberMounth == 5) return ListMonth.Spring;
            else if (NumberMounth == 6 || NumberMounth == 7 || NumberMounth == 8) return ListMonth.Summer;
            else return ListMonth.Autumn;
        }
        public enum ListMonth : int
        {
            Winter = 1,
            Spring,
            Summer,
            Autumn,
            //Null
        }
        //Задание № 4
        public static int FibonacciNumbers(int NumberPosition)
        {
            if (NumberPosition == 1 || NumberPosition == 0) return 0;
            int FirstNumbers = 0;
            int SecondNumbers = 1;
            int EndNumbers = FirstNumbers + SecondNumbers;
            (FirstNumbers, SecondNumbers, EndNumbers) = FibonacciNumbers(NumberPosition+1, FirstNumbers, SecondNumbers, EndNumbers);
            return EndNumbers;
        }
        public static (int FirstNumbers, int SecondNumbers, int EndNumbers) FibonacciNumbers(int NumberPosition, int FirstNumbers, int SecondNumbers, int EndNumbers)
        {
            if (NumberPosition > 3)
            {
                (FirstNumbers, SecondNumbers, EndNumbers) = FibonacciNumbers(NumberPosition - 1, FirstNumbers, SecondNumbers, EndNumbers);
                //FibonacciNumbers(NumberPosition-1, FirstNumbers, SecondNumbers, EndNumbers);
                FirstNumbers = SecondNumbers;
                SecondNumbers = EndNumbers;
                EndNumbers = FirstNumbers + SecondNumbers;
                return (FirstNumbers, SecondNumbers, EndNumbers); // бесмысленная строчка кода
            }
            else
            {
                FirstNumbers = 0;
                SecondNumbers = 1;
                EndNumbers = FirstNumbers + SecondNumbers;
                return (FirstNumbers, SecondNumbers, EndNumbers);
            }
        }
        //Задание № 5
        public static void DotPlacment(string str)
        {
            int poiskProbelov = 0;
            for (int i = 0; i < str.Length; i++)
            {
                int x = str.Length;
                if (str[0] == ' ')
                {
                    str = str.Remove(0, 1);
                }
                else if (i == str.Length - 1 && str[str.Length - 1] == ' ')
                {
                    str = str.Remove(str.Length - 1, 1);
                    i -= 2;
                    poiskProbelov = 0;
                }
                else if (poiskProbelov == 2)
                {
                    str = str.Remove(i - 1, 1);
                    poiskProbelov = 0;
                    i -= 3;
                }
                else if (poiskProbelov < 2 && str[i] == ' ')
                {
                    poiskProbelov += 1;
                }
                else if (poiskProbelov == 1 && str[i] != ' ')
                {
                    poiskProbelov = 0;
                }

            } // убираем лишние пробелы перед началом текста

            for (int i = 1; i < str.Length; i++)
            {
                if (char.IsUpper(str[i]))
                {
                    str = str.Insert(i - 1, ".");
                    i += 1;
                }
                else if (i == str.Length - 1)
                {
                    str = str.Insert(i + 1, ".");
                    i = str.Length + 1;
                }
            }
            Console.WriteLine(str);
        }
    }
}

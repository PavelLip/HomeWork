using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_3
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowArrayElementsDiagonally();
            Console.WriteLine();

            ShowTelephoneDirectory();
            Console.WriteLine();

            WordsInReverseOrder();
            Console.WriteLine();

            Console.WriteLine("Введите число на которое должен быть смещен массив (от 1 до 9 или от -1 до -9).");
            int InsertNumber = Int32.Parse(Console.ReadLine());
            MethodShiftArray(InsertNumber);
            Console.ReadLine();

            void MethodShiftArray(int x) 
                // Знаю что можно написать проще через 2 цикла или базовый метод, но у нас был челендж с сокурсниками кто напишет через 1 цикл и без встроенных методов, доп массивов и рекурсий
            {
                
                int[] ShiftArrayNumbers = new int[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                int ShiftArray = 1;
                int Buf= ShiftArrayNumbers[ShiftArrayNumbers.Length - 1];
                bool LeftOrRight = false;
                int CouterArray = ShiftArrayNumbers.Length-1;

                if (x > 0)
                {
                    ShiftArray = 0;
                    LeftOrRight = true;
                    Buf = ShiftArrayNumbers[0];
                }

                for (;;)
                {
                    if (LeftOrRight == true) 
                    {
                        if (ShiftArrayNumbers.Length != ShiftArray+1)
                        {
                            ShiftArrayNumbers[ShiftArray] = ShiftArrayNumbers[ShiftArray + 1];
                            ShiftArray += 1;
                        }
                        else
                        {
                            ShiftArrayNumbers[ShiftArrayNumbers.Length - 1]= Buf;
                            Buf = ShiftArrayNumbers[0];
                            x -= 1;
                            ShiftArray = 0;
                            if (x == 0) break;
                        }
                    }
                    else
                    {
                        if (CouterArray != 0)
                        {
                            ShiftArrayNumbers[CouterArray] = ShiftArrayNumbers[CouterArray - 1];
                            CouterArray -= 1;
                        }
                        else
                        {
                            ShiftArrayNumbers[0] = Buf;
                            Buf = ShiftArrayNumbers[ShiftArrayNumbers.Length - 1];
                            x += 1;
                            CouterArray = ShiftArrayNumbers.Length - 1;
                            if (x == 0) break;
                        }
                    }
                }

                /*while (x != 0 && y != 0)
                {
                    Buf = ShiftArrayNumbers[SaveNumbers];
                    Array.ConstrainedCopy(ShiftArrayNumbers, ShiftArray, ShiftArrayNumbers, FirstElementArray, ShiftArrayNumbers.Length - 1);
                    ShiftArrayNumbers[InsertArray] = Buf;
                    y -= 1;
                    x += 1;
                }
                */

                for (int i = 0; i < ShiftArrayNumbers.Length; i++)
                {
                    Console.Write(ShiftArrayNumbers[i]);
                }

            }
            void ShowArrayElementsDiagonally()
            {

                Random RandomNumbers = new Random();
                int lengthArray = RandomNumbers.Next(5, 10); // Есть ли возможность записать такое объявление в одну строку? 

                int[,] ArrayNumbers = new int[lengthArray, lengthArray];

                for (int i = 0; i < lengthArray; i++)
                {
                    for (int j = 0; j < lengthArray; j++)
                    {
                        ArrayNumbers[i, j] = RandomNumbers.Next(1, 9);
                    }
                }

                for (int i = 0; i < lengthArray; i++)
                {
                    for (int j = 0; j < lengthArray; j++)
                    {
                        if (i == j) Console.Write(ArrayNumbers[i, j]);
                        else Console.Write(0);
                    }
                    Console.WriteLine();
                }
            }
            void ShowTelephoneDirectory()
            {
                String[,] TelephoneDirectory = new String[5, 2]
                   {
                        {"Ivan","Ivan@mail.ru"},
                        {"Stanislav","568-44-32"},
                        {"Egor","Egor@yandex.ru"},
                        {"Vasiliy","+7 524 224 25 54"},
                        {"Pavel","Pavel@gmail.com"}
                   };

                for (int i = 0; i < TelephoneDirectory.GetLength(0); i++)
                {
                    for (int j = 0; j < TelephoneDirectory.GetLength(1); j++)
                    {
                        Console.Write(TelephoneDirectory[i, j] + " ");
                    }
                    Console.WriteLine();
                }
            }
            void WordsInReverseOrder ()
            {
                string RandomString = "Hello World";

                for (int i = RandomString.Length; i > 0; i--)
                {
                    Console.Write(RandomString.Substring(i - 1, 1));
                }
            }

            /*
            Игра морской бой не работает
            Хотел написать метод случайного распределения кораблей по полю, но пока не получается. 
            Не правильный метод генерации координат кораблей
            Не правильная проверка допустимости добавления нового корабля (новый добавляется поверх уже существующего)
            Отсутствует проверка и запрет на расположения кораблей вплотную друг к другу 
            */
            //SeaBattle();
            void SeaBattle()
            {
                char[,] Battlefield = new char[10, 10];
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        Battlefield[i, j] = '.';
                    }
                }

                //Battlefield[0, 0] = '@';

                int CountOneDecShip = 4;
                int CountTwoDecShip = 3;
                int CountThreeDecShip = 2;
                int CountFourDecShip = 1;

                int[,] OneDecShip = new int[1, 2];
                int[,] TwoDecShip = new int[2, 2];
                int[,] ThreeDecShip = new int[3, 2];
                int[,] FourDecShip = new int[4, 2];


                AddShipsOfBattelfild(FourDecShip, Battlefield, CountFourDecShip);
                AddShipsOfBattelfild(ThreeDecShip, Battlefield, CountThreeDecShip);
                //AddShipsOfBattelfild(TwoDecShip, Battlefield, CountTwoDecShip);
                //AddShipsOfBattelfild(OneDecShip, Battlefield, CountOneDecShip);


                ShowSeaBattle(Battlefield);
            }
            void AddShipsOfBattelfild(int[,] ArrayShips, char[,] Battlefield, int Count)
            {
                for (int j = 1; j <= Count; j++)
                {
                    bool CrossingShips = false;
                    int test = 0;
                    while (CrossingShips == false)
                    {
                        Ships.CreateShipsPoint(ArrayShips, Count);
                        int zzz = 0;
                        int xxx = 0;
                        int yyy = 0;

                        for (; zzz < 2; zzz++)
                        {
                            for (; xxx < 9; xxx++)
                            {
                                for (; yyy < 9; yyy++)
                                {

                                    if (Battlefield[ArrayShips[zzz, 0], ArrayShips[zzz, 1]] == Battlefield[xxx, yyy] && Battlefield[xxx, yyy] == 'X')
                                    {
                                        CrossingShips = false;
                                        test = 1;
                                    }

                                }
                            }
                        }
                        if (test == 0)
                        {
                            CrossingShips = true;
                        }
                        else
                        {
                            test = 0;
                        }





                        for (int i = 0; i < ArrayShips.Length / 2; i++)
                        {
                            int x = ArrayShips[i, 0];
                            int y = ArrayShips[i, 1];
                            Battlefield[x, y] = 'X';
                        }

                    }
                    //Ships.CreateShipsPoint(ArrayShips, Count);


                }
            }
            void ShowSeaBattle(char[,] Battlefield)
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        Console.Write(Battlefield[i, j] + " ");
                    }
                    Console.WriteLine();
                }
            }
            
            Console.ReadLine();
        }
    }
}

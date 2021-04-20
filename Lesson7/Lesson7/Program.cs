using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Lesson7
{
    class Program
    {

        //Прямоугольное поле не работает (времени не хватает исправить)
        //Знаю что получился плохой код и тупой ИИ, опять же как будет время попробую все оптимизировать 
        //Хотелось бы получать побольше замечаний что не так с кодом,
        //а то по предыдущим работам я даже не понимаю что и где я сделал не так (точнее как можно было сделать лучше)
        //Рамку на все поле то же не поправил (время, время....), ну надеюсь такая визуалка не обязательна) 

        static int SIZE_X = 5;
        static int SIZE_Y = 5;
        static int SIZE_FINISH = 4;

        static char[,] field = new char[SIZE_Y, SIZE_X];

        static char PLAYER_DOT = 'X';
        static char AI_DOT = 'O';
        static char EMPTY_DOT = '.';

        static Random random = new Random();

        private static void InitField()
        {
            for (int i = 0; i < SIZE_Y; i++)
            {
                for (int j = 0; j < SIZE_X; j++)
                {
                    field[i, j] = EMPTY_DOT;
                }
            }
        }

        private static void PrintField()
        {
            Console.Clear();
            Console.WriteLine("-------");
            for (int i = 0; i < SIZE_Y; i++)
            {
                Console.Write("|");
                for (int j = 0; j < SIZE_X; j++)
                {
                    Console.Write(field[i, j] + "|");
                }
                Console.WriteLine();
            }
            Console.WriteLine("-------");
        }

        private static void SetSym(int y, int x, char sym)
        {
            field[y, x] = sym;
        }

        private static bool IsCellValid(int y, int x)
        {
            if (x < 0 || y < 0 || x > SIZE_X - 1 || y > SIZE_Y - 1)
            {
                return false;
            }

            return field[y, x] == EMPTY_DOT;
        }

        private static bool IsFieldFull()
        {
            for (int i = 0; i < SIZE_Y; i++)
            {
                for (int j = 0; j < SIZE_X; j++)
                {
                    if (field[i, j] == EMPTY_DOT)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private static void playerMove()
        {
            int x, y;
            do
            {
                Console.WriteLine("Координат по строке ");
                Console.WriteLine("Введите координаты вашего хода в диапозоне от 1 до " + SIZE_Y);
                x = Int32.Parse(Console.ReadLine()) - 1;
                Console.WriteLine("Координат по столбцу ");
                Console.WriteLine("Введите координаты вашего хода в диапозоне от 1 до " + SIZE_X);
                y = Int32.Parse(Console.ReadLine()) - 1;
            } while (!IsCellValid(y, x));
            SetSym(y, x, PLAYER_DOT);
        }

        private static void AiMove()
        {
            int x, y;
            bool pointFound;
            (y, x, pointFound) = WayToWinAI(field, PLAYER_DOT);
            if (pointFound)
            {
                SetSym(y, x, AI_DOT);
            }
            else
            {
                (y, x, pointFound) = WayToWinAI(field, AI_DOT);
                if (pointFound)
                {
                    SetSym(y, x, AI_DOT);
                }
                else
                {
                    do
                    {
                        x = random.Next(0, SIZE_X);
                        y = random.Next(0, SIZE_Y);
                    } while (!IsCellValid(y, x));
                    SetSym(y, x, AI_DOT);
                }
            }
        }

        public static (int, int, bool) WayToWinAI(char[,] array, char sym)
        {

            for (int i = 1; i < SIZE_FINISH-1; i++)
            {
                int[,] arrayFound = new int [SIZE_FINISH, 2];
                bool pointFound;
                if (SearchDown(sym, SIZE_FINISH-i))
                {
                    (arrayFound, pointFound) = SearchDownAI(SIZE_FINISH,i, sym);
                    if (arrayFound[0,0] !=-100500)
                    {
                        for (int j = 0; j < SIZE_FINISH - 1; j++)
                        {
                            if (field[arrayFound[j, 0], arrayFound[j, 1]] == EMPTY_DOT)
                            {
                                return (arrayFound[j, 0], arrayFound[j, 1], true);
                            }
                        }
                    }
                }

                if (SearchRight(sym, SIZE_FINISH - i))
                {
                    (arrayFound, pointFound) = SearchRightAI(SIZE_FINISH, i, sym);
                    for (int j = 0; j < SIZE_FINISH - 1; j++)
                    {
                        if (field[arrayFound[j, 0], arrayFound[j, 1]] == EMPTY_DOT)
                        {
                            return (arrayFound[j, 0], arrayFound[j, 1], true);
                        }
                    }
                }

                if (DiagonalSearchLeft(sym, SIZE_FINISH - i))
                {
                    (arrayFound, pointFound) = DiagonalSearchLeftAI(SIZE_FINISH, i, sym);
                    for (int j = 0; j < SIZE_FINISH - 1; j++)
                    {
                        if (field[arrayFound[j, 0], arrayFound[j, 1]] == EMPTY_DOT)
                        {
                            return (arrayFound[j, 0], arrayFound[j, 1], true);
                        }
                    }
                }

                if (DiagonalSearchRight(sym, SIZE_FINISH - i))
                {
                    (arrayFound, pointFound) = DiagonalSearchRightAI(SIZE_FINISH, i, sym);
                    for (int j = 0; j < SIZE_FINISH - 1; j++)
                    {
                        if (field[arrayFound[j, 0], arrayFound[j, 1]] == EMPTY_DOT)
                        {
                            return (arrayFound[j, 0], arrayFound[j, 1], true);
                        }
                    }
                }
            }
            return (0,0,false);
        }

        private static bool opportunity (int [,] array, char sym)
        {
            int count = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                if (field[array[i, 0], array[i, 1]] == sym)
                {
                    count += 1;
                }
                if (field[array[i, 0], array[i, 1]] == EMPTY_DOT)
                {
                    count += 1;
                }
            }
            if (count== array.GetLength(0))
            {
                return true;
            }
            return false;
        }

        public static (int,int) NextMoveAI ()
        {
            int x = 1;
            int y = 2;
            return (x, y);
        }

        public static (int [,], bool) DiagonalSearchRightAI(int finish, int step, char sym)
        {
            int count;
            int[,] arrayFound = new int[finish, 2];
            for (int x = 0; x <= SIZE_Y - finish; x++)
            {
                for (int y = 0; y <= SIZE_X - finish; y++)
                {
                    if (field[x, y] == sym)
                    {
                        count = 1;
                        arrayFound[count - 1, 0] = x;
                        arrayFound[count - 1, 1] = y;
                        //(int z = 1; z < finish; z++)
                        for (int z = 1; z<finish; z++)
                        {
                            arrayFound[z, 0] = x + z;
                            arrayFound[z, 1] = y + z;

                            if (field[x + z, y + z] == sym)
                            {
                                count += 1;
                            }
                        }
                        if (count == finish- step && count >= 2)
                        {
                            if (opportunity(arrayFound, sym))
                            {
                                return (arrayFound, true);
                            }
                        }     
                    }
                }
            }
            return (arrayFound, false);
        }

        public static (int[,], bool) DiagonalSearchLeftAI(int finish, int step, char sym)
        {
            int count;
            int[,] arrayFound = new int[finish, 2];
            for (int y = SIZE_Y - 1; y >= finish - 1; y--)
            {
                for (int x = 0; x <= SIZE_X - finish; x++)
                {
                    if (field[x, y] == sym)
                    {
                        count = 1;
                        arrayFound[count - 1, 0] = y;
                        arrayFound[count - 1, 1] = x;
                        for (int z = 1; z < finish; z++)
                        {
                            arrayFound[z, 0] = x + z;
                            arrayFound[z, 1] = y - z;
                            if (field[x + z, y - z] == sym)
                            {
                                count += 1;
                            }
                        }
                        if (count == finish - step && count >= 2)
                        {
                            if (opportunity(arrayFound, sym))
                            {
                                return (arrayFound, true);
                            }
                        }
                    }
                }
            }
            return (arrayFound, false);
        }

        public static (int[,], bool) SearchDownAI(int finish, int step, char sym)
        {
            int count;
            int[,] arrayFound = new int[finish, 2];
            for (int x = 0; x < SIZE_Y - finish + 1; x++)
            {
                for (int y = 0; y < SIZE_X; y++)
                {
                    if (field[x, y] == sym)
                    {
                        count = 1;
                        arrayFound[count - 1, 0] = x;
                        arrayFound[count - 1, 1] = y;
                        for (int z = 1; z < finish; z++)
                        {
                            arrayFound[z, 0] = x + z;
                            arrayFound[z, 1] = y;
                            if (field[x + z, y] == sym)
                            {
                                count += 1;
                            }
                        }
                        if (count == finish - step && count>=2)
                        {
                            if (opportunity(arrayFound, sym))
                            {
                                return (arrayFound, true);
                            }
                        }
                    }
                }
            }
            return (arrayFound, false);

        }

        public static (int[,], bool) SearchRightAI(int finish, int step, char sym)
        {
            int count;
            int[,] arrayFound = new int[finish, 2];
            for (int x = 0; x < SIZE_Y; x++)
            {
                for (int y = 0; y < SIZE_X - finish + 1; y++)
                {
                    if (field[x, y] == sym)
                    {
                        count = 1;
                        arrayFound[count - 1, 1] = y;
                        arrayFound[count - 1, 0] = x;
                        for (int z = 0; z < finish - 1; z++)
                        {
                            arrayFound[z + 1, 0] = x;
                            arrayFound[z + 1, 1] = y + z + 1;

                            if (field[x, y + z + 1] == sym)
                            {
                                count += 1;
                            }
                        }
                        if (count == finish - step && count >= 2)
                        {
                            if (opportunity(arrayFound, sym))
                            {
                                return (arrayFound, true);
                            }
                        }
                    }
                }
            }
            return (arrayFound, false);
        }

        public static bool DiagonalSearchRight(char sym, int finish)
        {
            int count;
            for (int x = 0; x <= SIZE_Y - finish; x++)
            {
                for (int y = 0; y <= SIZE_X - finish; y++)
                {
                    if (field[x, y]==sym)
                    {
                        count = 1;
                        for (int z = 1; z < finish; z++)
                        {
                            if (field[x + z, y + z] == sym)
                            {
                                count += 1;
                            }
                        }
                        if (count == finish) return true;
                    }
                }
            }
            return false;
        }

        public static bool DiagonalSearchLeft(char sym, int finish)
        {
            int count;
            for (int y = SIZE_Y - 1; y >= finish - 1; y--)
            {
                for (int x = 0; x <= SIZE_X - finish; x++)
                {
                    if (field[x, y] == sym)
                    {
                        count = 1;
                        for (int z = 1; z < finish; z++)
                        {
                            if (field[x + z, y - z] == sym)
                            {
                                count += 1;
                            }
                        }
                        if (count == finish) return true;
                    }
                }
            }
            return false;
        }

        public static bool SearchDown(char sym, int finish)
        {
            int count;
            for (int x = 0; x < SIZE_Y - finish + 1; x++)
            {
                for (int y = 0; y < SIZE_X; y++)
                {
                    if (field[x, y]==sym)
                    {
                        count = 1;
                        for (int z = 1; z < finish; z++)
                        {
                            if (field[x + z, y] == sym)
                            {
                                count += 1;
                            }
                        }
                        if (count == finish) return true;
                    }
                }
            }
            return false;

        }

        public static bool SearchRight(char sym, int finish)
        {
            int count;
            for (int x = 0; x < SIZE_Y; x++)
            {
                for (int y = 0; y < SIZE_X - finish + 1; y++)
                {
                    if (field[x, y] == sym)
                    {
                        count = 1;
                        for (int z = 1; z < finish; z++)
                        {
                            if (field[x, y+z] == sym)
                            {
                                count += 1;
                            }
                        }
                        if (count == finish) return true;
                    }
                }
            }
            return false;
        }

        private static bool CheckWin(char sym)
        {
            if (SearchDown(sym, SIZE_FINISH)) return true;
            if (SearchRight(sym, SIZE_FINISH)) return true;
            if (DiagonalSearchLeft(sym, SIZE_FINISH)) return true;
            if (DiagonalSearchRight(sym, SIZE_FINISH)) return true;
            return false;
        }

        static void Main(string[] args)
        {
            InitField();
            PrintField();
            do
            {
                playerMove();
                Console.WriteLine("Ваш ход на поле");
                PrintField();
                if (CheckWin(PLAYER_DOT))
                {
                    Console.WriteLine("Вы выиграли");
                    break;
                }
                else if (IsFieldFull()) break;
                AiMove();
                Console.WriteLine("Ход Компа на поле");
                PrintField();
                if (CheckWin(AI_DOT))
                {
                    Console.WriteLine("Выиграли Комп");
                    break;
                }
                else if (IsFieldFull()) break;
            } while (true);
            Console.WriteLine("!Конец игры!");
            Console.ReadLine();
        }
    }
}

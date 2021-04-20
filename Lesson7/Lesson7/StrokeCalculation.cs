using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Lesson7
{
    
    class StrokeCalculation
    {
        int Move_X { get; }
        int Move_Y { get; }

        /*
         *Разбить всек поле на ячейки в которых может быть победа
         *метод разбивающий все поле на ячейки (на взоде символ что бы знать мешать или самому выигрывать)
         *Метод ищущий выигрышные комбинации в ячейках, можно ли помешать 
         *
        */


        //public void SearchWinAI(char [,] array, char sym)
        //{
        //    if (SearchRight(array, sym))
        //    {

        //    }
        //}

        //public bool SearchRight(char[,] array, char sym)
        //{

        //}

        //public bool SearchDown(char[,] array, char sym)
        //{

        //}

        //public bool SearchDiagonalRight(char[,] array, char sym)
        //{

        //}

        //public bool SearchDiagonalLeft(char[,] array, char sym)
        //{

        //}

        //public char[,] ArrayFinishPosition(int x, int y, int finish, char[,] field)
        //{
        //    char[,] array = new char[((x - finish + 1) * y) * 4, finish];

        //    array = AddArrayFinishPosition(field, array, finish);
        //    return array;
        //}

        //public char[,] AddArrayFinishPosition(char[,] field, char[,] array, int finish)
        //{
        //    bool test;
        //    int x;
        //    int y;
        //    (test, x, y) = Program.SearchDown('X', 2);
        //    if (test)
        //    {
        //        if (Search()) //поиск возможности помешать если есть то return
        //        {

        //        }
        //    }

        //    (test, x, y) = Program.SearchRight('X', 2);
        //    if (test)
        //    {
        //        if (Search()) //поиск возможности помешать если есть то return
        //        {

        //        }
        //    }

        //    (test, x, y) = Program.DiagonalSearchLeft('X', 2);
        //    if (test)
        //    {
        //        if (Search()) //поиск возможности помешать если есть то return
        //        {

        //        }
        //    }

        //    (test, x, y) = Program.DiagonalSearchRight('X', 2);
        //    if (test)
        //    {
        //        if (Search()) //поиск возможности помешать если есть то return
        //        {

        //        }
        //    }

        //    return array;
        //}


        //public bool Search()//поиск куда поставить точку что бы помешать 
        //{
        //    return true;
        //}

        //public bool DrawOnInterfere(char[,] field)
        //{
        //    int countMove = 0;
        //    for (int x = 0; x < field.GetLength(0); x++)
        //    {
        //        for (int y = 0; y < field.GetLength(1); y++)
        //        {
        //            if (field[x, y] == 'X')
        //            {
        //                countMove += 1;
        //            }
        //        }
        //    }
        //    if (countMove < 2) return false;
        //    else return true;
        //}













    }




}

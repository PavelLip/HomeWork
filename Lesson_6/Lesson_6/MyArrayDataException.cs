using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lesson_6
{
    [Serializable]
    class MyArrayDataException : Exception
    {
        public static int LineArray { get; set; }
        public static int ColumnArray { get; set; }
        public MyArrayDataException(int lineArray, int columnArray)
        {
            LineArray = lineArray;
            ColumnArray = columnArray;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lesson_6
{
    public enum ErrorCode
    {
        LineArrayMore,
        LineArrayLess,
        ColumnsArrayMore,
        ColumnsArrayLess,
    }
    [Serializable]
    class MyArraySizeException : Exception
    {
        public int countLineArray { get; set; }
        public int countColumnsArray { get; set; }
        public ErrorCode Code { get; }

        public MyArraySizeException (ErrorCode code)
        {
            Code = code;
        }

    }
}

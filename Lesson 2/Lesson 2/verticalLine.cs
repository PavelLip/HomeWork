using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_2
{
    class verticalLine : Figure
    {
        public verticalLine(int topy, int botttony, int x, char sym)
        {
            pList = new List<Point>();
            for (int y = topy; y <= botttony; y++)
            {
                Point p = new Point(x, y, sym);
                pList.Add(p);
            }
        }
    }
}

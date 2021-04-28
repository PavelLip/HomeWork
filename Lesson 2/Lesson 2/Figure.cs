using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_2
{
    class Figure
    {
        protected List<Point> pList;
        public void draw()
        {
            foreach (Point p in pList)
            {
                p.draw();
            }
        }
    }
}

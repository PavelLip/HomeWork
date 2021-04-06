using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_3
{
    class Ships
    {
        
        /*
              public void CreateShips(int[,] Ships, int count)
              {
                  
                  int CountOneDecSЫhip = 4;
                  int CountTwoDecSЫhip = 3;
                  int CountThreeDecSЫhip = 2;
                  int CountFourDecSЫhip = 1;

                  int[,] OneDecShip = new int[1, 2];
                  int[,] TwoDecShip = new int[2, 2];
                  int[,] ThreeDecShip = new int[3, 2];
                  int[,] FourDecShip = new int[4, 2];
                  

        Random RandomPoint = new Random();


        }
        */
        public static void CreateShipsPoint (int [,] Ship, int count)
        {
            //Random RandomPoint = new Random.Seed();

            Random RandomPoint = new Random(DateTime.Now.Millisecond);

            Ship[0, 0] = RandomPoint.Next (0, Ship.Length / 2);
            Ship[0, 1] = RandomPoint.Next(0, Ship.Length / 2);
            int RightOrDown = RandomPoint.Next(0, 100);

            if (count < 4)
            {
                if (RightOrDown < 50) //строим вправо
                {
                    AddArrayShip(Ship, 1, 0);
                }
                else //строим влево
                {
                    AddArrayShip(Ship, 0, 1);
                }
            }

        }

        public static void AddArrayShip (int[,] Ship, int x, int y)
        {
            for (int i = 1; i<Ship.Length/2; i++)
            {
                Ship[i, 0] = Ship[i - 1, 0] + x;
                Ship[i, 1] = Ship[i - 1, 1] + y;

            }
        }

    }
    
}

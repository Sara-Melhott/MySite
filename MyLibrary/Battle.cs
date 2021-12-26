using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class Battle : IBattle
    {
        public Frog MyFrog;
        public Frog Enemy;
        public TimeSpan wait_time = new TimeSpan(2, 0, 0);
        public Battle(Frog my_frog)
        {
            Enemy = new Frog(my_frog.Level);
            MyFrog = my_frog;
        }
        public bool IsWin()
        {
            double HP1 = 10;
            double HP2 = 10;
            int power1 = MyFrog.levelOfPoints("power");
            int power2 = Enemy.levelOfPoints("power");
            int agility1 = MyFrog.levelOfPoints("agility");
            int agility2 = Enemy.levelOfPoints("agility");
            double luck1 = MyFrog.Luck;
            double luck2 = Enemy.Luck;

            while ((HP1 > 0) && (HP2 > 0))
            {
                HP1 -= power2 * agility2 * (1 - luck1);
                HP2 -= power1 * agility1 * (1 - luck2);
            }
            if (HP1 > 0)
                return true;
            else
                return false;
        }
        public int ButtleWinPoints(Frog my_frog)
        {
            int level = my_frog.levelOfPoints("power");
            return (my_frog.pointsOfLevelMax(level) - my_frog.pointsOfLevelMin(level)) / 10;
        }
    }
}

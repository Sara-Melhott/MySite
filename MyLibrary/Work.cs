using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class Work
    {
        public TimeSpan wait_time4 = new TimeSpan(4, 0, 0);
        public TimeSpan wait_time8 = new TimeSpan(8, 0, 0);
        public TimeSpan wait_time12 = new TimeSpan(12, 0, 0);
        public Work()
        {

        }
        /// <summary>
        /// Шанс получение выговора на работе 
        /// </summary>
        /// <returns></returns>
        public bool workNotSuccess()
        {
            Random rnd = new Random();
            int chance = rnd.Next(1, 100);
            if (chance > 90)
                return false;
            else
                return true;
        }
        /// <summary>
        /// Шанс получения премии на работе
        /// </summary>
        /// <param name="frog"></param>
        /// <returns></returns>
        public bool workGoodDay(Frog frog)
        {
            Random rnd = new Random();
            int chance = rnd.Next(1, 100);
            if (chance >= (1 - frog.Luck) * 10)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Дополнительные очки к интелекту (премия)
        /// </summary>
        /// <param name="frog"></param>
        /// <returns></returns>
        public int workExtraPoints(Frog frog)
        {
            int level = frog.levelOfPoints("intelligence");
            return (frog.pointsOfLevelMax(level) - frog.pointsOfLevelMin(level)) / 8;
        }
        public int work4Hour(Frog frog)
        {
            int level = frog.levelOfPoints("intelligence");
            return (frog.pointsOfLevelMax(level) - frog.pointsOfLevelMin(level)) / 16;
        }
        public int work8Hour(Frog frog)
        {
            int level = frog.levelOfPoints("intelligence");
            return (frog.pointsOfLevelMax(level) - frog.pointsOfLevelMin(level)) / 8;
        }
        public int work12Hour(Frog frog)
        {
            int level = frog.levelOfPoints("intelligence");
            return (frog.pointsOfLevelMax(level) - frog.pointsOfLevelMin(level)) / 4;
        }
    }
}

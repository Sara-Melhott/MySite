using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class Feeding
    {
        public TimeSpan wait_time = new TimeSpan(23, 59, 59);
        public Feeding()
        {

        }
        /// <summary> Шанс неудачной кормежки</summary>
        /// <param name="frog"></param>
        /// <returns></returns>
        public bool feedingBadDay()
        {
            Random rnd = new Random();
            int chance = rnd.Next(1, 100);
            if (chance > 90)
                return false;
            else
                return true;
        }
        /// <summary>
        /// Получение очков при удачной кормежке
        /// </summary>
        /// <param name="frog"></param>
        /// <returns></returns>
        public int feedingPoints(Frog frog)
        {
            int level = frog.levelOfPoints("agility");
            return (frog.pointsOfLevelMax(level) - frog.pointsOfLevelMin(level)) / 4;
        }
        /// <summary>
        /// Шанс хорошего дня 
        /// </summary>
        /// <param name="frog"></param>
        /// <returns></returns>
        public bool feedingGoodDay(Frog frog)
        {
            Random rnd = new Random();
            int chance = rnd.Next(1, 100);
            if (chance >= (1 - frog.Luck) * 10)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Дополнительные очки
        /// </summary>
        /// <param name="frog"></param>
        /// <returns></returns>
        public int feedingExtraPoints(Frog frog)
        {
            int level = frog.levelOfPoints("agility");
            return (frog.pointsOfLevelMax(level) - frog.pointsOfLevelMin(level)) / 8;
        }
    }
}

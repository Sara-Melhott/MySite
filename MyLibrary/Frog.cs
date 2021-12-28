using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class Frog
    {
        public int ID { get; set; }
        public int ID_Player { get; set; }
        public string Name { get; set; }
        public int Power_point { get; set; }
        public int Agility_point { get; set; }
        public int Intelligence_points { get; set; }
        public double Luck { get; set; }
        public int Level { get; set; }
        public string BattleTime { get; set; }
        public string FeedingTime { get; set; }
        public string WorkTime { get; set; }
        public Frog()
        {

        }

        public Frog(int id, int id_player, string name, int power_point, int agility_point,
            int intelligence_point, double luck, int level, string battle_time, string feeding_time,
            string work_time)
        {
            ID = id;
            ID_Player = id_player;
            Name = name;
            Power_point = power_point;
            Agility_point = agility_point;
            Intelligence_points = intelligence_point;
            Luck = luck;
            Level = level;
            BattleTime = battle_time;
            FeedingTime = feeding_time;
            WorkTime = work_time;
        }

        public int levelOfPoints(string type)
        {
            int power = String.Compare(type, "power");
            int agility = String.Compare(type, "agility");
            int intelligence = String.Compare(type, "intelligence");
            int points = -1;

            if (power == 0) points = Power_point;
            else if (agility == 0) points = Agility_point;
            else if (intelligence == 0) points = Intelligence_points;
            else throw new ArgumentException("Неверно введенная строка");

            if (points < 100)
                return 1;
            else if (points < 300)
                return 2;
            else if (points < 700)
                return 3;
            else if (points < 1500)
                return 4;
            else if (points < 3100)
                return 5;
            else if (points < 6300)
                return 6;
            else if (points < 12700)
                return 7;
            else if (points < 25500)
                return 8;
            else if (points < 51100)
                return 9;
            else return 10;
        }

        public int pointsOfLevelMin(int level)
        {
            switch (level)
            {
                case 1: return 0;
                case 2: return 100;
                case 3: return 300;
                case 4: return 700;
                case 5: return 1500;
                case 6: return 3100;
                case 7: return 6300;
                case 8: return 12700;
                case 9: return 25500;
                case 10: return 51100;
                default: throw new ArgumentException("Недопустимый код операции");
            }
        }
        public int pointsOfLevelMax(int level)
        {
            switch (level)
            {
                case 10: return 51101;
                case 1: return 99;
                case 2: return 299;
                case 3: return 699;
                case 4: return 1499;
                case 5: return 3099;
                case 6: return 6499;
                case 7: return 12699;
                case 8: return 25499;
                case 9: return 51099;
                default: throw new ArgumentException("Недопустимый код операции");
            }
        }
        /// <summary>Создание рандомной жабки +- определенного уровня</summary>
        /// /// <param name="level"></param>
        public Frog(int level)
        {
            Random rnd = new Random();
            ID_Player = 0;
            Name = "Frog";
            int rndLevelPower = 1;
            int rndLevelAgility = 1;
            int rndLevelIntelligence = 1;

            int start = level - 1, end = level + 3;
            if (level == 1) start = 1;
            if (level > 7) end = 10;

            rndLevelPower = rnd.Next(start, end);
            rndLevelAgility = rnd.Next(start, end);
            rndLevelIntelligence = rnd.Next(start, end);


            Power_point = rnd.Next(pointsOfLevelMin(rndLevelPower), pointsOfLevelMax(rndLevelPower));
            Agility_point = rnd.Next(pointsOfLevelMin(rndLevelAgility), pointsOfLevelMax(rndLevelAgility)); ;
            Intelligence_points = rnd.Next(pointsOfLevelMin(rndLevelIntelligence), pointsOfLevelMax(rndLevelIntelligence));
            Level = (rndLevelAgility + rndLevelIntelligence + rndLevelPower) / 3;
            Luck = rnd.Next(1, 10) / 10.0;
            BattleTime = null;
            WorkTime = null;
            FeedingTime = null;
        }
        public void updatePoint(int point, string type)
        {
            int power = String.Compare(type, "power");
            int agility = String.Compare(type, "agility");
            int intelligence = String.Compare(type, "intelligence");

            if (power == 0) Power_point += point;
            else if (agility == 0) Agility_point += point;
            else if (intelligence == 0) Intelligence_points += point;
        }
        public void updateLevel()
        {
            int new_level = (levelOfPoints("power") + levelOfPoints("agility") + levelOfPoints("intelligence")) / 3;
            if (new_level > Level)
            {
                Level = new_level;
            }
        }
    }
}

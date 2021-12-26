using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class Time
    {
        public Time()
        {

        }
        public bool iswaitTime(string leftTime)
        {
            if (leftTime != null)
            {
                if (DateTime.Parse(leftTime) < DateTime.Now)
                    return false;
                else
                    return true;
            }
            else
                return false;
        }
    }
}

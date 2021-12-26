using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    interface IBattle
    {
        bool IsWin();
        int ButtleWinPoints(Frog frog);
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class AppContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Frog> Frogs { get; set; }

        //public AppContext() : base("DefaultConnection2") { }
    }
}

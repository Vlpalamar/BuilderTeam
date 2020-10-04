using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class Program
    {
        static void Main(string[] args)
        {
            Team t = new Team();
            Brigadir br = new Brigadir();
            Worker w = new Worker();
            t.team.Add(br);
            t.team.Add(w);
            t.Work();
        }
    }
}

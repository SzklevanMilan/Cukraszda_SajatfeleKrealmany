using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cukraszda
{
    class Ajanlat
    {
        public string nev, egyseg;
        public int ar;

        public Ajanlat(string nev,string egyseg, int ar)
        {
            this.egyseg = egyseg;
            this.ar = ar;
            this.nev = nev;
        }
    }
}

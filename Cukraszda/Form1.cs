using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Cukraszda
{
    public partial class Form1 : Form
    {
        static List<Sutemeny> sutemenyek = new List<Sutemeny>();
        public Form1()
        {
            InitializeComponent();
            StreamReader be = new StreamReader("cuki.txt");
            while (!be.EndOfStream)
            {
                string[] a = be.ReadLine().Split(';');
                sutemenyek.Add(new Sutemeny(a[0], a[1], bool.Parse(a[2]), int.Parse(a[3]), a[4]));
            }
            be.Close();
            Random();
            MinMax();
            DijazottDb();
            ListaKiiras();
        }
        public void Random()
        {
            Random rnd = new Random();
            int rand = rnd.Next(0, sutemenyek.Count);
            tbMaiAjanlat.Text = sutemenyek[rand].Nev;
        }
        public void MinMax()
        {
            foreach (var s in sutemenyek.OrderBy(x => x.Ar).Take(1))
            {
               tbLegolcsobbNev.Text = s.Nev;
                tbLegolcsobbAr.Text = s.Ar +"/"+ s.Egyseg;
            }
            foreach (var s in sutemenyek.OrderByDescending(x => x.Ar).Take(1))
            {
                tbLegdragabbNev.Text = s.Nev;
                tbLegdragabbAr.Text = s.Ar + "/" + s.Egyseg;
            }
        }
        public void DijazottDb()
        {
            int db = 0;
            foreach (var s in sutemenyek)
            {
                if (s.Dijazott)
                {
                    db++;
                }
            }
            tbValaszthato.Text = db + "Féle díjnyertes édességből választhat";
        }
        public void ListaKiiras()
        {
            StreamWriter ki = new StreamWriter("list.txt");
            Dictionary<string, string> lista = new Dictionary<string, string>();
            foreach (var s in sutemenyek)
            {
                if (!lista.ContainsKey(s.Nev))
                {
                    lista.Add(s.Nev,s.Tipus);
                }
            }
            foreach (var s in sutemenyek)
            {
                ki.WriteLine();
            }
            ki.Close();
        }

        private void btnMentes_Click(object sender, EventArgs e)
        {

        }
    }
}

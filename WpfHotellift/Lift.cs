using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfHotellift
{
    internal class Lift
    {
        private string idopont;
        private int kartyaszam;
        private int induloszint;
        private int celszint;

        public Lift(string sor)
        {
            var temp = sor.Split(" ");
            Idopont = temp[0];
            Kartyaszam = int.Parse(temp[1]);
            Induloszint = int.Parse(temp[2]);
            Celszint = int.Parse(temp[3]);
        }

        public string Idopont { get => idopont; set => idopont = value; }
        public int Kartyaszam { get => kartyaszam; set => kartyaszam = value; }
        public int Induloszint { get => induloszint; set => induloszint = value; }
        public int Celszint { get => celszint; set => celszint = value; }
    }
}

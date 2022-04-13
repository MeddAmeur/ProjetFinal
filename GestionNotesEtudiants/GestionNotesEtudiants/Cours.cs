using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionNotesEtudiants
{
    internal class Cours
    {
        public int numeroCours { get; set; }
        public string code { get; set; }
        public string titre { get; set; }

        public Cours(int numeroCours, string code, string titre)
        {
            this.numeroCours = numeroCours;
            this.code = code;   
            this.titre = titre;
        }
        public string toString()
        {
            return "\nNuméro du cours: " + this.numeroCours +
                   "\t\tCode : " + this.code +
                   "\t\ttitre : " + this.titre;
        }
    }
}

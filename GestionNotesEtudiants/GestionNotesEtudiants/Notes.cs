using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionNotesEtudiants
{
    internal class Notes
    {
        private double noteEtudiant;
        public int numeroEtudiant { get; set; }
        public int numeroCours { get; set; }
        public double note { 
            get =>  noteEtudiant; 
            set=> noteEtudiant = value>=0 ? value:0; 
        }

        public Notes(int numeroEtudiant, int numeroCours, double note)
        {
            this.numeroEtudiant = numeroEtudiant;
            this.numeroCours = numeroCours;
            this.note = note;
        }
        public string toString()
        {
            return "\tNote : " + this.note;
        }
    }
}

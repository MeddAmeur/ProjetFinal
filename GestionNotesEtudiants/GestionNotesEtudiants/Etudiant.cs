using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionNotesEtudiants
{
    internal class Etudiant
    {
        public int numeroEtudiant { get; set; }
        public string name { get; set; }
        public string prenom { get; set; }
        
        public Etudiant(int numeroEtudiant, string name, string prenom)
        {
            this.numeroEtudiant = numeroEtudiant;
            this.name = name;
            this.prenom = prenom;
        }

        public string toString()
        {
            return "Numéro d'étudiant: "+this.numeroEtudiant+
                   "\tNom : "+this.name+
                   "\tPrénom : "+this.prenom;
        }
    }
}

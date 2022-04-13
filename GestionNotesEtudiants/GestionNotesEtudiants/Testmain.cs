using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace GestionNotesEtudiants 
{
    internal class Testmain
    {
        static List<string> etudiantListFile;
        static int GererException(string message, string messageException)
        {
            int numero;
            saisirNumero:
            Console.Write(message+" ");
            try {
                numero = int.Parse(Console.ReadLine());
            }
            catch (Exception) {
                Console.WriteLine(messageException);
                goto saisirNumero;
            }
            return numero;
        }
        static bool IsExiste(int numeroEtudiant)
        {
            bool isExiste = false;
            foreach (string str in etudiantListFile)
                if (str.Equals(numeroEtudiant.ToString())) isExiste = true;
            return isExiste;
        }
        static int EtudiantExist()
        {   
            int numero;
        saisirNumero:
                numero = GererException("Numéro d'étudiant: ", "Le Numéro d'étudiant doit être un nombre entier");
                if (IsExiste(numero))
                {
                    Console.WriteLine("cette numero deja existe ! Entrez un autre numéro");
                    goto saisirNumero;
                }
                
            return numero;

        }
        static void AjouterUnNouvelEtudiant()
        {
            Etudiant etudiant = CreerEtudiant();
            Cours cours = CreerCours();
            Notes notes = CreerNotes(etudiant.numeroEtudiant, cours.numeroCours);
            CreerFile(etudiant, cours, notes);
        }
        static Etudiant CreerEtudiant()
        {
            int numeroEtudiant;
            string nom = "";
            string prenom = "";

            numeroEtudiant = EtudiantExist();

            Console.Write("Nom d'étudiant: ");
            nom = Console.ReadLine();


            Console.Write("Prénom d'étudiant: ");
            prenom = Console.ReadLine();

            Etudiant etudiant =new Etudiant(numeroEtudiant, nom, prenom);
            return etudiant;
            
        }
        static Cours CreerCours() {
            int numeroCours;
            string code;
            string titre;
            numeroCours = GererException("Numéro du cours: ", "Le Numéro du cours doit être un nombre entier");
            Console.Write("Code : ");
             code = Console.ReadLine();
            Console.Write("Titre : ");
             titre = Console.ReadLine();

            Cours cours = new Cours(numeroCours, code, titre);
            return cours;

        }
        static Notes CreerNotes(int numeroEtudiant, int numeroCours) {
            double note=0.0;
            saisirNote:
            Console.Write("Saisir une note : ");
            try
            {
                note = double.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("La note doit être un nombre réel ");
                goto saisirNote;
            }
            Notes notes=new Notes(numeroEtudiant, numeroCours, note);
            return notes;

        }
        static void CreerFile(Etudiant etudiant, Cours cours, Notes notes)
        {
            StreamWriter ecrireFichier = new StreamWriter(etudiant.numeroEtudiant+".txt");
            ecrireFichier.WriteLine("----------------------------------------------------------------------------------");
            ecrireFichier.WriteLine(etudiant.toString());
            ecrireFichier.WriteLine("----------------------------------------------------------------------------------");
            ecrireFichier.WriteLine("\n                                    Courses                                     ");
            ecrireFichier.WriteLine(cours.toString() + notes.toString());
            ecrireFichier.Close();
            etudiantListFile.Add(etudiant.numeroEtudiant.ToString());
            Console.WriteLine($"Le fichier txt ({etudiant.numeroEtudiant}.txt) a été créé avec succès");
        }

        static void ModifieFile(int  numEtudiant)
        {
            StreamWriter ecrireFichier = File.AppendText(numEtudiant+".txt");
            Cours cours = CreerCours();
            Notes notes = CreerNotes(numEtudiant, cours.numeroCours);
            ecrireFichier.WriteLine(cours.toString() + notes.toString());

            ecrireFichier.Close();
            Console.WriteLine($"Le fichier txt ({numEtudiant}.txt) a été bien modifie");
        }

        static void AfficherFile()
        {
            int numeroEtudiant;
            numeroEtudiant = GererException("Numéro d'étudiant: ", "Le Numéro d'étudiant doit être un nombre entier");
            if (IsExiste(numeroEtudiant))
            {
                StreamReader lireFichier = new StreamReader(numeroEtudiant + ".txt");
                Console.WriteLine(lireFichier.ReadToEnd());
                lireFichier.Close();

            }
            else Console.WriteLine("Cet étudiant n'existe pas .");

        }
        static void AfficherFile(int numeroEtudiant)
        {
 
                StreamReader lireFichier = new StreamReader(numeroEtudiant + ".txt");
                Console.WriteLine(lireFichier.ReadToEnd());
                lireFichier.Close();


        }

        static void ProgrameMain()
           {
            int option;
               do
               {
                   Console.WriteLine("");
                   Console.WriteLine("Veuillez choisir une option");
                   Console.WriteLine("");
                   Console.WriteLine(" 0 : Ajouter un Nouveau etudiant");
                   Console.WriteLine(" 1 : Ajouter un Coure dans un etudiant existe deja");
                   Console.WriteLine(" 2 : Afficher les information sur un etudiant");
                   Console.WriteLine(" 3 : Afficher tous les etudiants");
                   Console.WriteLine(" 4 : Fin de programme");
                   Console.WriteLine("");

                   option = GererException("option :", "Le Numéro d'étudiant doit être un nombre entier");

                   switch (option)
                   {
                    case 0:
                        AjouterUnNouvelEtudiant();
                        break;

                    case 1:
                        int numEtudiant = GererException("Le numéro d'etudiant auquel vous souhaitez ajouter une cours :", "Le Numéro d'étudiant doit être un nombre entier");
                        if (IsExiste(numEtudiant))
                            ModifieFile(numEtudiant);
                        else Console.WriteLine("Cet étudiant n'existe pas");
                        break;

                    case 2:
                        AfficherFile();
                        break ;

                    case 3:
                        Console.WriteLine("\nLa liste des Etudiant :\n");
                        if (etudiantListFile.Count > 0)
                            foreach (String numeroEtudiant in etudiantListFile)
                                AfficherFile(Int16.Parse(numeroEtudiant));
                        else Console.WriteLine("list vide !\n");
                        
                        break ;
                    default: Console.WriteLine();break;
                }

               } while (option!=4);
           }

        static void Main(string[] args)
        {
            etudiantListFile = new List<string>();
            ProgrameMain();


        }
    }
}

using System;

public class Joueur
{
    public char Symbole { get; private set; }

    public Joueur(char symbole)
    {
        Symbole = symbole;
    }

    public void JouerTour(Plateau plateau)
    {
        int ligne, colonne;

        while (true)
        {
            Console.WriteLine($"\n|||||||| C'est au tour du joueur {Symbole} ||||||||");

            
            ligne = SaisirEntier($"Joueur {Symbole}, entre la ligne (0-2) : ");
            colonne = SaisirEntier($"Joueur {Symbole}, entre la colonne (0-2) : ");


            bool coupValide = plateau.PlacerCoup(ligne, colonne, Symbole);

            if (coupValide)
            {
                break;
            }
            else
            {
                Console.WriteLine("Mouvement impossible : Case occupée ou hors limites. Réessaie.");
            }
        }
    }

 
    private int SaisirEntier(string message)
    {
        int valeur;
        while (true)
        {
            Console.Write(message);
            string saisie = Console.ReadLine();

            if (int.TryParse(saisie, out valeur))
            {
                if (valeur >= 0 && valeur <= 2)
                {
                    return valeur;
                }
                else
                {
                    Console.WriteLine("Erreur : Le chiffre doit être entre 0 et 2.");
                }
            }
            else
            {
                Console.WriteLine("Erreur : Ceci n'est pas un chiffre valide.");
            }
        }
    }
}
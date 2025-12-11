using System;

public abstract class Joueur
{
    public char Symbole { get; private set; }

    public Joueur(char symbole)
    {
        Symbole = symbole;
    }

    public abstract void JouerTour(Plateau plateau);

    //public void JouerTour(Plateau plateau)
    //{
    //    int ligne, colonne;

    //    while (true)
    //    {
    //        Console.WriteLine($"\n|||||||| C'est au tour du joueur {Symbole} ||||||||");

    //        ligne = SaisirEntier($"Joueur {Symbole}, entre la ligne (1-3) : ");
    //        colonne = SaisirEntier($"Joueur {Symbole}, entre la colonne (1-3) : ");

    //        bool coupValide = plateau.PlacerCoup(ligne - 1, colonne - 1, Symbole);

    //        if (coupValide)
    //        {
    //            break;
    //        }
    //        else
    //        {
    //            Console.WriteLine("Mouvement impossible : Case occupée. Réessaie.");
    //        }
    //    }
    //}

    private int SaisirEntier(string message)
    {
        int valeur;
        while (true)
        {
            Console.Write(message);
            string? saisie = Console.ReadLine(); 

            if (int.TryParse(saisie, out valeur))
            {
                if (valeur >= 1 && valeur <= 3)
                {
                    return valeur;
                }
                else
                {
                    Console.WriteLine("Erreur : Le chiffre doit être entre 1 et 3.");
                }
            }
            else
            {
                Console.WriteLine("Erreur : Ceci n'est pas un chiffre valide.");
            }
        }
    }
}
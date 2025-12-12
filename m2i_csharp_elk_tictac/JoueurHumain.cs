using System;

public class JoueurHumain : Joueur
{
    public JoueurHumain(char symbole) : base(symbole) { }

    public override Task JouerTour(Plateau plateau)
    {
        int ligne, colonne;

        while (true)
        {
            Console.WriteLine($"\n|||||||| C'est au tour du joueur HUMAIN {Symbole} ||||||||");

            ligne = SaisirEntier($"Joueur {Symbole}, entre la ligne (1-3) : ");
            colonne = SaisirEntier($"Joueur {Symbole}, entre la colonne (1-3) : ");

            bool coupValide = plateau.PlacerCoup(ligne - 1, colonne - 1, Symbole);

            if (coupValide) break;
            else Console.WriteLine("Mouvement impossible : Case occupée. Réessaie.");
        }

        return Task.CompletedTask;
    }

    private int SaisirEntier(string message)
    {
        int valeur;
        while (true)
        {
            Console.Write(message);
            string? saisie = Console.ReadLine();

            if (int.TryParse(saisie, out valeur) && valeur >= 1 && valeur <= 3)
                return valeur;

            Console.WriteLine("Erreur : Le chiffre doit être entre 1 et 3.");
        }
    }
}
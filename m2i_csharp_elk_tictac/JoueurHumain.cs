using System;

public class JoueurHumain : Joueur
{
    public JoueurHumain(char symbole) : base(symbole) { }

    public override Task<bool> JouerTour(Plateau plateau)
    {
        while (true)
        {
            Console.WriteLine($"\n|||||||| Tour du joueur HUMAIN {Symbole} (Tapez 'q' pour quitter) ||||||||");

            int? ligne = SaisirEntierOuQuitter($"Joueur {Symbole}, entre la ligne (1-3) ou 'q' : ");
            if (ligne == null) return Task.FromResult(false);

            int? colonne = SaisirEntierOuQuitter($"Joueur {Symbole}, entre la colonne (1-3) ou 'q' : ");
            if (colonne == null) return Task.FromResult(false);

            bool coupValide = plateau.PlacerCoup(ligne.Value - 1, colonne.Value - 1, Symbole);

            if (coupValide) break;
            
            Console.WriteLine("Mouvement impossible : Case occupée. Réessaie.");
        }

        return Task.FromResult(true); // Tour terminé avec succès
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
    
    private int? SaisirEntierOuQuitter(string message)
    {
        while (true)
        {
            Console.Write(message);
            string? saisie = Console.ReadLine()?.Trim().ToLower();

            if (saisie == "q" || saisie == "quitter")
                return null;

            if (int.TryParse(saisie, out int valeur) && valeur >= 1 && valeur <= 3)
                return valeur;

            Console.WriteLine("Erreur : Entrez 1, 2, 3 ou 'q' pour quitter.");
        }
    }
}
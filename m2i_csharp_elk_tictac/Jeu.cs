using System;

public class Jeu
{
    private Plateau _plateau;
    private Joueur _joueur1;
    private Joueur _joueur2;

    public Jeu()
    {
        _plateau = new Plateau();
        _joueur1 = new Joueur('N');
        _joueur2 = new Joueur('O');
    }

    public void LancerPartie()
    {
        char resultat = ' ';
        Joueur joueurActuel = _joueur1;

        Console.WriteLine("TD | Croix rond!");
        _plateau.Afficher_grille();

        while (resultat == ' ')
        {
            joueurActuel.JouerTour(_plateau);

            _plateau.Afficher_grille();

            resultat = _plateau.VerifierFinDePartie();

            if (resultat == ' ')
            {
                if (joueurActuel == _joueur1)
                    joueurActuel = _joueur2;
                else
                    joueurActuel = _joueur1;
            }
        }

        AnnoncerGagnant(resultat);
    }

    private void AnnoncerGagnant(char resultat)
    {
        if (resultat == 'N')
            Console.WriteLine("Match nul !");
        else
            Console.WriteLine($"Bravo ! Le joueur {resultat} a gagné !");
    }
}
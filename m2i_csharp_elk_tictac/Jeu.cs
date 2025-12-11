using System;

public class Jeu
{
    private Plateau _plateau;
    private Joueur _joueur1;
    private Joueur _joueur2;

    public Jeu()
    {
        _plateau = new Plateau();
        _joueur1 = new JoueurHumain('X');
        _joueur2 = new JoueurRobot('O');
    }

    public void LancerPartie()
    {
        char resultat = ' ';
        Joueur joueurActuel = _joueur1;

        Console.Clear();
        Console.WriteLine("TD | Croix rond!");
        _plateau.Afficher_grille();

        while (resultat == ' ')
        {
            joueurActuel.JouerTour(_plateau);

            Console.Clear();
            _plateau.Afficher_grille();

            resultat = _plateau.VerifierFinDePartie();

            if (resultat == ' ')
            {
                joueurActuel = (joueurActuel == _joueur1) ? _joueur2 : _joueur1;
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
using System;

public class Jeu
{
    private Plateau _plateau;
    private Joueur _joueur1;
    private Joueur _joueur2;

    public Jeu(Plateau? plateau = null, Joueur? j1 = null, Joueur? j2 = null)
    {
        _plateau = plateau ?? new Plateau();
    _joueur1 = j1 ?? new JoueurHumain('X');
    _joueur2 = j2 ?? new JoueurRobot('O');
    }

    public async Task LancerPartie()
    {
        char resultat = ' ';
        Joueur joueurActuel = _joueur1;

        try
        {
            Console.Clear();
        }
        catch (IOException)
        {
            
        }
        Console.WriteLine("TD | Croix rond!");
        _plateau.Afficher_grille();

        while (resultat == ' ')
        {
            await joueurActuel.JouerTour(_plateau);

            try
            {
                Console.Clear();
            }
            catch (IOException)
            {
                
            }
            _plateau.Afficher_grille();

            resultat = _plateau.VerifierFinDePartie();

            if (resultat == ' ')
            {
                joueurActuel = (joueurActuel == _joueur1) ? _joueur2 : _joueur1;
            }
        }

        AnnoncerGagnant(resultat);
    }

    public void AnnoncerGagnant(char resultat)
    {
        if (resultat == 'N')
            Console.WriteLine("Match nul !");
        else
            Console.WriteLine($"Bravo ! Le joueur {resultat} a gagné !");
    }


}
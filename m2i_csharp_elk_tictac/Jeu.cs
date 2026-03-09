using System;
using System.Threading.Tasks;

public class Jeu
{
    private Plateau _plateau;
    private Joueur _joueur1;
    private Joueur _joueur2;
    private MorpionDbContext _db;
    private Partie _partieEnBase;

    public Jeu(MorpionDbContext db, Partie partieEnBase)
    {
        _db = db;
        _partieEnBase = partieEnBase;
        
        _plateau = new Plateau();
        _plateau.ImporterGrille(_partieEnBase.Grille);
        
        _joueur1 = new JoueurHumain('X');
        _joueur2 = new JoueurRobot('O');
    }

    public async Task LancerPartie()
    {
        char resultat = ' ';
        // Reprend au bon joueur
        Joueur joueurActuel = _partieEnBase.JoueurActuel == 'X' ? _joueur1 : _joueur2;

        try { Console.Clear(); } catch (IOException) { }
        Console.WriteLine($"TD | Croix rond! (Partie #{_partieEnBase.Id})");
        _plateau.Afficher_grille();

        while (resultat == ' ')
        {
            bool aJoue = await joueurActuel.JouerTour(_plateau);

            if (!aJoue)
            {
                Console.WriteLine("\nPartie mise en pause. Retour au menu principal...");
                await Task.Delay(1500);
                return; 
            }

            try { Console.Clear(); } catch (IOException) { }
            _plateau.Afficher_grille();

            resultat = _plateau.VerifierFinDePartie();

            _partieEnBase.Grille = _plateau.ExporterGrille();
            
            if (resultat == ' ')
            {
                joueurActuel = (joueurActuel == _joueur1) ? _joueur2 : _joueur1;
                _partieEnBase.JoueurActuel = joueurActuel.Symbole;
            }
            else
            {
                if (resultat == 'N') _partieEnBase.Statut = "Nul";
                else if (resultat == 'X') _partieEnBase.Statut = "Humain";
                else _partieEnBase.Statut = "Robot";
            }

            await _db.SaveChangesAsync();
        }

        AnnoncerGagnant(resultat);
        Console.WriteLine("\nAppuyez sur Entrée pour retourner au menu...");
        Console.ReadLine();
    }

    public void AnnoncerGagnant(char resultat)
    {
        if (resultat == 'N')
            Console.WriteLine("Match nul !");
        else
            Console.WriteLine($"Bravo ! Le joueur {resultat} a gagné !");
    }
}
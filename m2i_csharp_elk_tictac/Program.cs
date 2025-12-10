using System;
class Program
{
    private static char[,] plateau = new char[3, 3] {
            {' ', ' ', ' '}, {' ', ' ', ' '}, {' ', ' ', ' '}
        };


    static void Main(string[] args)
    {
        char joueurActuel = 'X';
        char fini = ' ';
        

        System.Console.WriteLine("TD | Croix rond!");
        AfficherPlateau();
        while (fini == ' ')
        {
            SaisirCoup(joueurActuel);
            AfficherPlateau();
            fini = VerifierFinDePartie();

            // changement de joueur
            if (joueurActuel == 'X')
            {
                joueurActuel = 'O';
            }
            else
            {
                joueurActuel = 'X';
            }
        }

        // annonce du résultat
        if (fini == 'N')
        {
            Console.WriteLine("Match nul !");
        }
        else
        {
            Console.WriteLine($"Le joueur {fini} a gagné !");
        }


        // on propose de rejouer
        Console.WriteLine("Si vous souhaitez rejouer appuyez sur o, sinon n'importe quelle autre touche !");
        if (Console.ReadLine().ToLower() == "o")
        {
            // Réinitialiser le plateau
            plateau = new char[3, 3] {
                {' ', ' ', ' '}, {' ', ' ', ' '}, {' ', ' ', ' '}
            };
            Main(args); // Relancer la partie
        }
        else
        {
            Console.WriteLine("Merci d'avoir joué !");
        }
    }


    static void AfficherPlateau()
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("  0   1   2");
        for (int i = 0; i < 3; i++)
        {
            Console.Write(i + " ");
            for (int j = 0; j < 3; j++)
            {
                Console.Write(plateau[i, j]);
                if (j < 2) Console.Write(" | ");
            }
            Console.WriteLine();
            if (i < 2) Console.WriteLine(" ---+---+---");
        }
        Console.WriteLine();
    }

    static void SaisirCoup(char joueur)
    {
        int ligne, colonne;

        while (true)
        {
            Console.Write($"Joueur {joueur}, entre la ligne (0-2) : ");
            ligne = SaisirEntier("Entre la ligne (0-2) : ");
            if (ligne < 0 || ligne > 2)
            {
                Console.WriteLine("Ligne invalide. Choisis une ligne entre 0 et 2.");
                continue;
            }

            Console.Write($"Joueur {joueur}, entre la colonne (0-2) : ");
            colonne = SaisirEntier("Entre la colonne (0-2) : ");
            if (colonne < 0 || colonne > 2)
            {
                Console.WriteLine("Colonne invalide. Choisis une colonne entre 0 et 2.");
                continue;
            }

            // Vérification : case libre
            if (plateau[ligne, colonne] == ' ')
            {
                plateau[ligne, colonne] = joueur;
                break;
            }
            else
            {
                Console.WriteLine("Case déjà occupée. Choisis une autre case.");
            }
        }
    }

    static int SaisirEntier(string message)
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

    static char VerifierFinDePartie()
    {
        // Vérification des lignes
        for (int i = 0; i < 3; i++)
        {
            if (plateau[i, 0] != ' ' &&
                plateau[i, 0] == plateau[i, 1] &&
                plateau[i, 1] == plateau[i, 2])
            {
                return plateau[i, 0]; // X ou O
            }
        }

        // Vérification des colonnes
        for (int j = 0; j < 3; j++)
        {
            if (plateau[0, j] != ' ' &&
                plateau[0, j] == plateau[1, j] &&
                plateau[1, j] == plateau[2, j])
            {
                return plateau[0, j]; // X ou O
            }
        }

        // vérification des diagonales
        if (plateau[1, 1] != ' ')
        {
            // Diagonale 1
            if (plateau[0, 0] == plateau[1, 1] && plateau[1, 1] == plateau[2, 2])
                return plateau[1, 1];

            // Diagonale 2
            if (plateau[0, 2] == plateau[1, 1] && plateau[1, 1] == plateau[2, 0])
                return plateau[1, 1];
        }

        // si le plateau est plein → match nul
        bool plein = true;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (plateau[i, j] == ' ')
                    plein = false;
            }
        }

        if (plein)
            return 'N'; // match nul

        return ' '; // Partie non terminée
    }

}
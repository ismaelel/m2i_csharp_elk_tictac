using System;
class Program
{
    private static char[,] plateau = new char[3, 3] {
            {' ', ' ', ' '}, {' ', ' ', ' '}, {' ', ' ', ' '}
        };


    static void Main(string[] args)
    {
        char joueurActuel = 'X';

        


        System.Console.WriteLine("TD | Croix rond!");

        AfficherPlateau();

        SaisirCoup('X');

        AfficherPlateau();
        SaisirCoup('O');
        AfficherPlateau();

        SaisirCoup('X');

        AfficherPlateau();
        SaisirCoup('O');
        AfficherPlateau();
        SaisirCoup('X');

        AfficherPlateau();
        SaisirCoup('O');
        AfficherPlateau();
        SaisirCoup('X');

        AfficherPlateau();
        SaisirCoup('O');
        AfficherPlateau();
        SaisirCoup('X');

        AfficherPlateau();
    }

    static void AfficherPlateau()
    {
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
            ligne = int.Parse(Console.ReadLine());
            if (ligne < 0 || ligne > 2)
            {
                Console.WriteLine("Ligne invalide. Choisis une ligne entre 0 et 2.");
                continue;
            }

            Console.Write($"Joueur {joueur}, entre la colonne (0-2) : ");
            colonne = int.Parse(Console.ReadLine());
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


    
}
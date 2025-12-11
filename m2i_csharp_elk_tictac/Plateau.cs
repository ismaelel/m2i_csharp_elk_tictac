using System;
using System.Linq;

public class Plateau
{
    private char[,] _grille;
    public const int Taille = 3;

    public Plateau()
    {
        _grille = new char[Taille, Taille];
        Initialiser();
    }

    public void Initialiser()
    {
        for (int i = 0; i < Taille; i++)
            for (int j = 0; j < Taille; j++)
                _grille[i, j] = ' ';
    }

    public void Afficher_grille()
    {
        Console.WriteLine();
        Console.WriteLine("  1   2   3");
        for (int i = 0; i < Taille; i++)
        {
            Console.Write((i + 1) + " ");
            for (int j = 0; j < Taille; j++)
            {
                Console.Write(_grille[i, j]);
                if (j < Taille - 1) Console.Write(" | ");
            }
            Console.WriteLine();
            if (i < Taille - 1) Console.WriteLine(" ---+---+---");
        }
        Console.WriteLine();
    }

    public char VerifierFinDePartie()
    {
        char winner = Enumerable.Range(0, 3)
            .SelectMany(i => new[]
            {
                _grille[i, 0] == _grille[i, 1] && _grille[i, 1] == _grille[i, 2] ? _grille[i, 0] : ' ',
                _grille[0, i] == _grille[1, i] && _grille[1, i] == _grille[2, i] ? _grille[0, i] : ' '
            })
            .Append(_grille[0, 0] == _grille[1, 1] && _grille[1, 1] == _grille[2, 2] ? _grille[1, 1] : ' ')
            .Append(_grille[0, 2] == _grille[1, 1] && _grille[1, 1] == _grille[2, 0] ? _grille[1, 1] : ' ')
            .FirstOrDefault(c => c != ' ');

        if (winner != '\0' && winner != ' ') return winner;

        return _grille.Cast<char>().Any(c => c == ' ') ? ' ' : 'N';
    }

    public bool PlacerCoup(int ligne, int colonne, char symboleJoueur)
    {
        if (ligne < 0 || ligne >= Taille || colonne < 0 || colonne >= Taille)
        {
            return false;
        }

        if (_grille[ligne, colonne] != ' ')
        {
            return false;
        }

        _grille[ligne, colonne] = symboleJoueur;
        return true;
    }
}
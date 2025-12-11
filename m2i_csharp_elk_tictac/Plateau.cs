using System;
using System.Collections.Generic;
using System.Text;

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
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("  0   1   2");
        for (int i = 0; i < Taille; i++)
        {
            Console.Write(i + " ");
            for (int j = 0; j < Taille; j++)
            {
                Console.Write(_grille[i, j]);
                if (j < Taille-1) Console.Write(" | ");
            }
            Console.WriteLine();
            if (i < Taille-1) Console.WriteLine(" ---+---+---");
        }
        Console.WriteLine();
    }

    

    public char VerifierFinDePartie()
    {
        // Vérification des lignes
        for (int i = 0; i < 3; i++)
        {
            if ( _grille[i, 0] != ' ' &&
                _grille[i, 0] == _grille[i, 1] &&
                _grille[i, 1] == _grille[i, 2])
            {
                return _grille[i, 0]; // X ou O
            }
        }

        // Vérification des colonnes
        for (int j = 0; j < 3; j++)
        {
            if (_grille[0, j] != ' ' &&
                _grille[0, j] == _grille[1, j] &&
                _grille[1, j] == _grille[2, j])
            {
                return _grille[0, j]; // X ou O
            }
        }

        // vérification des diagonales
        if (_grille[1, 1] != ' ')
        {
            // Diagonale 1
            if (_grille[0, 0] == _grille[1, 1] && _grille[1, 1] == _grille[2, 2])
                return _grille[1, 1];

            // Diagonale 2
            if (_grille[0, 2] == _grille[1, 1] && _grille[1, 1] == _grille[2, 0])
                return _grille[1, 1];
        }

        // si le _grille est plein → match nul
        bool plein = true;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (_grille[i, j] == ' ')
                    plein = false;
            }
        }

        if (plein)
            return 'N';

        return ' '; // Partie non terminée
    }

    public bool PlacerCoup(int ligne, int colonne, char symboleJoueur)
    {
        if (ligne < 0 || ligne >= Taille || colonne < 0 || colonne >= Taille)
        {
            return false;
        }

        if (_grille[ligne, colonne] != ' ')
        {
            return false; //la case est prise
        }

        _grille[ligne, colonne] = symboleJoueur;
        return true;
    }

}
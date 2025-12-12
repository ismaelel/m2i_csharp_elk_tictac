using System;

public abstract class Joueur
{
    public char Symbole { get; private set; }

    public Joueur(char symbole)
    {
        Symbole = symbole;
    }

    public abstract Task JouerTour(Plateau plateau);

  
}
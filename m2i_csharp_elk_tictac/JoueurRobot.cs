using System;
using System.Threading; 

public class JoueurRobot : Joueur
{
    private Random _random;

    public JoueurRobot(char symbole) : base(symbole)
    {
        _random = new Random();
    }

    public override void JouerTour(Plateau plateau)
    {
        Console.WriteLine($"\n|||||||| Le Robot {Symbole} réfléchit... ||||||||");
        Thread.Sleep(1000); 

        bool coupValide = false;
        while (!coupValide)
        {
          
            int ligne = _random.Next(0, 3);
            int colonne = _random.Next(0, 3);

            coupValide = plateau.PlacerCoup(ligne, colonne, Symbole);
        }
        Console.WriteLine("Le Robot a joué !");
    }
}
using System;
class Program
{

    static async Task Main(string[] args)
    {
        bool continuer = true;

        while (continuer)
        {

            Jeu partie = new Jeu();

            await partie.LancerPartie();

            Console.WriteLine("Rejouer ? (o/n)");
            if (Console.ReadLine() != "o")
            {
                continuer = false;
                Console.WriteLine("Au revoir !");
            }
        }
    }

}
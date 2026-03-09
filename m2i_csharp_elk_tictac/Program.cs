using System;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        using var db = new MorpionDbContext();
       // await db.Database.EnsureCreatedAsync(); 

        bool continuer = true;
        while (continuer)
        {
            Console.Clear();
            Console.WriteLine("=== MENU MORPION ===");
            Console.WriteLine("1. Nouvelle partie");
            Console.WriteLine("2. Reprendre une partie en cours");
            Console.WriteLine("3. Afficher les statistiques");
            Console.WriteLine("4. Quitter");
            Console.Write("Choix : ");
            
            switch (Console.ReadLine())
            {
                case "1":
                    var nouvellePartie = new Partie();
                    db.Parties.Add(nouvellePartie);
                    await db.SaveChangesAsync();
                    await new Jeu(db, nouvellePartie).LancerPartie();
                    break;
                case "2":
                    var partieEnCours = db.Parties
                        .Where(p => p.Statut == "EnCours")
                        .OrderByDescending(p => p.Id)
                        .FirstOrDefault();

                    if (partieEnCours != null) await new Jeu(db, partieEnCours).LancerPartie();
                    else
                    {
                        Console.WriteLine("Aucune partie en cours !");
                        Console.ReadLine();
                    }
                    break;
                case "3":
                    AfficherStats(db);
                    break;
                case "4":
                    continuer = false;
                    break;
            }
        }
    }

    static void AfficherStats(MorpionDbContext db)
    {
        Console.Clear();
        int total = db.Parties.Count(p => p.Statut != "EnCours");
        int victoiresHumain = db.Parties.Count(p => p.Statut == "Humain");
        int victoiresBot = db.Parties.Count(p => p.Statut == "Robot");
        int matchsNuls = db.Parties.Count(p => p.Statut == "Nul");

        Console.WriteLine($"Parties terminées : {total}");
        if (total > 0)
        {
            Console.WriteLine($"Victoires Humain : {victoiresHumain} ({(double)victoiresHumain/total*100:0.0}%)");
            Console.WriteLine($"Victoires Robot  : {victoiresBot} ({(double)victoiresBot/total*100:0.0}%)");
            Console.WriteLine($"Matchs Nuls      : {matchsNuls} ({(double)matchsNuls / total * 100:0.0}%)\n");
        }
        Console.WriteLine("\nAppuyez sur une touche...");
        Console.ReadKey();
    }
}
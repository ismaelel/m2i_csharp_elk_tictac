using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


public class Partie
{
    [Key]
    public int Id { get; set; }
    
    public string Grille { get; set; } = "         "; 
    
    public char JoueurActuel { get; set; } = 'X';
    
    public string Statut { get; set; } = "EnCours"; 
}

public class MorpionDbContext : DbContext
{
    public DbSet<Partie> Parties { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Database=tictactoe;Username=postgres;Password=postgres");
    }
}
namespace TestProject
{
    public class JeuTest
    {
        [Fact]
        public void Scenario_PartieNulle_GrillePleine()
        {
            // Arrange
            Plateau plateau = new Plateau();

            // Act

            //// Ligne 1 : X O X
            plateau.PlacerCoup(0, 0, 'X');
            plateau.PlacerCoup(0, 1, 'O');
            plateau.PlacerCoup(0, 2, 'X');

            //// Ligne 2 : X X O
            plateau.PlacerCoup(1, 0, 'X');
            plateau.PlacerCoup(1, 1, 'X');
            plateau.PlacerCoup(1, 2, 'O');

            //// Ligne 3 : O X O
            plateau.PlacerCoup(2, 0, 'O');
            plateau.PlacerCoup(2, 1, 'X');
            plateau.PlacerCoup(2, 2, 'O');

            char resultat = plateau.VerifierFinDePartie();

            // Assert
            Assert.Equal('N', resultat); // N = match nul
        }
    }
}
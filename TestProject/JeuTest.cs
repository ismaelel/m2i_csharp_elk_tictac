using Xunit;
using Moq;

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

       

        [Fact]
        public void LancerPartie_AvecMocks_LeJeuSarreteSiVictoire()
        {
            //arrange
            var mockPlateau = new Mock<Plateau>();
            mockPlateau.SetupSequence(p => p.VerifierFinDePartie())
                       .Returns(' ')  
                       .Returns('X'); 

            var mockJ1 = new Mock<Joueur>('X');
            var mockJ2 = new Mock<Joueur>('O');

            var jeu = new Jeu(mockPlateau.Object, mockJ1.Object, mockJ2.Object);

            // act
            jeu.LancerPartie();

            // assert
            mockJ1.Verify(j => j.JouerTour(It.IsAny<Plateau>()), Times.Once);
            mockJ2.Verify(j => j.JouerTour(It.IsAny<Plateau>()), Times.Once);

        }

        [Fact]
        public void AnnoncerGagnant_SiVictoireX_AfficheMessageBravo()
        {
            // Arrange
            var jeu = new Jeu(new Plateau(), new JoueurHumain('X'), new JoueurRobot('O'));
            var output = new StringWriter();
            Console.SetOut(output); 

            // Act
            jeu.AnnoncerGagnant('X');

            // Assert
            var resultatTexte = output.ToString();
            Assert.Contains("Bravo", resultatTexte);
            Assert.Contains("X", resultatTexte);
        }

    }


}
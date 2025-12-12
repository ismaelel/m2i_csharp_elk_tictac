namespace TestProject
{
    public class PlateauTest
    {
        [Fact]
        public void PlacerCoup_CaseVide_True()
        {
            // Arrange
            Plateau plateau = new Plateau();
            int ligne = 0;
            int colonne = 0;
            char joueur = 'X';

            // Act
            bool coupReussi = plateau.PlacerCoup(ligne, colonne, joueur);

            // Assert
            Assert.True(coupReussi);

        }

        [Fact]
        public void PlacerCoup_CasePrise_False()
        {
            // Arrange
            Plateau plateau = new Plateau();
            plateau.PlacerCoup(0, 0, 'X');

            // Act
            bool coupReussi = plateau.PlacerCoup(0, 0, '0');

            // Assert
            Assert.False(coupReussi);

        }

        [Fact]
        public void VerifierFinDePartie_VictoireLigne_RetourneGagnant()
        {
            // Arrange
            var plateau = new Plateau();
            plateau.PlacerCoup(0, 0, 'X');
            plateau.PlacerCoup(0, 1, 'X');
            plateau.PlacerCoup(0, 2, 'X'); 

            // Act
            char resultat = plateau.VerifierFinDePartie();

            // Assert
            Assert.Equal('X', resultat);
        }

        [Fact]
        public void VerifierFinDePartie_VictoireDiagonale_RetourneGagnant()
        {
            // Arrange
            var plateau = new Plateau();
            plateau.PlacerCoup(0, 0, 'O');
            plateau.PlacerCoup(1, 1, 'O');
            plateau.PlacerCoup(2, 2, 'O');

            // Act
            char resultat = plateau.VerifierFinDePartie();

            // Assert
            Assert.Equal('O', resultat);
        }

        [Fact]
        public void PlacerCoup_CoordonneesHorsLimites_False()
        {
            // Arrange
            var plateau = new Plateau();

            // Act & Assert
            Assert.False(plateau.PlacerCoup(-1, 0, 'X')); 
            Assert.False(plateau.PlacerCoup(0, 3, 'X')); 
            Assert.False(plateau.PlacerCoup(10, 10, 'X'));
        }

        [Fact]
        public void VerifierFinDePartie_VictoireColonne_RetourneGagnant()
        {
            // Arrange
            var plateau = new Plateau();

            plateau.PlacerCoup(0, 1, 'O');
            plateau.PlacerCoup(1, 1, 'O');
            plateau.PlacerCoup(2, 1, 'O');

            // Act
            char resultat = plateau.VerifierFinDePartie();

            // Assert
            Assert.Equal('O', resultat);
        }

    }
}

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

    }
}

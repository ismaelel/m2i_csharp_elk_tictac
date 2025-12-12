using Xunit;

namespace TestProject
{
    public class JoueurTest
    {
        [Fact]
        public void JouerTour_AvecInputInvalidePuisValide_DevraitPlacerLeCoup()
        {
            // arrange
            var plateau = new Plateau();
            var joueur = new JoueurHumain('X');

            var inputSimule = new StringReader("a\n9\n1\n1");
            Console.SetIn(inputSimule);
            // act
            joueur.JouerTour(plateau);

            // assert
            bool estLibre = plateau.PlacerCoup(0, 0, 'O');

            Assert.False(estLibre);
        }

        [Fact]
        public void JoueurRobot_PlateauPresquePlein_DevraitTrouverDerniereCase()
        {
            // arrange
            var plateau = new Plateau();
            var robot = new JoueurRobot('O');

            
            plateau.PlacerCoup(0, 0, 'X'); plateau.PlacerCoup(0, 1, 'X'); plateau.PlacerCoup(0, 2, 'X');
            plateau.PlacerCoup(1, 0, 'X'); plateau.PlacerCoup(1, 1, 'X'); plateau.PlacerCoup(1, 2, 'X');
            plateau.PlacerCoup(2, 0, 'X'); plateau.PlacerCoup(2, 1, 'X'); // 2,2 libre
            

            // act
            robot.JouerTour(plateau);

            // assert
            bool estLibre = plateau.PlacerCoup(2, 2, 'X');
            Assert.False(estLibre);
        }

       

    }
}

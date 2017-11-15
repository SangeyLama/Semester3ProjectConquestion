using DataLayer.DataLayer.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Tests
{

    [TestFixture]
    public class GameControllerTests
    {
        GameController ctr = new GameController();
        DataLayer.ConquestionDBContext db = new DataLayer.ConquestionDBContext();

        [Test]
        public void AddAPlayerToAGame()
        {
            //Arrange
            Game game = new Game { Id = 1, Name = "Test Game", Players = new List<Player>() };
            Player player = new Player{ Id = 1, Name = "TestPlayer", Games = new List<Game>()};

            //Act
            ctr.AddPlayer(game, player);

            //Assert
            Assert.Contains(player, game.Players);  
        }

        [Test]
        public void AddPlayerToGameAndSaveToDatabase()
        {
            //Arrange
            Game game = new Game { Id = 1, Name = "Test Game1", Players = new List<Player>() };
            Player player = new Player { Id = 1, Name = "TestPlayer1", Games = new List<Game>() };
            db.Players.Add(player);
            db.Games.Add(game);
            db.SaveChanges();

            //Act
            ctr.AddPlayer(game, player);

            //Assert
            Assert.Contains(player, game.Players);
            db.Players.Remove(player);
            db.Games.Remove(game);
            db.SaveChanges();
        }

        [Test]
        public void ChooseGame()
        {
           //Arrange
            Game chosenGame = new Game();

            //Act
            chosenGame = ctr.ChooseGame("Mimi's game");
            
            //Assert
            Assert.AreEqual(4, chosenGame.Id);
        }

        [Test]
        public void ActiveGames()
        {
            //Arrange
            List<Game> activeGame = new List<Game>();

            //Act
            activeGame = ctr.ActiveGames();

            //Assert
            Assert.AreEqual(2, activeGame.Count);
        }
    }
}

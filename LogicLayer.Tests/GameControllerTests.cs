using DataLayer;
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
        ConquestionDBContext db = new ConquestionDBContext();

        [Test]
        public void AddAPlayerToAGame()
        {
            //Arrange
            Game game = new Game { Id = 4, Name = "TestGame", Players = new List<Player>() };
            //var game = db.Games.Where(g => g.Name.Equals("TestGame")).FirstOrDefault();
            Player player = new Player{ Id = 1, Name = "TestPlayer", Games = new List<Game>()};

            //Act
            ctr.AddPlayer(game, player);

            //Assert
            var dbGame = db.Games.Include("Players").Where(g => g.Id == 4).FirstOrDefault();
            var dbPlayer = db.Players.Where(p => p.Id == 1).FirstOrDefault();
            Assert.Contains(dbPlayer, dbGame.Players);  
        }

        [Test]
        public void AddPlayerToNullGame_ShouldThrowException()
        {
            //Arrange
            Game game = new Game { Id = 4, Name = "FailTest", Players = new List<Player>() }; ;
            Player player = new Player { Id = 1, Name = "TestPlayer", Games = new List<Game>() };

            //Act
            //ctr.AddPlayer(game, player);

            //Assert
            Assert.Throws<Exception>(() => ctr.AddPlayer(game, player));
        }


        [Test]
        public void ChooseGame()
        {
           //Arrange
            Game chosenGame = new Game();

            //Act
            chosenGame = ctr.ChooseGame("Test");
            
            //Assert
            Assert.AreEqual(1, chosenGame.Id);
        }

        [Test]
        public void ChooseGame_NullGame()
        {
            //Arrange
            Game chosenGame = new Game();

            //Act
            chosenGame = ctr.ChooseGame("FailTest");

            //Assert
            Assert.Null(chosenGame);
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

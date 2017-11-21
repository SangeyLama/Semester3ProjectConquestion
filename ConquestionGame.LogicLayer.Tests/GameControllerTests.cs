using ConquestionGame.DataAccessLayer;
using ConquestionGame.Domain;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConquestionGame.LogicLayer.Tests
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
            Game game = new Game { Id = 1, Name = "TestGame", Players = new List<Player>() };
            //var game = db.Games.Where(g => g.Name.Equals("TestGame")).FirstOrDefault();
            Player player = new Player { Id = 1, Name = "TestPlayer", Games = new List<Game>() };

            //Act
            ctr.AddPlayer(game, player);

            //Assert
            var dbGame = db.Games.Include("Players").Where(g => g.Id == 1).FirstOrDefault();
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
            chosenGame = ctr.ChooseGame("TestGame", false);

            //Assert
            Assert.AreEqual(1, chosenGame.Id);
        }

        [Test]
        public void ChooseGame_NullGame()
        {
            //Arrange
            Game chosenGame = new Game();

            //Act
            chosenGame = ctr.ChooseGame("FailTest", false);

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
            Assert.AreEqual(1, activeGame.Count);
        }

        [Test]
        public void createGame_NameIsUniqueToActiveList()
        {
            //Arrange 
            Game game = new Game { Name = "TestGame2" };

            //Act
            ctr.CreateGame(game);

            //Assert
            var gameEntity = db.Games.Where(g => g.Name.Equals(game.Name)).FirstOrDefault();
            Assert.AreEqual(game.Name, gameEntity.Name);
            db.Games.Remove(gameEntity);
            db.SaveChanges();
        }

        [Test]
        public void createGame_NameIsNotUniqueToActiveList()
        {
            //Arrange
            Game game = new Game { Name = "TestGame" };
            string msg = "";

            //Act
            try
            {
                ctr.CreateGame(game);
                Assert.Fail();
            }
            catch(Exception e)
            {
                msg = e.Message;
            }

            //Assert
            Assert.Throws<Exception>(() => ctr.CreateGame(game));
            Assert.AreEqual("Game name is already taken, please select an unique name.", msg);
        }

        [Test]
        public void JoinGame_SuccessfulJoin()
        {
            Game game = new Game { Id = 1, Name = "TestGame" };
            Player player = new Player { Id = 4, Name = "TestPlayer4" };
            ctr.LeaveGame(game, new Player { Id = 5 });
            bool success = ctr.JoinGame(game, player);
            Assert.IsTrue(success);
        }

        //[Test]
        //public void NotARealTest()
        //{
        //    QuestionSet qs = db.InitializeData();
        //    db.QuestionSets.Add(qs);
        //    db.SaveChanges();
        //}
    }
}


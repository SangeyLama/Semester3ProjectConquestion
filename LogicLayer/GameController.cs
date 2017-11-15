using DataLayer;
using DataLayer.DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class GameController
    {
        ConquestionDBContext db = new ConquestionDBContext();

        public Game CreateGame(Game game)
        {
            db.Games.Add(game);
            db.SaveChanges();
            return game;

        }

        public void AddPlayer(Game game, Player player)
        {
            game.Players = new List<Player>();
            game.Players.Add(player);
            if (game != null)
            {
                if (game.Players == null)
                    game.Players = new List<Player>();
                if (!game.Players.Contains(player))
                {
                    game.Players.Add(player);
                    db.Entry(game).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }


            }

        }

        public Game ChooseGame(string name)
        {
            Game chosenGame = new Game();

            chosenGame = db.Games
                .Where(x => x.Name == name)
                .FirstOrDefault();

            return chosenGame;
        }

        public List<Game> ActiveGames()
        {
            List<Game> activeGames = new List<Game>();

            activeGames = db.Games.ToList();

            return activeGames;
        }

        

    }
}

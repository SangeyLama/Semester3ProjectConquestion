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
            var gameEntity = db.Games.Where(g => g.Name == game.Name) .FirstOrDefault();
            db.Entry(gameEntity).Collection(g => g.Players).Load();
            if (gameEntity != null)
            {
                if (gameEntity.Players == null)
                    gameEntity.Players = new List<Player>();
                var playerEntity = db.Players.Where(p => p.Name == player.Name).FirstOrDefault();
                if (!gameEntity.Players.Contains(playerEntity))
                {
                    gameEntity.Players.Add(playerEntity);
                    db.Entry(gameEntity).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }


            }

        }

    }
}

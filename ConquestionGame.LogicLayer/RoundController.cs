using ConquestionGame.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConquestionGame.Domain;

namespace ConquestionGame.LogicLayer
{
    public class RoundController
    {
        ConquestionDBContext db = new ConquestionDBContext();

        public bool CheckPlayerAnswers(Game game, RoundAction roundAction)
        {
            bool ready = false;

            var gameEntity = db.Games.Include("Players").Where(g => g.Name.Equals(game.Name)).FirstOrDefault();

            var roundActionEntity = db.RoundActions.Include("PlayerAnswers").Where(p => p.Id==(roundAction.Id)).FirstOrDefault();

            while (gameEntity.Players.Count != roundActionEntity.PlayerAnswers.Count)
            {
                Console.WriteLine("waiting");
            }
            ready = true;
            return ready;
        } 
    }
}

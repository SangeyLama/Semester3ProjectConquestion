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

            var roundActionEntity = db.RoundActions.Include("PlayerAnswers").Where(p => p.Id == (roundAction.Id)).FirstOrDefault();

            while (gameEntity.Players.Count != roundActionEntity.PlayerAnswers.Count)
            {
                Console.WriteLine("waiting");
            }
            ready = true;
            return ready;
        }

        public void CreateStartingRound(Game game)
        {
            var gameEntity = db.Games.Include("Players").Include("QuestionSet.Questions.Answers").Include("Map").Include("Rounds.RoundActions.Question.Answers")
                .Where(x => x.Name.Equals(game.Name))
                .FirstOrDefault();
            Round starting = new Round { RoundType = Round.RoundTypeEnum.starting };
            if (gameEntity.Rounds == null)
            {
                gameEntity.Rounds = new List<Round>();
            }
            CreateFirstRoundAction(game.QuestionSet, starting);
            gameEntity.Rounds.Add(starting);
            db.SaveChanges();
        }

        public Round GetRound(Game game, Round.RoundTypeEnum roundType)
        {
            Round roundEntity = game.Rounds.Where(r => r.RoundType == roundType).FirstOrDefault();
            return roundEntity;
        }

        public void CreateFirstRoundAction(QuestionSet questionSet, Round round)
        {
            Question question = questionSet.Questions[0];
            RoundAction firstRoundAction = new RoundAction
            {
                QuestionStartTime = DateTime.Now,
                MapStartTime = DateTime.Now,
                Question = question
            };
            if (round.RoundActions == null)
            {
                round.RoundActions = new List<RoundAction>();
            }
            round.RoundActions.Add(firstRoundAction);
        }
    }
}

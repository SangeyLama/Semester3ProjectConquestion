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
            // Should be ok
            var gameEntity = db.Games.Include("Players").Include("QuestionSet.Questions.Answers").Include("Map").Include("Rounds.RoundActions.Question.Answers")
                .Where(x => x.Name.Equals(game.Name))
                .FirstOrDefault();

            //Check if rounds list has been initialised
            if (gameEntity.Rounds == null)
            {
                gameEntity.Rounds = new List<Round>();
            }
            //Check if starting round already exists, if not create one
            var startingRound = gameEntity.Rounds.Where(r => r.RoundType.Equals(Round.RoundTypeEnum.starting)).FirstOrDefault();
            if (startingRound == null)
            {
                startingRound = new Round { RoundType = Round.RoundTypeEnum.starting, RoundActions = new List<RoundAction>() };
                gameEntity.Rounds.Add(startingRound);

            }

            //Create firstRoundAction for starting round
            RoundAction firstRoundAction = new RoundAction
            {
                QuestionStartTime = DateTime.Now,
                MapStartTime = DateTime.Now,
                Question = gameEntity.QuestionSet.Questions[0]
            };
            startingRound.RoundActions.Add(firstRoundAction);

            db.Entry(gameEntity).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public Round GetRound(Game game, Round.RoundTypeEnum roundType)
        {
            Round roundEntity = game.Rounds.Where(r => r.RoundType.Equals(roundType)).FirstOrDefault();
            return roundEntity;
        }

        //WE shouldnt need this anymore
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

        public void SubmitAnswer(RoundAction roundAction, PlayerAnswer playerAnswer)
        {
            //This is important to compare to the question start time to see if the player answered in time.
            playerAnswer.PlayerAnswerTime = DateTime.Now;
            db.Players.Attach(playerAnswer.Player);
            db.Answers.Attach(playerAnswer.AnswerGiven);
            RoundAction raEntity = db.RoundActions.Where(ra => ra.Id == roundAction.Id).FirstOrDefault();

            // Check is the list has been initialised, if not intialise it
            if(raEntity.PlayerAnswers == null)
            {
                raEntity.PlayerAnswers = new List<PlayerAnswer>();
            }

            //Checking if the player answers in time and that they haven't already submitted an answer
            int elapsedSeconds = (int)(playerAnswer.PlayerAnswerTime - raEntity.QuestionStartTime).TotalSeconds;
            bool playerHasntAnswered = true;
            if(raEntity.PlayerAnswers.Where(pa=> pa.Player.Id == playerAnswer.Player.Id).FirstOrDefault() != null)
            {
                playerHasntAnswered = false;
            }

            //Saves the player's answer to the database  
            if (elapsedSeconds <= 35 && playerHasntAnswered)
            {
                raEntity.PlayerAnswers.Add(playerAnswer);
                db.Entry(raEntity).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

        }

        public bool ValidateAnswer(Answer answer)
        {
            var answerEntity = db.Answers.Where(a => a.Id == answer.Id).FirstOrDefault();
            if (answerEntity.IsValid)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //To see if everyone has answered in this round
        public bool CheckIfAllPlayersAnswered(Game game, RoundAction roundAction)
        {
            bool allPlayersAnswered = false;
            int noOfPlayers = game.Players.Count;
            var raEntity = db.RoundActions.Include("PlayerAnswers").Where(ra => ra.Id == roundAction.Id).FirstOrDefault();
            int? noOfAnswers = raEntity.PlayerAnswers?.Count;
            if(noOfPlayers == noOfAnswers)
            {
                allPlayersAnswered = true;
            }
            return allPlayersAnswered;
        }

        public List<Player> GetPlayerOrder(RoundAction roundAction)
        {
            //int[] order = new int[4];
            //var raEntity = db.RoundActions.Include("PlayerAnswers.Player").Where(r => r.Id == roundAction.Id).FirstOrDefault();
            //List<PlayerAnswer> validAnswer = raEntity.PlayerAnswers;
            //validAnswer.OrderBy(pa => pa.PlayerAnswerTime.Ticks).ToList();
            //int i = 0;
            //foreach(PlayerAnswer pa in validAnswer)
            //{
            //    order[i] = pa.Player.Id;
            //    i++;
            //}

            //return order;

            List<Player> playerOrder = new List<Player>();
            var raEntity = db.RoundActions.Include("PlayerAnswers.Player").Where(r => r.Id == roundAction.Id).FirstOrDefault();
            List<PlayerAnswer> validAnswer = raEntity.PlayerAnswers;
            validAnswer.OrderBy(pa => pa.PlayerAnswerTime.Ticks).ToList();
            foreach (PlayerAnswer pa in validAnswer)
            {
                playerOrder.Add(pa.Player);
            }

            return playerOrder;


            //foreach(PlayerAnswer pa in roundAction.PlayerAnswers)
            //{
            //    if(pa.AnswerGiven.IsValid == true)
            //    {
            //        validAnswer.Add(pa);
            //    }
            //}



            //int index = 0;
            //while(validAnswer != null)
            //{
            //    PlayerAnswer fastestPlayer = null;
            //    foreach (PlayerAnswer pa in validAnswer)
            //    {

            //        if (fastestPlayer != null)
            //        {
            //            if (pa.PlayerAnswerTime.Ticks < fastestPlayer.PlayerAnswerTime.Ticks)
            //            {
            //                fastestPlayer = pa;
            //            }
            //        }
            //        pa.Player = fastestPlayer.Player;
            //    }
            //    order[index] = fastestPlayer.Player.Id;
            //}



        }
    }
}

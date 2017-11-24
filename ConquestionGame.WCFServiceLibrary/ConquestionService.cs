using ConquestionGame.Domain;
using ConquestionGame.LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConquestionGame.WCFServiceLibrary
{
    public class ConquestionService : IConquestionService
    {
        PlayerController playerCtr = new PlayerController();
        GameController gameCtr = new GameController();
        QuestionSetController quesCtr = new QuestionSetController();
        MapController mapCtr = new MapController();
        RoundController roundCtr = new RoundController();
        public Player CreatePlayer(Player player)
        {
            return playerCtr.CreatePlayer(player);
        }

        public void CreateGame(Game game)
        {
            gameCtr.CreateGame(game);
        }

        public void AddPlayer(Game game, Player player)
        {
            gameCtr.AddPlayer(game, player);
        }

        public List<Game> ActiveGames()
        {
            return gameCtr.ActiveGames();
        }

        public Game ChooseGame(string name, bool retrieveAssociation)
        {
            return gameCtr.ChooseGame(name, retrieveAssociation);
        }

        public List<QuestionSet> RetrieveAllQuestionSets()
        {
            return quesCtr.RetrieveAllQuestionSets();
        }

        public List<Map> RetrieveAllMaps()
        {
            return mapCtr.RetrieveAllMaps();
        }

        public Question AskQuestion()
        {
            return quesCtr.AskQuestion();
        }

        public bool ValidateAnswer(Answer answer)
        {
            return roundCtr.ValidateAnswer(answer);
        }

        public bool CheckPlayerAnswers(Game game, RoundAction roundAction)
        {
            return roundCtr.CheckPlayerAnswers(game, roundAction);
        }

        public Map ChooseMap(string name)
        {
            return mapCtr.ChooseMap(name);
        }

        public QuestionSet RetrieveQuestionSet(int id)
        {
            return quesCtr.RetrieveQuestionSet(id);
        }

        public void AddMap(Game game, Map map)
        {

            gameCtr.AddMap(game, map);
        }

        public void AddQuestionSet(Game game, QuestionSet questionSet)
        {
            gameCtr.AddQuestionSet(game, questionSet);
        }

        public QuestionSet RetrieveQuestionSetByTitle(string title)
        {
            return quesCtr.RetrieveQuestionSetByTitle(title);
        }

        public Player RetrievePlayer(string name)
        {
            return playerCtr.RetrievePlayer(name);
        }

        public bool JoinGame(Game game, Player player)
        {
            return gameCtr.JoinGame(game, player);
        }

        public bool LeaveGame(Game game, Player player)
        {
            return gameCtr.LeaveGame(game, player);
        }

        public bool StartGame(Game game, Player player)
        {
            return gameCtr.StartGame(game, player);
        }

        public void SubmitAnswer(RoundAction roundAction, PlayerAnswer playerAnswer)
        {
            roundCtr.SubmitAnswer(roundAction, playerAnswer);
        }

        public bool CheckIfAllPlayersAnswered(Game game, RoundAction roundAction)
        {
            return roundCtr.CheckIfAllPlayersAnswered(game, roundAction);
        }

        public List<Player> GetPlayerOrder(RoundAction roundAction)
        {
            return roundCtr.GetPlayerOrder(roundAction);
        }

        //public Round GetRound(Game game, string roundType)
        //{
        //    Round.RoundTypeEnum type;
        //    if (roundType.Equals("starting"))
        //    {
        //        type = Round.RoundTypeEnum.starting;
        //    }
        //    else if (roundType.Equals("expansion"))
        //    {
        //        type = Round.RoundTypeEnum.expansion;
        //    }
        //    else if (roundType.Equals("conquest"))
        //    {
        //        type = Round.RoundTypeEnum.conquest;
        //    }
        //    else
        //    {
        //        throw new Exception();
        //    }
        //    return roundCtr.GetRound(game, type);
        //}
    }
}

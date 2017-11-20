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
        RoundController rndActCtr = new RoundController();
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

        public Game ChoseGame(string name)
        {
            return gameCtr.ChooseGame(name);
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

        public bool ValidateAnswer(int userAnswer)
        {
            return quesCtr.ValidateAnswer(userAnswer);
        }

        public bool CheckPlayerAnswers(Game game, RoundAction roundAction)
        {
            return rndActCtr.CheckPlayerAnswers(game, roundAction);
        }
    }
}

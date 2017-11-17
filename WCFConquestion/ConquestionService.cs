using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DataLayer.DataLayer.Model;

using LogicLayer;

namespace WCFConquestion
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class ConquestionService : IConquestionService
    {
        PlayerController playerCtr = new PlayerController();
        GameController gameCtr = new GameController();
        QuestionSetController quesCtr = new QuestionSetController();
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
    }
}

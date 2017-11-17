using DataLayer.DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFConquestion
{
    [ServiceContract]
    public interface IConquestionService
    {
        [OperationContract]
        Player CreatePlayer(Player player);
        [OperationContract]
        void CreateGame(Game game);
        [OperationContract]
        void AddPlayer(Game game, Player player);
        [OperationContract]
        List<Game> ActiveGames();
        [OperationContract]
        Game ChoseGame(string name);
        [OperationContract]
        List<QuestionSet> RetrieveAllQuestionSets();
        [OperationContract]
        List<Map> RetrieveAllMaps();
    }
}

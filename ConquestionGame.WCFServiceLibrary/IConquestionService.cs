using ConquestionGame.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ConquestionGame.WCFServiceLibrary
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
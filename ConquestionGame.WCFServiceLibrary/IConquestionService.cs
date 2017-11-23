﻿using ConquestionGame.Domain;
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
        Game ChooseGame(string name, bool retrieveAssociation);
        [OperationContract]
        List<QuestionSet> RetrieveAllQuestionSets();
        [OperationContract]
        List<Map> RetrieveAllMaps();
        [OperationContract]
        Question AskQuestion();
        [OperationContract]
        bool ValidateAnswer(Answer answer);
        [OperationContract]
        bool CheckPlayerAnswers(Game game, RoundAction roundAction);
        [OperationContract]
        Map ChooseMap(string name);
        [OperationContract]
        QuestionSet RetrieveQuestionSet(int id);
        [OperationContract]
        QuestionSet RetrieveQuestionSetByTitle(string title);
        [OperationContract]
        void AddMap(Game game, Map map);
        [OperationContract]
        void AddQuestionSet(Game game, QuestionSet questionSet);
        [OperationContract]
        Player RetrievePlayer(string name);
        [OperationContract]
        bool JoinGame(Game game, Player player);
        [OperationContract]
        bool LeaveGame(Game game, Player player);
        [OperationContract]
        bool StartGame(Game game, Player player);

    }
}
﻿using ConquestionGame.DataAccessLayer;
using ConquestionGame.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConquestionGame.LogicLayer
{
    public class GameController
    {
        ConquestionDBContext db = new ConquestionDBContext();

        public Game CreateGame(Game game)
        {
            if (!ActiveGamesNames().Contains(game.Name))
            {
                game.GameStatus = Game.GameStatusEnum.starting;
                db.Games.Add(game);
                db.SaveChanges();
                return game;
            }
            else
            {
                throw new Exception("Game name is already taken, please select an unique name.");
            }

        }

        public void AddPlayer(Game game, Player player)
        {
            var gameEntity = db.Games.Include("Players").Where(g => g.Name.Equals(game.Name)).FirstOrDefault();
            var playerEntity = db.Players.Where(p => p.Name.Equals(player.Name)).FirstOrDefault();
            if (gameEntity != null)

            {
                if (gameEntity.Players == null)
                    gameEntity.Players = new List<Player>();
                if (!gameEntity.Players.Contains(playerEntity))
                {
                    gameEntity.Players.Add(playerEntity);
                    db.Entry(gameEntity).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }

            }
            else
            {
                throw new Exception();
            }
        }   

        public Game ChooseGame(string name)
        {
            Game chosenGame = db.Games
                .Where(x => x.Name == name)
                .FirstOrDefault();

            return chosenGame;
        }

        public List<Game> ActiveGames()
        {
            List<Game> activeGames = new List<Game>();
            activeGames = db.Games.Where(g => g.GameStatus == Game.GameStatusEnum.starting).ToList();

            return activeGames;
        }

        public List<string> ActiveGamesNames()
        {
            List<Game> activeGames = new List<Game>();
            activeGames = db.Games.Where(g => g.GameStatus == Game.GameStatusEnum.starting).ToList();
            List<string> activeGamesNames = new List<string>();
            foreach(Game g in activeGames)
            {
                activeGamesNames.Add(g.Name);
            }
            return activeGamesNames;
        }

        public bool JoinGame(Game game, Player player)
        {
            var gameEntity = db.Games.Include("Players").Where(g => g.Id == game.Id).FirstOrDefault();
            var playerEntity = db.Players.Where(p => p.Id == player.Id).FirstOrDefault();

            if (gameEntity.Players.Count < 4)
            {
                gameEntity.Players.Add(playerEntity);
                db.Entry(gameEntity).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool LeaveGame(Game game, Player player)
        {
            var gameEntity = db.Games.Include("Players").Where(g => g.Id == game.Id).FirstOrDefault();
            var playerEntity = db.Players.Where(p => p.Id == player.Id).FirstOrDefault();
            try
            {
                gameEntity.Players.Remove(playerEntity);
                db.Entry(gameEntity).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                throw e;
            }     
        }
    }
}
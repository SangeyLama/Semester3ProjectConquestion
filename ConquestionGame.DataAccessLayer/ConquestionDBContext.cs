﻿using ConquestionGame.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConquestionGame.DataAccessLayer
{
    public class ConquestionDBContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<QuestionSet> QuestionSets { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Map> Maps { get; set; }
        public DbSet<RoundAction> RoundActions { get; set; }
        public DbSet<PlayerAnswer> PlayerAnswers { get; set; }

        public ConquestionDBContext()
            : base("name=ConquestionConnectionSangey")
        {

        }
    }
}

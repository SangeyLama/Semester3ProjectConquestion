﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DataLayer.Model
{
    [DataContract]
    public class Game
    {
        public enum GameStatusEnum
        {
            starting=0,
            ongoing=1,
            finished=2
        };


        public int Id { get; set; }
        [DataMember]
        public String Name { get; set; }
        [DataMember]
        public List<Player> Players { get; set; }
        public GameStatusEnum GameStatus { get; set; }
        [DataMember]
        public Map Map { get; set; }
        [DataMember]
        public QuestionSet QuestionSet { get; set; }


    }
}

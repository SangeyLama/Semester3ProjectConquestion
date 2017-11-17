﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DataLayer.Model
{
    [DataContract]
    public class Map
    {
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        public List<MapNode> MapNodes { get; set; }
        public List<Game> Games { get; set; }
    }
}

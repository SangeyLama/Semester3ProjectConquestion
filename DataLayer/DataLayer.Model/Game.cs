using System;
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
        public int Id { get; set; }
        [DataMember]
        public String Name { get; set; }
        [DataMember]
        public List<Player> Players { get; set; }

    }
}

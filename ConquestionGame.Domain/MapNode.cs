using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConquestionGame.Domain
{
    [DataContract]
    public class MapNode
    {
        public int Id { get; set; }
        [DataMember]
        public bool IsStartingNode { get; set; }
        public Map Map { get; set; }
        public List<MapNode> NeigbouringNodes { get; set; }
    }
}

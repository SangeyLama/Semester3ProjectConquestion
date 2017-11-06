using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    class Map
    {
        public int Id { get; set; }
        public List<Node> Nodes { get; set; }
        public int Size { get; set; }
        public string Type { get; set; }



    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    class Node
    {
        public int id { get; set; }
        public List<Node> Neighbours { get; set; }
    }
}

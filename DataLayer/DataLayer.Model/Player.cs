using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DataLayer.Model
{
    public class Player
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Player(string name)
        {
            this.Name = name;
        }
    }
}

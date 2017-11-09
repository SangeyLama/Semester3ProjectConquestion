using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataLayer.DataLayer.Model;
using DataLayer;

namespace LogicLayer
{
    public class PlayerController
    {
        ConquestionDBContext db = new ConquestionDBContext();
        public Player CreatePlayer(string name)
        {
            Player player = new Player(name);
            db.Players.Add(player);
            return player;
        }
    }
}

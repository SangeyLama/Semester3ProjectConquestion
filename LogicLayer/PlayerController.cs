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
        public Player CreatePlayer(Player player)
        {
            db.Players.Add(player);
            db.SaveChanges();
            return player;
        }
    }
}

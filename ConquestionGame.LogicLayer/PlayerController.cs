using ConquestionGame.DataAccessLayer;
using ConquestionGame.Domain;

namespace ConquestionGame.LogicLayer
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConquestionGame.Domain
{
    public class PlayerAnswer
    {
        public int Id { get; set; }
        public Player player { get; set; }
        public Answer answerGiven { get; set; }
        public RoundAction RoundAction { get; set; }
    }
}

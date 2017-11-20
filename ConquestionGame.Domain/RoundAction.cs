using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConquestionGame.Domain
{
    public class RoundAction
    {
        public int Id { get; set; }

        public Question Question { get; set; }
        public Round Round { get; set; }
        public List<PlayerAnswer> PlayerAnswers { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConquestionGame.Domain
{
    public class Round
    {
        public int Id { get; set; }
        public RoundTypeEnum RoundType { get; set; }
        public List<RoundAction> RoundActions { get; set; }

        public enum RoundTypeEnum
        {
            expansion = 0,
            conquest = 1,
        };
    }
}

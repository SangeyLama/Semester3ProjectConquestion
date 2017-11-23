using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConquestionGame.Domain
{
    [DataContract]
    public class RoundAction
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public Question Question { get; set; }

        public Round Round { get; set; }
        [DataMember]
        public List<PlayerAnswer> PlayerAnswers { get; set; }
    }
}

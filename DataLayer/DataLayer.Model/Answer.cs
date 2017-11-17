using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace DataLayer.DataLayer.Model
{
    [DataContract]
    public class Answer
    {
        public int Id { get; set; }
        [DataMember]
        public bool IsValid { get; set; }
        [DataMember]
        public string Text { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }

        public override string ToString()
        {
            return this.Text + "\n"
                + "Is Valid? " + this.IsValid + "\n";
        }
    }
}
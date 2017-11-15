using System.Collections.Generic;

namespace DataLayer.DataLayer.Model
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int QuestionSetId { get; set; }
        public List<Answer> Answers { get; set; }

        public override string ToString()
        {
            string toString = this.Text + "\n";
            if (Answers != null)
            {
                int i = 1;
                foreach (Answer a in Answers)
                {
                    toString += string.Format("Answer {0}: {1}", i, a.ToString());
                    i++;
                }
            }
            return toString;
        }
    }
}
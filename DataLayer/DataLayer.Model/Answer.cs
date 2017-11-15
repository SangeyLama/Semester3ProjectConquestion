namespace DataLayer.DataLayer.Model
{
    public class Answer
    {
        public int Id { get; set; }
        public bool IsValid { get; set; }
        public int QuestionId { get; set; }
        public string Text { get; set; }

        public override string ToString()
        {
            return this.Text + "\n"
                + "Is Valid? " + this.IsValid + "\n";
        }
    }
}
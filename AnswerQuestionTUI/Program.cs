using AnswerQuestionTUI.ConquestionServiceReference;
using System;

namespace AnswerQuestionTUI
{
    class Program
    {
        public static ConquestionServiceClient client = new ConquestionServiceClient();
        static void Main(string[] args)
        {

            ShowQuestion();
            int userAnswer = Convert.ToInt32(Console.ReadLine());

            //client.CheckPlayerAnswers()
            // work here
            

            bool val = client.ValidateAnswer(userAnswer);
            if(val==true)
            {
                Console.WriteLine("correct");
            }
            else
            {
                Console.WriteLine("incorrect");
            }

            Console.ReadLine();
        }

        public static void ShowQuestion()
        {
            Question q = client.AskQuestion();
            Console.WriteLine(q.Text);
            int i = 1;
            foreach(Answer a in q.Answers)
            {
                Console.WriteLine(string.Format("{0}: {1}",i , a.Text));
                i++;
            }

        }
    }
}

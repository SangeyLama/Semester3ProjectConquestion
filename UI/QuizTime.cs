using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.ConquestionServiceReference;

namespace UI
{
    public partial class QuizTime : Form
    {
        ConquestionServiceClient client = new ConquestionServiceClient();
        static int index = 0;
        PlayerAnswer pa = new PlayerAnswer();
        Question q = null;
        Game currentGame = null;
        Round currentRound = null;
        public QuizTime(Game game)
        {
            InitializeComponent();
            Game gameEntity = client.ChooseGame(game.Name, true);
            currentGame = gameEntity;
            //q = gameEntity.QuestionSet.Questions[index];
            //currentRound = client.GetRound(currentGame, "starting");
            //q = currentRound.RoundActions.LastOrDefault().Question;
            label1.Text = string.Format("Question number: {0}", index + 1);
            richTextBox1.Text = q.Text;
            button1.Text = q.Answers[0].Text;
            button2.Text = q.Answers[1].Text;
            button3.Text = q.Answers[2].Text;
            button4.Text = q.Answers[3].Text;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckAllButtons();
            pa.answerGiven = q.Answers[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CheckAllButtons();
            pa.answerGiven = q.Answers[1];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CheckAllButtons();
            pa.answerGiven = q.Answers[2];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CheckAllButtons();
            pa.answerGiven = q.Answers[3];
        }

        public void disableButtons()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;

        }

        public void CheckButton(Button button)
        {
            int buttonNo = button.TabIndex - 1;
            bool correct = client.ValidateAnswer(q.Answers[buttonNo - 1]);
            if (correct)
            {
                button.BackColor = Color.Lime;
            }
            else
            {
                button.BackColor = Color.Red;
            }
        }

        public void CheckAllButtons()
        {
            CheckButton(button1);
            CheckButton(button2);
            CheckButton(button3);
            CheckButton(button4);
            disableButtons();
            button5.Visible = true;
            button5.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            index++;
            (new QuizTime(currentGame)).Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}

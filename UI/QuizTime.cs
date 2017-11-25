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
        PlayerAnswer pa = new PlayerAnswer { Player = PlayerCredentials.Instance.Player};
        RoundAction currentRoundAction;
        DateTime startTime;
        Question q = null;
        private int TimerCountdown = 30;
        public QuizTime(Game game)
        {
            InitializeComponent();
            currentRoundAction = CurrentRound.Instance.Round.RoundActions.LastOrDefault();
            q = currentRoundAction.Question;
            label1.Text = string.Format("Question number: {0}", index + 1);
            richTextBox1.Text = q.Text;
            button1.Text = q.Answers[0].Text;
            button2.Text = q.Answers[1].Text;
            button3.Text = q.Answers[2].Text;
            button4.Text = q.Answers[3].Text;

        }
        
        private void Answer1_Click(object sender, EventArgs e)
        {
            DisableButtons();
            pa.AnswerGiven = q.Answers[0];
            client.SubmitAnswer(currentRoundAction, pa);
        }

        private void Answer2_Click(object sender, EventArgs e)
        {
            DisableButtons();
            pa.AnswerGiven = q.Answers[1];
            client.SubmitAnswer(currentRoundAction, pa);
        }

        private void Answer3_Click(object sender, EventArgs e)
        {
            DisableButtons();
            pa.AnswerGiven = q.Answers[2];
            client.SubmitAnswer(currentRoundAction, pa);
        }

        private void Answer4_Click(object sender, EventArgs e)
        {
            DisableButtons();
            pa.AnswerGiven = q.Answers[3];
            client.SubmitAnswer(currentRoundAction, pa);
        }

        public void DisableButtons()
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
            DisableButtons();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            index++;
            (new QuizTime(CurrentGame.Instance.Game)).Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int elaspedSeconds = (int)(DateTime.Now - startTime).TotalSeconds;
            int remainingSeconds = TimerCountdown - elaspedSeconds;

            timerLabel.Text = String.Format("{0}", remainingSeconds);

            if (remainingSeconds <= 0 || client.CheckIfAllPlayersAnswered(CurrentGame.Instance.Game, currentRoundAction))
            {
                CheckAllButtons();
                timer1.Stop();
                //int[] order = client.GetPlayerOrder(currentRoundAction);
                Player[] playerOrder = client.GetPlayerOrder(currentRoundAction);
                timerLabel.Text = String.Format("1stPlayer: {0} 2ndPlayer: {1} 3rdPlayer: {2} 4thPlayer {3}", 
                    playerOrder[0]?.Id, playerOrder[1]?.Id, 0, 0);
                //, playerOrder[2]?.Id, playerOrder[3]?.Id
            }
        }

        private void QuizTime_Load(object sender, EventArgs e)
        {
            timer1.Start();
            startTime = DateTime.Now;
            label2.Text = PlayerCredentials.Instance.Player.Name;
        }
    }
}

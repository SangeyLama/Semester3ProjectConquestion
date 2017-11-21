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
    public partial class Lobby : Form
    {
        ConquestionServiceClient client = new ConquestionServiceClient();

        Game currentGame = null;
        public Lobby(Game game)
        {
            InitializeComponent();

            Game gameEntity = client.ChooseGame(game.Name, true);
            currentGame = gameEntity;
            label1.Text = gameEntity.Name;
            label3.Text = gameEntity.QuestionSet.Title;
            label5.Text = gameEntity.Map.Name;

            listBox1.DataSource = gameEntity.Players;
            listBox1.DisplayMember = "Name";
            listBox1.ValueMember = "Name";

        }

        public void refreshPlayerList()
        {
                Game gameEntity = client.ChooseGame(currentGame.Name, true);
                listBox1.DataSource = gameEntity.Players;
                listBox1.DisplayMember = "Name";
                listBox1.ValueMember = "Name";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            refreshPlayerList();
        }

        private void Lobby_Load(object sender, EventArgs e)
        {
            timer1.Interval = (5 * 1000); // 5 secs
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new QuizTime(currentGame)).Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            client.LeaveGame(currentGame, PlayerCredentials.Instance.Player);
            this.Hide();
            (new JoinGame()).Show();
        }
    }
}

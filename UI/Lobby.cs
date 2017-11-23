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

            Start_Game.Enabled = false;
            CheckIfLobbyHost();

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
            CheckIfLobbyHost();
        }

        private void Lobby_Load(object sender, EventArgs e)
        {
            timer1.Interval = (1 * 1000); // 5 secs
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Tick += new EventHandler(timer2_Tick);
            timer1.Start();
            //timer2.Interval = (1 * 1000); // 1 Sec
            //timer2.Tick += new EventHandler(timer2_Tick);
            //timer2.Start();
        }

        private void Start_Game_Click(object sender, EventArgs e)
        {
            client.StartGame(currentGame, PlayerCredentials.Instance.Player);
            this.Close();
            (new QuizTime(currentGame)).Show();
        }

        private void Exit_Lobby_Click(object sender, EventArgs e)
        {
            client.LeaveGame(currentGame, PlayerCredentials.Instance.Player);
            this.Hide();
            (new JoinGame()).Show();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //Checks to see if the game has been started by the lobby host
            var gameEntity = client.ChooseGame(currentGame.Name, false);
            if(gameEntity.GameStatus == Game.GameStatusEnum.ongoing)
            {
                this.Close();
                (new QuizTime(currentGame)).Show();
            }
        }

        private void CheckIfLobbyHost()
        {
            var gameEntity = client.ChooseGame(currentGame.Name, true);
            if (PlayerCredentials.Instance.Player.Name.Equals(gameEntity.Players[0].Name))
            {
                Start_Game.Enabled = true;
            }
            else
            {
                Start_Game.Enabled = false;
            }
        }
    }
}

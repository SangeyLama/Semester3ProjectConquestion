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
    public partial class JoinGame : Form
    {
        public ConquestionServiceClient client = new ConquestionServiceClient();
        public JoinGame()
        {
            InitializeComponent();
            if (client.ActiveGames().Length != 0)
            {
                listBox1.DataSource = client.ActiveGames();
                listBox1.DisplayMember = "Name";
                listBox1.ValueMember = "Name";
            }
            else
            {
                MessageBox.Show("No active games found!", "Error",
                 MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void UpdateGameList_Click(object sender, EventArgs e)
        {
            if (client.ActiveGames().Length != 0)
            {
                listBox1.DataSource = client.ActiveGames();
                listBox1.DisplayMember = "Name";
                listBox1.ValueMember = "Name";
            }
            else
            {
                MessageBox.Show("No active games found!", "Error",
                 MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void JoinGame_Click(object sender, EventArgs e)
        {
            Game game = listBox1.SelectedItem as Game;
            Game game2 = client.ChooseGame(game.Name, false);
            //label1.Text = CurrentPlayer.Name;
            bool success = client.JoinGame(game2, PlayerCredentials.Instance.Player);
            if (success)
            {
                this.Close();
                (new Lobby(game2)).Show();
            }
            else
            {
                MessageBox.Show("Unable to join game!", "Error",
                 MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void CreateGame_Click(object sender, EventArgs e)
        {
            this.Close();
            (new CreateGame()).Show();
        }

        private void JoinGame_Load(object sender, EventArgs e)
        {
            label1.Text = PlayerCredentials.Instance.Player.Name;
        }
    }
}

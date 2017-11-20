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
            //for(int i=0; i<service.ActiveGames().Length; i++)
            //{
            //    listBox1.Items.Add(service.ActiveGames()[i].Name);
            //}
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

        private void button1_Click(object sender, EventArgs e)
        {
            //listBox1.DataSource = client.ActiveGames();
            //listBox1.DisplayMember = "Name";
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

        private void button3_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Game game = listBox1.SelectedItem as Game;
            Game game2 = client.ChoseGame(game.Name);
            //label1.Text = CurrentPlayer.Name;
            client.AddPlayer(game2, PlayerCredentials.Instance.Player);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new CreateGame()).Show();
        }
    }
}

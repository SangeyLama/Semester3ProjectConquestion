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
        public static Player CurrentPlayer = new Player();
        ConquestionServiceClient service = new ConquestionServiceClient();
        public JoinGame()
        {
            InitializeComponent();
            //for(int i=0; i<service.ActiveGames().Length; i++)
            //{
            //    listBox1.Items.Add(service.ActiveGames()[i].Name);
            //}
            listBox1.DataSource = service.ActiveGames();
            listBox1.DisplayMember = "Name";
            listBox1.ValueMember = "Name";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.DataSource = service.ActiveGames();
            listBox1.DisplayMember = "Name";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Game game = listBox1.SelectedItem as Game;
            Game game2 = service.ChoseGame(game.Name);
            //label1.Text = CurrentPlayer.Name;
            //service.AddPlayer(game2, CurrentPlayer);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new CreateGame()).Show();
        }
    }
}

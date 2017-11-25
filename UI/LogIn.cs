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
    public partial class LogIn : Form
    {
        public PlayerCredentials PC { get; set; }
        public LogIn()
        {
            InitializeComponent();
            PC = PlayerCredentials.Instance;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConquestionServiceClient client = new ConquestionServiceClient();

            Player foundPlayer = client.RetrievePlayer(textBox1.Text);
            if (textBox1.Text != null && textBox1.Text != String.Empty)
            {

                if (foundPlayer == null)
                {
                    Player newPlayer = client.CreatePlayer(new Player { Name = textBox1.Text });
                    PC.Player = newPlayer;
                    this.Close();
                    (new JoinGame()).Show();
                }
                else
                {
                    this.Close();
                    PC.Player = foundPlayer;
                    (new JoinGame()).Show();
                }

            }
            else
            {
                MessageBox.Show("Name can not be empty!", "Error",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            (new JoinGame()).Show();

        }
    }
}

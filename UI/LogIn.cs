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
        
        public LogIn()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConquestionServiceClient service = new ConquestionServiceClient();

            if(textBox1.Text != null && textBox1.Text != String.Empty)
            {
                
                Player newPlayer = service.CreatePlayer(new Player { Name = textBox1.Text }); 
                JoinGame.CurrentPlayer = newPlayer;
                this.Hide();
                (new JoinGame()).Show();
                
            }
            else
            {
                label2.Text = "Name can not be empty";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new JoinGame()).Show();

        }
    }
}

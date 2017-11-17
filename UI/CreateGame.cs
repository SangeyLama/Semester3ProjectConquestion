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
    public partial class CreateGame : Form
    {
        ConquestionServiceClient service = new ConquestionServiceClient();
        public CreateGame()
        {
            InitializeComponent();
            comboBox1.DataSource = service.RetrieveAllMaps();
            comboBox1.DisplayMember = "Name";
            comboBox2.DataSource = service.RetrieveAllQuestionSets();
            comboBox2.DisplayMember = "Title";
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CreateGame_Load(object sender, EventArgs e)
        {
            service.CreateGame(new Game { Name = textBox1.Text});
        }
    }
}

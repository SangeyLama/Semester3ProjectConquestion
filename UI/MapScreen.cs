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
    public partial class MapScreen : Form
    {
        ConquestionServiceClient client = new ConquestionServiceClient();

        Game CurrentGame = null;

        List<Button> NodeButtons = new List<Button>();
        // contains a list of all the buttons that represent map nodes
        IList<Player> ourPlayers = new List<Player>();
        // a list of the players that play and own nodes

        public MapScreen(Game Game)
        {
            InitializeComponent();
            Game GameEntity = client.ChooseGame(Game.Name, true);
            CurrentGame = GameEntity;
            AddAllNodeButtonsToList();
            AssignPlayerColors();
            ColorOccupiedNodes(NodeButtons);
        }

        // adds all the map nodes buttons to the list of node buttons for easier management 
        private void AddAllNodeButtonsToList()
        {
            NodeButtons.Add(MapNode_1);
            NodeButtons.Add(MapNode_2);
            NodeButtons.Add(MapNode_3);
            NodeButtons.Add(MapNode_4);
            NodeButtons.Add(MapNode_5);
            NodeButtons.Add(MapNode_6);
            NodeButtons.Add(MapNode_7);
            NodeButtons.Add(MapNode_8);
            NodeButtons.Add(MapNode_9);
            NodeButtons.Add(MapNode_10);
            NodeButtons.Add(MapNode_11);
            NodeButtons.Add(MapNode_12);
            NodeButtons.Add(MapNode_13);
            NodeButtons.Add(MapNode_14);
            NodeButtons.Add(MapNode_15);
            NodeButtons.Add(MapNode_16);
        }

        // initialises the timer when the screen loads
        private void MapScreen_Load(object sender, EventArgs e)
        {
            timer1.Interval = (5 * 1000); // 5 secs
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
        }

        // retrieves the players from the db and assigns them colors so we can tell them apart 
        private void AssignPlayerColors()
        {
            ourPlayers = client.RetrieveAllPlayersByGameId(CurrentGame);

            if(ourPlayers[0] != null)
            {
                PlayerLabel1.Text = ourPlayers[0].Name;
                PlayerLabel1.ForeColor = Color.Red;
                PlayerLabel1.Visible = true;
            }

            if (ourPlayers[1] != null)
            {
                PlayerLabel2.Text = ourPlayers[1].Name;
                PlayerLabel2.ForeColor = Color.Yellow;
                PlayerLabel2.Visible = true;
            }

            try
            {
                if (ourPlayers[2] != null)
                {
                    PlayerLabel3.Text = ourPlayers[2].Name;
                    PlayerLabel3.ForeColor = Color.Green;
                    PlayerLabel3.Visible = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("error", e);
            }

            try
            {
                if (ourPlayers[3] != null)
                {
                    PlayerLabel4.Text = ourPlayers[3].Name;
                    PlayerLabel4.ForeColor = Color.Blue;
                    PlayerLabel4.Visible = true;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("error", e);
            }
        }

        // each node button is colored with their players color so know who owns each node
        private void ColorOccupiedNodes(List<Button> buttons)
        {
            ourPlayers = client.RetrieveAllPlayersByGameId(CurrentGame);
            Player aPlayer = new Player();
            foreach (Button aButton in buttons)
            {
                int Index = Convert.ToInt32(aButton.Text);
                aPlayer = client.ReturnNodeOwner(CurrentGame, Index);

                if (aPlayer != null)
                {
                    if (ourPlayers[0] !=null)
                    {
                        if(aPlayer.Name.Equals(ourPlayers[0].Name))
                        {
                            aButton.BackColor = Color.Red;
                        }

                        if(aPlayer.Name.Equals(ourPlayers[1].Name))
                        {
                            aButton.BackColor = Color.Yellow;
                        }

                        try
                        {
                            if (aPlayer.Name.Equals(ourPlayers[2].Name))
                            {
                                aButton.BackColor = Color.Green;
                            }
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine("error", e);
                        }

                        try
                        {
                            if (aPlayer.Name.Equals(ourPlayers[3].Name))
                            {
                                aButton.BackColor = Color.Blue;
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("error", e);
                        }
                    }
                }
                else if(aPlayer == null)
                {
                    aButton.BackColor = Color.Transparent;
                }
            }
        }

        private void MapNode_1_Click(object sender, EventArgs e)
        {
        }

        private void MapNode_2_Click(object sender, EventArgs e)
        {
        }

        private void MapNode_3_Click(object sender, EventArgs e)
        {
        }

        private void MapNode_4_Click(object sender, EventArgs e)
        {
        }

        private void MapNode_5_Click(object sender, EventArgs e)
        {
        }

        private void MapNode_6_Click(object sender, EventArgs e)
        {
        }

        private void MapNode_7_Click(object sender, EventArgs e)
        {
        }

        private void MapNode_8_Click(object sender, EventArgs e)
        {
        }

        private void MapNode_9_Click(object sender, EventArgs e)
        {
        }

        private void MapNode_10_Click(object sender, EventArgs e)
        {
        }

        private void MapNode_11_Click(object sender, EventArgs e)
        {
        }

        private void MapNode_12_Click(object sender, EventArgs e)
        {
        }

        private void MapNode_13_Click(object sender, EventArgs e)
        {
        }

        private void MapNode_14_Click(object sender, EventArgs e)
        {
        }

        private void MapNode_15_Click(object sender, EventArgs e)
        {
        }

        private void MapNode_16_Click(object sender, EventArgs e)
        { 
        }

        // the timer refreshes our map every 5 secs so the colors are accurate 
        private void timer1_Tick(object sender, EventArgs e)
        {
            ColorOccupiedNodes(NodeButtons);
        }

        private void MapScreen_Closing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}

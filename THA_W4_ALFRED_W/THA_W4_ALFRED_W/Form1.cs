using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THA_W4_ALFRED_W
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Team> teams = new List<Team>();
        private void btn_addteam_Click(object sender, EventArgs e)
        {
            comboBox_country.Items.Clear();
            bool teamExists = false;
            if(textBox_tname.Text == "" || textBox_tcountry.Text == "" || textBox_tcity.Text == "")
            {
                MessageBox.Show("Please fill in all the fields.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Team newTeam = new Team(textBox_tname.Text, textBox_tcountry.Text, textBox_tcity.Text);
                foreach (Team team in teams)
                {
                    if (team.teamName == newTeam.teamName)
                    {
                        teamExists = true;
                    }
                }
                if (teamExists == false)
                {
                    teams.Add(newTeam);
                }
                else
                {
                    MessageBox.Show("Team already exist, please add another team.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                textBox_tname.Text = "";
                textBox_tcountry.Text = "";
                textBox_tcity.Text = "";
            }
            foreach (Team team in teams)
            {
                if (!comboBox_country.Items.Contains(team.teamCountry))
                {
                    comboBox_country.Items.Add(team.teamCountry);
                }
            }
        }

        private void comboBox_country_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string pickedCountry = comboBox_country.Text;
            comboBox_team.Items.Clear();
            foreach(Team team in teams)
            {
                if(team.teamCountry == pickedCountry)
                {
                    comboBox_team.Items.Add(team.teamName);
                }
            }
        }

        private void comboBox_team_SelectionChangeCommitted(object sender, EventArgs e)
        {
            list_players.Items.Clear();
            foreach(Team team in teams)
            {
                if(team.teamName == comboBox_team.Text)
                {
                    foreach(Player players in team.Players)
                    {
                        list_players.Items.Add("(" + players.playerNum + ") " + players.playerName + ", " + players.playerPos);
                        list_players.Sorted = true;
                    }
                    break;
                }
            }
        }

        private void btn_removeplayer_Click(object sender, EventArgs e)
        {
            if(list_players.Items.Count < 11)
            {
                MessageBox.Show("Players must be more or equal to 11.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                list_players.Items.RemoveAt(list_players.SelectedIndex);
            }
        }

        private void btn_addplayer_Click(object sender, EventArgs e)
        {
            bool belumada = true;
            if (textBox_pname.Text == "" || textBox_pnum.Text == "" || comboBox_position.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill in all the fields.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (comboBox_team.Text == "")
                {
                    MessageBox.Show("Please select a team first.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Player newPlayer = new Player(textBox_pname.Text, textBox_pnum.Text, comboBox_position.Text);
                    foreach (Team team in teams)
                    {
                        if (team.teamName == comboBox_team.Text)
                        {

                            foreach (Player player in team.Players)
                            {
                                if (newPlayer.playerNum == player.playerNum)
                                {
                                    belumada = false;
                                    break;
                                }
                            }
                            if (belumada == true)
                            {
                                team.Players.Add(newPlayer);
                            }
                            else
                            {
                                MessageBox.Show("Player with same number is found.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        }
                    }
                }
                textBox_pname.Text = "";
                textBox_pnum.Text = "";
                comboBox_position.SelectedIndex = -1;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Team sampleteam1 = new Team("Bayern Munich", "Germany", "Munich");
            teams.Add(sampleteam1);
            Team sampleteam2 = new Team("", "England", "");
            teams.Add(sampleteam2);
            Team sampleteam3 = new Team("", "England", "");
            teams.Add(sampleteam3);
            foreach (Team team in teams)
            {
                if (!comboBox_country.Items.Contains(team.teamCountry)) {
                    comboBox_country.Items.Add(team.teamCountry);
                } 
            }
            Player player1 = new Player("Manuel Neuer", "01", "GK");
            sampleteam1.Players.Add(player1);
            Player player2 = new Player("Dayot Upamecano", "02", "DF");
            sampleteam1.Players.Add(player2);
            Player player3 = new Player("Matthjis de Ligt", "04", "DF");
            sampleteam1.Players.Add(player3);
            Player player4 = new Player("Benjamin Pavard", "05", "DF");
            sampleteam1.Players.Add(player4);
            Player player5 = new Player("Joshua Kimmich", "06", "MF");
            sampleteam1.Players.Add(player5);
            Player player6 = new Player("Serge Gnarby", "07", "FW");
            sampleteam1.Players.Add(player6);
            Player player7 = new Player("Leon Goretzka", "08", "MF");
            sampleteam1.Players.Add(player7);
            Player player8 = new Player("Leroy Sane", "10", "FW");
            sampleteam1.Players.Add(player8);
            Player player9 = new Player("Paul Wanner", "14", "MF");
            sampleteam1.Players.Add(player9);
            Player player10 = new Player("Lucas Hernandez", "21", "DF");
            sampleteam1.Players.Add(player10);
            Player player11 = new Player("Thomas Muller", "25", "FW");
            sampleteam1.Players.Add(player11);
        }
    }
}

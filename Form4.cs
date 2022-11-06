using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form4 : Form
    {
       Model1 db = new Model1();
        public Form4()
        {
            InitializeComponent();
            this.Text = "Панель администратора";
            var no_admins = db.users.Where(y => y.user_is_admin == false).Select(y => y.user_login).ToArray();
            foreach (var item in no_admins)
            {
                comboBox2.Items.Add(item);
            }
            var countries = db.countries.Select(y => y.country_name).ToArray();
            foreach (var item in countries)
            {
                comboBox1.Items.Add(item);
                comboBox3.Items.Add(item);
                comboBox5.Items.Add(item);
                comboBox8.Items.Add(item);
            }

            var leag = db.leagues.Where(y => y.league_country == comboBox3.Text).Select(y => y.league_name).ToArray();
            foreach (var item in leag)
            {
                comboBox4.Items.Add(item);
                comboBox6.Items.Add(item);
                comboBox9.Items.Add(item);
            }
            var teams = db.teams.Where(y => y.team_name == comboBox6.Text).Select(y => y.team_name).ToArray();
            foreach (var item in teams)
            {
                comboBox7.Items.Add(item);
                comboBox10.Items.Add(item);
                comboBox11.Items.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            db.users.Where(y => y.user_login == comboBox2.SelectedItem.ToString()).ToArray().Last().user_is_admin = true;
            db.SaveChanges();
            MessageBox.Show("Успешно");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 fr1 = new Form1();
            fr1.Show();
            Hide();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Model1 db = new Model1();
            String id = db.countries.ToArray().Last().id_country.ToString();//считывание последнего id
            int id1 = Convert.ToInt32(id);
            bool flag = false;
            countries count = new countries//начало добавления
            {
                id_country = id1 + 1,
                country_name = textBox1.Text,
                country_value = Convert.ToDouble(textBox2.Text),
                country_fifa_place = Convert.ToInt32(textBox3.Text)

            };
            db.countries.Add(count);
            db.SaveChanges();//конец
            MessageBox.Show("Вы успешно добавили страну.");
            Form1 fr1 = new Form1();
            fr1.Show();
            Hide();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Model1 db = new Model1();
            String id = db.leagues.ToArray().Last().id_league.ToString();//считывание последнего id
            int id1 = Convert.ToInt32(id);
            bool flag = false;
           
            leagues lg = new leagues//начало добавления
            {
                id_league = id1 + 1,
                league_name = textBox4.Text.ToString(),
                league_country = comboBox1.Text,
                league_value = Convert.ToInt32(textBox5.Text),
                league_country_place = Convert.ToInt32(textBox6.Text),
                league_teams_number = Convert.ToInt32(textBox7.Text),
                league_uefa_place = Convert.ToInt32(textBox8.Text),
                league_uefa_points = Convert.ToDouble(textBox9.Text)
            };
            db.leagues.Add(lg);
            db.SaveChanges();//конец
            MessageBox.Show("Вы успешно добавили лигу.");
            Form1 fr1 = new Form1();
            fr1.Show();
            Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Model1 db = new Model1();
            String id = db.teams.ToArray().Last().id_team.ToString();//считывание последнего id
            int id1 = Convert.ToInt32(id);
            bool flag = false;

            teams tm = new teams//начало добавления
            {
                id_team = id1 + 1,
                team_name = textBox10.Text.ToString(),
                team_id_league = db.leagues.Where(y => y.league_name == comboBox4.SelectedItem).ToArray().Last().id_league,
                team_value = Convert.ToDouble(textBox11.Text),
                team_stadium = Convert.ToString(textBox12.Text),
                team_league_points = Convert.ToInt32(textBox13.Text),
                team_goals_diff = Convert.ToInt32(textBox14.Text),
                team_games_played = Convert.ToInt32(textBox15.Text)
            };
            db.teams.Add(tm);
            db.SaveChanges();//конец
            MessageBox.Show("Вы успешно добавили команду.");
            Form1 fr1 = new Form1();
            fr1.Show();
            Hide();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            var leag = db.leagues.Where(y => y.league_country == comboBox3.Text).Select(y => y.league_name).ToArray();
            foreach (var item in leag)
            {
                comboBox4.Items.Add(item);
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Model1 db = new Model1();
            String id = db.players.ToArray().Last().id_player.ToString();//считывание последнего id
            int id1 = Convert.ToInt32(id);
            bool flag = false;

            players pl = new players//начало добавления
            {
                id_player = id1 + 1,
                player_id_national_team = db.countries.Where(y => y.country_name == comboBox5.SelectedItem).ToArray().Last().id_country,
                player_id_team = db.teams.Where(y => y.team_name == comboBox7.SelectedItem).ToArray().Last().id_team,
                player_name = Convert.ToString(textBox16.Text),
                player_number = Convert.ToInt32(textBox17.Text),
                player_value = Convert.ToDouble(textBox18.Text),
                player_birth_date = Convert.ToDateTime(textBox19.Text),
                player_position = Convert.ToString(textBox20.Text),
                player_height = Convert.ToInt32(textBox21.Text)
            };
            db.players.Add(pl);
            db.SaveChanges();//конец
            MessageBox.Show("Вы успешно добавили игрока.");
            Form1 fr1 = new Form1();
            fr1.Show();
            Hide();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            var leag = db.leagues.Where(y => y.league_country == comboBox5.Text).Select(y => y.league_name).ToArray();
            foreach (var item in leag)
            {
                comboBox6.Items.Add(item);
            }
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id_league = db.leagues.Where(y => y.league_name == comboBox6.SelectedItem).ToArray().Last().id_league;
            var teams = db.teams.Where(y => y.team_id_league == id_league).Select(y => y.team_name).ToArray();
            foreach (var item in teams)
            {
                comboBox7.Items.Add(item);
            }
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            var leag = db.leagues.Where(y => y.league_country == comboBox8.Text).Select(y => y.league_name).ToArray();
            foreach (var item in leag)
            {
                comboBox9.Items.Add(item);
            }
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id_league = db.leagues.Where(y => y.league_name == comboBox9.SelectedItem).ToArray().Last().id_league;
            var teams = db.teams.Where(y => y.team_id_league == id_league).Select(y => y.team_name).ToArray();
            foreach (var item in teams)
            {
                comboBox10.Items.Add(item);
                comboBox11.Items.Add(item);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int id_team1 = db.teams.Where(y => y.team_name == comboBox10.SelectedItem).ToArray().Last().id_team;
            int id_team2 = db.teams.Where(y => y.team_name == comboBox11.SelectedItem).ToArray().Last().id_team;
            int points1 = db.teams.Where(y => y.team_name == comboBox10.SelectedItem).Select(y => y.team_league_points).ToArray().Last();
            int points2 = db.teams.Where(y => y.team_name == comboBox11.SelectedItem).Select(y => y.team_league_points).ToArray().Last();
            int diff1 = db.teams.Where(y => y.team_name == comboBox10.SelectedItem).Select(y => y.team_goals_diff).ToArray().Last();
            int diff2 = db.teams.Where(y => y.team_name == comboBox11.SelectedItem).Select(y => y.team_goals_diff).ToArray().Last();
            int matches1 = db.teams.Where(y => y.team_name == comboBox10.SelectedItem).Select(y => y.team_games_played).ToArray().Last();
            int matches2 = db.teams.Where(y => y.team_name == comboBox11.SelectedItem).Select(y => y.team_games_played).ToArray().Last();
            int point1 = Convert.ToInt32(textBox22.Text);
            int point2 = Convert.ToInt32(textBox23.Text);
            //if(point1 > point2)
            //{
            //    int pointsAdd = points1 + 3;
            //    int diffAdd1 = diff1 + point1 - point2;
            //    int diffAdd2 = diff2 - point1 + point2;
            //    int matchesAdd1 = matches1 + 1;
            //    int matchesAdd2 = matches2 + 1;
            //    db.teams.Where(y => y.team_name == comboBox10.SelectedItem).Update().(y => y.team_league_points).ToArray().Last().pointsAdd;
            //    db.teams.Where(y => y.team_name == comboBox10.SelectedItem).Update().(y => y.team_goals_diff).ToArray().Last().diffAdd1;
            //    db.teams.Where(y => y.team_name == comboBox11.SelectedItem).Update().(y => y.team_goals_diff).ToArray().Last().diffAdd2;
            //    db.teams.Where(y => y.team_name == comboBox10.SelectedItem).Update().(y => y.team_games_played).ToArray().Last().matchesAdd1;
            //    db.teams.Where(y => y.team_name == comboBox11.SelectedItem).Update().(y => y.team_games_played).ToArray().Last().matchesAdd2;
            //}
            //else if (point1 < point2)
            //{
            //    int pointsAdd = points2 + 3;
            //    int diffAdd1 = diff1 + point1 - point2;
            //    int diffAdd2 = diff2 - point1 + point2;
            //    int matchesAdd1 = matches1 + 1;
            //    int matchesAdd2 = matches2 + 1;
            //    db.teams.Where(y => y.team_name == comboBox11.SelectedItem).Update().(y => y.team_league_points).ToArray().Last().pointsAdd;
            //    db.teams.Where(y => y.team_name == comboBox10.SelectedItem).Update().(y => y.team_goals_diff).ToArray().Last().diffAdd1;
            //    db.teams.Where(y => y.team_name == comboBox11.SelectedItem).Update().(y => y.team_goals_diff).ToArray().Last().diffAdd2;
            //    db.teams.Where(y => y.team_name == comboBox10.SelectedItem).Update().(y => y.team_games_played).ToArray().Last().matchesAdd1;
            //    db.teams.Where(y => y.team_name == comboBox11.SelectedItem).Update().(y => y.team_games_played).ToArray().Last().matchesAdd2;
            //}
            //else
            //{
            //    int pointsAdd1 = points1 + 1;
            //    int pointsAdd2 = points2 + 1;
            //    int matchesAdd1 = matches1 + 1;
            //    int matchesAdd2 = matches2 + 1;
            //    db.teams.Where(y => y.team_name == comboBox10.SelectedItem).Update().(y => y.team_league_points).ToArray().Last().pointsAdd1;
            //    db.teams.Where(y => y.team_name == comboBox10.SelectedItem).Update().(y => y.team_league_points).ToArray().Last().pointsAdd2;
            //    db.teams.Where(y => y.team_name == comboBox10.SelectedItem).Update().(y => y.team_games_played).ToArray().Last().matchesAdd1;
            //    db.teams.Where(y => y.team_name == comboBox11.SelectedItem).Update().(y => y.team_games_played).ToArray().Last().matchesAdd2;
            //}

        }
    }
}

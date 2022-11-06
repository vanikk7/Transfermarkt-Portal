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
    public partial class Form2 : Form
    {
        Model1 db = new Model1();
        public Form2()
        {

            InitializeComponent();
            label1.Parent = pictureBox1;
            label2.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            this.Text = "Добро пожаловать в Transfermarkt!";
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            comboBox3.Visible = false;
            comboBox4.Visible = false;
            label1.Visible = false;

            dataGridView1.Visible = false;
            dataGridView1.Columns.Add("Команда", "Команда");
            dataGridView1.Columns.Add("Игр сыграно", "Игр сыграно");
            dataGridView1.Columns.Add("Разница мячей", "Разница мячей");
            dataGridView1.Columns.Add("Набрано очков", "Набрано очков");

            dataGridView2.Visible = false;
            dataGridView2.Columns.Add("Игрок", "Игрок");
            dataGridView2.Columns.Add("Номер", "Номер");
            dataGridView2.Columns.Add("Позиция", "Позиция");
            dataGridView2.Columns.Add("Дата рождения", "Дата рождения");
            dataGridView2.Columns.Add("Рост", "Рост");

            button5.Visible = false;
            textBox1.Visible = false;

            comboBox1.SelectedItem = -1;
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            comboBox2.Items.Clear();
            comboBox1.Items.Clear();
            var countries = db.countries.Select(y => y.country_name).ToArray();
            foreach (var item in countries)
            {
                comboBox1.Items.Add(item);
            }

            label2.Text = "Приветствуем вас на портале TRANSFERMARKT!" + "\nЧтобы найти информацию о национальной команде, лиге, клубе или игроке, воспользуйтесь вкладкой ПОИСК. " + "\nДля того, чтобы узнать имена последних победителей лиг, посетите вкладку ЧЕМПИОНЫ." + "\n" + "\nПОСЛЕДНИЕ НОВОСТИ: " + "\n";
 
            int size = db.news.Count();
            for(int i = 0; i < 4; i++)
            {
                string news = db.news.Where(y => y.id_news == size - i).ToArray().Last().news_text;
                label2.Text += "\n";
                label2.Text += news;
                label2.Text += "\n";
            }
          
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "champDataSet.teams". При необходимости она может быть перемещена или удалена.
            this.teamsTableAdapter.Fill(this.champDataSet.teams);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "champDataSet.news". При необходимости она может быть перемещена или удалена.
            this.newsTableAdapter.Fill(this.champDataSet.news);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "champDataSet.players". При необходимости она может быть перемещена или удалена.
            this.playersTableAdapter.Fill(this.champDataSet.players);

        }
        
        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            comboBox3.Visible = false;
            comboBox4.Visible = false;
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            label2.Visible = true;
            button5.Visible = false;
            textBox1.Visible = false;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.Visible = true;
            comboBox2.Visible = true;
            comboBox3.Visible = true;
            comboBox4.Visible = true;
            label1.Visible = true;
            label2.Visible = false;
            button5.Visible = true;
            textBox1.Visible = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            comboBox2.SelectedItem = -1;
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            comboBox2.Items.Clear();

            string name_country = db.countries.Where(y => y.country_name == comboBox1.SelectedItem).ToArray().Last().country_name;
            var leagues = db.leagues.Where(y => y.league_country == name_country).Select(y => y.league_name).ToArray();
            foreach (var item in leagues)
            {
                comboBox2.Items.Add(item);
            }
            string value = db.countries.Where(y => y.country_name == comboBox1.SelectedItem).ToArray().Last().country_value.ToString();
            string mesto = db.countries.Where(y => y.country_name == comboBox1.SelectedItem).ToArray().Last().country_fifa_place.ToString();
            label1.Text = "Страна: " + comboBox1.SelectedItem + "\nЦена национальной команды: " + value + "\nМесто в рейтинге фифа: " + mesto;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView2.Visible = false;
            dataGridView1.Rows.Clear();


            comboBox4.SelectedItem = -1;
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            int id_league = db.leagues.Where(y => y.league_name == comboBox2.SelectedItem).ToArray().Last().id_league;
            var teams = db.teams.Where(y => y.team_id_league == id_league).Select(y => y.team_name).ToArray();
        
            foreach (var item in teams)
            {
                comboBox4.Items.Add(item);
            }

            var tableteams = db.teams.Where(y => y.team_id_league == id_league).Select(y => y.team_name).ToArray();
            foreach (var item in tableteams)
            {
                dataGridView1.Rows.Add(item);
            }

            int number = 0;
            var tablegames = db.teams.Where(y => y.team_id_league == id_league).Select(y => y.team_games_played).ToArray();
            foreach (var item in tablegames)
            {

                dataGridView1[1, number].Value = item;
                number++;
            }

            number = 0;
            var tablediff = db.teams.Where(y => y.team_id_league == id_league).Select(y => y.team_games_played).ToArray();
            foreach (var item in tablediff)
            {

                dataGridView1[2, number].Value = item;
                number++;
            }

            number = 0;
            var tablepoints = db.teams.Where(y => y.team_id_league == id_league).Select(y => y.team_league_points).ToArray();
            foreach (var item in tablepoints)
            {

                dataGridView1[3, number].Value = item;
                number++;
            }

            dataGridView1.Visible = true;

            string value = db.leagues.Where(y => y.league_name == comboBox2.SelectedItem).ToArray().Last().league_value.ToString();
            string country_place = db.leagues.Where(y => y.league_name == comboBox2.SelectedItem).ToArray().Last().league_country_place.ToString();
            string count = db.leagues.Where(y => y.league_name == comboBox2.SelectedItem).ToArray().Last().league_teams_number.ToString();
            string uefa_place = db.leagues.Where(y => y.league_name == comboBox2.SelectedItem).ToArray().Last().league_uefa_place.ToString();
            string uefa_points = db.leagues.Where(y => y.league_name == comboBox2.SelectedItem).ToArray().Last().league_uefa_points.ToString();
            label1.Text = "Лига: " + comboBox2.SelectedItem + "\nСтрана: " + comboBox1.SelectedItem + "\nЦена лиги: " + value + "\n" + "Номер приоритетности лиги в стране: " + country_place + "\n" +
                "Количество команд в лиге: " + count + "\n" + "Место в уефа: " + uefa_place + "\n" + "Очки в уефа: " + uefa_points;

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            dataGridView2.Rows.Clear();
            comboBox3.SelectedItem = -1;
            comboBox3.Items.Clear();
            int id_team = db.teams.Where(y => y.team_name == comboBox4.SelectedItem).ToArray().Last().id_team;
            var players = db.players.Where(y => y.player_id_team == id_team).Select(y => y.player_name).ToArray();
            foreach (var item in players)
            {
                comboBox3.Items.Add(item);
            }
            var tableplayers = db.players.Where(y => y.player_id_team == id_team).Select(y => y.player_name).ToArray();
            foreach (var item in tableplayers)
            {
                dataGridView2.Rows.Add(item);
            }

            int number = 0;
            var tablenumbers = db.players.Where(y => y.player_id_team == id_team).Select(y => y.player_number).ToArray();
            foreach (var item in tablenumbers)
            {

                dataGridView2[1, number].Value = item;
                number++;
            }

            number = 0;
            var tableposition = db.players.Where(y => y.player_id_team == id_team).Select(y => y.player_position).ToArray();
            foreach (var item in tableposition)
            {

                dataGridView2[2, number].Value = item;
                number++;
            }

            number = 0;
            var tabledate = db.players.Where(y => y.player_id_team == id_team).Select(y => y.player_birth_date).ToArray();
            foreach (var item in tabledate)
            {

                dataGridView2[3, number].Value = item.ToShortDateString();
                number++;
            }

            number = 0;
            var tableheight = db.players.Where(y => y.player_id_team == id_team).Select(y => y.player_height).ToArray();
            foreach (var item in tableheight)
            {

                dataGridView2[4, number].Value = item;
                number++;
            }

            dataGridView2.Visible = true;
            dataGridView2.Sort(dataGridView2.Columns[2], ListSortDirection.Ascending);
            string value = db.teams.Where(y => y.team_name == comboBox4.SelectedItem).ToArray().Last().team_value.ToString();
            string stadium = db.teams.Where(y => y.team_name == comboBox4.SelectedItem).ToArray().Last().team_stadium.ToString();
            string points = db.teams.Where(y => y.team_name == comboBox4.SelectedItem).ToArray().Last().team_league_points.ToString();
            string goals = db.teams.Where(y => y.team_name == comboBox4.SelectedItem).ToArray().Last().team_goals_diff.ToString();
            string games = db.teams.Where(y => y.team_name == comboBox4.SelectedItem).ToArray().Last().team_games_played.ToString();
            label1.Text = "Название команды: " + comboBox4.SelectedItem + "\nЛига: " + comboBox2.SelectedItem + "\nЦена команды: " + value  + "\nСтадион: " + stadium + "\n" + "Набрано очков: " + points + "\n" +
                "Разница голов: " + goals + "\n" + "Игр сыграно: " + games;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            string value = db.players.Where(y => y.player_name == comboBox3.SelectedItem).ToArray().Last().player_value.ToString();
            string number = db.players.Where(y => y.player_name == comboBox3.SelectedItem).ToArray().Last().player_number.ToString();
            string birth = db.players.Where(y => y.player_name == comboBox3.SelectedItem).ToArray().Last().player_birth_date.ToShortDateString();
            string position = db.players.Where(y => y.player_name == comboBox3.SelectedItem).ToArray().Last().player_position.ToString();
            string height = db.players.Where(y => y.player_name == comboBox3.SelectedItem).ToArray().Last().player_height.ToString();
            label1.Text = "Имя: " + comboBox3.SelectedItem + "\nКоманда: " + comboBox4.SelectedItem + "\nСтоимость: " + value + "\nНомер: " + number + "\n" + "Дата рождения: " + birth + "\n" +
                "Позиция: " + position + "\n" + "Рост: " + height;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form5 fr5 = new Form5();
            fr5.Show();
            Hide();
            //comboBox1.Visible = false;
            //comboBox2.Visible = false;
            //comboBox3.Visible = false;
            //comboBox4.Visible = false;
            //label1.Visible = false;
            //dataGridView1.Visible = false;
            //label2.Visible = false;
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Вы вышли. Всего хорошего!");
            Form1 fr1 = new Form1();
            fr1.Show();
            Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string teamname = "";
            string value = db.players.Where(y => y.player_name == textBox1.Text).ToArray().Last().player_value.ToString();
            string number = db.players.Where(y => y.player_name == textBox1.Text).ToArray().Last().player_number.ToString();
            string birth = db.players.Where(y => y.player_name == textBox1.Text).ToArray().Last().player_birth_date.ToShortDateString();
            string position = db.players.Where(y => y.player_name == textBox1.Text).ToArray().Last().player_position.ToString();
            string height = db.players.Where(y => y.player_name == textBox1.Text).ToArray().Last().player_height.ToString();
            string name = db.players.Where(y => y.player_name == textBox1.Text).ToArray().Last().player_name.ToString();
            int team = db.players.Where(y => y.player_name == textBox1.Text).ToArray().Last().player_id_team;

            var teams = db.teams.Where(y => y.id_team == team).Select(y => y.team_name).ToArray();
            foreach (var item in teams)
            {
                teamname = item.ToString();
            }
            label1.Text = "Имя: " + name + "\nКоманда: " + teamname + "\nСтоимость: " + value + "\nНомер: " + number + "\n" + "Дата рождения: " + birth + "\n" +
                "Позиция: " + position + "\n" + "Рост: " + height;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

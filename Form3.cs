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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Model1 db = new Model1();
            String id = db.users.ToArray().Last().id_user.ToString();//считывание последнего id
            int id1 = Convert.ToInt32(id);
            bool flag = false;
            users us = new users//начало добавления
            {
                id_user = id1 + 1,
                user_login = textBox1.Text,
                user_password = textBox2.Text,
                user_is_admin = flag
            };
            db.users.Add(us);
            db.SaveChanges();//конец
            MessageBox.Show("Вы успешно зарегестрированы, система вернет вас на окно входа.");
            Form1 fr1 = new Form1();
            fr1.Show();
            Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

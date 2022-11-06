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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Авторизация";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Model1 db = new Model1();
            string log = textBox1.Text;
            string pas = textBox2.Text;
            if (db.users.Any(x => x.user_login == log))
            {
                if (db.users.Where(x => x.user_login == log).Any(x => x.user_password == pas))
                {
                    if (db.users.Where(y => y.user_login == log).Where(x => x.user_password == pas).Select(y => y.user_is_admin).ToArray().Last() == true)
                    {
                        MessageBox.Show("Вы залогинены как админ");
                        Form4 fr4 = new Form4();
                        fr4.Show();
                        Hide();
                    }
                    else
                    {
                        //MessageBox.Show("Вы залогинены как пользователь");

                        MessageBox.Show("Вы залогинены");
                        Form2 fr2 = new Form2();
                        fr2.Show();
                        Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Неверный пароль");
                }
            }
            else
            {
                MessageBox.Show("Юзера с таким логином нет");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 fr3 = new Form3();
            fr3.Show();
            Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

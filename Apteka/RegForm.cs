using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Apteka
{
    public partial class RegForm : Form
    {
        private AuthForm _authform;
        public RegForm(AuthForm authform)
        {
            _authform = authform;
            InitializeComponent();       

        }

        private void RegForm_Load(object sender, EventArgs e)
        {

        }

        private void AuthField_TextChanged(object sender, EventArgs e)
        {

        }

        private void Passfield_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

            Application.Exit();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(AuthField.Text) || String.IsNullOrEmpty(Passfield.Text))
            {
                MessageBox.Show("Заполните поля.");
            }
            else if (AuthField.Text.Length <= 5)
            {
                MessageBox.Show("Логин должен быть больше 5", "Ошибка");
            }
            else if (Passfield.Text.Length <= 5)
            {
                MessageBox.Show("Пароль должен быть больше 5", "Ошибка");

            }
            else
            {
                DataBase1.command = new NpgsqlCommand($@"SELECT  COUNT(*) FROM auth WHERE login=@Login", DataBase1.conn);
                DataBase1.command.Parameters.AddWithValue("@Login", AuthField.Text.ToLower());
                int count2 = Convert.ToInt32(DataBase1.command.ExecuteScalar());
                
                if (count2 == 1)
                {
                    MessageBox.Show("Логин занят", "Ошибка");
                    
                }
                else
                {
                    DataBase1.command = new NpgsqlCommand("INSERT INTO auth (login, password) VALUES (@Login, @Password)", DataBase1.conn);
                    DataBase1.command.Parameters.AddWithValue("@Login", AuthField.Text.ToLower());
                    DataBase1.command.Parameters.AddWithValue("@Password", Passfield.Text);
                    int count = Convert.ToInt32(DataBase1.command.ExecuteScalar());
                }
                MessageBox.Show("Пользователь Зарегестрирован!");
                this.Visible = false;
                _authform.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            _authform.Visible = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (Passfield.UseSystemPasswordChar == true)
            {
                Passfield.UseSystemPasswordChar = false;
            }
            else
            {
                Passfield.UseSystemPasswordChar = true;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        Point lastPoint2;
        private void RegForm_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint2 = new Point(e.X, e.Y);
        }

        private void RegForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint2.X;
                this.Top += e.Y - lastPoint2.Y;
            }
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }
    }
}

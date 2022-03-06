using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Npgsql;

namespace Apteka
{
    public partial class AuthForm : Form
    {
        private RegForm regform;
        private MainForm mainform;
        public AuthForm()
        {
            InitializeComponent();
            regform = new RegForm(this) { Visible = false };
            mainform = new MainForm(this) { Visible = false };
            string connectionString = "Server = localhost; Port = 5432; User Id = postgres; Password = 3333is79; Database = testing project";
            try
            {
                DataBase1.conn = new Npgsql.NpgsqlConnection(connectionString);
                DataBase1.conn.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }


        }




        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (pass.UseSystemPasswordChar == true)
            {
                pass.UseSystemPasswordChar = false;
            }
            else
            {
                pass.UseSystemPasswordChar = true;
            }
        }

        private void pass_TextChanged(object sender, EventArgs e)
        {

        }

        private void login_TextChanged(object sender, EventArgs e)
        {

        }

        private void AuthForm_Load(object sender, EventArgs e)
        {

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void Vxod_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(login.Text) || String.IsNullOrEmpty(pass.Text))
            {
                MessageBox.Show("Заполните поля.");
            }
            
            DataBase1.command = new NpgsqlCommand($@"SELECT  COUNT(*) FROM auth WHERE Login=@Login AND Password=@Pass", DataBase1.conn);
            DataBase1.command.Parameters.AddWithValue("@Login", login.Text.ToLower());
            DataBase1.command.Parameters.AddWithValue("@Pass", pass.Text);
            int count = Convert.ToInt32(DataBase1.command.ExecuteScalar());
            if (count == 1)
            {
                
                MessageBox.Show("Добро пожаловать!");
                this.Visible = false;
                mainform.Visible = true;

            }
            else
            {
                MessageBox.Show("Ты лысый чорт.", "Ошибка");
            }
        }
    
            
      

    
        Point lastPoint; //Для передвежения формы
        private void AuthForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void AuthForm_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void Registr_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            regform.Visible = true;
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            mainform.Visible = true;
        }

    }
}

using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Apteka
{
    public partial class MainForm : Form
    {
        private AuthForm _authform;
        public MainForm(AuthForm authform)
        {
            _authform = authform;
            InitializeComponent();
        }
        private void apteka_update()
        {
            DataSet datasetmain = new DataSet();

            datasetmain.Tables.Clear();

            DataBase1.command = new Npgsql.NpgsqlCommand("select * from tovar;", DataBase1.conn);

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(DataBase1.command);

            da.Fill(datasetmain, "table1") ;

            datasetmain.Tables[0].Columns[0].ColumnName = "id";
            datasetmain.Tables[0].Columns[1].ColumnName = "Название";
            datasetmain.Tables[0].Columns[2].ColumnName = "Количество";
            datasetmain.Tables[0].Columns[3].ColumnName = "Цена";
            datasetmain.Tables[0].Columns[4].ColumnName = "Тип";
            datasetmain.Tables[0].Columns[5].ColumnName = "Производитель";

            datasetmain.Tables[0].Select("");

            aptekaTable.DataSource = datasetmain.Tables[0].DefaultView;
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tovar_refresh(object sender, EventArgs e)
        {
            apteka_update();
        }

        private void tovar_delete(object sender, EventArgs e)
        {

        }

        private void tovar_add(object sender, EventArgs e)
        {

        }

        private void aptekaTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MainClose_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
        Point lastPoint1;
        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint1 = new Point(e.X, e.Y);
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint1.X;
                this.Top += e.Y - lastPoint1.Y;
            }
        }

        private void FormExit_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            _authform.Visible = true;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}

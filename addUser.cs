using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace curse
{
    public partial class addUser : Form
    {
        public addUser()
        {
            InitializeComponent();
        }

        private void addUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void отчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            makeReport mr = new makeReport();
            mr.Show();
        }

        private void штрафыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            countFine cg = new countFine();
            cg.Show();
        }

        private void журналToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            showJournal sj = new showJournal();
            sj.Show();
        }

        private void возвратКнигиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            returnBook rb = new returnBook();
            rb.Show();
        }

        private void добавитьПользователяToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void книгиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            showBooks sb = new showBooks();
            sb.Show();
        }

        private void клиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            showClients sc = new showClients();
            sc.Show();
        }

        private void addUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            string pna = pName.Text;
            string fna = fName.Text;
            string lna = lName.Text;
            string ps = pSer.Text;
            string pn = pNum.Text;
            MySqlCommand command = new MySqlCommand("SELECT `isUserExists`(@p0, @p1, @p2, @p3, @p4) AS `isUserExists`", db.getConnection());
            command.Parameters.Add("@p0", MySqlDbType.VarChar).Value = fna;
            command.Parameters.Add("@p1", MySqlDbType.VarChar).Value = lna;
            command.Parameters.Add("@p2", MySqlDbType.VarChar).Value = pna;
            command.Parameters.Add("@p3", MySqlDbType.VarChar).Value = ps;
            command.Parameters.Add("@p4", MySqlDbType.VarChar).Value = pn;
            db.openConnection();
            string cnt = command.ExecuteScalar().ToString();
            db.closeConnection();
            if (cnt == "0")
            {
                try
                {
                    command = new MySqlCommand("Insert into `clients` (first_name, last_name, pather_name, passport_seria, passport_num) values(@p0, @p1, @p2, @p3, @p4)", db.getConnection());
                    command.Parameters.Add("@p0", MySqlDbType.VarChar).Value = pna;
                    command.Parameters.Add("@p1", MySqlDbType.VarChar).Value = fna;
                    command.Parameters.Add("@p2", MySqlDbType.VarChar).Value = lna;
                    command.Parameters.Add("@p3", MySqlDbType.VarChar).Value = ps;
                    command.Parameters.Add("@p4", MySqlDbType.VarChar).Value = pn;
                    db.openConnection();
                    command.ExecuteNonQuery();
                    db.closeConnection();
                }
                catch(Exception ex) {
                    MessageBox.Show(ex.ToString());

                }
                MessageBox.Show("новый пользователь добавлен");
            }
            else
            {
                MessageBox.Show("Такой пользователь уже существует");
            }
        }

        private void отчетToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            makeReport mr = new makeReport();
            mr.Show();
        }

        private void штрафыToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            countFine cg = new countFine();
            cg.Show();
        }
    }
}

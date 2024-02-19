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
    public partial class countFine : Form
    {
        public countFine()
        {
            InitializeComponent();
        }

        private void отчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            makeReport mr = new makeReport();
            mr.Show();
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

        private void добавитьКлиентаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            addUser au = new addUser();
            au.Show();
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

        private void countFine_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dateBeg.Format = DateTimePickerFormat.Short;
            dateEnd.Format = DateTimePickerFormat.Short;

            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            string beg = dateBeg.Text;
            string end = dateEnd.Text;
            MySqlCommand command = new MySqlCommand("SELECT `countFineInPer`(@p0, @p1)", db.getConnection());
            command.Parameters.Add("@p0", MySqlDbType.VarChar).Value = beg;
            command.Parameters.Add("@p1", MySqlDbType.VarChar).Value = end;
            string fineSum;
            db.openConnection();
            fineSum = command.ExecuteScalar().ToString();
            db.closeConnection();
            if (fineSum == "")
            {
                MessageBox.Show("0");
            }
            else
            {
                MessageBox.Show(fineSum);
            }
        }
    }
}

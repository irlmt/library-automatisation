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
    public partial class showClients : Form
    {
        public showClients()
        {
            InitializeComponent();
        }

        private void отчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            makeReport mr = new makeReport();
            this.Hide();
            showJournal sj = new showJournal();
            sj.Show(); mr.Show();
        }

        private void штрафыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            countFine cg = new countFine();
            cg.Show();
        }

        private void журналToolStripMenuItem_Click(object sender, EventArgs e)
        {

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

        private void showClients_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `clients`", db.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            clientsTable.DataSource = table;
        }
    }
}

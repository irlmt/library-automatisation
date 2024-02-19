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
    public partial class showBooks : Form
    {
        public showBooks()
        {
            InitializeComponent();
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

        private void добавитьКлиентаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            addUser au = new addUser();
            au.Show();
        }

        private void клиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            showClients sc = new showClients();
            sc.Show();
        }

        private void showBooks_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `books`", db.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataBooks.DataSource = table;
            command = new MySqlCommand("SELECT * FROM `book_types`", db.getConnection());
            MySqlDataAdapter adapter1 = new MySqlDataAdapter();
            DataTable table1 = new DataTable();

            adapter1.SelectCommand = command;
            adapter1.Fill(table1);
            dataBookTypes.DataSource = table1;
        }
    }
}

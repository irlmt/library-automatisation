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
    public partial class returnBook : Form
    {
        public returnBook()
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

        private void returnBook_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            string cl = clientId.Text;
            string booksId = bookId.Text;
            MySqlCommand command = new MySqlCommand("update journal set date_ret = CURRENT_DATE where client_id =@p0 and book_id = @p1", db.getConnection());
            command.Parameters.Add("@p0", MySqlDbType.VarChar).Value = cl;
            command.Parameters.Add("@p1", MySqlDbType.VarChar).Value = booksId;
            db.openConnection();
            command.ExecuteNonQuery();
            db.closeConnection();
            command = new MySqlCommand("CALL `retBook`()", db.getConnection());
            db.openConnection();
            command.ExecuteNonQuery();
            db.closeConnection();
            MessageBox.Show("Книга возвращена");
            command = new MySqlCommand("CALL `updCnt`()", db.getConnection());
            db.openConnection();
            command.ExecuteNonQuery();
            db.closeConnection();
            
        }
    }
}

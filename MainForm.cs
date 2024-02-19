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
using WindowsFormsApp3;

namespace curse
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void отчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            makeReport mr= new makeReport();
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

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();

        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            string cl = clientId.Text;
            MySqlCommand command = new MySqlCommand("SELECT COUNT(*) FROM `journal` WHERE `client_id`=@ic and `date_ret` is null", db.getConnection());
            command.Parameters.Add("@ic", MySqlDbType.VarChar).Value = cl.ToString();
            
            db.openConnection();
            string booksCnt = command.ExecuteScalar().ToString();
            db.closeConnection();
            if (Convert.ToInt32(booksCnt) >= 10)
            {
                MessageBox.Show("have already taken 10 books");
            }
            else
            {
                string booksId = bookId.Text;
                string bcnt = "SELECT cnt from books where id = @bi";
                command = new MySqlCommand(bcnt, db.getConnection());
                command.Parameters.Add("@bi", MySqlDbType.VarChar).Value = booksId;
                db.openConnection();
                booksCnt = command.ExecuteScalar().ToString();
                db.closeConnection();
                if (booksCnt == "0")
                {
                    MessageBox.Show("книга закончилась");
                }
                else
                {
                    command = new MySqlCommand("Insert into `journal` (`book_id`, `client_id`) values(@bi, @ci)", db.getConnection());
                    command.Parameters.Add("@ci", MySqlDbType.VarChar).Value = cl.ToString();
                    command.Parameters.Add("@bi", MySqlDbType.VarChar).Value = booksId.ToString();
                    db.openConnection();
                    command.ExecuteNonQuery();
                    db.closeConnection();
                    command = new MySqlCommand("CALL `setDataEnd`()", db.getConnection());
                    db.openConnection();
                    command.ExecuteNonQuery();
                    db.closeConnection();
                    MessageBox.Show("Книга выдана");
                    command = new MySqlCommand("CALL `updCnt`()", db.getConnection());
                    db.openConnection();
                    command.ExecuteNonQuery();
                    db.closeConnection();
                }

            }
        }

        private void добавитьКлиентаToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            addUser au = new addUser();
            au.Show();
        }

        private void журналToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            showJournal au = new showJournal();
            au.Show();
        }

        private void изменитьДанныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Hide();
            changeData au = new changeData();
            au.Show();
        }

        private void книгиToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            showBooks sb = new showBooks();
            sb.Show();
        }

        private void клиентыToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            showClients sc = new showClients();
            sc.Show();
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

        private void возвратКнигиToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            returnBook rb = new returnBook();
            rb.Show();
        }

        private void сменитьПользователяToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}

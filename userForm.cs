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
    public partial class userForm : Form
    {
        public userForm()
        {
            InitializeComponent();
        }

        private void userForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `books`", db.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataSourceUser.DataSource = table;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            uint cl = Convert.ToUInt32(Form1.id_cl);
            MySqlCommand command = new MySqlCommand("SELECT * FROM `journal` WHERE `client_id`=@ic AND `date_ret` is NULL", db.getConnection());
            command.Parameters.Add("@ic", MySqlDbType.VarChar).Value = cl.ToString();
            adapter.SelectCommand = command;
            adapter.Fill(table);
            userBookToRet.DataSource = table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            string cl = Form1.id_cl;
            MySqlCommand command = new MySqlCommand("SELECT `countUserFineSum`(@ic) AS `countUserFineSum`", db.getConnection());
            command.Parameters.Add("@ic", MySqlDbType.VarChar).Value = cl;
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
        //выдача книги выдать книгу
        private void button2_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            string cl = Form1.id_cl;
            MySqlCommand command = new MySqlCommand("SELECT COUNT(*) FROM `journal` WHERE `client_id`=@ic and `date_ret` is null", db.getConnection());
            command.Parameters.Add("@ic", MySqlDbType.VarChar).Value = cl;
            string booksCnt;
            db.openConnection();
            booksCnt = command.ExecuteScalar().ToString();
            db.closeConnection();
            if (Convert.ToInt32(booksCnt) >= 10)
            {
                MessageBox.Show("U have already taken 10 books");
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
                    command.Parameters.Add("@ci", MySqlDbType.VarChar).Value = cl;
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
    }
}

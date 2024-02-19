using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System.IO;

//using IronXL;
//IronXL.License.LicenseKey = "IRONSUITE.IRELMTT.GMAIL.COM.14849-B43E4EAE4A-EBLS3ZH4RMO526-YRTEB53FBIW3-2OBUXZJE3JDA-MTCLWIFBQQOR-6WVMFXWQZHHM-FDFNXKFTAEMK-V5EWAM-TPTLHYGFM56LEA-DEPLOYMENT.TRIAL-QPFGJT.TRIAL.EXPIRES.07.JAN.2024";
namespace curse
{
    public partial class makeReport : Form
    {
        DataTable dt;
        public makeReport()
        {
            InitializeComponent();
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void makeReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();

        }

        private void makeReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();

        }
        private void ExportToXml(string pathToXmlFile)
        {
            if (dt.Rows.Count > 0)
            {
                try
                {
                    dt.WriteXml(pathToXmlFile);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*DB db = new DB();
            dt = new DataTable();
            //db.openConnection();
            //MySqlCommand command = new MySqlCommand("SELECT * FROM `journal`", db.getConnection());
            //MySqlDataReader sqlReader = command.ExecuteReader();
            //string fileName = @"C:\Users\User\Desktop\labs\db\curse\curse\rep.txt";
            //using (System.IO.StreamWriter writer = new System.IO.StreamWriter(fileName, false, Encoding.UTF8))
            //{
            //    writer.WriteLine("id" + "\t" + "client_id" + "\t" + "book_id" + "\t" + "date_beg" + "\t" + "date_end" + "\t" + "date_ret");
            //    while (sqlReader.Read())
            //    {
            //        writer.WriteLine(sqlReader["id"] + "\t" + sqlReader["client_id"] + "\t" + sqlReader["book_id"] + "\t" + sqlReader["date_beg"] + "\t" + sqlReader["date_end"] + "\t" + sqlReader["date_ret"]);
            //    }
            //}
            //MessageBox.Show("данные выгружены");
            //sqlReader.Close();
            //db.closeConnection();
            string sql = "SELECT * FROM `journal`";

            // Your connection string

            // Open connections to the database
            db.openConnection();
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, db.getConnection());
            DataSet ds = new DataSet();
                // Fill DataSet with data
            adapter.Fill(ds);

            // Create an Excel workbook from the SQL DataSet
            WorkBook workBook = WorkBook.Load(ds);
            workBook.SaveAs("rep.xlsx");
            MessageBox.Show("данные выгружены");*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            dt = new DataTable();
            db.openConnection();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `journal`", db.getConnection());
            MySqlDataReader sqlReader = command.ExecuteReader();
            string fileName = @"C:\Users\User\Desktop\labs\db\curse\curse\rep.txt";
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(fileName, false, Encoding.UTF8))
            {
                writer.WriteLine("id" + "\t" + "client_id" + "\t" + "book_id" + "\t" + "date_beg" + "\t" + "date_end" + "\t" + "date_ret");
                while (sqlReader.Read())
                {
                    writer.WriteLine(sqlReader["id"] + "\t" + sqlReader["client_id"] + "\t" + sqlReader["book_id"] + "\t" + sqlReader["date_beg"] + "\t" + sqlReader["date_end"] + "\t" + sqlReader["date_ret"]);
                }
            }
            MessageBox.Show("данные выгружены");
            sqlReader.Close();
            db.closeConnection();
        }
    }
}

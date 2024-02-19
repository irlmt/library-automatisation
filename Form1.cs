using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace curse
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static string id_cl="2";
        public string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Преобразование байтов хэша в строку
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashedBytes.Length; i++)
                {
                    builder.Append(hashedBytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            String loginUser = textLog.Text;
            String passUser = textPass.Text;
            String ac = cAccess.Text;
            string hashedEnteredPassword = HashPassword(passUser);
            String iJ;
            if (ac == "Админ")
            {
                iJ = "1";
            }
            else if(ac == "Пользователь")
            {
                iJ = "2";
            }
            else
            {
                iJ = "0";
            }
            DB db = new DB();
            DataTable table = new DataTable();
            db.openConnection();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login`=@uL AND `pass` = @uP AND `id_job`=@ij", db.getConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser;
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = hashedEnteredPassword;
            command.Parameters.Add("@ij", MySqlDbType.VarChar).Value = iJ;
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if(table.Rows.Count > 0)
            {
                if (iJ == "1")
                {
                    
                    this.Hide();
                    MainForm mf = new MainForm();
                    mf.Show();
                }
                else if (iJ == "2")
                {
                    MySqlCommand com = new MySqlCommand("SELECT `clientt_id` FROM `users` WHERE `login`=@uL AND `pass` = @uP AND `id_job`=@ij", db.getConnection());
                    com.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser;
                    com.Parameters.Add("@uP", MySqlDbType.VarChar).Value = hashedEnteredPassword;
                    com.Parameters.Add("@ij", MySqlDbType.VarChar).Value = iJ;
                    //dataSourceUser.Rows[0].Cells[0].Value = cl;
                    id_cl = com.ExecuteScalar().ToString();
                    db.closeConnection();
                    this.Hide();
                    userForm mf = new userForm();
                    mf.Text = "User id:" + id_cl;
                    mf.Show();
                }
            }
            else
            {
                MessageBox.Show("No");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            regForm reg = new regForm();
            reg.Show();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}

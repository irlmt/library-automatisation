using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace curse
{
    public partial class regForm : Form
    {
        public regForm()
        {
            InitializeComponent();
        }
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
        private void buttonReg_Click(object sender, EventArgs e)
        {
            if(textLogR.Text == "" || textPassR.Text == "")
            {
                return;
            }
            if (isUserExists())
            {
                MessageBox.Show("такой пользователь уже существует");
                return;
            }
            DB db = new DB();
            string plainPassword = textPassR.Text;
            string hashedPassword = HashPassword(plainPassword);
            MySqlCommand command = new MySqlCommand("INSERT INTO `users` (`login`, `pass`) VALUES (@log, @ps)", db.getConnection());
            command.Parameters.Add("@log", MySqlDbType.VarChar).Value = textLogR.Text;
            command.Parameters.Add("@ps", MySqlDbType.VarChar).Value = hashedPassword;
            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Made new user");
            else
            {
                MessageBox.Show("couldn't make new user");
            }
            db.closeConnection();
        }
        public Boolean isUserExists()
        {
            String loginUser = textLogR.Text;
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login`=@uL", db.getConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser;
            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table.Rows.Count > 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f2 = new Form1();
            f2.Show();
        }

        private void regForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();

        }
    }
}

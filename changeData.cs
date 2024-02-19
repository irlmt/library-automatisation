using curse;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class changeData : Form
    {
        public changeData()
        {
            InitializeComponent();
            label1.Visible= false;
            label2.Visible= false;
            label3.Visible= false;
            label4.Visible= false;
            label5.Visible= false;
            label6.Visible= false;
            textBox1.Visible= false;
            textBox2.Visible= false;
            textBox3.Visible= false;
            textBox4.Visible= false;
            textBox5.Visible= false;
            textBox6.Visible= false;

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string t = comboBox1.Text;
            string o = comboBox2.Text;
            if (t == "journal")
            {
                label1.Text = "id";
                label2.Text = "book_id";
                label3.Text = "client_id";
                label4.Text = "date_beg";
                label5.Text = "date_end";
                label6.Text = "date_ret";
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = true;
            }
            else if (t == "clients")
            {
                label1.Text = "id";
                label2.Text = "first_name";
                label3.Text = "last_name";
                label4.Text = "pather_name";
                label5.Text = "passport_seria";
                label6.Text = "passport_num";
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = true;
            }
            else if (t == "books")
            {
                label1.Text = "id";
                label2.Text = "name";
                label3.Text = "cnt";
                label4.Text = "type_id";
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = false;
                label6.Visible = false;
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = false;
                textBox6.Visible = false;
            }
            if (t == "book_types")
            {
                label1.Text = "id";
                label2.Text = "name";
                label3.Text = "cnt";
                label4.Text = "fine";
                label5.Text = "day_count";
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = false;
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string t = comboBox1.Text;
            string o = comboBox2.Text;
            if (t == "journal")
            {
                if (o == "update")
                {
                    try
                    {
                        DB db = new DB();
                        MySqlCommand command = new MySqlCommand("Update `journal` set book_id = @p1 client_id = @p2 date_beg=@p3 date_end=@p4 date_ret=@p5 WHERE `id`=@p0", db.getConnection());
                        command.Parameters.Add("@p0", MySqlDbType.VarChar).Value = textBox1.Text;
                        command.Parameters.Add("@p1", MySqlDbType.VarChar).Value = textBox2.Text;
                        command.Parameters.Add("@p2", MySqlDbType.VarChar).Value = textBox3.Text;
                        command.Parameters.Add("@p3", MySqlDbType.VarChar).Value = textBox4.Text;
                        command.Parameters.Add("@p4", MySqlDbType.VarChar).Value = textBox5.Text;
                        command.Parameters.Add("@p5", MySqlDbType.VarChar).Value = textBox6.Text;

                        db.openConnection();
                        command.ExecuteNonQuery();
                        db.closeConnection();
                        MessageBox.Show("Data updated");
                    }
                    catch(Exception ex) {
                        MessageBox.Show(ex.Message);
                    }

                }
                else if (o == "delete")
                {
                    try
                    {
                        DB db = new DB();
                        MySqlCommand command = new MySqlCommand("DELETE `journal` WHERE `id`=@p0", db.getConnection());
                        command.Parameters.Add("@p0", MySqlDbType.VarChar).Value = textBox1.Text;

                        db.openConnection();
                        command.ExecuteNonQuery();
                        db.closeConnection();
                        MessageBox.Show("Data deleted");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (o == "insert")
                {
                    try
                    {
                        DB db = new DB();
                        MySqlCommand command = new MySqlCommand("Insert into `journal`(book_id, client_id, date_beg, date_end, date_ret) VALUES(@p1, @p2, @p3, @p4, @p5)", db.getConnection());
                        command.Parameters.Add("@p1", MySqlDbType.VarChar).Value = textBox2.Text;
                        command.Parameters.Add("@p2", MySqlDbType.VarChar).Value = textBox3.Text;
                        command.Parameters.Add("@p3", MySqlDbType.VarChar).Value = textBox4.Text;
                        command.Parameters.Add("@p4", MySqlDbType.VarChar).Value = textBox5.Text;
                        command.Parameters.Add("@p5", MySqlDbType.VarChar).Value = textBox6.Text;

                        db.openConnection();
                        command.ExecuteNonQuery();
                        db.closeConnection();
                        MessageBox.Show("Data inserted");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else if (t == "clients")
            {
                if (o == "update")
                {
                    try
                    {
                        DB db = new DB();
                        MySqlCommand command = new MySqlCommand("Update `clients` set first_name = @p1 last_name = @p2 pather_name=@p3 passport_seria=@p4 passport_num=@p5 WHERE `id`=@p0", db.getConnection());
                        command.Parameters.Add("@p0", MySqlDbType.VarChar).Value = textBox1.Text;
                        command.Parameters.Add("@p1", MySqlDbType.VarChar).Value = textBox2.Text;
                        command.Parameters.Add("@p2", MySqlDbType.VarChar).Value = textBox3.Text;
                        command.Parameters.Add("@p3", MySqlDbType.VarChar).Value = textBox4.Text;
                        command.Parameters.Add("@p4", MySqlDbType.VarChar).Value = textBox5.Text;
                        command.Parameters.Add("@p5", MySqlDbType.VarChar).Value = textBox6.Text;

                        db.openConnection();
                        command.ExecuteNonQuery();
                        db.closeConnection();
                        MessageBox.Show("Data updated");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (o == "delete")
                {
                    try
                    {
                        DB db = new DB();
                        MySqlCommand command = new MySqlCommand("DELETE `clients` WHERE `id`=@p0", db.getConnection());
                        command.Parameters.Add("@p0", MySqlDbType.VarChar).Value = textBox1.Text;

                        db.openConnection();
                        command.ExecuteNonQuery();
                        db.closeConnection();
                        MessageBox.Show("Data deleted");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (o == "insert")
                {
                    try
                    {
                        DB db = new DB();
                        MySqlCommand command = new MySqlCommand("Insert into `clients`(first_name, last_name, pather_name, passport_seria, passport_num) VALUES(@p1, @p2, @p3, @p4, @p5)", db.getConnection());
                        command.Parameters.Add("@p1", MySqlDbType.VarChar).Value = textBox2.Text;
                        command.Parameters.Add("@p2", MySqlDbType.VarChar).Value = textBox3.Text;
                        command.Parameters.Add("@p3", MySqlDbType.VarChar).Value = textBox4.Text;
                        command.Parameters.Add("@p4", MySqlDbType.VarChar).Value = textBox5.Text;
                        command.Parameters.Add("@p5", MySqlDbType.VarChar).Value = textBox6.Text;

                        db.openConnection();
                        command.ExecuteNonQuery();
                        db.closeConnection();
                        MessageBox.Show("Data inserted");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else if (t == "books")
            {
                if (o == "update")
                {
                    try
                    {
                        DB db = new DB();
                        MySqlCommand command = new MySqlCommand("Update `books` set name = @p1 cnt = @p2 type_id=@p3 WHERE `id`=@p0", db.getConnection());
                        command.Parameters.Add("@p0", MySqlDbType.VarChar).Value = textBox1.Text;
                        command.Parameters.Add("@p1", MySqlDbType.VarChar).Value = textBox2.Text;
                        command.Parameters.Add("@p2", MySqlDbType.VarChar).Value = textBox3.Text;
                        command.Parameters.Add("@p3", MySqlDbType.VarChar).Value = textBox4.Text;

                        db.openConnection();
                        command.ExecuteNonQuery();
                        db.closeConnection();
                        MessageBox.Show("Data updated");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (o == "delete")
                {
                    try
                    {
                        DB db = new DB();
                        MySqlCommand command = new MySqlCommand("DELETE `books` WHERE `id`=@p0", db.getConnection());
                        command.Parameters.Add("@p0", MySqlDbType.VarChar).Value = textBox1.Text;

                        db.openConnection();
                        command.ExecuteNonQuery();
                        db.closeConnection();
                        MessageBox.Show("Data deleted");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (o == "insert")
                {
                    try
                    {
                        DB db = new DB();
                        MySqlCommand command = new MySqlCommand("Insert into `books`(name, cnt, type_id) VALUES(@p1, @p2, @p3)", db.getConnection());
                        command.Parameters.Add("@p1", MySqlDbType.VarChar).Value = textBox2.Text;
                        command.Parameters.Add("@p2", MySqlDbType.VarChar).Value = textBox3.Text;
                        command.Parameters.Add("@p3", MySqlDbType.VarChar).Value = textBox4.Text;

                        db.openConnection();
                        command.ExecuteNonQuery();
                        db.closeConnection();
                        MessageBox.Show("Data inserted");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            if (t == "book_types")
            {
                if (o == "update")
                {
                    try
                    {
                        DB db = new DB();
                        MySqlCommand command = new MySqlCommand("Update `book_types` set name = @p1 cnt = @p2 fine=@p3 day_count=@p4 WHERE `id`=@p0", db.getConnection());
                        command.Parameters.Add("@p0", MySqlDbType.VarChar).Value = textBox1.Text;
                        command.Parameters.Add("@p1", MySqlDbType.VarChar).Value = textBox2.Text;
                        command.Parameters.Add("@p2", MySqlDbType.VarChar).Value = textBox3.Text;
                        command.Parameters.Add("@p3", MySqlDbType.VarChar).Value = textBox4.Text;
                        command.Parameters.Add("@p4", MySqlDbType.VarChar).Value = textBox5.Text;

                        db.openConnection();
                        command.ExecuteNonQuery();
                        db.closeConnection();
                        MessageBox.Show("Data updated");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (o == "delete")
                {
                    try
                    {
                        DB db = new DB();
                        MySqlCommand command = new MySqlCommand("DELETE `book_types` WHERE `id`=@p0", db.getConnection());
                        command.Parameters.Add("@p0", MySqlDbType.VarChar).Value = textBox1.Text;

                        db.openConnection();
                        command.ExecuteNonQuery();
                        db.closeConnection();
                        MessageBox.Show("Data deleted");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (o == "insert")
                {
                    try
                    {
                        DB db = new DB();
                        MySqlCommand command = new MySqlCommand("Insert into `book_types`(name, cnt, fine, day_count) VALUES(@p1, @p2, @p3, @p4)", db.getConnection());
                        command.Parameters.Add("@p1", MySqlDbType.VarChar).Value = textBox2.Text;
                        command.Parameters.Add("@p2", MySqlDbType.VarChar).Value = textBox3.Text;
                        command.Parameters.Add("@p3", MySqlDbType.VarChar).Value = textBox4.Text;
                        command.Parameters.Add("@p4", MySqlDbType.VarChar).Value = textBox5.Text;

                        db.openConnection();
                        command.ExecuteNonQuery();
                        db.closeConnection();
                        MessageBox.Show("Data inserted");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using TrabalhoPOO;

namespace TrabalhoPOOwinforms
{
    public partial class Forms2 : Form
    {
        RegisterClass registerClass = new RegisterClass();

        public Forms2()
        {
            InitializeComponent();
        }


        public class RegisterClass
        {
            string connectingString = "Data Source=JOELFARIA\\SQLEXPRESS;Initial Catalog=LoginApp;Integrated Security=True;TrustServerCertificate=True";
            string query = "INSERT INTO LoginTable (username, password, email) VALUES (@Username, @Password, @Email)";

            public void RegisterUser(User user)
            {
                using (SqlConnection con = new SqlConnection(connectingString))
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Username", user.nomeUser);
                    cmd.Parameters.AddWithValue("@Password", user.PasswordUser);
                    cmd.Parameters.AddWithValue("@Email", user.emailUser);
                    int a = Convert.ToInt32(cmd.ExecuteScalar());

                    if (a > 0)
                    {
                        MessageBox.Show("User already exists!");
                    }
                    else
                    {
                        try
                        {
                            con.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("User registered successfully!");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                    }

                }
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox3.Text;
            string email = textBox2.Text;

            User user = new User(username, email, password);

            registerClass.RegisterUser(user);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox3.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();

            login.FormClosed += (s, args) => this.Close();
        }
    }
}

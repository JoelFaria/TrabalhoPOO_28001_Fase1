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
            private string con = "Data Source=JOELFARIA\\SQLEXPRESS;Initial Catalog=LoginApp;Integrated Security=True;TrustServerCertificate=True";

            public bool RegisterUser(Usuario usuario)
            {
                using (SqlConnection conn = new SqlConnection(con))
                {
                    conn.Open();
                    string query = "INSERT INTO LoginTable (username, password, email) VALUES (@Username, @Password, @Email)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Username", usuario.nomeUsuario);
                    cmd.Parameters.AddWithValue("@Password", usuario.Senha);

                    int count = (int)cmd.ExecuteScalar();

                    return count > 0;

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

            Usuario usuario = new Usuario(username, password);

            bool register = registerClass.RegisterUser(usuario);

            if (register) 
            {
                MessageBox.Show("Register Successful!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Login login = new Login();
                login.Show();
                this.Hide();

                login.FormClosed += (s, args) => this.Close();
            }
            else
            {
                MessageBox.Show("Register Failed!");
            }


            //string Username = textBox1.Text;
            //string Email = textBox2.Text;
            //string Password = textBox3.Text;

            //if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
            //{
            //    MessageBox.Show("Please fill all the fields!");
            //}
            //else
            //{

            //    SqlConnection con = new SqlConnection("Data Source=JOELFARIA\\SQLEXPRESS;Initial Catalog=LoginApp;Integrated Security=True;TrustServerCertificate=True");
            //    con.Open();
            //    string query = "INSERT INTO LoginTable (username, password, email) VALUES (@Username, @Password, @Email)";
            //    SqlCommand cmd = new SqlCommand(query, con);
            //    cmd.Parameters.AddWithValue("@Username", Username);
            //    cmd.Parameters.AddWithValue("@Password", Password);
            //    cmd.Parameters.AddWithValue("@Email", Email);
            //    int count = cmd.ExecuteNonQuery();
            //    con.Close();
            //    if (count > 0)
            //    {
            //        MessageBox.Show("Register Successful!", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        Login login = new Login();
            //        login.Show();
            //        this.Hide();

            //        login.FormClosed += (s, args) => this.Close();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Register Failed!");
            //    }
            //}

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

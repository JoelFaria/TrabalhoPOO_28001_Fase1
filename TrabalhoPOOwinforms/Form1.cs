using Microsoft.Data.SqlClient;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Drawing;

namespace TrabalhoPOOwinforms
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtPass.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "admin" && txtPass.Text == "admin")
            {
                MessageBox.Show("Admin login successful!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Abre a tela de administrador
                AdminForm adminForm = new AdminForm();
                adminForm.Show();
                this.Hide();

                // Fecha o formulário de login quando o AdminForm for fechado
                adminForm.FormClosed += (s, args) => this.Close();
                return;
            }

            SqlConnection con = new SqlConnection("Data Source=JOELFARIA\\SQLEXPRESS;Initial Catalog=LoginApp;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            string query = "SELECT COUNT(*) FROM LoginTable WHERE username=@Username AND password=@Password";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Username", txtUser.Text);
            cmd.Parameters.AddWithValue("@Password", txtPass.Text);
            int count = (int)cmd.ExecuteScalar();
            con.Close();
            if (count > 0)
            {
                MessageBox.Show("Login Successful!", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Items items = new Items();
                items.Show();
                this.Hide();

                items.FormClosed += (s, args) => this.Close();
            }
            else
            {
                MessageBox.Show("Login Failed!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Forms2 forms2 = new Forms2();
            forms2.Show();
            this.Hide();

            forms2.FormClosed += (s, args) => this.Close();
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

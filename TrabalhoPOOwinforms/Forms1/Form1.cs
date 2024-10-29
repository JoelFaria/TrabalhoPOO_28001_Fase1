using Microsoft.Data.SqlClient;
using System.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Drawing;
using TrabalhoPOO;

namespace TrabalhoPOOwinforms
{
    public partial class Login : Form
    {
        private LoginClass loginClass = new LoginClass();

        public Login()
        {
            InitializeComponent();
        }


        public class LoginClass
        {
            private string con = "Data Source=JOELFARIA\\SQLEXPRESS;Initial Catalog=LoginApp;Integrated Security=True;TrustServerCertificate=True";
            
            public bool ValidarLogin(Usuario usuario)
            {

                using(SqlConnection conn = new SqlConnection(con))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM LoginTable WHERE username=@Username AND password=@Password";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Username", usuario.nomeUsuario);
                    cmd.Parameters.AddWithValue("@Password", usuario.Senha);

                    int count = (int)cmd.ExecuteScalar();

                    return count > 0;
                }    
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtPass.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }
        private void button1_Click(object sender, EventArgs e)
        {

            string username = txtUser.Text;
            string password = txtPass.Text;

            Usuario usuario = new Usuario(username, password);

            bool ValidarLogin = loginClass.ValidarLogin(usuario);

            if (ValidarLogin)
            {

                if (username == "admin" && password == "admin")
                {
                    MessageBox.Show("Admin login successful!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Abre a tela de administrador
                    AdminForm adminForm = new AdminForm();
                    adminForm.Show();

                    // Fecha o formulário de login quando o AdminForm for fechado
                    adminForm.FormClosed += (s, args) => this.Close();
                    return;
                }
                else
                {
                    Items items = new Items();
                    items.Show();

                }
                this.Hide();
            }
            else
            {
                MessageBox.Show("Login failed!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

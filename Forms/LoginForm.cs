using discos.Data;
using discos.Forms;
using MySqlConnector;
using System;
using System.Data;
using System.Windows.Forms;

namespace discos2
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            textPass.UseSystemPasswordChar = true;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string user = textLogin.Text.Trim();
            string pass = textPass.Text.Trim();

            if (string.IsNullOrEmpty(user) ||
                string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("Preencha todos os campos!");
                return;
            }

            try
            {
                var logins = Database.ListarLogins();

                foreach (var login in logins)
                {
                    if (login.Username == user && login.Password == pass)
                    {
                        this.Hide();
                        MainForm form = new MainForm();
                        form.Show();
                    } else
                    {
                        MessageBox.Show("Utilizador ou senha incorretos!");
                        textPass.Clear();
                        textPass.Focus();
                    }
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
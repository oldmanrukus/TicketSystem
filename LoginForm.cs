using System;
using System.Windows.Forms;

namespace TicketingSystem
{
    public partial class LoginForm : Form
    {
        public User CurrentUser { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Validate user using DataAccess (for simplicity, plain text is used)
            User user = DataAccess.ValidateUser(username, password);
            if (user != null)
            {
                CurrentUser = user;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid credentials. Please try again.", "Login Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

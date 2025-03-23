using System;
using System.Data;
using System.Windows.Forms;

namespace TicketingSystem
{
    public partial class AddUserForm : Form
    {
        public AddUserForm()
        {
            InitializeComponent();
            // Populate the role combo box.
            comboRole.Items.Add("Admin");
            comboRole.Items.Add("SupportAgent");
            comboRole.Items.Add("Client");
            comboRole.SelectedIndex = 0;

            // Initially disable client selection since the default role is not "Client"
            comboClient.Enabled = false;

            // Load the clients list into the combo box.
            LoadClients();
        }

        private void LoadClients()
        {
            // Retrieve the clients from the database.
            DataTable dtClients = DataAccess.GetClients();
            comboClient.DataSource = dtClients;
            comboClient.DisplayMember = "Name";      // Display the client name.
            comboClient.ValueMember = "ClientID";      // The underlying value is ClientID.
        }

        private void comboRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Enable the client selector only if the selected role is "Client".
            if (comboRole.SelectedItem.ToString() == "Client")
            {
                comboClient.Enabled = true;
            }
            else
            {
                comboClient.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validate the username and password.
            if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Username and Password are required.", "Input Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int? clientID = null;
            if (comboRole.SelectedItem.ToString() == "Client")
            {
                if (comboClient.SelectedValue != null)
                {
                    clientID = Convert.ToInt32(comboClient.SelectedValue);
                }
                else
                {
                    MessageBox.Show("Please select a client.", "Input Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            try
            {
                bool success = DataAccess.InsertUser(
                    txtUsername.Text.Trim(),
                    txtPassword.Text.Trim(),
                    comboRole.SelectedItem.ToString(),
                    clientID);

                if (success)
                {
                    MessageBox.Show("User added successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to add user.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Exception",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

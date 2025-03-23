using System;
using System.Data;
using System.Windows.Forms;

namespace TicketingSystem
{
    public partial class EditUserForm : Form
    {
        private User userToEdit;

        public EditUserForm(User user)
        {
            InitializeComponent();
            userToEdit = user;
            PopulateFields();
            LoadClients();
            PopulateRoles();
        }

        private void PopulateFields()
        {
            txtUsername.Text = userToEdit.Username;
            // For security, the password field is left blank.
            comboRole.SelectedItem = userToEdit.Role;
            if (userToEdit.ClientID.HasValue)
            {
                comboClient.SelectedValue = userToEdit.ClientID.Value;
            }
        }

        private void LoadClients()
        {
            DataTable dtClients = DataAccess.GetClients();
            comboClient.DataSource = dtClients;
            comboClient.DisplayMember = "Name";
            comboClient.ValueMember = "ClientID";
        }

        private void PopulateRoles()
        {
            comboRole.Items.Clear();
            comboRole.Items.Add("Admin");
            comboRole.Items.Add("SupportAgent");
            comboRole.Items.Add("Client");
            comboRole.SelectedItem = userToEdit.Role;
        }

        private void comboRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Enable the client selector only if the selected role is "Client"
            comboClient.Enabled = (comboRole.SelectedItem.ToString() == "Client");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Username is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Update user object.
            userToEdit.Username = txtUsername.Text.Trim();
            userToEdit.Role = comboRole.SelectedItem.ToString();
            if (userToEdit.Role == "Client")
            {
                userToEdit.ClientID = Convert.ToInt32(comboClient.SelectedValue);
            }
            else
            {
                userToEdit.ClientID = null;
            }
            // Get new password (required in this demo).
            string newPassword = txtPassword.Text.Trim();
            if (string.IsNullOrWhiteSpace(newPassword))
            {
                MessageBox.Show("Please enter a new password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool success = DataAccess.UpdateUser(userToEdit, newPassword);
            if (success)
            {
                MessageBox.Show("User updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to update user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

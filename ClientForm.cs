using System;
using System.Windows.Forms;

namespace TicketingSystem
{
    public partial class ClientForm : Form
    {
        private Client _client; // If null, we're adding a new client; otherwise, editing.

        // Constructor for adding a new client.
        public ClientForm()
        {
            InitializeComponent();
            this.Text = "Add New Client";
        }

        // Constructor for editing an existing client.
        public ClientForm(Client client) : this()
        {
            _client = client;
            this.Text = "Edit Client";
            PopulateFields();
        }

        private void PopulateFields()
        {
            if (_client != null)
            {
                txtName.Text = _client.Name;
                txtEmail.Text = _client.Email;
                txtPhone.Text = _client.Phone;
                txtAddress.Text = _client.Address;
                txtNotes.Text = _client.Notes;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validate required fields.
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Name and Email are required.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_client == null)
            {
                // Add new client.
                Client newClient = new Client
                {
                    Name = txtName.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Phone = txtPhone.Text.Trim(),
                    Address = txtAddress.Text.Trim(),
                    Notes = txtNotes.Text.Trim()
                };

                try
                {
                    bool success = DataAccess.InsertClient(newClient);
                    if (success)
                    {
                        MessageBox.Show("Client created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Failed to create client.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Update existing client.
                _client.Name = txtName.Text.Trim();
                _client.Email = txtEmail.Text.Trim();
                _client.Phone = txtPhone.Text.Trim();
                _client.Address = txtAddress.Text.Trim();
                _client.Notes = txtNotes.Text.Trim();

                try
                {
                    bool success = DataAccess.UpdateClient(_client);
                    if (success)
                    {
                        MessageBox.Show("Client updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Failed to update client.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

using System;
using System.Data;
using System.Windows.Forms;

namespace TicketingSystem
{
    public partial class TicketForm : Form
    {
        private User currentUser;
        private int ticketId = 0; // 0 = new ticket; >0 means editing an existing ticket.
        private bool isResolved = false;

        public TicketForm(User user, int ticketId = 0)
        {
            InitializeComponent();
            currentUser = user;
            this.ticketId = ticketId;
            LoadClients();

            if (ticketId > 0)
            {
                LoadTicketData(ticketId);
            }
            else
            {
                comboStatus.SelectedItem = "Open";
                EnableEditing(true);
            }
        }

        private void LoadClients()
        {
            DataTable dtClients = DataAccess.GetClients();
            comboClient.DataSource = dtClients;
            comboClient.DisplayMember = "Name";
            comboClient.ValueMember = "ClientID";

            if (currentUser.Role == "Client")
            {
                comboClient.SelectedValue = currentUser.ClientID;
                comboClient.Enabled = false;
            }
        }

        private void LoadTicketData(int ticketId)
        {
            DataRow ticketRow = DataAccess.GetTicketById(ticketId);
            if (ticketRow != null)
            {
                comboClient.SelectedValue = Convert.ToInt32(ticketRow["ClientID"]);
                txtTitle.Text = ticketRow["Title"].ToString();
                txtDescription.Text = ticketRow["Description"].ToString();
                comboStatus.SelectedItem = ticketRow["Status"].ToString();
                comboPriority.SelectedItem = ticketRow["Priority"].ToString();
                txtResolutionComment.Text = ticketRow["ResolutionNote"] != DBNull.Value ? ticketRow["ResolutionNote"].ToString() : "";

                if (ticketRow["Status"].ToString() == "Resolved")
                {
                    isResolved = true;
                    EnableEditing(false);
                }
                else
                {
                    isResolved = false;
                    EnableEditing(true);
                }
            }
            else
            {
                MessageBox.Show("Ticket data not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EnableEditing(bool enable)
        {
            comboClient.Enabled = enable && (currentUser.Role != "Client");
            txtTitle.ReadOnly = !enable;
            txtDescription.ReadOnly = !enable;
            comboStatus.Enabled = enable;
            comboPriority.Enabled = enable;
            txtResolutionComment.ReadOnly = !enable;

            btnReopenTicket.Visible = !enable && isResolved;
            btnCloseTicket.Enabled = enable;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text) || string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Title and Description are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int clientID = Convert.ToInt32(comboClient.SelectedValue);
            if (ticketId == 0)
            {
                // Insert new ticket.
                bool success = DataAccess.InsertTicket(clientID, txtTitle.Text.Trim(), txtDescription.Text.Trim(),
                                                         comboStatus.SelectedItem.ToString(), comboPriority.SelectedItem.ToString());
                if (success)
                {
                    MessageBox.Show("Ticket created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to create ticket.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Update existing ticket.
                bool success = DataAccess.UpdateTicket(ticketId, clientID, txtTitle.Text.Trim(), txtDescription.Text.Trim(),
                                                         comboStatus.SelectedItem.ToString(), comboPriority.SelectedItem.ToString());
                if (success)
                {
                    MessageBox.Show("Ticket updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to update ticket.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCloseTicket_Click(object sender, EventArgs e)
        {
            if (ticketId == 0)
            {
                MessageBox.Show("Ticket must be created before it can be closed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtResolutionComment.Text))
            {
                MessageBox.Show("Please enter a resolution comment to close the ticket.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool success = DataAccess.UpdateTicketClose(ticketId, txtResolutionComment.Text.Trim());
            if (success)
            {
                MessageBox.Show("Ticket closed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                isResolved = true;
                EnableEditing(false);
            }
            else
            {
                MessageBox.Show("Failed to close ticket.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReopenTicket_Click(object sender, EventArgs e)
        {
            if (ticketId == 0)
            {
                MessageBox.Show("Ticket must be created before it can be reopened.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool success = DataAccess.UpdateTicketReopen(ticketId);
            if (success)
            {
                MessageBox.Show("Ticket reopened successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                isResolved = false;
                EnableEditing(true);
            }
            else
            {
                MessageBox.Show("Failed to reopen ticket.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

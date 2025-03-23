using System;
using System.Data;
using System.Windows.Forms;

namespace TicketingSystem
{
    public partial class MainForm : Form
    {
        private User currentUser;

        public MainForm(User user)
        {
            InitializeComponent();
            currentUser = user;
            SetupUI();
            LoadData();

            // Attach double-click events
            dgvTickets.CellDoubleClick += dgvTickets_CellDoubleClick;
            dgvClients.CellDoubleClick += dgvClients_CellDoubleClick;
            dgvUsers.CellDoubleClick += dgvUsers_CellDoubleClick;
        }

        /// <summary>
        /// Configures which Admin tab buttons are visible based on user role.
        /// </summary>
        private void SetupUI()
        {
            // In the Admin tab, display buttons based on the logged-in user's role.
            if (currentUser.Role == "Admin")
            {
                btnAddUser.Visible = true;
                btnAddClient.Visible = true;
                btnNewTicket.Visible = true;
            }
            else if (currentUser.Role == "SupportAgent")
            {
                btnAddUser.Visible = false;
                btnAddClient.Visible = true;
                btnNewTicket.Visible = true;
            }
            else if (currentUser.Role == "Client")
            {
                btnAddUser.Visible = false;
                btnAddClient.Visible = false;
                btnNewTicket.Visible = true;
            }
        }

        /// <summary>
        /// Loads data for tickets, clients, and (if admin) users.
        /// </summary>
        private void LoadData()
        {
            // Load tickets into the Tickets tab.
            DataTable dtTickets = DataAccess.GetTickets(currentUser);
            dgvTickets.DataSource = dtTickets;

            // Load clients into the Clients tab for Admin/SupportAgent.
            if (currentUser.Role == "Admin" || currentUser.Role == "SupportAgent")
            {
                DataTable dtClients = DataAccess.GetClients();
                dgvClients.DataSource = dtClients;
            }

            // Load users into the Admin tab if the current user is an admin.
            if (currentUser.Role == "Admin")
            {
                LoadUsers();
            }
        }

        /// <summary>
        /// Loads users from the database into dgvUsers.
        /// </summary>
        private void LoadUsers()
        {
            DataTable dtUsers = DataAccess.GetUsers();
            dgvUsers.DataSource = dtUsers;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        /// <summary>
        /// Opens ClientForm in "Add New" mode.
        /// </summary>
        private void btnAddClient_Click(object sender, EventArgs e)
        {
            using (ClientForm clientForm = new ClientForm())
            {
                if (clientForm.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        /// <summary>
        /// Opens AddUserForm in "Add New" mode.
        /// </summary>
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            using (AddUserForm addUserForm = new AddUserForm())
            {
                if (addUserForm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("User added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUsers();
                }
            }
        }

        /// <summary>
        /// Opens TicketForm in "New Ticket" mode.
        /// </summary>
        private void btnNewTicket_Click(object sender, EventArgs e)
        {
            using (TicketForm ticketForm = new TicketForm(currentUser))
            {
                if (ticketForm.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        /// <summary>
        /// Opens TicketForm for editing when a ticket row is double-clicked.
        /// </summary>
        private void dgvTickets_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int ticketId = Convert.ToInt32(dgvTickets.Rows[e.RowIndex].Cells["TicketID"].Value);
                using (TicketForm ticketForm = new TicketForm(currentUser, ticketId))
                {
                    if (ticketForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
        }

        /// <summary>
        /// Opens ClientForm in edit mode when a client row is double-clicked.
        /// </summary>
        private void dgvClients_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvClients.Rows[e.RowIndex];
                Client client = new Client
                {
                    ClientID = Convert.ToInt32(row.Cells["ClientID"].Value),
                    Name = row.Cells["Name"].Value.ToString(),
                    Email = row.Cells["Email"].Value.ToString(),
                    Phone = row.Cells["Phone"].Value.ToString(),
                    Address = row.Cells["Address"].Value.ToString(),
                    Notes = row.Cells["Notes"] != null && row.Cells["Notes"].Value != null ? row.Cells["Notes"].Value.ToString() : ""
                };

                using (ClientForm clientForm = new ClientForm(client))
                {
                    if (clientForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
        }

        /// <summary>
        /// Opens EditUserForm when a user row is double-clicked.
        /// </summary>
        private void dgvUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvUsers.Rows[e.RowIndex];
                User user = new User
                {
                    UserID = Convert.ToInt32(row.Cells["UserID"].Value),
                    Username = row.Cells["Username"].Value.ToString(),
                    Role = row.Cells["RoleName"].Value.ToString(),
                    ClientID = row.Cells["ClientID"].Value != DBNull.Value ? (int?)Convert.ToInt32(row.Cells["ClientID"].Value) : null
                };

                using (EditUserForm editUserForm = new EditUserForm(user))
                {
                    if (editUserForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadUsers();
                    }
                }
            }
        }

        /// <summary>
        /// Runs ChatGPT analysis based on current ticket data.
        /// </summary>
        private async void btnRunAnalysis_Click(object sender, EventArgs e)
        {
            string summary = "Monthly Summary:\n" +
                             $"Total Tickets: {dgvTickets.Rows.Count}\n";
            string apiKey = txtApiKey.Text.Trim();
            if (string.IsNullOrEmpty(apiKey))
            {
                MessageBox.Show("Please enter your OpenAI API key.", "API Key Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string analysis = await ChatGPTIntegration.GetAnalysisAsync(apiKey, summary);
                txtAnalysisResult.Text = analysis;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error calling ChatGPT API: " + ex.Message, "API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

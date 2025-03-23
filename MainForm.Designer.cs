namespace TicketingSystem
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageTickets;
        private System.Windows.Forms.TabPage tabPageClients;
        private System.Windows.Forms.TabPage tabPageAnalytics;
        private System.Windows.Forms.TabPage tabPageAdmin;

        // Tickets tab controls
        private System.Windows.Forms.DataGridView dgvTickets;
        private System.Windows.Forms.Button btnRefresh;

        // Clients tab controls
        private System.Windows.Forms.DataGridView dgvClients;

        // Analytics tab controls
        private System.Windows.Forms.Label lblApiKey;
        private System.Windows.Forms.TextBox txtApiKey;
        private System.Windows.Forms.Button btnRunAnalysis;
        private System.Windows.Forms.TextBox txtAnalysisResult;

        // Admin tab controls
        private System.Windows.Forms.Panel panelAdminButtons;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnAddClient;
        private System.Windows.Forms.Button btnNewTicket;
        private System.Windows.Forms.DataGridView dgvUsers;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageTickets = new System.Windows.Forms.TabPage();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dgvTickets = new System.Windows.Forms.DataGridView();
            this.tabPageClients = new System.Windows.Forms.TabPage();
            this.dgvClients = new System.Windows.Forms.DataGridView();
            this.tabPageAnalytics = new System.Windows.Forms.TabPage();
            this.lblApiKey = new System.Windows.Forms.Label();
            this.txtApiKey = new System.Windows.Forms.TextBox();
            this.btnRunAnalysis = new System.Windows.Forms.Button();
            this.txtAnalysisResult = new System.Windows.Forms.TextBox();
            this.tabPageAdmin = new System.Windows.Forms.TabPage();
            this.panelAdminButtons = new System.Windows.Forms.Panel();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnAddClient = new System.Windows.Forms.Button();
            this.btnNewTicket = new System.Windows.Forms.Button();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPageTickets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTickets)).BeginInit();
            this.tabPageClients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).BeginInit();
            this.tabPageAnalytics.SuspendLayout();
            this.tabPageAdmin.SuspendLayout();
            this.panelAdminButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageTickets);
            this.tabControl1.Controls.Add(this.tabPageClients);
            this.tabControl1.Controls.Add(this.tabPageAnalytics);
            this.tabControl1.Controls.Add(this.tabPageAdmin);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 450);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageTickets
            // 
            this.tabPageTickets.Controls.Add(this.btnRefresh);
            this.tabPageTickets.Controls.Add(this.dgvTickets);
            this.tabPageTickets.Location = new System.Drawing.Point(4, 22);
            this.tabPageTickets.Name = "tabPageTickets";
            this.tabPageTickets.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTickets.Size = new System.Drawing.Size(792, 424);
            this.tabPageTickets.TabIndex = 0;
            this.tabPageTickets.Text = "Tickets";
            this.tabPageTickets.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(711, 372);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 46);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "Refresh Data";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dgvTickets
            // 
            this.dgvTickets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                                                            | System.Windows.Forms.AnchorStyles.Left)
                                                                           | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTickets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTickets.Location = new System.Drawing.Point(6, 6);
            this.dgvTickets.Name = "dgvTickets";
            this.dgvTickets.Size = new System.Drawing.Size(780, 360);
            this.dgvTickets.TabIndex = 1;
            // 
            // tabPageClients
            // 
            this.tabPageClients.Controls.Add(this.dgvClients);
            this.tabPageClients.Location = new System.Drawing.Point(4, 22);
            this.tabPageClients.Name = "tabPageClients";
            this.tabPageClients.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageClients.Size = new System.Drawing.Size(792, 424);
            this.tabPageClients.TabIndex = 1;
            this.tabPageClients.Text = "Clients";
            this.tabPageClients.UseVisualStyleBackColor = true;
            // 
            // dgvClients
            // 
            this.dgvClients.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                                                            | System.Windows.Forms.AnchorStyles.Left)
                                                                           | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClients.Location = new System.Drawing.Point(6, 6);
            this.dgvClients.Name = "dgvClients";
            this.dgvClients.Size = new System.Drawing.Size(780, 412);
            this.dgvClients.TabIndex = 0;
            // 
            // tabPageAnalytics
            // 
            this.tabPageAnalytics.Controls.Add(this.txtAnalysisResult);
            this.tabPageAnalytics.Controls.Add(this.btnRunAnalysis);
            this.tabPageAnalytics.Controls.Add(this.txtApiKey);
            this.tabPageAnalytics.Controls.Add(this.lblApiKey);
            this.tabPageAnalytics.Location = new System.Drawing.Point(4, 22);
            this.tabPageAnalytics.Name = "tabPageAnalytics";
            this.tabPageAnalytics.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAnalytics.Size = new System.Drawing.Size(792, 424);
            this.tabPageAnalytics.TabIndex = 2;
            this.tabPageAnalytics.Text = "Analytics";
            this.tabPageAnalytics.UseVisualStyleBackColor = true;
            // 
            // lblApiKey
            // 
            this.lblApiKey.AutoSize = true;
            this.lblApiKey.Location = new System.Drawing.Point(6, 15);
            this.lblApiKey.Name = "lblApiKey";
            this.lblApiKey.Size = new System.Drawing.Size(95, 13);
            this.lblApiKey.TabIndex = 0;
            this.lblApiKey.Text = "OpenAI API Key:";
            // 
            // txtApiKey
            // 
            this.txtApiKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                                                                            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtApiKey.Location = new System.Drawing.Point(107, 12);
            this.txtApiKey.Name = "txtApiKey";
            this.txtApiKey.Size = new System.Drawing.Size(679, 20);
            this.txtApiKey.TabIndex = 1;
            // 
            // btnRunAnalysis
            // 
            this.btnRunAnalysis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRunAnalysis.Location = new System.Drawing.Point(711, 38);
            this.btnRunAnalysis.Name = "btnRunAnalysis";
            this.btnRunAnalysis.Size = new System.Drawing.Size(75, 23);
            this.btnRunAnalysis.TabIndex = 2;
            this.btnRunAnalysis.Text = "Analyze";
            this.btnRunAnalysis.UseVisualStyleBackColor = true;
            this.btnRunAnalysis.Click += new System.EventHandler(this.btnRunAnalysis_Click);
            // 
            // txtAnalysisResult
            // 
            this.txtAnalysisResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                                                              | System.Windows.Forms.AnchorStyles.Left)
                                                                             | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAnalysisResult.Location = new System.Drawing.Point(6, 67);
            this.txtAnalysisResult.Multiline = true;
            this.txtAnalysisResult.Name = "txtAnalysisResult";
            this.txtAnalysisResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAnalysisResult.Size = new System.Drawing.Size(780, 351);
            this.txtAnalysisResult.TabIndex = 3;
            // 
            // tabPageAdmin
            // 
            this.tabPageAdmin.Controls.Add(this.panelAdminButtons);
            this.tabPageAdmin.Controls.Add(this.dgvUsers);
            this.tabPageAdmin.Location = new System.Drawing.Point(4, 22);
            this.tabPageAdmin.Name = "tabPageAdmin";
            this.tabPageAdmin.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAdmin.Size = new System.Drawing.Size(792, 424);
            this.tabPageAdmin.TabIndex = 3;
            this.tabPageAdmin.Text = "Admin";
            this.tabPageAdmin.UseVisualStyleBackColor = true;
            // 
            // panelAdminButtons
            // 
            this.panelAdminButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                                                                                   | System.Windows.Forms.AnchorStyles.Right)));
            this.panelAdminButtons.Controls.Add(this.btnAddUser);
            this.panelAdminButtons.Controls.Add(this.btnAddClient);
            this.panelAdminButtons.Controls.Add(this.btnNewTicket);
            this.panelAdminButtons.Location = new System.Drawing.Point(6, 6);
            this.panelAdminButtons.Name = "panelAdminButtons";
            this.panelAdminButtons.Size = new System.Drawing.Size(780, 50);
            this.panelAdminButtons.TabIndex = 0;
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(10, 10);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(100, 30);
            this.btnAddUser.TabIndex = 0;
            this.btnAddUser.Text = "Add User";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // btnAddClient
            // 
            this.btnAddClient.Location = new System.Drawing.Point(120, 10);
            this.btnAddClient.Name = "btnAddClient";
            this.btnAddClient.Size = new System.Drawing.Size(100, 30);
            this.btnAddClient.TabIndex = 1;
            this.btnAddClient.Text = "Add Client";
            this.btnAddClient.UseVisualStyleBackColor = true;
            this.btnAddClient.Click += new System.EventHandler(this.btnAddClient_Click);
            // 
            // btnNewTicket
            // 
            this.btnNewTicket.Location = new System.Drawing.Point(230, 10);
            this.btnNewTicket.Name = "btnNewTicket";
            this.btnNewTicket.Size = new System.Drawing.Size(100, 30);
            this.btnNewTicket.TabIndex = 2;
            this.btnNewTicket.Text = "New Ticket";
            this.btnNewTicket.UseVisualStyleBackColor = true;
            this.btnNewTicket.Click += new System.EventHandler(this.btnNewTicket_Click);
            // 
            // dgvUsers
            // 
            this.dgvUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                                                            | System.Windows.Forms.AnchorStyles.Left)
                                                                           | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Location = new System.Drawing.Point(6, 62);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.Size = new System.Drawing.Size(780, 356);
            this.dgvUsers.TabIndex = 1;
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "Ticketing System";
            this.tabControl1.ResumeLayout(false);
            this.tabPageTickets.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTickets)).EndInit();
            this.tabPageClients.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).EndInit();
            this.tabPageAnalytics.ResumeLayout(false);
            this.tabPageAnalytics.PerformLayout();
            this.tabPageAdmin.ResumeLayout(false);
            this.panelAdminButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
    }
}

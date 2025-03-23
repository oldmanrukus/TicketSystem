namespace TicketingSystem
{
    partial class AddUserForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.ComboBox comboRole;
        private System.Windows.Forms.ComboBox comboClient; // Using a ComboBox for client selection.
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblClient = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.comboRole = new System.Windows.Forms.ComboBox();
            this.comboClient = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(12, 15);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(58, 13);
            this.lblUsername.Text = "Username:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(100, 12);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(250, 20);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(12, 45);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.Text = "Password:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(100, 42);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(250, 20);
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new System.Drawing.Point(12, 75);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(32, 13);
            this.lblRole.Text = "Role:";
            // 
            // comboRole
            // 
            this.comboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboRole.FormattingEnabled = true;
            this.comboRole.Location = new System.Drawing.Point(100, 72);
            this.comboRole.Name = "comboRole";
            this.comboRole.Size = new System.Drawing.Size(250, 21);
            this.comboRole.TabIndex = 3;
            this.comboRole.SelectedIndexChanged += new System.EventHandler(this.comboRole_SelectedIndexChanged);
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Location = new System.Drawing.Point(12, 105);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(39, 13);
            this.lblClient.Text = "Client:";
            // 
            // comboClient
            // 
            this.comboClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboClient.FormattingEnabled = true;
            this.comboClient.Location = new System.Drawing.Point(100, 102);
            this.comboClient.Name = "comboClient";
            this.comboClient.Size = new System.Drawing.Size(250, 21);
            this.comboClient.TabIndex = 4;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(100, 140);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(175, 140);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            // 
            // AddUserForm
            // 
            this.AcceptButton = this.btnSave;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(370, 180);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.comboRole);
            this.Controls.Add(this.lblClient);
            this.Controls.Add(this.comboClient);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Name = "AddUserForm";
            this.Text = "Add New User";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

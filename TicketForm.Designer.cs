namespace TicketingSystem
{
    partial class TicketForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.ComboBox comboClient;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox comboStatus;
        private System.Windows.Forms.Label lblPriority;
        private System.Windows.Forms.ComboBox comboPriority;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblResolution;
        private System.Windows.Forms.TextBox txtResolutionComment;
        private System.Windows.Forms.Button btnCloseTicket;
        private System.Windows.Forms.Button btnReopenTicket;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblClient = new System.Windows.Forms.Label();
            this.comboClient = new System.Windows.Forms.ComboBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.comboStatus = new System.Windows.Forms.ComboBox();
            this.lblPriority = new System.Windows.Forms.Label();
            this.comboPriority = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblResolution = new System.Windows.Forms.Label();
            this.txtResolutionComment = new System.Windows.Forms.TextBox();
            this.btnCloseTicket = new System.Windows.Forms.Button();
            this.btnReopenTicket = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Location = new System.Drawing.Point(12, 15);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(39, 13);
            this.lblClient.TabIndex = 0;
            this.lblClient.Text = "Client:";
            // 
            // comboClient
            // 
            this.comboClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboClient.FormattingEnabled = true;
            this.comboClient.Location = new System.Drawing.Point(100, 12);
            this.comboClient.Name = "comboClient";
            this.comboClient.Size = new System.Drawing.Size(250, 21);
            this.comboClient.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(12, 45);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(30, 13);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Title:";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(100, 42);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(250, 20);
            this.txtTitle.TabIndex = 3;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(12, 75);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(63, 13);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Description:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(100, 72);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(250, 80);
            this.txtDescription.TabIndex = 5;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 165);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "Status:";
            // 
            // comboStatus
            // 
            this.comboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboStatus.FormattingEnabled = true;
            this.comboStatus.Items.AddRange(new object[] {
            "Open",
            "In Progress",
            "Resolved"});
            this.comboStatus.Location = new System.Drawing.Point(100, 162);
            this.comboStatus.Name = "comboStatus";
            this.comboStatus.Size = new System.Drawing.Size(250, 21);
            this.comboStatus.TabIndex = 7;
            this.comboStatus.SelectedIndex = 0;
            // 
            // lblPriority
            // 
            this.lblPriority.AutoSize = true;
            this.lblPriority.Location = new System.Drawing.Point(12, 195);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(41, 13);
            this.lblPriority.TabIndex = 8;
            this.lblPriority.Text = "Priority:";
            // 
            // comboPriority
            // 
            this.comboPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPriority.FormattingEnabled = true;
            this.comboPriority.Items.AddRange(new object[] {
            "Low",
            "Medium",
            "High"});
            this.comboPriority.Location = new System.Drawing.Point(100, 192);
            this.comboPriority.Name = "comboPriority";
            this.comboPriority.Size = new System.Drawing.Size(250, 21);
            this.comboPriority.TabIndex = 9;
            this.comboPriority.SelectedIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(100, 230);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(175, 230);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            // 
            // lblResolution
            // 
            this.lblResolution.AutoSize = true;
            this.lblResolution.Location = new System.Drawing.Point(12, 265);
            this.lblResolution.Name = "lblResolution";
            this.lblResolution.Size = new System.Drawing.Size(95, 13);
            this.lblResolution.TabIndex = 12;
            this.lblResolution.Text = "Resolution Note:";
            // 
            // txtResolutionComment
            // 
            this.txtResolutionComment.Location = new System.Drawing.Point(115, 262);
            this.txtResolutionComment.Multiline = true;
            this.txtResolutionComment.Name = "txtResolutionComment";
            this.txtResolutionComment.Size = new System.Drawing.Size(235, 60);
            this.txtResolutionComment.TabIndex = 13;
            // 
            // btnCloseTicket
            // 
            this.btnCloseTicket.Location = new System.Drawing.Point(115, 330);
            this.btnCloseTicket.Name = "btnCloseTicket";
            this.btnCloseTicket.Size = new System.Drawing.Size(100, 30);
            this.btnCloseTicket.TabIndex = 14;
            this.btnCloseTicket.Text = "Close Ticket";
            this.btnCloseTicket.UseVisualStyleBackColor = true;
            this.btnCloseTicket.Click += new System.EventHandler(this.btnCloseTicket_Click);
            // 
            // btnReopenTicket
            // 
            this.btnReopenTicket.Location = new System.Drawing.Point(225, 330);
            this.btnReopenTicket.Name = "btnReopenTicket";
            this.btnReopenTicket.Size = new System.Drawing.Size(100, 30);
            this.btnReopenTicket.TabIndex = 15;
            this.btnReopenTicket.Text = "Reopen Ticket";
            this.btnReopenTicket.UseVisualStyleBackColor = true;
            this.btnReopenTicket.Click += new System.EventHandler(this.btnReopenTicket_Click);
            // 
            // TicketForm
            // 
            this.AcceptButton = this.btnSave;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(370, 370);
            this.Controls.Add(this.lblClient);
            this.Controls.Add(this.comboClient);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.comboStatus);
            this.Controls.Add(this.lblPriority);
            this.Controls.Add(this.comboPriority);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblResolution);
            this.Controls.Add(this.txtResolutionComment);
            this.Controls.Add(this.btnCloseTicket);
            this.Controls.Add(this.btnReopenTicket);
            this.Name = "TicketForm";
            this.Text = "Ticket Form";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

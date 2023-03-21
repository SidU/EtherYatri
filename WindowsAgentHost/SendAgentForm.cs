using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace AgentHost2003
{
	/// <summary>
	/// Used to gather the required information from the user
	/// to send an agent to another host.
	/// </summary>
	public class SendAgentForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label agentTypeNameLabel;
		private System.Windows.Forms.Label agentAssemblyPathLabel;
		private System.Windows.Forms.Label initializationArgsLabel;
		private System.Windows.Forms.Label creationTimeLabel;
		private System.Windows.Forms.TextBox agentTypeNameTextBox;
		private System.Windows.Forms.TextBox agentAssemblyPathTextBox;
		private System.Windows.Forms.TextBox agentCreationTimeTextBox;
		private System.Windows.Forms.TextBox initilizationArgsTextBox;
		private System.Windows.Forms.Label destinationHostAddressLabel;
		private System.Windows.Forms.TextBox destinationHostAddressTextBox;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Label commentsLabel;
		private System.Windows.Forms.TextBox commentsTextBox;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SendAgentForm(string agentTypeName, string agentAssemblyPath, string agentInitArgs, string agentCreationTime, string agentComments)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			this.agentTypeNameTextBox.Text = agentTypeName;
			this.agentAssemblyPathTextBox.Text = agentAssemblyPath;
			this.initilizationArgsTextBox.Text = agentInitArgs;
			this.agentCreationTimeTextBox.Text = agentCreationTime;
			this.commentsTextBox.Text = agentComments;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.agentTypeNameLabel = new System.Windows.Forms.Label();
			this.initializationArgsLabel = new System.Windows.Forms.Label();
			this.agentAssemblyPathLabel = new System.Windows.Forms.Label();
			this.creationTimeLabel = new System.Windows.Forms.Label();
			this.agentTypeNameTextBox = new System.Windows.Forms.TextBox();
			this.agentAssemblyPathTextBox = new System.Windows.Forms.TextBox();
			this.agentCreationTimeTextBox = new System.Windows.Forms.TextBox();
			this.initilizationArgsTextBox = new System.Windows.Forms.TextBox();
			this.destinationHostAddressLabel = new System.Windows.Forms.Label();
			this.destinationHostAddressTextBox = new System.Windows.Forms.TextBox();
			this.okButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.commentsLabel = new System.Windows.Forms.Label();
			this.commentsTextBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// agentTypeNameLabel
			// 
			this.agentTypeNameLabel.Location = new System.Drawing.Point(16, 24);
			this.agentTypeNameLabel.Name = "agentTypeNameLabel";
			this.agentTypeNameLabel.Size = new System.Drawing.Size(104, 16);
			this.agentTypeNameLabel.TabIndex = 0;
			this.agentTypeNameLabel.Text = "Type Name";
			// 
			// initializationArgsLabel
			// 
			this.initializationArgsLabel.Location = new System.Drawing.Point(16, 88);
			this.initializationArgsLabel.Name = "initializationArgsLabel";
			this.initializationArgsLabel.Size = new System.Drawing.Size(104, 16);
			this.initializationArgsLabel.TabIndex = 1;
			this.initializationArgsLabel.Text = "Initialization Args";
			// 
			// agentAssemblyPathLabel
			// 
			this.agentAssemblyPathLabel.Location = new System.Drawing.Point(16, 56);
			this.agentAssemblyPathLabel.Name = "agentAssemblyPathLabel";
			this.agentAssemblyPathLabel.Size = new System.Drawing.Size(104, 16);
			this.agentAssemblyPathLabel.TabIndex = 2;
			this.agentAssemblyPathLabel.Text = "Assembly Path";
			// 
			// creationTimeLabel
			// 
			this.creationTimeLabel.Location = new System.Drawing.Point(16, 120);
			this.creationTimeLabel.Name = "creationTimeLabel";
			this.creationTimeLabel.Size = new System.Drawing.Size(104, 16);
			this.creationTimeLabel.TabIndex = 3;
			this.creationTimeLabel.Text = "Creation Time";
			// 
			// agentTypeNameTextBox
			// 
			this.agentTypeNameTextBox.Location = new System.Drawing.Point(168, 24);
			this.agentTypeNameTextBox.Name = "agentTypeNameTextBox";
			this.agentTypeNameTextBox.ReadOnly = true;
			this.agentTypeNameTextBox.Size = new System.Drawing.Size(200, 20);
			this.agentTypeNameTextBox.TabIndex = 3;
			this.agentTypeNameTextBox.Text = "";
			// 
			// agentAssemblyPathTextBox
			// 
			this.agentAssemblyPathTextBox.Location = new System.Drawing.Point(168, 56);
			this.agentAssemblyPathTextBox.Name = "agentAssemblyPathTextBox";
			this.agentAssemblyPathTextBox.ReadOnly = true;
			this.agentAssemblyPathTextBox.Size = new System.Drawing.Size(200, 20);
			this.agentAssemblyPathTextBox.TabIndex = 4;
			this.agentAssemblyPathTextBox.Text = "";
			// 
			// agentCreationTimeTextBox
			// 
			this.agentCreationTimeTextBox.Location = new System.Drawing.Point(168, 120);
			this.agentCreationTimeTextBox.Name = "agentCreationTimeTextBox";
			this.agentCreationTimeTextBox.ReadOnly = true;
			this.agentCreationTimeTextBox.Size = new System.Drawing.Size(200, 20);
			this.agentCreationTimeTextBox.TabIndex = 6;
			this.agentCreationTimeTextBox.Text = "";
			// 
			// initilizationArgsTextBox
			// 
			this.initilizationArgsTextBox.Location = new System.Drawing.Point(168, 88);
			this.initilizationArgsTextBox.Name = "initilizationArgsTextBox";
			this.initilizationArgsTextBox.ReadOnly = true;
			this.initilizationArgsTextBox.Size = new System.Drawing.Size(200, 20);
			this.initilizationArgsTextBox.TabIndex = 5;
			this.initilizationArgsTextBox.Text = "";
			// 
			// destinationHostAddressLabel
			// 
			this.destinationHostAddressLabel.Location = new System.Drawing.Point(16, 184);
			this.destinationHostAddressLabel.Name = "destinationHostAddressLabel";
			this.destinationHostAddressLabel.Size = new System.Drawing.Size(136, 16);
			this.destinationHostAddressLabel.TabIndex = 8;
			this.destinationHostAddressLabel.Text = "Destination Host Address";
			// 
			// destinationHostAddressTextBox
			// 
			this.destinationHostAddressTextBox.Location = new System.Drawing.Point(168, 184);
			this.destinationHostAddressTextBox.Name = "destinationHostAddressTextBox";
			this.destinationHostAddressTextBox.Size = new System.Drawing.Size(200, 20);
			this.destinationHostAddressTextBox.TabIndex = 0;
			this.destinationHostAddressTextBox.Text = "";
			// 
			// okButton
			// 
			this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.okButton.Location = new System.Drawing.Point(200, 224);
			this.okButton.Name = "okButton";
			this.okButton.TabIndex = 1;
			this.okButton.Text = "Send";
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cancelButton.Location = new System.Drawing.Point(296, 224);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.TabIndex = 2;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// commentsLabel
			// 
			this.commentsLabel.Location = new System.Drawing.Point(16, 152);
			this.commentsLabel.Name = "commentsLabel";
			this.commentsLabel.Size = new System.Drawing.Size(136, 16);
			this.commentsLabel.TabIndex = 9;
			this.commentsLabel.Text = "Comments";
			// 
			// commentsTextBox
			// 
			this.commentsTextBox.Location = new System.Drawing.Point(168, 152);
			this.commentsTextBox.Name = "commentsTextBox";
			this.commentsTextBox.ReadOnly = true;
			this.commentsTextBox.Size = new System.Drawing.Size(200, 20);
			this.commentsTextBox.TabIndex = 7;
			this.commentsTextBox.Text = "";
			// 
			// SendAgentForm
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(386, 264);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.commentsTextBox,
																		  this.commentsLabel,
																		  this.cancelButton,
																		  this.okButton,
																		  this.destinationHostAddressTextBox,
																		  this.destinationHostAddressLabel,
																		  this.initilizationArgsTextBox,
																		  this.agentCreationTimeTextBox,
																		  this.agentAssemblyPathTextBox,
																		  this.agentTypeNameTextBox,
																		  this.creationTimeLabel,
																		  this.agentAssemblyPathLabel,
																		  this.initializationArgsLabel,
																		  this.agentTypeNameLabel});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SendAgentForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Send Agent";
			this.ResumeLayout(false);

		}
		#endregion

		private void cancelButton_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void okButton_Click(object sender, System.EventArgs e)
		{
			if (this.destinationHostAddressTextBox.Text.Trim().Length == 0)
			{
				MessageBox.Show("Please enter the address of the host where the agent should be moved to.", "Unspecified Destination Host Address", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		
		public string DestinationHostAddress
		{
			get
			{
				return this.destinationHostAddressTextBox.Text.Trim();
			}
		}

	}
}

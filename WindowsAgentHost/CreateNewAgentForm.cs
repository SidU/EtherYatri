/*************************************************************************************
 * 
 * (c) 2003 Siddharth Uppal <siddharthuppal@yahoo.co.in>
 * All rights reserved.
 * 
 * Visit EtherYatri Homepage: http://www.geocities.com/siddharthuppal/EtherYatri.htm
 * 
 *************************************************************************************/

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace WindowsAgentHost
{
	/// <summary>
	/// Summary description for CreateNewAgentForm.
	/// </summary>
	public class CreateNewAgentForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label pathLabel;
		private System.Windows.Forms.Label agentTypeNameLabel;
		private System.Windows.Forms.TextBox assemblyPathTextBox;
		private System.Windows.Forms.Button browseAssemblyButton;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.Label initStringLabel;
		private System.Windows.Forms.TextBox initStringTextBox;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Label commentsLabel;
		private System.Windows.Forms.TextBox commentsTextBox;
		private System.Windows.Forms.TextBox typeNameTextbox;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CreateNewAgentForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
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
			this.pathLabel = new System.Windows.Forms.Label();
			this.agentTypeNameLabel = new System.Windows.Forms.Label();
			this.assemblyPathTextBox = new System.Windows.Forms.TextBox();
			this.browseAssemblyButton = new System.Windows.Forms.Button();
			this.okButton = new System.Windows.Forms.Button();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.initStringLabel = new System.Windows.Forms.Label();
			this.initStringTextBox = new System.Windows.Forms.TextBox();
			this.cancelButton = new System.Windows.Forms.Button();
			this.commentsLabel = new System.Windows.Forms.Label();
			this.commentsTextBox = new System.Windows.Forms.TextBox();
			this.typeNameTextbox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// pathLabel
			// 
			this.pathLabel.Location = new System.Drawing.Point(16, 24);
			this.pathLabel.Name = "pathLabel";
			this.pathLabel.Size = new System.Drawing.Size(152, 23);
			this.pathLabel.TabIndex = 0;
			this.pathLabel.Text = "Path of agent\'s assembly file";
			// 
			// agentTypeNameLabel
			// 
			this.agentTypeNameLabel.Location = new System.Drawing.Point(16, 64);
			this.agentTypeNameLabel.Name = "agentTypeNameLabel";
			this.agentTypeNameLabel.Size = new System.Drawing.Size(136, 23);
			this.agentTypeNameLabel.TabIndex = 1;
			this.agentTypeNameLabel.Text = "Full name of agent\'s type";
			// 
			// assemblyPathTextBox
			// 
			this.assemblyPathTextBox.Location = new System.Drawing.Point(168, 24);
			this.assemblyPathTextBox.Name = "assemblyPathTextBox";
			this.assemblyPathTextBox.Size = new System.Drawing.Size(152, 20);
			this.assemblyPathTextBox.TabIndex = 1;
			this.assemblyPathTextBox.Text = "";
			// 
			// browseAssemblyButton
			// 
			this.browseAssemblyButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.browseAssemblyButton.Location = new System.Drawing.Point(336, 24);
			this.browseAssemblyButton.Name = "browseAssemblyButton";
			this.browseAssemblyButton.Size = new System.Drawing.Size(32, 20);
			this.browseAssemblyButton.TabIndex = 0;
			this.browseAssemblyButton.Text = "...";
			this.browseAssemblyButton.Click += new System.EventHandler(this.browseAssemblyButton_Click);
			// 
			// okButton
			// 
			this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.okButton.Location = new System.Drawing.Point(216, 176);
			this.okButton.Name = "okButton";
			this.okButton.TabIndex = 6;
			this.okButton.Text = "OK";
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// initStringLabel
			// 
			this.initStringLabel.Location = new System.Drawing.Point(16, 104);
			this.initStringLabel.Name = "initStringLabel";
			this.initStringLabel.TabIndex = 6;
			this.initStringLabel.Text = "Initialization string";
			// 
			// initStringTextBox
			// 
			this.initStringTextBox.Location = new System.Drawing.Point(168, 104);
			this.initStringTextBox.Name = "initStringTextBox";
			this.initStringTextBox.Size = new System.Drawing.Size(200, 20);
			this.initStringTextBox.TabIndex = 4;
			this.initStringTextBox.Text = "";
			// 
			// cancelButton
			// 
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cancelButton.Location = new System.Drawing.Point(296, 176);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.TabIndex = 7;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// commentsLabel
			// 
			this.commentsLabel.Location = new System.Drawing.Point(16, 144);
			this.commentsLabel.Name = "commentsLabel";
			this.commentsLabel.TabIndex = 8;
			this.commentsLabel.Text = "Comments";
			// 
			// commentsTextBox
			// 
			this.commentsTextBox.Location = new System.Drawing.Point(168, 144);
			this.commentsTextBox.Name = "commentsTextBox";
			this.commentsTextBox.Size = new System.Drawing.Size(200, 20);
			this.commentsTextBox.TabIndex = 5;
			this.commentsTextBox.Text = "";
			// 
			// typeNameTextbox
			// 
			this.typeNameTextbox.Location = new System.Drawing.Point(168, 64);
			this.typeNameTextbox.Name = "typeNameTextbox";
			this.typeNameTextbox.Size = new System.Drawing.Size(200, 20);
			this.typeNameTextbox.TabIndex = 2;
			this.typeNameTextbox.Text = "NamespaceName.ClassName";
			// 
			// CreateNewAgentForm
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(386, 216);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.typeNameTextbox,
																		  this.commentsTextBox,
																		  this.commentsLabel,
																		  this.cancelButton,
																		  this.initStringTextBox,
																		  this.initStringLabel,
																		  this.okButton,
																		  this.browseAssemblyButton,
																		  this.assemblyPathTextBox,
																		  this.agentTypeNameLabel,
																		  this.pathLabel});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CreateNewAgentForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Create New Agent";
			this.ResumeLayout(false);

		}
		#endregion

		private void browseAssemblyButton_Click(object sender, System.EventArgs e)
		{
			DialogResult dialogResult = this.openFileDialog.ShowDialog(this);
			if (dialogResult == DialogResult.OK)
			{
				this.assemblyPathTextBox.Text = this.openFileDialog.FileName;
			}
		}

		private void okButton_Click(object sender, System.EventArgs e)
		{
			this.Close();
			this.DialogResult = DialogResult.OK;
		}

		private void cancelButton_Click(object sender, System.EventArgs e)
		{
			this.Close();
			this.DialogResult = DialogResult.Cancel;
		}


		public string AgentAssemblyPath
		{
			get
			{
				return this.assemblyPathTextBox.Text;
			}
		}


		public string AgentTypeName
		{
			get
			{
				return this.typeNameTextbox.Text;
			}
		}

		public string InitString
		{
			get
			{
				return this.initStringTextBox.Text;
			}
		}

		public string Comments
		{
			get
			{
				return this.commentsTextBox.Text;
			}
		}
	}
}

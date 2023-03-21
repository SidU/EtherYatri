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

namespace AgentHost2003
{
	/// <summary>
	/// Summary description for PreferencesForm.
	/// </summary>
	public class PreferencesForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label portNumberlabel;
		private System.Windows.Forms.TextBox portNumberTextBox;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Label descriptonLabel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public PreferencesForm(int defaultPortNumber)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			this.portNumber = defaultPortNumber;
			this.portNumberTextBox.Text = defaultPortNumber.ToString();
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
			this.portNumberlabel = new System.Windows.Forms.Label();
			this.portNumberTextBox = new System.Windows.Forms.TextBox();
			this.okButton = new System.Windows.Forms.Button();
			this.descriptonLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// portNumberlabel
			// 
			this.portNumberlabel.Location = new System.Drawing.Point(8, 64);
			this.portNumberlabel.Name = "portNumberlabel";
			this.portNumberlabel.Size = new System.Drawing.Size(80, 24);
			this.portNumberlabel.TabIndex = 0;
			this.portNumberlabel.Text = "Port Number";
			// 
			// portNumberTextBox
			// 
			this.portNumberTextBox.Location = new System.Drawing.Point(104, 64);
			this.portNumberTextBox.Name = "portNumberTextBox";
			this.portNumberTextBox.TabIndex = 1;
			this.portNumberTextBox.Text = "";
			// 
			// okButton
			// 
			this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.okButton.Location = new System.Drawing.Point(232, 64);
			this.okButton.Name = "okButton";
			this.okButton.TabIndex = 2;
			this.okButton.Text = "OK";
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// descriptonLabel
			// 
			this.descriptonLabel.Location = new System.Drawing.Point(8, 16);
			this.descriptonLabel.Name = "descriptonLabel";
			this.descriptonLabel.Size = new System.Drawing.Size(304, 32);
			this.descriptonLabel.TabIndex = 3;
			this.descriptonLabel.Text = "Please specify the port number where WINAH should listen for incoming agents.";
			this.descriptonLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// PreferencesForm
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(320, 95);
			this.Controls.Add(this.descriptonLabel);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.portNumberTextBox);
			this.Controls.Add(this.portNumberlabel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PreferencesForm";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "WINAH Preferences";
			this.ResumeLayout(false);

		}
		#endregion

		private int portNumber;

		private void okButton_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.portNumber = int.Parse(this.portNumberTextBox.Text);
			}
			catch (FormatException)
			{
				MessageBox.Show("Error: Invalid port-number.\n" +
								"Please enter an integer.", "Invalid Port-Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			this.Close();
		}

		public bool multiServer = false;

		private void button1_Click(object sender, System.EventArgs e)
		{
			multiServer = true;
			Close();
		}

		public int PortNumber
		{
			get
			{
				return this.portNumber;
			}
		}
	}
}

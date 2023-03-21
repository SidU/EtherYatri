using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace MigratoryApps
{
	/// <summary>
	/// Summary description for DestinationHostForm: 
	/// </summary>
	public class DestinationHostForm: System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label destinationHostUrlLabel;
		private System.Windows.Forms.TextBox destinationHostUrlTextBox;
		private System.Windows.Forms.Button okButton;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DestinationHostForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			this.destinationHostUrlLabel = new System.Windows.Forms.Label();
			this.destinationHostUrlTextBox = new System.Windows.Forms.TextBox();
			this.okButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// destinationHostUrlLabel
			// 
			this.destinationHostUrlLabel.Location = new System.Drawing.Point(8, 16);
			this.destinationHostUrlLabel.Name = "destinationHostUrlLabel";
			this.destinationHostUrlLabel.Size = new System.Drawing.Size(120, 23);
			this.destinationHostUrlLabel.TabIndex = 0;
			this.destinationHostUrlLabel.Text = "Url of destination host";
			// 
			// destinationHostUrlTextBox
			// 
			this.destinationHostUrlTextBox.Location = new System.Drawing.Point(176, 16);
			this.destinationHostUrlTextBox.Name = "destinationHostUrlTextBox";
			this.destinationHostUrlTextBox.Size = new System.Drawing.Size(168, 20);
			this.destinationHostUrlTextBox.TabIndex = 1;
			this.destinationHostUrlTextBox.Text = "";
			// 
			// okButton
			// 
			this.okButton.Location = new System.Drawing.Point(144, 56);
			this.okButton.Name = "okButton";
			this.okButton.TabIndex = 2;
			this.okButton.Text = "OK";
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// DestinationHostForm
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(362, 94);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.okButton,
																		  this.destinationHostUrlTextBox,
																		  this.destinationHostUrlLabel});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DestinationHostForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Destination Host";
			this.ResumeLayout(false);

		}
		#endregion

		private void okButton_Click(object sender, System.EventArgs e)
		{
			this.Close();
			this.DialogResult = DialogResult.OK;
		}


		public string DestinationHostUrl
		{
			get
			{
				return this.destinationHostUrlTextBox.Text;
			}
		}
	}
}

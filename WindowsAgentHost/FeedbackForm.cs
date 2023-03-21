using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace AgentHost2003
{
	/// <summary>
	/// Summary description for FeedbackForm.
	/// </summary>
	public class FeedbackForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label directionsLabel;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Label winahVersionLabel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FeedbackForm(string winahVersion)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			this.winahVersionLabel.Text += winahVersion;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FeedbackForm));
			this.directionsLabel = new System.Windows.Forms.Label();
			this.okButton = new System.Windows.Forms.Button();
			this.winahVersionLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// directionsLabel
			// 
			this.directionsLabel.Location = new System.Drawing.Point(24, 24);
			this.directionsLabel.Name = "directionsLabel";
			this.directionsLabel.Size = new System.Drawing.Size(360, 56);
			this.directionsLabel.TabIndex = 0;
			this.directionsLabel.Text = "We will love to hear from you about your experience with WINAH. You may mail your" +
				" feedback to Siddharth Uppal at sidupp@yahoo.co.in. Please don\'t forget to menti" +
				"on the version of WINAH that you are using. Thanks!";
			this.directionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// okButton
			// 
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.okButton.Location = new System.Drawing.Point(304, 136);
			this.okButton.Name = "okButton";
			this.okButton.TabIndex = 1;
			this.okButton.Text = "OK";
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// winahVersionLabel
			// 
			this.winahVersionLabel.Location = new System.Drawing.Point(24, 96);
			this.winahVersionLabel.Name = "winahVersionLabel";
			this.winahVersionLabel.Size = new System.Drawing.Size(360, 16);
			this.winahVersionLabel.TabIndex = 3;
			this.winahVersionLabel.Text = "WINAH Version: ";
			this.winahVersionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// FeedbackForm
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.okButton;
			this.ClientSize = new System.Drawing.Size(402, 176);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.winahVersionLabel,
																		  this.okButton,
																		  this.directionsLabel});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FeedbackForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Feedback";
			this.ResumeLayout(false);

		}
		#endregion

		private void okButton_Click(object sender, System.EventArgs e)
		{
			this.Close();
			this.Dispose();
		}
	}
}

#region Copyright (c) 2003, Siddharth Uppal <siddharthuppal@yahoo.co.in>
/************************************************************************************
*
* Copyright © 2003 Siddharth Uppal
*
* This software is provided 'as-is', without any express or implied warranty. In no 
* event will the authors be held liable for any damages arising from the use of this 
* software.
* 
* Permission is granted to anyone to use this software for any purpose, including 
* commercial applications, and to alter it and redistribute it freely, subject to the 
* following restrictions:
*
* 1. The origin of this software must not be misrepresented; you must not claim that 
* you wrote the original software. If you use this software in a product, an 
* acknowledgment (see the following) in the product documentation is required.
*
* Portions Copyright © 2003 Siddharth Uppal
*
* 2. Altered source versions must be plainly marked as such, and must not be 
* misrepresented as being the original software.
*
* 3. This notice may not be removed or altered from any source distribution.
*
************************************************************************************/
#endregion

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Reflection;

namespace AgentHost2003
{
	public class AboutForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label copyrightLabel;
		private System.Windows.Forms.Label companyLabel;
		private System.Windows.Forms.LinkLabel websiteLinkLabel;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Label versionLabel;
		
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AboutForm(string productName, string productDesc, string company, string copyright, string version)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

//			Assembly executingAssembly = Assembly.GetExecutingAssembly();
//			object[] objectAttrs = executingAssembly.GetCustomAttributes(typeof(AssemblyVersionAttribute), false);
//			this.versionLabel.Text = ((AssemblyVersionAttribute)objectAttrs[0]).Version.ToString();
//			
//			objectAttrs = executingAssembly.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
//			this.copyrightLabel.Text = ((AssemblyCopyrightAttribute)objectAttrs[0]).Copyright.ToString();			

			this.versionLabel.Text = "Version " + version;
			this.copyrightLabel.Text = copyright;
			this.companyLabel.Text = company;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(AboutForm));
			this.panel1 = new System.Windows.Forms.Panel();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.versionLabel = new System.Windows.Forms.Label();
			this.companyLabel = new System.Windows.Forms.Label();
			this.copyrightLabel = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.websiteLinkLabel = new System.Windows.Forms.LinkLabel();
			this.okButton = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.White;
			this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.pictureBox2,
																				 this.pictureBox1});
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(298, 80);
			this.panel1.TabIndex = 0;
			// 
			// pictureBox2
			// 
			this.pictureBox2.Image = ((System.Drawing.Bitmap)(resources.GetObject("pictureBox2.Image")));
			this.pictureBox2.Location = new System.Drawing.Point(88, 48);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(128, 24);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox2.TabIndex = 1;
			this.pictureBox2.TabStop = false;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Bitmap)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(16, 16);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(178, 24);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.versionLabel,
																					this.companyLabel,
																					this.copyrightLabel,
																					this.label1});
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(24, 96);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(250, 152);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Product Information";
			// 
			// versionLabel
			// 
			this.versionLabel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.versionLabel.Location = new System.Drawing.Point(8, 48);
			this.versionLabel.Name = "versionLabel";
			this.versionLabel.Size = new System.Drawing.Size(235, 16);
			this.versionLabel.TabIndex = 5;
			this.versionLabel.Text = "Version xx.xx.xx";
			this.versionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// companyLabel
			// 
			this.companyLabel.Location = new System.Drawing.Point(72, 120);
			this.companyLabel.Name = "companyLabel";
			this.companyLabel.TabIndex = 4;
			this.companyLabel.Text = "Company";
			this.companyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// copyrightLabel
			// 
			this.copyrightLabel.Location = new System.Drawing.Point(8, 72);
			this.copyrightLabel.Name = "copyrightLabel";
			this.copyrightLabel.Size = new System.Drawing.Size(235, 48);
			this.copyrightLabel.TabIndex = 3;
			this.copyrightLabel.Text = "Here goes the copyright notice. It is long.";
			this.copyrightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(8, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(235, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "WINAH";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// websiteLinkLabel
			// 
			this.websiteLinkLabel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.websiteLinkLabel.Location = new System.Drawing.Point(64, 264);
			this.websiteLinkLabel.Name = "websiteLinkLabel";
			this.websiteLinkLabel.Size = new System.Drawing.Size(184, 16);
			this.websiteLinkLabel.TabIndex = 2;
			this.websiteLinkLabel.TabStop = true;
			this.websiteLinkLabel.Text = "Visit the EtherYatri.NET Homepage";
			this.websiteLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.websiteLinkLabel_LinkClicked);
			// 
			// okButton
			// 
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.okButton.Location = new System.Drawing.Point(200, 296);
			this.okButton.Name = "okButton";
			this.okButton.TabIndex = 3;
			this.okButton.Text = "OK";
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// AboutForm
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.okButton;
			this.ClientSize = new System.Drawing.Size(298, 336);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.okButton,
																		  this.websiteLinkLabel,
																		  this.groupBox1,
																		  this.panel1});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutForm";
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "About EtherYatri.NET WINAH";
			this.panel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void okButton_Click(object sender, System.EventArgs e)
		{
			this.Close();
			this.Dispose();
		}

		private void websiteLinkLabel_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				System.Diagnostics.Process.Start("iexplore", "http://geocities.com/siddharthuppal/EtherYatri.htm");
			}
			catch (Exception)
			{
			}
		}


	}
}

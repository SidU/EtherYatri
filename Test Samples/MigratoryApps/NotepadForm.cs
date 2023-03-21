/*
 * Migratory Notepad
 * Thursday, March 27, 2003
 * 
 * Siddharth Uppal (http://uppal.cjb.net)
 * 
 * All rights reserved.
 * (c) 2003 Siddharth Uppal <siddharthuppal@yahoo.co.in>
 */

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace MigratoryApps
{
	/// <summary>
	/// Summary description for NotepadForm.
	/// </summary>
	public class NotepadForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox textBox;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem fileMenuItem;
		private System.Windows.Forms.MenuItem migrateMenuItem;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.MenuItem exitMenuItem;
		private System.Windows.Forms.MenuItem saveFileMenuItem;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.StatusBar statusBar;
		private System.Windows.Forms.StatusBarPanel hostUrlStatusBarPanel;
		private System.Windows.Forms.MenuItem menuItem2;

		private EtherYatri.Agent agent;

		public NotepadForm(EtherYatri.Agent agent)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			this.agent = agent;
			this.hostUrlStatusBarPanel.Text = this.agent.AgentContext.LocalHostAddress;
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
			this.textBox = new System.Windows.Forms.TextBox();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.fileMenuItem = new System.Windows.Forms.MenuItem();
			this.saveFileMenuItem = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.migrateMenuItem = new System.Windows.Forms.MenuItem();
			this.exitMenuItem = new System.Windows.Forms.MenuItem();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.statusBar = new System.Windows.Forms.StatusBar();
			this.hostUrlStatusBarPanel = new System.Windows.Forms.StatusBarPanel();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			((System.ComponentModel.ISupportInitialize)(this.hostUrlStatusBarPanel)).BeginInit();
			this.SuspendLayout();
			// 
			// textBox
			// 
			this.textBox.AcceptsTab = true;
			this.textBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.textBox.Multiline = true;
			this.textBox.Name = "textBox";
			this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBox.Size = new System.Drawing.Size(472, 281);
			this.textBox.TabIndex = 0;
			this.textBox.Text = "";
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.fileMenuItem});
			// 
			// fileMenuItem
			// 
			this.fileMenuItem.Index = 0;
			this.fileMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.saveFileMenuItem,
																						 this.menuItem1,
																						 this.migrateMenuItem,
																						 this.menuItem2,
																						 this.exitMenuItem});
			this.fileMenuItem.Text = "&File";
			// 
			// saveFileMenuItem
			// 
			this.saveFileMenuItem.Index = 0;
			this.saveFileMenuItem.Text = "&Save";
			this.saveFileMenuItem.Click += new System.EventHandler(this.saveFileMenuItem_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 1;
			this.menuItem1.Text = "-";
			// 
			// migrateMenuItem
			// 
			this.migrateMenuItem.Index = 2;
			this.migrateMenuItem.Text = "&Migrate";
			this.migrateMenuItem.Click += new System.EventHandler(this.migrateMenuItem_Click);
			// 
			// exitMenuItem
			// 
			this.exitMenuItem.Index = 4;
			this.exitMenuItem.Text = "E&xit";
			this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
			// 
			// saveFileDialog
			// 
			this.saveFileDialog.FileName = "doc1";
			// 
			// statusBar
			// 
			this.statusBar.Location = new System.Drawing.Point(0, 259);
			this.statusBar.Name = "statusBar";
			this.statusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																						 this.hostUrlStatusBarPanel});
			this.statusBar.ShowPanels = true;
			this.statusBar.Size = new System.Drawing.Size(472, 22);
			this.statusBar.TabIndex = 1;
			// 
			// hostUrlStatusBarPanel
			// 
			this.hostUrlStatusBarPanel.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.hostUrlStatusBarPanel.Width = 456;
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 3;
			this.menuItem2.Text = "-";
			// 
			// NotepadForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(472, 281);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.statusBar,
																		  this.textBox});
			this.Menu = this.mainMenu1;
			this.Name = "NotepadForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Yatri Notepad";
			((System.ComponentModel.ISupportInitialize)(this.hostUrlStatusBarPanel)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void migrateMenuItem_Click(object sender, System.EventArgs e)
		{
			DestinationHostForm destinationHostForm = new DestinationHostForm();
			DialogResult dialogResult = destinationHostForm.ShowDialog();
			if (dialogResult == DialogResult.Cancel)
				return;

			this.agent.MoveTo(destinationHostForm.DestinationHostUrl);
			this.Close();
		}

		private void exitMenuItem_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}


		private void saveFileMenuItem_Click(object sender, System.EventArgs e)
		{
			DialogResult dialogResult = this.saveFileDialog.ShowDialog();		
			if (dialogResult == DialogResult.Cancel)
				return;

			System.IO.StreamWriter sw = System.IO.File.CreateText(this.saveFileDialog.FileName);
			sw.Write(this.textBox.Text);
			sw.Close();
		}


		public string[] State
		{
			get
			{
				return this.textBox.Lines;
			}
			set
			{
				this.textBox.Lines = value;
			}
		}

	}
}

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
using System.Data;
using System.Reflection;
using EtherYatri;

namespace AgentHost2003
{
	public class MainForm : System.Windows.Forms.Form, EtherYatri.ISubscribe
	{
		private System.Windows.Forms.MainMenu mainMenu;
		private System.Windows.Forms.StatusBar statusBar;
		private System.Windows.Forms.StatusBarPanel statusBarAddressPanel;
		private System.Windows.Forms.MenuItem serverMenuItem;
		private System.Windows.Forms.MenuItem exitMenuItem;
		private System.Windows.Forms.MenuItem agentMenuItem;
		private System.Windows.Forms.MenuItem createNewAgentMenuItem;
		private System.Windows.Forms.MenuItem aboutMenuItem;
		private System.Windows.Forms.StatusBarPanel statusBarInfoPanel;
		private System.ComponentModel.IContainer components;

		private System.Windows.Forms.MenuItem sendAgentMenuItem;
		private System.Windows.Forms.MenuItem killAgentMenuItem;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem samplesMenuItem;
		private System.Windows.Forms.Panel mainPanel;
		private System.Windows.Forms.MenuItem helpMenuItem;
		private System.Windows.Forms.ToolBar mainToolBar;
		private System.Windows.Forms.ToolBarButton createNewAgentToolBarButton;
		private System.Windows.Forms.ToolBarButton feedbackToolBarButton;
		private System.Windows.Forms.ImageList mainToolBarImageList;
		private System.Windows.Forms.Panel displayPanel;
		private System.Windows.Forms.TabControl mainTabControl;
		private System.Windows.Forms.TabPage outputTabPage;
		private System.Windows.Forms.TextBox outputTextBox;
		private System.Windows.Forms.TabPage activeAgentsTabPage;
		private System.Windows.Forms.DataGrid activeAgentsGrid;
		private System.Windows.Forms.ToolBarButton sendAgentToolbarButton;
		private System.Windows.Forms.ToolBarButton KillAgentToolbarButton;
		private System.Windows.Forms.MenuItem menuItem1;
		private DataTable agentsDataTable;

				
		public MainForm(string address)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
//			this.MinimumSize = this.Size;
//			this.MaximumSize = this.MinimumSize;
			
			this.activeAgentsGrid.PreferredColumnWidth = this.activeAgentsGrid.ClientRectangle.Width / 5;

			
			// Create the agents data table and add it to the agents grid
			this.agentsDataTable = new DataTable("Active Agents");
			this.agentsDataTable.Columns.Add("Type Name");
			this.agentsDataTable.Columns.Add("Assembly Path");
			this.agentsDataTable.Columns.Add("Initialization Args");
			this.agentsDataTable.Columns.Add("Started");
			this.agentsDataTable.Columns.Add("Comments");
			this.agentsDataTable.Columns.Add("id");
			
			this.activeAgentsGrid.SetDataBinding(this.agentsDataTable, null);
            			
			this.statusBarAddressPanel.Text = address;

			Console.SetOut(new TextBoxWriter(this.outputTextBox));
			Console.SetError(new TextBoxWriter(this.outputTextBox));
			ObserverSingelton.GetInstance().Add(this,EtherYatri.AgentHost.Url);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				// cleanup managed objects
				if(components != null)
				{
					components.Dispose();
				}
			}

			// cleanup unmanaged objects
			base.Dispose( disposing );
		}


		/*	public override void Dispose()
			{
				this.Dispose(true);
				GC.SuppressFinalize(this);
			}
	 */


		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.mainMenu = new System.Windows.Forms.MainMenu();
			this.serverMenuItem = new System.Windows.Forms.MenuItem();
			this.exitMenuItem = new System.Windows.Forms.MenuItem();
			this.agentMenuItem = new System.Windows.Forms.MenuItem();
			this.createNewAgentMenuItem = new System.Windows.Forms.MenuItem();
			this.sendAgentMenuItem = new System.Windows.Forms.MenuItem();
			this.killAgentMenuItem = new System.Windows.Forms.MenuItem();
			this.helpMenuItem = new System.Windows.Forms.MenuItem();
			this.samplesMenuItem = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.aboutMenuItem = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.statusBar = new System.Windows.Forms.StatusBar();
			this.statusBarInfoPanel = new System.Windows.Forms.StatusBarPanel();
			this.statusBarAddressPanel = new System.Windows.Forms.StatusBarPanel();
			this.mainPanel = new System.Windows.Forms.Panel();
			this.mainToolBar = new System.Windows.Forms.ToolBar();
			this.createNewAgentToolBarButton = new System.Windows.Forms.ToolBarButton();
			this.sendAgentToolbarButton = new System.Windows.Forms.ToolBarButton();
			this.KillAgentToolbarButton = new System.Windows.Forms.ToolBarButton();
			this.feedbackToolBarButton = new System.Windows.Forms.ToolBarButton();
			this.mainToolBarImageList = new System.Windows.Forms.ImageList(this.components);
			this.displayPanel = new System.Windows.Forms.Panel();
			this.mainTabControl = new System.Windows.Forms.TabControl();
			this.outputTabPage = new System.Windows.Forms.TabPage();
			this.outputTextBox = new System.Windows.Forms.TextBox();
			this.activeAgentsTabPage = new System.Windows.Forms.TabPage();
			this.activeAgentsGrid = new System.Windows.Forms.DataGrid();
			((System.ComponentModel.ISupportInitialize)(this.statusBarInfoPanel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarAddressPanel)).BeginInit();
			this.displayPanel.SuspendLayout();
			this.mainTabControl.SuspendLayout();
			this.outputTabPage.SuspendLayout();
			this.activeAgentsTabPage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.activeAgentsGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// mainMenu
			// 
			this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.serverMenuItem,
																					 this.agentMenuItem,
																					 this.helpMenuItem,
																					 this.menuItem1});
			// 
			// serverMenuItem
			// 
			this.serverMenuItem.Index = 0;
			this.serverMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						   this.exitMenuItem});
			this.serverMenuItem.Text = "&Server";
			// 
			// exitMenuItem
			// 
			this.exitMenuItem.Index = 0;
			this.exitMenuItem.Shortcut = System.Windows.Forms.Shortcut.AltF4;
			this.exitMenuItem.Text = "E&xit";
			this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
			// 
			// agentMenuItem
			// 
			this.agentMenuItem.Index = 1;
			this.agentMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						  this.createNewAgentMenuItem,
																						  this.sendAgentMenuItem,
																						  this.killAgentMenuItem});
			this.agentMenuItem.Text = "&Agent";
			// 
			// createNewAgentMenuItem
			// 
			this.createNewAgentMenuItem.Index = 0;
			this.createNewAgentMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
			this.createNewAgentMenuItem.Text = "Create &New";
			this.createNewAgentMenuItem.Click += new System.EventHandler(this.createNewAgentMenuItem_Click);
			// 
			// sendAgentMenuItem
			// 
			this.sendAgentMenuItem.Index = 1;
			this.sendAgentMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
			this.sendAgentMenuItem.Text = "&Send";
			this.sendAgentMenuItem.Click += new System.EventHandler(this.sendAgentMenuItem_Click);
			// 
			// killAgentMenuItem
			// 
			this.killAgentMenuItem.Index = 2;
			this.killAgentMenuItem.Shortcut = System.Windows.Forms.Shortcut.Del;
			this.killAgentMenuItem.Text = "&Kill";
			this.killAgentMenuItem.Click += new System.EventHandler(this.killAgentMenuItem_Click);
			// 
			// helpMenuItem
			// 
			this.helpMenuItem.Index = 2;
			this.helpMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.samplesMenuItem,
																						 this.menuItem2,
																						 this.aboutMenuItem});
			this.helpMenuItem.Text = "&Help";
			// 
			// samplesMenuItem
			// 
			this.samplesMenuItem.Index = 0;
			this.samplesMenuItem.Shortcut = System.Windows.Forms.Shortcut.F1;
			this.samplesMenuItem.Text = "Sa&mples and Walkthroughs";
			this.samplesMenuItem.Click += new System.EventHandler(this.samplesMenuItem_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.Text = "-";
			// 
			// aboutMenuItem
			// 
			this.aboutMenuItem.Index = 2;
			this.aboutMenuItem.Text = "&About";
			this.aboutMenuItem.Click += new System.EventHandler(this.aboutMenuItem_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 3;
			this.menuItem1.Text = "";
			// 
			// statusBar
			// 
			this.statusBar.Location = new System.Drawing.Point(0, 382);
			this.statusBar.Name = "statusBar";
			this.statusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																						 this.statusBarInfoPanel,
																						 this.statusBarAddressPanel});
			this.statusBar.ShowPanels = true;
			this.statusBar.Size = new System.Drawing.Size(584, 28);
			this.statusBar.SizingGrip = false;
			this.statusBar.TabIndex = 3;
			// 
			// statusBarInfoPanel
			// 
			this.statusBarInfoPanel.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.statusBarInfoPanel.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.Raised;
			this.statusBarInfoPanel.Width = 574;
			// 
			// statusBarAddressPanel
			// 
			this.statusBarAddressPanel.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
			this.statusBarAddressPanel.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.Raised;
			this.statusBarAddressPanel.ToolTipText = "Shown here is the address of this instance of WINAH";
			this.statusBarAddressPanel.Width = 10;
			// 
			// mainPanel
			// 
			this.mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainPanel.Location = new System.Drawing.Point(0, 0);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.Size = new System.Drawing.Size(584, 382);
			this.mainPanel.TabIndex = 10;
			// 
			// mainToolBar
			// 
			this.mainToolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.mainToolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						   this.createNewAgentToolBarButton,
																						   this.sendAgentToolbarButton,
																						   this.KillAgentToolbarButton,
																						   this.feedbackToolBarButton});
			this.mainToolBar.DropDownArrows = true;
			this.mainToolBar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mainToolBar.ImageList = this.mainToolBarImageList;
			this.mainToolBar.Location = new System.Drawing.Point(0, 0);
			this.mainToolBar.Name = "mainToolBar";
			this.mainToolBar.ShowToolTips = true;
			this.mainToolBar.Size = new System.Drawing.Size(584, 42);
			this.mainToolBar.TabIndex = 0;
			this.mainToolBar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.mainToolBar_ButtonClick);
			// 
			// createNewAgentToolBarButton
			// 
			this.createNewAgentToolBarButton.ImageIndex = 0;
			this.createNewAgentToolBarButton.Text = "New Agent";
			this.createNewAgentToolBarButton.ToolTipText = "Click here to load a new mobile agent";
			// 
			// sendAgentToolbarButton
			// 
			this.sendAgentToolbarButton.ImageIndex = 1;
			this.sendAgentToolbarButton.Text = "Send Agent";
			this.sendAgentToolbarButton.ToolTipText = "Click here to send a mobile agent to a remote host";
			// 
			// KillAgentToolbarButton
			// 
			this.KillAgentToolbarButton.ImageIndex = 2;
			this.KillAgentToolbarButton.Text = "Kill Agent";
			this.KillAgentToolbarButton.ToolTipText = "Click here to kill a mobile agent";
			// 
			// feedbackToolBarButton
			// 
			this.feedbackToolBarButton.ImageIndex = 3;
			this.feedbackToolBarButton.Text = "Feedback";
			this.feedbackToolBarButton.ToolTipText = "We need your feedback!";
			// 
			// mainToolBarImageList
			// 
			this.mainToolBarImageList.ImageSize = new System.Drawing.Size(16, 16);
			this.mainToolBarImageList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// displayPanel
			// 
			this.displayPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.displayPanel.Controls.Add(this.mainTabControl);
			this.displayPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.displayPanel.Location = new System.Drawing.Point(0, 42);
			this.displayPanel.Name = "displayPanel";
			this.displayPanel.Size = new System.Drawing.Size(584, 340);
			this.displayPanel.TabIndex = 13;
			// 
			// mainTabControl
			// 
			this.mainTabControl.Controls.Add(this.outputTabPage);
			this.mainTabControl.Controls.Add(this.activeAgentsTabPage);
			this.mainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainTabControl.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.mainTabControl.HotTrack = true;
			this.mainTabControl.Location = new System.Drawing.Point(0, 0);
			this.mainTabControl.Name = "mainTabControl";
			this.mainTabControl.SelectedIndex = 0;
			this.mainTabControl.ShowToolTips = true;
			this.mainTabControl.Size = new System.Drawing.Size(580, 336);
			this.mainTabControl.TabIndex = 0;
			this.mainTabControl.Click += new System.EventHandler(this.mainTabControl_Click);
			// 
			// outputTabPage
			// 
			this.outputTabPage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.outputTabPage.Controls.Add(this.outputTextBox);
			this.outputTabPage.Location = new System.Drawing.Point(4, 27);
			this.outputTabPage.Name = "outputTabPage";
			this.outputTabPage.Size = new System.Drawing.Size(572, 305);
			this.outputTabPage.TabIndex = 0;
			this.outputTabPage.Text = "Output";
			this.outputTabPage.ToolTipText = "Click here to see the console output";
			// 
			// outputTextBox
			// 
			this.outputTextBox.BackColor = System.Drawing.Color.Black;
			this.outputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.outputTextBox.Cursor = System.Windows.Forms.Cursors.Default;
			this.outputTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.outputTextBox.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.outputTextBox.ForeColor = System.Drawing.Color.White;
			this.outputTextBox.Location = new System.Drawing.Point(0, 0);
			this.outputTextBox.Multiline = true;
			this.outputTextBox.Name = "outputTextBox";
			this.outputTextBox.ReadOnly = true;
			this.outputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.outputTextBox.Size = new System.Drawing.Size(568, 301);
			this.outputTextBox.TabIndex = 1;
			this.outputTextBox.TabStop = false;
			this.outputTextBox.Text = "";
			this.outputTextBox.WordWrap = false;
			// 
			// activeAgentsTabPage
			// 
			this.activeAgentsTabPage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.activeAgentsTabPage.Controls.Add(this.activeAgentsGrid);
			this.activeAgentsTabPage.Location = new System.Drawing.Point(4, 27);
			this.activeAgentsTabPage.Name = "activeAgentsTabPage";
			this.activeAgentsTabPage.Size = new System.Drawing.Size(572, 305);
			this.activeAgentsTabPage.TabIndex = 1;
			this.activeAgentsTabPage.Text = "Active Agents";
			this.activeAgentsTabPage.ToolTipText = "Click here to see the active agents";
			this.activeAgentsTabPage.Visible = false;
			// 
			// activeAgentsGrid
			// 
			this.activeAgentsGrid.AllowNavigation = false;
			this.activeAgentsGrid.CaptionFont = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.activeAgentsGrid.CaptionVisible = false;
			this.activeAgentsGrid.DataMember = "";
			this.activeAgentsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.activeAgentsGrid.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.activeAgentsGrid.HeaderFont = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.activeAgentsGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.activeAgentsGrid.Location = new System.Drawing.Point(0, 0);
			this.activeAgentsGrid.Name = "activeAgentsGrid";
			this.activeAgentsGrid.PreferredColumnWidth = 105;
			this.activeAgentsGrid.ReadOnly = true;
			this.activeAgentsGrid.Size = new System.Drawing.Size(568, 301);
			this.activeAgentsGrid.TabIndex = 3;
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 15);
			this.ClientSize = new System.Drawing.Size(584, 410);
			this.Controls.Add(this.displayPanel);
			this.Controls.Add(this.mainToolBar);
			this.Controls.Add(this.mainPanel);
			this.Controls.Add(this.statusBar);
			this.Menu = this.mainMenu;
			this.Name = "MainForm";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.Text = "Windows Agent Host";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
			((System.ComponentModel.ISupportInitialize)(this.statusBarInfoPanel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarAddressPanel)).EndInit();
			this.displayPanel.ResumeLayout(false);
			this.mainTabControl.ResumeLayout(false);
			this.outputTabPage.ResumeLayout(false);
			this.activeAgentsTabPage.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.activeAgentsGrid)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion


		private void exitMenuItem_Click(object sender, System.EventArgs e)
		{
			this.Close();
			Application.Exit();
		}
	

		public void DisplayStatusMessage(string message)
		{
			this.statusBarInfoPanel.Text = message;
		}
	

		private void aboutMenuItem_Click(object sender, System.EventArgs e)
		{
			new AboutForm(AboutProductInfo.Name, AboutProductInfo.Description, AboutProductInfo.Company, AboutProductInfo.Copyright, AboutProductInfo.Version).ShowDialog(this);
		}

		

		public void NewAgent(string agentname,string asmPath,string param)
		{
			EtherYatri.IAgentHost host = (EtherYatri.IAgentHost)Activator.GetObject(typeof(EtherYatri.IAgentHost),
				EtherYatri.AgentHost.Url);
			if (host == null)
			{
				Console.Write("Could not locate server");
				return;
			}
			
			try
			{
				ObserverSingelton.GetInstance().Remove(this);
				object initArg = null;
				if(param!=null)
				{if (param.Trim().Length != 0)
					 initArg = param;}

				// Create agent at the host
				this.statusBarInfoPanel.Text = "Creating Agent...";
				this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
				EtherYatri.AgentProxy agentProxy = host.CreateAgent(asmPath,agentname, initArg);
				ObserverSingelton.GetInstance().Add(this,EtherYatri.AgentHost.Url);
			}
			catch (Exception ex)
			{
				ex.ToString();
				MessageBox.Show("Could not create new agent.", "Create New Agent Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			finally
			{
				this.statusBarInfoPanel.Text = "Ready.";
				this.Cursor = Cursors.Default;
			}
	
		}
		
		private void CreateNewAgent()
		{
			// Show the create new agent form
			NewAgent newAgentForm = new NewAgent();
			DialogResult dialogResult = newAgentForm.ShowDialog(this);
			if (dialogResult == DialogResult.Cancel)
				return;
			NewAgent(newAgentForm.AgentTypeName,newAgentForm.AgentAssemblyPath,newAgentForm.InitString);
			newAgentForm.Dispose();
			newAgentForm.SavePast();
		}


		private void SendAgent()
		{
			try
			{
				// Find selected agent
				int selectedAgentIndex = this.activeAgentsGrid.CurrentRowIndex;
				if (selectedAgentIndex < 0)
				{
					this.mainTabControl.SelectedTab = this.activeAgentsTabPage;
					MessageBox.Show("Please select an agent to send.", "Agent Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				// Get the params of the selected agent
				// Typename, assemblypath, creationtime can never be null
				// other columns may be null.
				string agentTypeName = (string)this.agentsDataTable.Rows[selectedAgentIndex][0];
				string agentAssemblyPath = (string)this.agentsDataTable.Rows[selectedAgentIndex][1];
				string agentInitializationArgs = null;
				if (this.agentsDataTable.Rows[selectedAgentIndex][2] != System.DBNull.Value)
					agentInitializationArgs = (string)this.agentsDataTable.Rows[selectedAgentIndex][2];
				string agentCreationTime = (string)this.agentsDataTable.Rows[selectedAgentIndex][3];
				string agentComments = null;
				if (this.agentsDataTable.Rows[selectedAgentIndex][4] != System.DBNull.Value)
					agentComments = (string)this.agentsDataTable.Rows[selectedAgentIndex][4];

				// Get the address of the destination host
				SendAgentForm sendAgentForm = new SendAgentForm(agentTypeName, agentAssemblyPath, agentInitializationArgs, agentCreationTime, agentComments);
				DialogResult dialogResult = sendAgentForm.ShowDialog(this);
				if (dialogResult == DialogResult.Cancel)
					return;

				// Get the proxy of the agent from the list of proxies
				// Get the proxy of the selected agent
				string id = this.agentsDataTable.Rows[selectedAgentIndex]["id"].ToString();
				AgentProxy agentProxy = GetProxy(id);
			
				// Send the agent
				this.statusBarInfoPanel.Text = "Sending Agent to '" + sendAgentForm.DestinationHostAddress + "'. Please wait...";
				this.Cursor = Cursors.WaitCursor;
				agentProxy.MoveTo(sendAgentForm.DestinationHostAddress);
				this.statusBarInfoPanel.Text = "Sending Complete.";
			}
			catch (Exception)
			{
				MessageBox.Show("Could not send agent.", "Send Agent Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			finally
			{
				this.statusBarInfoPanel.Text = "Ready.";
				this.Cursor = Cursors.Default;
			}
		}


		private EtherYatri.AgentProxy GetProxy(string id)
		{
			EtherYatri.IAgentHost host = (EtherYatri.IAgentHost)Activator.GetObject(typeof(EtherYatri.IAgentHost),
				EtherYatri.AgentHost.Url);
			if (host == null)
			{
				Console.Write("Could not locate server");
				return null;
			}
			return host.FindId(new Guid(id));
	
		}

		private void KillAgent()
		{
			// Get the index of the selected Agent
			int selectedAgentIndex = this.activeAgentsGrid.CurrentRowIndex;
			if (selectedAgentIndex < 0)
			{
				this.mainTabControl.SelectedTab = this.activeAgentsTabPage;
				MessageBox.Show("Please select an agent to kill.", "Agent Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			DialogResult dialogResult = MessageBox.Show("Are you sure you want to kill the selected agent?", "Kill Agent", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dialogResult == DialogResult.No)
				return;

			// Get the proxy of the selected agent
			string id = this.agentsDataTable.Rows[selectedAgentIndex]["id"].ToString();
			AgentProxy agentProxy = GetProxy(id);

			

			try
			{
				ObserverSingelton.GetInstance().Remove(this);
				this.statusBarInfoPanel.Text = "Killing Agent...";
				agentProxy.Dispose();
				ObserverSingelton.GetInstance().Add(this,EtherYatri.AgentHost.Url);
			}
			catch (Exception ex)
			{
				ex.ToString();
				MessageBox.Show("Could not kill agent.", "Kill Agent Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			finally
			{
				this.statusBarInfoPanel.Text = "Ready.";
			}
		}

		
		private void createNewAgentMenuItem_Click(object sender, System.EventArgs e)
		{
			this.CreateNewAgent();
		}

		private void sendAgentMenuItem_Click(object sender, System.EventArgs e)
		{
			this.SendAgent();
		}

		private void killAgentMenuItem_Click(object sender, System.EventArgs e)
		{
			this.KillAgent();
		} 


		private void samplesMenuItem_Click(object sender, System.EventArgs e)
		{
			System.Diagnostics.Process.Start("iexplore", System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Help\EtherYatri_Samples_and_Walkthroughs_Start.htm");
		}


		private void mainToolBar_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if (e.Button.Equals(this.createNewAgentToolBarButton))
			{
				this.CreateNewAgent();
			}
			else if (e.Button.Equals(this.sendAgentToolbarButton))
			{
				this.SendAgent();
			}
			else if (e.Button.Equals(this.KillAgentToolbarButton))
			{
				this.KillAgent();
			}
			else if (e.Button.Equals(this.feedbackToolBarButton))
			{
				new FeedbackForm(AboutProductInfo.Version).ShowDialog();
			}
		}

		private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}


		public void UpdateList(DataTable tb)
		{
			for(int i=0; i<agentsDataTable.Rows.Count;i++)
			{
				if(tb.Select("id = '"+agentsDataTable.Rows[i]["id"]+"'").Length==0)
				{
					agentsDataTable.Rows.Remove(agentsDataTable.Rows[i]);
					i--;
				}
			}
			foreach(DataRow r in agentsDataTable.Rows)
			{
				if(tb.Select("id = '"+r["id"]+"'").Length==0)
					agentsDataTable.Rows.Remove(r);
			}


			foreach(DataRow row in tb.Rows)
			{
				DataRow[] rows = agentsDataTable.Select("id = '"+row["id"]+"'");
				if(rows.Length==1)
				{
					rows[0].ItemArray = row.ItemArray;
				}
				else agentsDataTable.Rows.Add(row.ItemArray);
			}
		}

		private void UpdateGrid()
		{
			/*	if(latest!=null)
				{
					activeAgentsGrid.SetDataBinding(latest,null);
					agentsDataTable=latest;
				} */
		}


		private void mainTabControl_Click(object sender, System.EventArgs e)
		{
			UpdateGrid();
		}


		//		// called thru a Invoke call on the this form's thread.
		//		private void AddAgent(string agentAssemblyPath, string agentTypeName, AgentProxy agentProxy)
		//		{
		//			this.agentProxies.Add(agentProxy);
		//			this.agentsDataTable.LoadDataRow(new object[] {agentTypeName, agentAssemblyPath, "<Un-known>", System.DateTime.Now, "Migrated here or was created by another agent",true}); 
		//		}
		//
		//
		//		// called thru a Invoke call on this form's thread.
		//		private void RemoveAgent(AgentProxy agentProxy)
		//		{
		//			this.agentsDataTable.Rows.RemoveAt(this.agentProxies.IndexOf(agentProxy));
		//			this.agentProxies.Remove(agentProxy);
		//		}


		
		


		


	}
}

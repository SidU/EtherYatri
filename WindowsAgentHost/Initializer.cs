/*************************************************************************************
 * 
 * (c) 2003 Siddharth Uppal <siddharthuppal@yahoo.co.in>
 * All rights reserved.
 * 
 * Visit EtherYatri Homepage: http://www.geocities.com/siddharthuppal/EtherYatri.htm
 * 
 *************************************************************************************/

using System;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;
using EtherYatri;


namespace AgentHost2003
{
	/// <summary>
	/// Initializes an instance of EtherYatri Agent Host application
	/// after taking the necessary input from the user.
	/// </summary>
	public class AppInitializer
	{
		private static Preferences preferences;
		public static string preferencesFilePath;


		private static bool OldPreferencesAvailable()
		{
			return File.Exists(preferencesFilePath+"/Preferences.xml");
		}


		private static Preferences LoadPreferences()
		{
			FileStream fs = File.OpenRead(AppInitializer.preferencesFilePath+"/Preferences.xml");
			XmlSerializer ser = new XmlSerializer(typeof(Preferences));
			Preferences preferences = (Preferences)ser.Deserialize(fs);
			fs.Close();

			return preferences;
		}


		public static void SavePreferences()
		{
			try
			{
				FileStream fs = File.Open(AppInitializer.preferencesFilePath+"/Preferences.xml", FileMode.OpenOrCreate);
				XmlSerializer ser = new XmlSerializer(typeof(Preferences));
				ser.Serialize(fs, preferences);
				fs.Close();
			}
			catch (Exception)
			{
				return; // Silently exit.
			}
		}


		private static void GetPreferencesFromUser()
		{
			// Show preferences form
			PreferencesForm preferencesForm = new PreferencesForm(8000);
			preferencesForm.ShowDialog();

			//if(preferencesForm.multiServer==true)
			
			string defaultContextDirParent = @"C:\EtherYatri\AgentContexts\";
			string defaultContextDir = defaultContextDirParent + preferencesForm.PortNumber;
			
			AppInitializer.preferences = new Preferences(defaultContextDir, preferencesForm.PortNumber);
			preferencesForm.Dispose();
		}


		[STAThread]
		public static void Main(string[] args)
		{
			string usage = "\nUsage:\n" + 
						   " WINAH [Port-Number]";
            
			/*if (args.Length > 1)
			{
				MessageBox.Show("Error: Invalid arguments.\n" +
					usage, "Invalid Arguments", MessageBoxButtons.OK, MessageBoxIcon.Error);
				
				return;
			}*/

			AppInitializer.preferencesFilePath = @"C:\EtherYatri";

			if (args.Length >0) // Port number was specified at command line.
			{
				int portNumber;
				
				try
				{
					portNumber = int.Parse(args[0]);
				}
				catch (FormatException)
				{
					MessageBox.Show("Error: Please enter an integer for port number.\n" + usage, "Invalid Port-Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				string defaultContextDirParent = @"C:\EtherYatri\AgentContexts\";
				string defaultContextDir = defaultContextDirParent + portNumber;
			
				AppInitializer.preferences = new Preferences(defaultContextDir, portNumber);
			}
			else
			{
				// Load old preferences if they are available, otherwise get preferences
				// from user.
				if (AppInitializer.OldPreferencesAvailable()) 
				{
					DialogResult dialogResult = MessageBox.Show("Load saved EtherYatri Agent Host preferences?", "Load WINAH Preferences", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
					if (dialogResult == DialogResult.Cancel)
						return;									// terminate execution
					else if (dialogResult == DialogResult.Yes)
						preferences = AppInitializer.LoadPreferences();
					else								// dialogResult == DialogResult.No
						AppInitializer.GetPreferencesFromUser();
				}
				else
					AppInitializer.GetPreferencesFromUser();
			}

			try
			{
				// Initialize AgentHost
				AgentHost.Start("http", preferences);
				ObserverSingelton.GetInstance().Start(preferences.PortNumber,"http");
			}
			catch (Exception)
			{
				MessageBox.Show("The port number you selected is in use.\n" +
								"Please restart WINAH and specify a different port number.",
					            "Port in Use", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			//try
			//{
				MainForm mainForm = new MainForm(AgentHost.Url);
			
				// Display some trace messages to the user.
				Console.WriteLine("WINAH listening for agents...");
				Console.WriteLine(); Console.WriteLine();
		
				mainForm.DisplayStatusMessage("Ready.");

				if(args.Length==3) mainForm.NewAgent(args[1],args[2],null);
				else if(args.Length==4) mainForm.NewAgent(args[1],args[2],args[3]);
			
			
				Application.Run(mainForm);

				//			mainForm.ShowDialog();
				//
				//			mainForm.Dispose();

				AppInitializer.SavePreferences();
			
				AgentHost.Stop();
			
				// To remove the bug that WINAH.exe continues to hang around in
				// the process table.
				System.Diagnostics.Process.GetCurrentProcess().Kill();
			//}
			//catch(Exception ex)
			//{
			//	MessageBox.Show(ex.ToString(),"Exception");
			//}
		}


		/// <summary>
		/// Make the default constructor private because no instances of a type
		/// whose all members are static can be expected to be created.
		/// </summary>
		private AppInitializer()
		{
		}
	}
}

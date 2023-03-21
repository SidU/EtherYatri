using System;
using System.Windows.Forms;
using EtherYatri;

namespace MigratoryApps
{
	[Serializable]
	public class NotepadAgent : EtherYatri.Agent
	{
		public string[] state = null;
		
		[NonSerializedAttribute]
		private NotepadForm notepadForm = null;

		public override void Run()
		{
			Console.WriteLine(this.GetType() + " executing on this host.");
			this.notepadForm = new NotepadForm(this);
			
			// Set state of Notepad form
			this.notepadForm.State = this.state;

			this.notepadForm.ShowDialog();
			Console.WriteLine(this.GetType() + " terminating execution on this host.");
		}


		public override void OnMigration(string url)
		{
			Console.WriteLine(this.GetType() + " migrating to " + url + ".");
			
			// Get state of Notepad Form
			this.state = this.notepadForm.State;
		}


		public static void Main()
		{
			EtherYatri.IAgentHost host = (EtherYatri.IAgentHost)Activator.GetObject(typeof(EtherYatri.IAgentHost),
				"http://localhost:8000/AgentHost");
			if (host == null)
			{
				Console.Write("Could not locate server");
				return;
			}

			EtherYatri.AgentProxy agentProxy = host.CreateAgent(typeof(MigratoryApps.NotepadAgent).Assembly.Location, "MigratoryApps.NotepadAgent", null);
		}

	}
}

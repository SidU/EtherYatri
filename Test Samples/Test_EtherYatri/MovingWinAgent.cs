using System;
using System.Windows.Forms;

namespace Test
{
	/// <summary>
	/// MovingWinAgent starts its execution on the host where it is loaded and
	/// subsequently moves to the host whose address is specified to it during
	/// its creation. 
	/// </summary>
	[Serializable]
	public class MovingWinAgent : EtherYatri.Agent
	{
		public string destinationHostUrl = null;
		public int state = 0;


		/// <summary>
		/// Is called once when this agent is created.
		/// </summary>
		/// <param name="init">can be used to initialize an agent.</param>
		public override void OnCreation(object init)
		{
			string message = this.GetType().ToString() + " created on host " + this.AgentContext.LocalHostAddress + ".";
            			
			Console.WriteLine(message);
			MessageBox.Show(message, this.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
			this.destinationHostUrl = (string)init;
		}


		/// <summary>
		/// This is where an agent does its main work.
		/// </summary>
		public override void Run()
		{
			string message = this.GetType() + " started execution on host " + this.AgentContext.LocalHostAddress + ".";

			Console.WriteLine(message);
			MessageBox.Show(message, this.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);

			if (this.state == 0)
			{
				this.MoveTo(this.destinationHostUrl);
			}
		}


		/// <summary>
		/// Is called before an agent moves from the current host to another host.
		/// </summary>
		/// <param name="url">Url of the host where the agent is moving to.</param>
		public override void OnMigration(string url)
		{
			Console.WriteLine(this.GetType().ToString() + " moving to host " + url + ".");
		}


		/// <summary>
		/// Is called on the agent when it reaches another host after migration.
		/// </summary>
		public override void OnArrival()
		{
			Console.WriteLine(this.GetType().ToString() + " has reached host " + this.AgentContext.LocalHostAddress + ".");
			this.state++;
		}

	}
}

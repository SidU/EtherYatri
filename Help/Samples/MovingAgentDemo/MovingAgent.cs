using System;
using EtherYatri;

namespace MovingAgentDemo
{
	/// <summary>
	/// MovingAgent when loaded on a host, starts executing and then moves
	/// to another host whose Url is passed as argument to its OnCreation method.
	/// </summary>
	[Serializable]
	public class MovingAgent : EtherYatri.Agent
	{
		private string destinationHostUrl = null;
		private int state = 0;	// to remember on which host we are executing.


		/// <summary>
		/// Is called once when this agent is created.
		/// </summary>
		/// <param name="init">can be used to initialize an agent.</param>
		public override void OnCreation(object init)
		{
			// Print a trace message on console and in a message box
			string message = this.GetType().ToString() + " created on host " + this.AgentContext.LocalHostAddress + ".";
			Console.WriteLine(message);
						
			if (init != null)
				this.destinationHostUrl = (string)init;
		}


		/// <summary>
		/// This is where an agent does its main work. Run is called afresh
		/// whenever the mobile agent starts executing on a host as a result of
		/// migrating to it, or being loaded at it.
		/// </summary>
		public override void Run()
		{
			// Print a trace message on console and display a message box.
			string message = this.GetType() + " started execution on host " + this.AgentContext.LocalHostAddress + ".";
			Console.WriteLine(message);

			// Move if we are on the initial host and some Url was passed to us OnCreation.
			if (this.state == 0 && this.destinationHostUrl != null)
				this.MoveTo(this.destinationHostUrl);
			
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

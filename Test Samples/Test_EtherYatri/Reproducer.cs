using System;
using System.Windows.Forms;

namespace Test
{
	/// <summary>
	/// WinAgent just prints trace messages to the console and also displays them
	/// in message-boxes as and when events in its lifetime are fired.
	/// </summary>
	[Serializable]
	public class ReproducerWinAgent : EtherYatri.Agent
	{
		private int nTimesReproduce;

		/// <summary>
		/// Is called once when this agent is created.
		/// </summary>
		/// <param name="init">can be used to initialize an agent.</param>
		public override void OnCreation(object init)
		{
			Console.WriteLine(this.GetType() + "'s OnCreation method called with: '{0}'.", (string)init);
			MessageBox.Show(this.GetType() + "'s OnCreation method called with: '" + (string)init + "' at Host: '" + this.AgentContext.LocalHostAddress + "'", "WinAgent", MessageBoxButtons.OK, MessageBoxIcon.Information);

			this.nTimesReproduce = int.Parse((string)init);
		}


		/// <summary>
		/// This is where an agent does its main work.
		/// </summary>
		public override void Run()
		{
			Console.WriteLine(this.GetType() + " started executing on this host.");
			MessageBox.Show(this.GetType() + "'s Run called at Host: '" + this.AgentContext.LocalHostAddress + "'", "WinAgent", MessageBoxButtons.OK, MessageBoxIcon.Information);

			if (this.nTimesReproduce > 0)
				this.AgentContext.CreateAgent(this.GetType().Assembly.Location, "Test.ReproducerWinAgent", (this.nTimesReproduce - 1).ToString());
            
			while (true) // Infinite loop
				;
		}


		/// <summary>
		/// Is called by remote agents on this agent.
		/// </summary>
		/// <param name="name">name of the person to greet.</param>
		/// <returns>greetings for the person.</returns>
		[EtherYatri.AgentWebMethod]
		public void SayHello(string name)
		{
			Console.WriteLine(this.GetType() + "'s method SayHello called with '" + name + "'.");
			MessageBox.Show("Hello '" + name + "'.", this.GetType().ToString());
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
		}

		/// <summary>
		/// Is called once when this agent is created.
		/// </summary>
		/// <param name="init">can be used to initialize an agent.</param>
		public override void OnStopping()
		{
			Console.WriteLine(this.GetType() + "'s OnStopping called.");
			MessageBox.Show(this.GetType() + "'s OnStopping called.", "WinAgent", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

	}
}

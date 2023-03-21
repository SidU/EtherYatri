using System;
using System.Windows.Forms;
using EtherYatri;

namespace Test
{
	/// <summary>
	/// Writes a key-value pair in the agent-context and then spawns another agent. The
	/// child agent reads the key-value pair from the agent-context.
	/// Key set: "wishWho" to value: "Siddharth".
	/// Agent Spawned: "Test.ReaderWinAgent".
	/// </summary>
	public class WriterWinAgent : EtherYatri.Agent
	{
		public override void Run()
		{
			MessageBox.Show(this.GetType().ToString() + "'s Run called on host '" + this.AgentContext.LocalHostAddress + "'.", this.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            Console.WriteLine(this.GetType() + " started executing on this host.");
			
			// Place a string key in the context with some string value.
			this.AgentContext.SetProperty("wishWho", "Siddharth");

			// Spawn new agent
			Console.WriteLine(this.GetType() + " spawning agent 'ReaderWinAgent'.");
			AgentProxy agentProxy = this.AgentContext.CreateAgent(this.GetType().Assembly.Location, "Test.ReaderWinAgent", null);
			
			Console.WriteLine(this.GetType() + " terminating execution.");
		}



	}
}

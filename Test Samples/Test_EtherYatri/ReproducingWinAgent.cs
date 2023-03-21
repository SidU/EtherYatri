using System;
using System.Windows.Forms;
using EtherYatri;

namespace Test
{
	/// <summary>
	/// ReproducingWinAgent spawns another agent and invokes one of its AgentWebMethods.
	/// This tests the communication features of the toolkit.
	/// </summary>
	public class ReproducingWinAgent : EtherYatri.Agent
	{
		public string childAgentTypeName = "Test.WinAgent";
		public string chidAgentMethodName = "SayHello";
		public string chidAgentMethodParams = "DotNetJunkie";

		/// <summary>
		/// This is where an agent does its main work.
		/// </summary>
		public override void Run()
		{
			MessageBox.Show(this.GetType().ToString() + "'s Run called on host '" + this.AgentContext.LocalHostAddress + "'.", this.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            Console.WriteLine(this.GetType() + " started executing on this host.");
			
			// Spawn new agent
			Console.WriteLine(this.GetType() + " spawning agent '" + this.childAgentTypeName + "'.");
			AgentProxy agentProxy = this.AgentContext.CreateAgent(this.GetType().Assembly.Location, this.childAgentTypeName, "Hi There!");

			// Invoke method on new agent
			Console.WriteLine(this.GetType() + " invoking method '" + this.chidAgentMethodName + "' with parameters '" + this.chidAgentMethodParams + "'.");
			agentProxy.InvokeMethod(this.chidAgentMethodName, new object[1] {this.chidAgentMethodParams});

			Console.WriteLine(this.GetType() + " terminating execution.");

			this.Proxy.LocalAgentHost = (IAgentHost) this.AgentContext;
		}



	}
}

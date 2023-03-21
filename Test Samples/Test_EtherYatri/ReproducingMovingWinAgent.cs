using System;
using System.Windows.Forms;
using EtherYatri;

namespace Test
{
	[Serializable]
	public class ReproducingMovingWinAgent : EtherYatri.Agent
	{
		private string childAgentTypeName = "Test.WinAgent";
		private string chidAgentMethodName = "SayHello";
		private string chidAgentMethodParams = "DotNetJunkie";

		private string destinationHostAddress;
		private int state;
		
		private AgentProxy childAgentProxy = null;


		public override void OnCreation(object init)
		{
			this.destinationHostAddress = (string)init;
		}


		/// <summary>
		/// This is where an agent does its main work.
		/// </summary>
		public override void Run()
		{
			MessageBox.Show(this.GetType().ToString() + "'s Run called on host '" + this.AgentContext.LocalHostAddress + "'.", this.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
			Console.WriteLine(this.GetType() + " started executing on this host.");

			if (this.state == 0)
			{
				// Spawn new agent
				Console.WriteLine(this.GetType() + " spawning agent '" + this.childAgentTypeName + "'.");
				this.childAgentProxy = this.AgentContext.CreateAgent(this.GetType().Assembly.Location, this.childAgentTypeName, "Hi There!");

				// Move to remote host
				this.MoveTo(this.destinationHostAddress);
			}
			else
			{
				// Invoke method on agent that we had spawned
				Console.WriteLine(this.GetType() + " invoking method '" + this.chidAgentMethodName + "' with parameters '" + this.chidAgentMethodParams + "'.");
				this.childAgentProxy.InvokeMethod(this.chidAgentMethodName, new object[1] {this.chidAgentMethodParams});
			}

			Console.WriteLine(this.GetType() + " terminating execution.");
		}


		public override void OnMigration(string destinationAddress)
		{
			Console.WriteLine(this.GetType() + " OnMigration called with '" + destinationAddress + "'.");
		}


		public override void OnArrival()
		{
			this.state++;
			Console.WriteLine(this.GetType() + " OnArrival called on this host.");
		}

	}
}

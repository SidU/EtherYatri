/**
 * Communication Sample: This sample demonstrates how an agent can communicate 
 * with another agent.
 * 
 * Running the sample:
 * 1. Press Ctrl-Shift-b to build the solution.
 * 2. Load ReproducingAgent in WINAH by specifying the path of the assembly file 
 *    generated as a result of compilation of the solution, and the type name of 
 *    agent as "CommunicationDemo.ReproducingAgent".
 * 
 * ReproducingAgent will create SimpleAgent and then invoke its SayHello method.
 * 
 * Send comments and suggestions at siddharthuppal@yahoo.co.in. 
 */

using System;
using System.Windows.Forms;
using EtherYatri;

namespace CommunicationDemo
{
	/// <summary>
	/// SimpleAgent prints trace messages to console and displays message-boxes
	/// as various events in its lifetime are fired.
	/// </summary>
	public class SimpleAgent : EtherYatri.Agent
	{
		/// <summary>
		/// Is called by remote agents on this agent.
		/// </summary>
		/// <param name="name">name of the person to greet.</param>
		/// <returns>greetings for the person.</returns>
		[AgentWebMethod]
		public void SayHello(string name)
		{
			Console.WriteLine(this.GetType() + "'s method SayHello called with '" + name + "'.");
			MessageBox.Show("Hello '" + name + "'.", this.GetType().ToString());
		}


		/// <summary>
		/// Is called once when this agent is created.
		/// </summary>
		/// <param name="init">can be used to initialize an agent.</param>
		public override void OnCreation(object init)
		{
			Console.WriteLine(this.GetType() + "'s OnCreation method called with: '{0}'.", (string)init);
			MessageBox.Show(this.GetType() + "'s OnCreation method called with: '" + (string)init + "' at Host: '" + this.AgentContext.LocalHostAddress + "'", "WinAgent", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}


		/// <summary>
		/// This is where an agent does its main work.
		/// </summary>
		public override void Run()
		{
			Console.WriteLine(this.GetType() + " started executing on this host.");
			MessageBox.Show(this.GetType() + "'s Run called at Host: '" + this.AgentContext.LocalHostAddress + "'", "WinAgent", MessageBoxButtons.OK, MessageBoxIcon.Information);

			while (true) // Infinite loop because someone might want to call our method.
				;
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
	}
}

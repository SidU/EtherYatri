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
using EtherYatri;
using System.Windows.Forms;

namespace CommunicationDemo
{
	/// <summary>
	/// ReproducingAgent when loaded spawns another agent and then invokes
	/// one of the new agent's exposed methods.
	/// </summary>
	public class ReproducingAgent : EtherYatri.Agent
	{
		public string childAgentTypeName = "CommunicationDemo.SimpleAgent";
		public string chidAgentMethodName = "SayHello";
		public string chidAgentMethodParams = "World";

		/// <summary>
		/// This is where an agent does its main work.
		/// </summary>
		public override void Run()
		{
			// Print a trace message to console and in a message box
			MessageBox.Show(this.GetType().ToString() + "'s Run called on host '" + this.AgentContext.LocalHostAddress + "'.", this.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
			Console.WriteLine(this.GetType() + " started executing on this host.");
			
			// Spawn new agent
			Console.WriteLine(this.GetType() + " spawning agent '" + this.childAgentTypeName + "'.");
			AgentProxy agentProxy = this.AgentContext.CreateAgent(this.GetType().Assembly.Location, this.childAgentTypeName, "Hi There!");
			
			// Invoke method on new agent
			Console.WriteLine(this.GetType() + " invoking method '" + this.chidAgentMethodName + "' with parameters '" + this.chidAgentMethodParams + "'.");
			agentProxy.InvokeMethod(this.chidAgentMethodName, new object[1] {this.chidAgentMethodParams});
			
			Console.WriteLine(this.GetType() + " terminating execution.");
		}
	}
}

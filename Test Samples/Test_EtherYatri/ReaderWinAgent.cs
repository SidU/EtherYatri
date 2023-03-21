using System;
using System.Windows.Forms;

namespace Test
{
	/// <summary>
	/// Reads the value of "wishWho" key from the agent-context and then 
	/// displays a message-box to wish hello to the name read.
	/// </summary>
	public class ReaderWinAgent : EtherYatri.Agent
	{
		/// <summary>
		/// This is where an agent does its main work.
		/// </summary>
		public override void Run()
		{
			Console.WriteLine(this.GetType() + " started executing on this host.");
			MessageBox.Show(this.GetType() + "'s Run called at Host: '" + this.AgentContext.LocalHostAddress + "'", "WinAgent", MessageBoxButtons.OK, MessageBoxIcon.Information);
			
			// Read the value of key "wishWho" from the context and wish the person Hello.
			MessageBox.Show("Hello '"+ (string)this.AgentContext.GetProperty("wishWho") + "'", this.GetType().ToString());
			Console.WriteLine(this.GetType() + " terminating execution on this host.");
		}
	}
}

using System;
using EtherYatri;

namespace EtherYatri.InternalSystem
{
	/// <summary>
	/// Handles the communication requests between two peers. 
	/// Abstracts the Runtime layer from the technology used
	/// for communication with peers. We use .NET Remoting
	/// for peer-to-peer communication.
	/// P2PCommunicator is a Singleton class.
	/// </summary>
	public class P2PCommunicator : System.MarshalByRefObject, IP2PCommunicator
	{
		#region Private Static Fields
		/// <summary>
		/// A reference to this P2PCommunicator itself.
		/// </summary>
		private P2PCommunicator p2pCommunicator = null;
		#endregion


		#region Private Fields
		/// <summary>
		/// A reference to the EtherYatri Runtime.
		/// </summary>
		Runtime runtime;
		#endregion


		#region Constructors
		private P2PCommunicator()
		{
		}

		private P2PCommunicator(Runtime runtime)
		{
			this.runtime = runtime;
		}

		public P2PCommunicator Initialize()
		{

		}

		#endregion

		
		#region Destructors and Disposers
		#endregion


		#region Public Methods corresponding to requests MADE-TO the Runtime
		#endregion

		#region Public Methods corresponding to requests MADE-BY the Runtime
		#endregion

		public void SendAgent(AgentId agentId, string destinationHostUrl)
		{
		}
		
		public AgentProxy ReceiveAgent(byte[] agentAssembly, byte[] agentState, string agentTypeName)
		{
		}

		public object InvokeAgentMethod(AgentId agentId, string methodName, object[] methodParams)
		{
		}

		public object InvokeRemoteAgentMethod(string hostingUrl, AgentId agentId, string methodName, object[] methodParams)
		{
		}

		public bool AgentExists(AgentId agentId)
		{
		}
		
		public bool RemoteAgentExists(string hostingUrl, AgentId agentId)
		{
		}
	}
}

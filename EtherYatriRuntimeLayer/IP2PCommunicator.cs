using System;

namespace EtherYatri.InternalSystem
{
	/// <summary>
	/// The Runtime-layer expects the Communication-layer to implement this interface.
	/// </summary>
	public interface IP2PCommunicator
	{
		IP2PCommunicator(Runtime runtime);

		public void SendAgent(AgentId agentId, string destinationHostUrl);
		public AgentProxy ReceiveAgent(byte[] agentAssembly, byte[] agentState, string agentTypeName);
		public object InvokeAgentMethod(AgentId agentId, string methodName, object[] methodParams);
		public object InvokeRemoteAgentMethod(string hostingUrl, AgentId agentId, string methodName, object[] methodParams);
		public bool AgentExists(AgentId agentId);
		public bool RemoteAgentExists(string hostingUrl, AgentId agentId);
	}
}

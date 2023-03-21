/*************************************************************************************
 * 
 * (c) 2003 Siddharth Uppal <siddharthuppal@yahoo.co.in>
 * All rights reserved.
 * 
 * Visit EtherYatri Homepage: http://www.geocities.com/siddharthuppal/EtherYatri.htm
 * 
 *************************************************************************************/

using System;
using System.Data;
using System.Collections;

namespace EtherYatri
{
	public delegate void UpdateList();
	/// <summary>
	/// IAgentHost interface describes the methods which the EtherYatri.NET communication-layer must implement.
	/// </summary>
	public interface IAgentHost
	{
		/// <summary>
		/// Execute is invoked by remote hosts to transfer an agent to the local host.
		/// </summary>
		EtherYatri.AgentProxy Execute(byte[] agentAssemblyBytes, byte[] agentState, string agentTypeName, EtherYatri.AgentId agentId);
		
		EtherYatri.AgentProxy Execute(byte[] agentAssemblyBytes, byte[] agentState, string agentTypeName,string stringAgentId);

		/// <summary>
		/// CreateAgent is called by remote hosts to create a new agent on local host.
		/// </summary>
		EtherYatri.AgentProxy CreateAgent(string agentAssemblyPath, string agentTypeName, object init);
		
		
		/// <summary>
		/// CreateAgentOnRemoteHost is used to create a new agent on a remote host.
		/// </summary>
		EtherYatri.AgentProxy CreateAgentOnRemoteHost(string remoteHostAddress, string agentAssemblyPath, string agentTypeName, object init);

		
		/// <summary>
		/// MoveAgent transfers the specified agent from the localhost to a remote host.
		/// </summary>
		EtherYatri.AgentProxy MoveAgent(string destinationAddress, EtherYatri.AgentId agentId);
		
		
		/// <summary>
		/// MoveAgentOnRemoteHost moves an agent located on a remote host to another remote host.
		/// </summary>
		EtherYatri.AgentProxy MoveAgentOnRemoteHost(string remoteHostAddress, string destinationAddress, EtherYatri.AgentId agentId);


		EtherYatri.AgentProxy Clone(string remoteHostAddress,EtherYatri.AgentId agentId,object arg);
		
		/// <summary>
		/// Performs cleanup at the end of an agent's execution.
		/// </summary>
		/// <param name="agentId"></param>
		void DisposeAgent(AgentId agentId);


		/// <summary>
		/// Used to dispose an agent located at a remote host.
		/// </summary>
		/// <param name="agentId"></param>
		void DisposeAgentAtRemoteHost(string remoteHostAddress, AgentId agentId);
		

		/// <summary>
		/// Used by remote hosts to invoke a method of an agent located at
		/// the local host.
		/// </summary>
		/// <param name="agentId">the id of agent whose method is to be invoked</param>
		/// <param name="methodName">the name of the method to be invoked</param>
		/// <param name="parameters">the parameters to be passed while invoking the method</param>
		/// <returns>returns whatever the method returns</returns>
		object InvokeAgentMethod(System.Guid id, string methodName, object[] parameters);
		
		
		/// <summary>
		/// To invoke a method of an agent located at a remote host.
		/// </summary>
		/// <param name="remoteHostAddress">Url of the host where agent is located</param>
		/// <param name="agentId">the id of the agent whose method is to be invoked</param>
		/// <param name="methodName">the method to be invoked on the agent</param>
		/// <param name="parameters">the parameters to be passed to the method while invoking it</param>
		/// <returns>whatever the agent's method returns</returns>
		object InvokeAgentMethodOnRemoteHost(string remoteHostAddress, EtherYatri.AgentId agentId, string methodName, object[] parameters);

		
		/// <summary>
		/// Remote hosts call AgentExists to determine whether specified agent exists
		/// on the local host.
		/// </summary>
		/// <param name="agentId">the id of the agent to be checked</param>
		/// <returns>true if the specified agent exists, false otherwise</returns>
		bool AgentExists(EtherYatri.AgentId agentId);
		
		
		/// <summary>
		/// AgentExistsOnRemoteHost is used to check whether the specified agent 
		/// exists at the specified host.
		/// </summary>
		/// <param name="remoteHostAddress">the url of the host where agent should be searched for</param>
		/// <param name="agentId">the id of the agent to be searched for</param>
		/// <returns>true if the specified agent exists at the specified host, false otherwise</returns>
		bool AgentExistsOnRemoteHost(string remoteHostAddress, EtherYatri.AgentId agentId);

		void AddObserver(string url);
		DataTable GetAgentList();

		EtherYatri.AgentProxy FindId(Guid id);

		ArrayList FindAgentType(string agentType);
	}
}

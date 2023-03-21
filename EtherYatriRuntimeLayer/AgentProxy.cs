#region Copyright (c) 2003, Siddharth Uppal <siddharthuppal@yahoo.co.in>
/************************************************************************************
*
* Copyright © 2003 Siddharth Uppal
*
* This software is provided 'as-is', without any express or implied warranty. In no 
* event will the authors be held liable for any damages arising from the use of this 
* software.
* 
* Permission is granted to anyone to use this software for any purpose, including 
* commercial applications, and to alter it and redistribute it freely, subject to the 
* following restrictions:
*
* 1. The origin of this software must not be misrepresented; you must not claim that 
* you wrote the original software. If you use this software in a product, an 
* acknowledgment (see the following) in the product documentation is required.
*
* Portions Copyright © 2003 Siddharth Uppal
*
* 2. Altered source versions must be plainly marked as such, and must not be 
* misrepresented as being the original software.
*
* 3. This notice may not be removed or altered from any source distribution.
*
************************************************************************************/
#endregion

using System;

namespace EtherYatri
{
	/// <summary>
	/// AgentProxy is like a handle for an agent that can be used to invoke methods
	/// on it. AgentProxy allows client code to be written so that it can transparently
	/// communicate with remote as well as local agents.
	/// </summary>
	[Serializable]
	public class AgentProxy
	{
		#region Private Fields
		/// <summary>
		/// The id of the target agent.
		/// </summary>
		private EtherYatri.AgentId agentId;

		
		/// <summary>
		/// The Url of the host where agent is located.
		/// </summary>
		private string targetHostAddress;

		
		/// <summary>
		/// A reference to the local agent host.
		/// </summary>
		/*[NonSerialized] */ private EtherYatri.IAgentHost localAgentHost;
		#endregion
		
		
		#region Constructor
		/// <summary>
		/// Creates an instance of AgentProxy.
		/// </summary>
		/// <param name="targetHostAddress">the url of the host where the referred agent is located</param>
		/// <param name="agentId">the id of the referred agent</param>
		public AgentProxy(string targetHostAddress, EtherYatri.AgentId agentId)
		{
			this.targetHostAddress = targetHostAddress;
			this.agentId = agentId;
		}
		#endregion
		

		#region Public Methods to perform operations on agents
		/// <summary>
		/// Moves the referred agent to another host from its current host.
		/// </summary>
		/// <param name="destinationAddress">the url of the host where migratio is desired</param>
		/// <returns>a new proxy referring to the agent after it has migrated to the destination host</returns>
		public AgentProxy MoveTo(string destinationAddress)
		{
			return this.localAgentHost.MoveAgentOnRemoteHost(this.targetHostAddress, destinationAddress, this.agentId);
		}

		public AgentProxy Clone(object arg)
		{
			return this.localAgentHost.Clone(this.targetHostAddress,this.agentId,arg);		
		}

		
		/// <summary>
		/// Invokes the specified method on the referred agent.
		/// </summary>
		/// <param name="methodName">the name of the method to be invoked</param>
		/// <param name="parameters">the paremeters that should be passed to the specified method</param>
		/// <returns>returns whatever the method returns</returns>
		public object InvokeMethod(string methodName, object[] parameters)
		{
			return this.localAgentHost.InvokeAgentMethodOnRemoteHost(this.targetHostAddress, this.agentId, methodName, parameters);
		}


		/// <summary>
		/// Causes the referred agent to be disposed off.
		/// </summary>
		public void Dispose()
		{
			this.localAgentHost.DisposeAgentAtRemoteHost(this.targetHostAddress, this.Id);
		}
		#endregion

		
		#region Public Properties
		public AgentId Id
		{
			get
			{
				return this.agentId;
			}
		}
	
		
		/// <summary>
		/// The Url of the host where agent is located.
		/// </summary>
		public string TargetHostAddress
		{
			get
			{
				return this.targetHostAddress;
			}
		}


		/// <summary>
		/// Determines whether the referred agent actually exists on the
		/// target host.
		/// </summary>
		public bool IsValid
		{
			get
			{
				// Contact remote host to determine if this proxy is valid
				return this.localAgentHost.AgentExistsOnRemoteHost(this.targetHostAddress, this.agentId);
			}
		}

		
		/// <summary>
		/// A reference to the local agent host.
		/// </summary>
		public EtherYatri.IAgentHost LocalAgentHost
		{
			get
			{
				return this.localAgentHost;
			}
			set
			{
				this.localAgentHost = value;
			}
		}
		#endregion
	}
}

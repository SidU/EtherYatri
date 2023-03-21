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
using EtherYatri.InternalSystem;

namespace EtherYatri
{
	/// <summary>
	/// To create their own agents, clients must inherit from Agent class and
	/// override atleast its Run method. Additionally, if the agent would be moving
	/// from one host to another, it must be marked with Serializable attribute.
	/// </summary>
	[Serializable]
	public abstract class Agent
	{
		#region Private Fields
		/// <summary>
		/// A reference to the agent mananager who controls this agent.
		/// </summary>
		[NonSerializedAttribute]
		private AgentManager agentManager;
		
		
		/// <summary>
		/// The unique id associated with this agent.
		/// </summary>
		private AgentId id;
		#endregion


		#region Public Abstract Methods
		/// <summary>
		/// An Agent does its main work in Run method. Run is called on every host
		/// where the agent begins its execution.
		/// </summary>
		public abstract void Run();
		#endregion
		

		#region Public Virtual Methods
		/// <summary>
		/// OnCreation is fired when this Agent is created. OnCreation is fired only
		/// once during the entire lifetime of the agent.
		/// </summary>
		/// <param name="init">You can use init to initialize your agent</param>
		public virtual void OnCreation(object init)
		{
		}

		public virtual void OnCloning(object arg)
		{
		}


		/// <summary>
		/// OnStopping is fired when this Agent is stopped. OnStopping is fired
		/// if the agent is asked to terminate by its proxy.
		/// </summary>
		public virtual void OnStopping()
		{
		}


		/// <summary>
		/// Fired when the agent reaches a new host.
		/// </summary>
		public virtual void OnArrival()
		{
		}

		/// <summary>
		/// Fired just before the agent moves to another host.
		/// </summary>
		public virtual void OnMigration(string destinationAddress)
		{
		}
		#endregion


		#region Public Methods to perform operations on mobile-agents
		/// <summary>
		/// Moves this Agent to another host.
		/// </summary>
		/// <param name="address">the url of the host where migration is desired</param>
		public void MoveTo(string address)
		{
			this.agentManager.MoveTo(address);
		}
		#endregion
		
		
		#region Methods invoked internally by system
		/// <summary>
		/// Used by EtherYatri.NET Framework to internally initialize the Agent
		/// </summary>
		/// <param name="agentManager"></param>
		internal void Initialize(AgentManager agentManager)
		{
			this.agentManager = agentManager;
			this.id = this.agentManager.Id;
		}
		#endregion
		

		#region Public Properties
		/// <summary>
		/// The globally unique id associated with this agent.
		/// </summary>
		public AgentId Id
		{
			get
			{
				return this.id;
			}
		}


		/// <summary>
		/// The Agent's context.
		/// </summary>
		public EtherYatri.IAgentContext AgentContext
		{
			get
			{
				return this.agentManager.GetContext();
			}
		}


		/// <summary>
		/// A proxy to the agent.
		/// </summary>
		public EtherYatri.AgentProxy Proxy
		{
			get
			{
				AgentProxy agentProxy = new AgentProxy(this.AgentContext.LocalHostAddress, this.Id);
				agentProxy.LocalAgentHost = (EtherYatri.IAgentHost)this.AgentContext;
				
				return agentProxy;
			}
		}


		/// <summary>
		/// Path of the assembly containing the agent's code.
		/// </summary>
		public string AssemblyPath
		{
			get
			{
				return this.GetType().Assembly.Location;
			}
		}
		#endregion


	}
}

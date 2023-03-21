/*
 * Added on July 14, 2003 by Siddharth Uppal <siddharthuppal@yahoo.co.in>
 * 
 */

using System;
using System.Collections;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Threading;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;



namespace EtherYatri.InternalSystem
{
	/// <summary>
	/// Runtime is a Singleton class, i.e. only one instance of this class will ever
	/// be created.
	/// AgentProxies use a reference to an instance of this class.
	/// </summary>
	public class Runtime
	{
		#region Private Static fields
		/// <summary>
		/// A reference to the runtime object. 
		/// </summary>
		private static Runtime	runtime = null;
		#endregion

		#region Private Fields
		/// <summary>
		/// A reference to the communicator which helps this Runtime communicate with
		/// Runtime on another host.
		/// </summary>
		private ICommunicator	communicator;

		
		/// <summary>
		/// The address of the host that is hosting this runtime.
		/// </summary>
		private string url;

		
		/// <summary>
		/// The agent context.
		/// </summary>
		private AgentContext agentContext;


		/// <summary>
		/// agentManagerTable is indexed by AgentId, and stores 
		/// the mapping between AgentId and AgentManager.
		/// </summary>
		private HashTable agentManagerTable;
		#endregion

		#region Private Constructor
		/// <summary>
		/// The default constructor is made private to prevent more than one instance
		/// of this class from being created.
		/// </summary>
		private Runtime()
		{
			this.agentTable = new Hashtable();
		}
		#endregion
		
		#region Factory Methods
		/// <summary>
		/// Initializes an instance of Runtime.
		/// </summary>
		public static Runtime Initialize()
		{
			if (Runtime.runtime != null)
				return null; // Already initialized. We return null to prevent someone
			// from getting a reference to Runtime.

			Runtime.runtime = new Runtime();
			return Runtime.runtime;
		}
		#endregion
		
		#region Internal Static Runtime Accessor Method
		/// <summary>
		/// Returns a reference to the runtime. 
		/// </summary>
		/// <returns>the runtime</returns>
		internal static Runtime GetRuntime()
		{
			/* 
			 * This method is scoped as internal to prevent 
			 * the user agents from obtaining a reference to 
			 * the Runtime. 
			 * The users' agents should not be able to obtain
			 * a reference to the Runtime in any way.
			 */

			return Runtime.runtime;
			
		}
		#endregion
		
		#region Public Properties
		/// <summary>
		/// The Url of the local agent host
		/// </summary>
		public string Url
		{
			get
			{
				return this.url;
			}
		}


		/// <summary>
		/// The Agent context associated with the Runtime.
		/// </summary>
		public AgentContext AgentContext
		{
			get
			{
				return this.agentContext;
			}
		}
		
		#endregion

		#region Public Methods to Create, Send, Kill (etc.) mobile agents
		/// <summary>
		/// Creates an instance of the specified agent.
		/// </summary>
		/// <param name="agentAssemblyPath">the path of the agent's assembly file</param>
		/// <param name="agentTypeName">the full type name of the agent</param>
		/// <param name="initArg">the initialization argument to the agent</param>
		/// <returns>AgentProxy referring to the created agent</returns>
		public AgentProxy CreateAgent(string agentAssemblyPath, string agentTypeName, object initArg)
		{
			lock(this)
			{
				AgentManager agentManager = new AgentManager(agentAssemblyPath, agentTypeName, initArg);

				// Save a reference to the newly created AgentManager in the table
				this.agentTable.Add(agentManager.Id, agentManager);

				// Return AgentProxy
				return new EtherYatri.AgentProxy(this.Url, agentManager.Id);
			}
		}
		
		
		public void SendAgent(AgentId agentId, string destinationHostUrl)
		{
		}


		public AgentProxy ReceiveAgent(byte[] agentAssembly, byte[] agentState, string agentTypeName)
		{
		}




		public void TerminateAgent(AgentId agentId, string message)
		{
		}


		public void Shutdown()
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

		#endregion
	}
}

#region Copyright (c) 2003, Siddharth Uppal <siddharthuppal@yahoo.co.in>
/************************************************************************************
*
* Copyright ?2003 Siddharth Uppal
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
* Portions Copyright ?2003 Siddharth Uppal
*
* 2. Altered source versions must be plainly marked as such, and must not be 
* misrepresented as being the original software.
*
* 3. This notice may not be removed or altered from any source distribution.
*
************************************************************************************/
#endregion


using System;
using System.Data;
using System.Collections;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Threading;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Windows.Forms;

using EtherYatri.InternalSystem;


namespace EtherYatri
{	
	/// <summary>
	/// Implementation of EtherYatri.IAgentHost interface (EtherYatri Communication
	/// Layer) and EtherYatri.IAgentContext interface (Agent Context)
	/// using .NET Remoting technology.
	/// </summary>
	public class AgentHost : System.MarshalByRefObject, EtherYatri.IAgentHost, EtherYatri.IAgentContext
	{
		#region Instance Variables
		private static int portNumber;
		private static string downloadedAgentCodeDirectory;
		private static string url;
		private static IChannel channel;
		
		

		/// <summary>
		/// Mapping of AgentId to AgentManager.
		/// </summary>
		private	Hashtable agentTable;


		/// <summary>
		/// A Hashtable to store properties. Agents can use the Agenthost Properties
		/// Collection as a means of communication.
		/// </summary>
		private Hashtable contextPropertiesCollection;
		#endregion

		
		#region Public Static Methods to Start and Stop the AgentHost
		/// <summary>
		/// Starts the host listening for agents.
		/// </summary>
		/// <param name="protocol">Protocol to be used, either http or tcp</param>
		/// <param name="preferences">Preferences information</param>
		/// <returns></returns>
		/// <summary>
		/// </summary>
		public static string Start(string protocol, Preferences preferences)
		{
			AgentHost.portNumber = preferences.PortNumber;
			AgentHost.downloadedAgentCodeDirectory = preferences.DownloadedAgentCodeDirectory;

			// Create directory for downloaded agent code if it does not exist
			if (! System.IO.Directory.Exists(AgentHost.downloadedAgentCodeDirectory))
				System.IO.Directory.CreateDirectory(AgentHost.downloadedAgentCodeDirectory);

			// Expose AgentHost using http or tcp as specified by the user
			if (protocol.ToLower().CompareTo("http") == 0)
				AgentHost.channel = new System.Runtime.Remoting.Channels.Http.HttpChannel(AgentHost.portNumber);
			else if (protocol.ToLower().CompareTo("tcp") == 0)
				AgentHost.channel = new System.Runtime.Remoting.Channels.Tcp.TcpChannel(AgentHost.portNumber);
			else
				throw new Exception("EtherYatri: protocol not supported exception.");

			ChannelServices.RegisterChannel(AgentHost.channel);
			RemotingConfiguration.RegisterWellKnownServiceType(typeof(AgentHost),
				"AgentHost",
				WellKnownObjectMode.Singleton);

			AgentHost.url = protocol + "://" + System.Net.Dns.GetHostName() + ":" + AgentHost.portNumber + "/" + "AgentHost";
            
			return AgentHost.url;
		}


		/// <summary>
		/// Stops the agenthost listening for agents
		/// </summary>
		public static void Stop()
		{
			ChannelServices.UnregisterChannel(AgentHost.channel);

			// TODO: Stop all running agents
		}
		#endregion


		#region Constructor
		/// <summary>
		/// Constructs an instance of AgentHost.
		/// </summary>
		public AgentHost()
		{
			this.agentTable = new Hashtable();
			this.contextPropertiesCollection = new Hashtable();
		}
		#endregion


		#region Methods of IAgentHost interface implemented
		/// <summary>
		/// Used to resume execution of agents from remote hosts on this host.
		/// </summary>
		/// <param name="agentAssemblyBytes">bytes of agent's assembly</param>
		/// <param name="agentState">bytes of serialized agent state</param>
		/// <param name="agentTypeName">the name of agent's type in assembly</param>
		/// <param name="agentId">the id of agent</param>
		/// <returns>an AgentProxy referring to the migrated agent</returns>
		public EtherYatri.AgentProxy Execute(byte[] agentAssemblyBytes, byte[] agentState, string agentTypeName, EtherYatri.AgentId agentId)
		{
			lock(this)
			{
				AgentManager agentManager = new AgentManager(this, AgentHost.downloadedAgentCodeDirectory, agentAssemblyBytes, agentState, agentTypeName, agentId);
			
				// Save a reference to the newly created AgentManager in the table
				this.agentTable.Add(agentManager.Id, agentManager);
				UpdateAll();

				EtherYatri.AgentProxy agentProxy = new EtherYatri.AgentProxy(AgentHost.url, agentManager.Id);
				agentProxy.LocalAgentHost = this;

				// Update form
				
				
				// Return AgentProxy
				return agentProxy;
			}
		}

		public EtherYatri.AgentProxy Execute(byte[] agentAssemblyBytes, byte[] agentState, string agentTypeName,string stringAgentId)
		{
			try
			{
				AgentId id = new AgentId(stringAgentId);
				return Execute(agentAssemblyBytes,agentState,agentTypeName,id);
			}
			catch(Exception ex)
			{
				ex.ToString();
				throw(ex);
			}
			
		}

		public EtherYatri.AgentProxy CreateProxy(string url,Guid id)
		{
			AgentId oid = new AgentId(id);
			EtherYatri.AgentProxy agentProxy = new EtherYatri.AgentProxy(AgentHost.url, oid);
			agentProxy.LocalAgentHost = this;
			return agentProxy;
		}
	

		/// <summary>
		/// Used by objects on the local host to create agents on the local host.
		/// </summary>
		/// <param name="agentAssemblyPath">the path of assembly containing code of agent type</param>
		/// <param name="agentTypeName">the name of agent's type</param>
		/// <param name="init">object to pass initialization information to agent</param>
		/// <returns>an AgentProxy referring to the newly created agent</returns>
		public EtherYatri.AgentProxy CreateAgent(string agentAssemblyPath, string agentTypeName, object init)
		{
			lock(this)
			{
				AgentManager agentManager = new AgentManager(this, agentAssemblyPath, agentTypeName, init);

				// Save a reference to the newly created AgentManager in the table
				this.agentTable.Add(agentManager.Id, agentManager);
				UpdateAll();

				EtherYatri.AgentProxy agentProxy = new EtherYatri.AgentProxy(AgentHost.url, agentManager.Id);
				agentProxy.LocalAgentHost = this;

				// Return AgentProxy
				return agentProxy;
			}
		}

	

		public ArrayList FindAgentType(string agentType)
		{
			ArrayList arr = new ArrayList();
			IDictionaryEnumerator inum = agentTable.GetEnumerator();
			while(inum.MoveNext()!=false)
			{
				AgentManager agentManager = (AgentManager)inum.Value;
				Agent agent = agentManager.GetAgent();
				if(agent.GetType().ToString()==agentType)
				{
					EtherYatri.AgentProxy agentProxy = new EtherYatri.AgentProxy(AgentHost.url, agentManager.Id);
					agentProxy.LocalAgentHost = this;
					arr.Add(agentProxy);
				}
			}
			return arr;
		}

		
		public EtherYatri.AgentProxy FindId(Guid id)
		{
			AgentId oid = new AgentId(id);
			if(AgentExists(oid)==false) return null;
			EtherYatri.AgentProxy agentProxy = new EtherYatri.AgentProxy(AgentHost.url, oid);
			agentProxy.LocalAgentHost = this;
			return agentProxy;
		}

		public DataTable GetAgentList()
		{
			DataTable tb = new DataTable("local agents");
			tb.Columns.Add("Type Name");
			tb.Columns.Add("Assembly Path");
			tb.Columns.Add("Initialization Args");
			tb.Columns.Add("Started");
			tb.Columns.Add("Comments");
			tb.Columns.Add("id");
			IDictionaryEnumerator inum = agentTable.GetEnumerator();
			while(inum.MoveNext()!=false)
			{
				
				AgentManager agentManager = (AgentManager)inum.Value;
				DataRow dr = tb.NewRow();
				Agent agent = agentManager.GetAgent();
				dr["Type Name"] = agent.GetType().ToString();
				dr["Assembly Path"] = agent.AssemblyPath;
				dr["Initialization Args"] = "";
				dr["Started"] = "";
				dr["Comments"] = "";
				dr["id"] = ((AgentId)inum.Key).Id.ToString();
				tb.Rows.Add(dr);
			}
			return tb;
		}
	
		private ArrayList arr = new ArrayList();
		
	
		public void AddObserver(string url)
		{
			arr.Add(url);
		}
		
		private void UpdateAll()
		{
			try
			{
				DataTable tb =  GetAgentList();
				for(int i=0;i<arr.Count;i++)
				{
					ISubscribe client = (ISubscribe)Activator.GetObject(typeof(ISubscribe),
						arr[i].ToString());
					if (client == null)
					{
						Console.Write("Could not locate clisn");
						arr.Remove(arr[i]);
						i--;
					}
					else client.UpdateList(tb);
				}
			}
			catch(Exception ex)
			{ex.ToString();}
		}
		
		// RAF: END


		/// <summary>
		/// To create agents on remote hosts.
		/// </summary>
		/// <param name="remoteHostAddress">Url of the host where agent is to be created</param>
		/// <param name="agentAssemblyPath">the path of assembly containing code of agent type</param>
		/// <param name="agentTypeName">the name of agent's type</param>
		/// <param name="init">object to pass initialization information to agent</param>
		/// <returns>a proxy for the newly created remote agent</returns>
		public EtherYatri.AgentProxy CreateAgentOnRemoteHost(string remoteHostAddress, string agentAssemblyPath, string agentTypeName, object init)
		{
			// Invoke CreateAgent on remote machine
			EtherYatri.IAgentHost host = (EtherYatri.IAgentHost)Activator.GetObject(typeof(EtherYatri.IAgentHost),
				remoteHostAddress);
			
			if (host == null)
				throw new EtherYatri.HostNotFoundException("Could not contact remote host");
			
			EtherYatri.AgentProxy agentProxy = host.CreateAgent(agentAssemblyPath, agentTypeName, init);
			agentProxy.LocalAgentHost = this;

			return agentProxy;
		}


		/// <summary>
		/// Used to perform cleanup when an agent ends its execution on
		/// current host. It may end its execution because its Run method
		/// returns or it decides to migrate to another host, or an AgentProxy
		/// referring to the agent wants to get it disposed.
		/// </summary>
		/// <param name="agentId"> id of the agent for which cleanup is to be performed</param></param>
		public void DisposeAgent(EtherYatri.AgentId agentId)
		{
			lock(this)
			{
				AgentManager agentManager = (AgentManager)this.agentTable[agentId];
				if (agentManager == null)
					return;

				this.agentTable.Remove(agentId);
				UpdateAll();
				// Remove reference to the agent manager from the table
				agentManager.CleanupAtEndOfAgentExecution();
			}
		}


		/// <summary>
		/// Used to dispose-off an agent located at a remote host.
		/// </summary>
		/// <param name="agentId"> id of the agent for which cleanup is to be performed</param></param>
		public void DisposeAgentAtRemoteHost(string remoteHostAddress, EtherYatri.AgentId agentId)
		{
			// By-pass remoting if the remoteHostAddress referrers to local host
			if (AgentHost.url.CompareTo(remoteHostAddress) == 0)
				this.DisposeAgent(agentId);
			else
			{
				// Invoke DisposeAgent on remote machine
				EtherYatri.IAgentHost host = (EtherYatri.IAgentHost)Activator.GetObject(typeof(EtherYatri.IAgentHost),
					remoteHostAddress);
				if (host == null)
					throw new Exception("EtherYatri: Could not contact remote host");
			
				host.DisposeAgent(agentId);
			}
		}
		

		/// <summary>
		/// Used to move an agent from the local host to another host.
		/// </summary>
		/// <param name="address">destination address</param>
		/// <param name="agentId">id of agent to be moved</param>
		public EtherYatri.AgentProxy MoveAgent(string destinationAddress, EtherYatri.AgentId agentId)
		{
			lock(this)
			{
				AgentManager agentManager = (AgentManager)this.agentTable[agentId];

				// Get a reference to the agent
				EtherYatri.Agent agent = agentManager.GetAgent();

				// Get the bytes of agent's state
				MemoryStream agentStateStream = new MemoryStream();
				IFormatter formatter = new BinaryFormatter();
				formatter.Serialize(agentStateStream, agent);
				byte[] agentState = agentStateStream.GetBuffer();
				agentStateStream.Close();

				// Load the bytes of agent's assembly
				FileStream fs = System.IO.File.OpenRead(agent.GetType().Assembly.Location);
				byte[] assemblyBytes = new Byte[fs.Length];
				fs.Read(assemblyBytes, 0, assemblyBytes.Length);
				fs.Close();

				// The statement below leads to a problem and hence it has been commented out.
				// Problem: MoveAgent is called on the thread of the agent. CleanupAtEndOfAgentExecution
				// attempts to terminate the execution of the agent's thread. So, the statements following the
				// commented statement below, never get a chance to be executed.
				
				// Perform required cleanup
				//agentManager.CleanupAtEndOfAgentExecution();

				// Remove reference to the agent manager from the table
				this.agentTable.Remove(agentId);
				UpdateAll();

				// Set the agent executing on the remote host
				EtherYatri.IAgentHost host = (EtherYatri.IAgentHost)Activator.GetObject(typeof(EtherYatri.IAgentHost),
					destinationAddress);
				if (host == null)
					throw new Exception("EtherYatri: Could not contact remote host");
			
				EtherYatri.AgentProxy agentProxy = host.Execute(assemblyBytes, agentState, agent.GetType().ToString(), agent.Id.ToString());
				agentProxy.LocalAgentHost = this;

				return agentProxy;
			}
		}


		/// <summary>
		/// Moves an agent located on a remote host to another host.
		/// </summary>
		/// <param name="remoteHostAddress">Url of the host where the agent is located</param>
		/// <param name="destinationAddress">Url of the host where the agent is to be moved to</param>
		/// <param name="agentId">Id of the agent to be moved</param>
		/// <returns>a proxy for the remote agent</returns>
		public EtherYatri.AgentProxy MoveAgentOnRemoteHost(string remoteHostAddress, string destinationAddress, EtherYatri.AgentId agentId)
		{
			EtherYatri.AgentProxy agentProxy = null;

			// By-pass remoting if the remoteHostAddress referrers to local host
			if (AgentHost.url.CompareTo(remoteHostAddress) == 0)
				agentProxy = this.MoveAgent(destinationAddress, agentId);
			else
			{
				// Invoke Execute on remote machine
				EtherYatri.IAgentHost host = (EtherYatri.IAgentHost)Activator.GetObject(typeof(EtherYatri.IAgentHost),
					remoteHostAddress);
				
				if (host == null)
					throw new Exception("EtherYatri: Could not contact remote host");
			
				agentProxy = host.MoveAgent(destinationAddress, agentId);
				agentProxy.LocalAgentHost = this;
			}

			return agentProxy;
		}

		public EtherYatri.AgentProxy Clone(string remoteHostAddress,EtherYatri.AgentId agentId,object arg)
		{
			// from move
			lock(this)
			{
				// Get a reference to the agent
				AgentManager agentManager = (AgentManager)this.agentTable[agentId];
				EtherYatri.Agent agent = agentManager.GetAgent();

				// Get the bytes of agent's state
				MemoryStream agentStateStream = new MemoryStream();
				IFormatter formatter = new BinaryFormatter();
				formatter.Serialize(agentStateStream, agent);
				byte[] agentState = agentStateStream.GetBuffer();
				agentStateStream.Close();

				// Load the bytes of agent's assembly
				FileStream fs = System.IO.File.OpenRead(agent.GetType().Assembly.Location);
				byte[] assemblyBytes = new Byte[fs.Length];
				fs.Read(assemblyBytes, 0, assemblyBytes.Length);
				fs.Close();

			// from execute
				AgentManager newagentManager = new AgentManager(this,AgentHost.downloadedAgentCodeDirectory, assemblyBytes, agentState, agent.GetType().ToString(), agent.Id,arg);
				
				// Save a reference to the newly created AgentManager in the table
				this.agentTable.Add(newagentManager.Id, newagentManager);
				UpdateAll();

				EtherYatri.AgentProxy agentProxy = new EtherYatri.AgentProxy(AgentHost.url, newagentManager.Id);
				agentProxy.LocalAgentHost = this;

				return agentProxy;
			}

		}


				
		
		/// <summary>
		/// Called by remote hosts to invoke a method of a local agent.
		/// </summary>
		/// <param name="agentId">Id of the agent whose method is to be invoked</param>
		/// <param name="methodName">Name of the method to be invoked</param>
		/// <param name="parameters">Parameters to be passed to the method</param>
		/// <returns>whatever the method returns</returns>
		public object InvokeAgentMethod(System.Guid id, string methodName, object[] parameters)
		{
			EtherYatri.AgentId agentId = new AgentId(id);
			AgentManager agentManager = (AgentManager)this.agentTable[agentId];
			EtherYatri.Agent agent = agentManager.GetAgent();

			// Check if the specified method has been marked with AgentWebMethod attribute
			Attribute definedAttribute = Attribute.GetCustomAttribute(agent.GetType().GetMember(methodName)[0], typeof(EtherYatri.AgentWebMethodAttribute));
			if (definedAttribute == null)
			{
				throw new Exception("Illegal method called"); // TODO: send an exception to client
			}

			// Invoke method and return results
			return agent.GetType().InvokeMember(methodName, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.InvokeMethod, null, agent, parameters);
		}
		

		/// <summary>
		/// Invokes method on an agent located on a remote host.
		/// </summary>
		/// <param name="remoteHostAddress">Url of the host where the agent is located</param>
		/// <param name="agentId">Id of the agent</param>
		/// <param name="methodName">Name of the method to be invoked</param>
		/// <param name="parameters">Parameters to be passed to the method</param>
		/// <returns>whatever the method returns</returns>
		public object InvokeAgentMethodOnRemoteHost(string remoteHostAddress, EtherYatri.AgentId agentId, string methodName, object[] parameters)
		{
			// Invoke Execute on remote machine
			EtherYatri.IAgentHost host = (EtherYatri.IAgentHost)Activator.GetObject(typeof(EtherYatri.IAgentHost),
				remoteHostAddress);
			if (host == null)
				throw new Exception("EtherYatri: Could not contact remote host");
			try
			{
				return host.InvokeAgentMethod(agentId.Id, methodName, parameters);
			}
			catch(Exception ex)
			{
				ex.ToString();
				throw new Exception("EtherYatri: Could not find method in remote agent");
			}
		}
		

		/// <summary>
		/// Called by remote hosts to check if the specified agent exists at the
		/// local host.
		/// </summary>
		/// <param name="agentId">Id of the agent to be checked</param>
		/// <returns>true if the agent exists, false otherwise</returns>
		public bool AgentExists(EtherYatri.AgentId agentId)
		{
			if(agentTable.Contains(agentId))
				return true;
			else return false;
		}
		

		/// <summary>
		/// To check for the existence of an agent on a remote host.
		/// </summary>
		/// <param name="remoteHostAddress">Url of the host to be checked</param>
		/// <param name="agentId">Id of the agent to be checked</param>
		/// <returns>true if the agent exists, false otherwise</returns>
		public bool AgentExistsOnRemoteHost(string remoteHostAddress, EtherYatri.AgentId agentId)
		{
			lock (this)
			{
				EtherYatri.IAgentHost host = (EtherYatri.IAgentHost)Activator.GetObject(typeof(EtherYatri.IAgentHost),
					remoteHostAddress);

				if (host == null)
					throw new Exception("EtherYatri: Could not contact remote host");

				return host.AgentExists(agentId);
			}
		}
		#endregion


		#region Members of IAgentContext interface implemented
		/// <summary>
		/// The address of the local host.
		/// </summary>
		public string LocalHostAddress
		{
			get
			{
				return AgentHost.Url;
			}
		}


		/// <summary>
		/// Sets a property with the specified key and value in the properties
		/// collection of the agent context. Make sure that the key implements
		/// System.Object.GetHashCode method and System.Object.Equals appropriately. 
		/// For example: the System.String class.
		/// </summary>
		/// <param name="key">the key of the property to add</param>
		/// <param name="value">the value of the property</param>
		public void SetProperty(object key, object value)
		{
			// Two or more agents may try to set/get a property in properties
			// collection simultaneously. We modify the properties collection in
			// a critical section.

			// Acquire lock on contextPropertiesCollection
			lock(this.contextPropertiesCollection)
			{
				this.contextPropertiesCollection[key] = value;
			}
		}

		/// <summary>
		/// Gets the value associated with the key, stored in the properties
		/// collection of the agent context.
		/// </summary>
		/// <param name="key">the key of the property</param>
		/// <returns>value associated with the key</returns>
		public object GetProperty(object key)
		{
			// Two or more agents may try to set/get a property in properties
			// collection simultaneously. We modify the properties collection in
			// a critical section.

			// Acquire lock on contextPropertiesCollection
			lock(this.contextPropertiesCollection)
			{
				return this.contextPropertiesCollection[key];
			}
		}
		#endregion

		
		#region Public Static Properties
		/// <summary>
		/// The Url of the local agent host
		/// </summary>
		public static string Url
		{
			get
			{
				return AgentHost.url;
			}
		}
		#endregion
	}
}

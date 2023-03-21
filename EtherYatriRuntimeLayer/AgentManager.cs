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
using System.IO;
using System.Threading;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace EtherYatri.InternalSystem
{
	/// <summary>
	/// Every agent is associated with an Agent Manager, and vice-versa. 
	/// </summary>
	public class AgentManager
	{
		#region Private Fields
		/// <summary>
		/// The path of the directory where received agent code is stored.
		/// </summary>
		private	string	receivedAgentAssembliesDir;
		
		
		/// <summary>
		/// Every agent runs in a separate thread.
		/// </summary>
		private Thread agentThread;
		

		/// <summary>
		/// A reference to the managed agent.
		/// </summary>
		private EtherYatri.Agent agent;
		

		/// <summary>
		/// The id of the managed agent.
		/// </summary>
		private	AgentId	agentId;
		

		/// <summary>
		/// A reference to the local host.
		/// </summary>
		private	IAgentHost agentHost;
		#endregion
		
		
		#region Constructors
		/// <summary>
		/// Manages an agent received from a remote host.
		/// </summary>
		/// <param name="agentHost">A reference to the local agent host on which the agent will execute</param>
		/// <param name="receivedAgentAssembliesDir">Path of directory where the received code of the agent will be stored in a file</param>
		/// <param name="agentAssemblyBytes">The bytes of the assembly containing the agent's type</param>
		/// <param name="agentState">The bytes of the serialized representation of the state of the agent</param>
		/// <param name="agentTypeName">The name of the agent's type in the assembly</param>
		/// <param name="agentId">The id of the agent</param>
		


		public AgentManager(IAgentHost agentHost, string receivedAgentAssembliesDir, byte[] agentAssemblyBytes, byte[] agentState, string agentTypeName, EtherYatri.AgentId agentId)
		{
			this.agentHost = agentHost;
			this.receivedAgentAssembliesDir = receivedAgentAssembliesDir;

			// Save Agent's code into a file
			// $$ To get rid of Bug# 1
			//string	agentAssemblyPath = receivedAgentAssembliesDir + @"\" + agentId.Id.ToString() + ".dll";
			string agentAssemblyPath = receivedAgentAssembliesDir + @"\" + System.Guid.NewGuid().ToString() + ".dll";
			
			System.IO.FileStream fs = System.IO.File.Open(agentAssemblyPath, System.IO.FileMode.OpenOrCreate);
			fs.Write(agentAssemblyBytes, 0, agentAssemblyBytes.Length);
			fs.Close();

			// Load agent state
			System.IO.MemoryStream agentStateStream = new System.IO.MemoryStream(agentState, 0, agentState.Length);
			IFormatter formatter = new BinaryFormatter();
			formatter.Binder = new AgentBinder(agentAssemblyPath);
			this.agent = (EtherYatri.Agent)formatter.Deserialize(agentStateStream);
			agentStateStream.Close();

			this.Id = this.agent.Id; 
			
			// Initialize agent
			this.agent.Initialize(this);
			
			// Fire agent's OnArrival event
			this.agent.OnArrival();
			
			// Start the agent running
			this.agentThread = new Thread(new ThreadStart(this.ExecuteAgent));
			this.agentThread.Start();
		}
		

		/// <summary>
		/// Used to manage an agent whose code is already available on local host.
		/// </summary>
		/// <param name="agentHost">A reference to the local host</param>
		/// <param name="agentAssemblyPath">The path of the assembly file containing agent type's code</param>
		/// <param name="agentTypeName">The name of the agent's type in the assembly</param>
		/// <param name="init">Used to pass initialization information to the agent</param>
		public AgentManager(IAgentHost agentHost, string agentAssemblyPath, string agentTypeName, object init)
		{
			this.agentHost = agentHost;
			this.receivedAgentAssembliesDir = System.IO.Path.GetDirectoryName(agentAssemblyPath);

			try
			{
				// Load Agent Type
				Assembly agentAssembly = Assembly.LoadFrom(agentAssemblyPath);
				System.Type agentType = agentAssembly.GetType(agentTypeName);
			
				// Get a new AgentId
				this.Id = new AgentId();

				// Instantiate the agent
				this.agent = (EtherYatri.Agent)agentType.GetConstructor(new System.Type[0]).Invoke(null);
			}
			catch (Exception ex)
			{
				throw new EtherYatri.AgentNotFoundException("Could not create agent", ex);
			}

			// Initialize the agent
			this.agent.Initialize(this);

			// Fire agent's OnCreation event
			this.agent.OnCreation(init);
			
			// Start the agent running
			this.agentThread = new Thread(new ThreadStart(this.ExecuteAgent));
			this.agentThread.Start();
		}

		public AgentManager(IAgentHost agentHost, string receivedAgentAssembliesDir, byte[] agentAssemblyBytes, byte[] agentState, string agentTypeName, EtherYatri.AgentId agentId,object arg)
		{
			this.agentHost = agentHost;
			this.receivedAgentAssembliesDir = receivedAgentAssembliesDir;

			string agentAssemblyPath = receivedAgentAssembliesDir + @"\" + System.Guid.NewGuid().ToString() + ".dll";
			
			System.IO.FileStream fs = System.IO.File.Open(agentAssemblyPath, System.IO.FileMode.OpenOrCreate);
			fs.Write(agentAssemblyBytes, 0, agentAssemblyBytes.Length);
			fs.Close();

			// Load agent state
			System.IO.MemoryStream agentStateStream = new System.IO.MemoryStream(agentState, 0, agentState.Length);
			IFormatter formatter = new BinaryFormatter();
			formatter.Binder = new AgentBinder(agentAssemblyPath);
			this.agent = (EtherYatri.Agent)formatter.Deserialize(agentStateStream);
			agentStateStream.Close();

			this.agentId = new AgentId();
			agent.Initialize(this);

			this.agent.OnCloning(arg);
			this.agentThread = new Thread(new ThreadStart(this.ExecuteAgent));
			this.agentThread.Start();
		}
		#endregion



		#region Private Helper Methods
		/// <summary>
		/// Is called on agent's thread. This is where the agent spends
		/// its entire lifetime.
		/// </summary>
		private void ExecuteAgent()
		{
			this.agent.Run();
			//this.agentHost.DisposeAgent(this.Id);
		}


		#endregion


		#region Public Methods
		/// <summary>
		/// AgentHost calls us to perform cleanup.
		/// </summary>
		public void CleanupAtEndOfAgentExecution()
		{
			this.agent.OnStopping();
			this.agentThread.Abort();
		}

	
		/// <summary>
		/// Used to move an agent from the local host to a remote host.
		/// </summary>
		/// <param name="destinationAddress">address of destination host</param>
		public void MoveTo(string destinationAddress)
		{
			// Fire the OnStopping event of agent
			this.agent.OnStopping();

			// Fire the OnMigration event of agent
			this.agent.OnMigration(destinationAddress);

			try
			{
				// Use the communication layer to perform the migration
				this.agentHost.MoveAgent(destinationAddress, this.Id);
			}
			catch (Exception ex)
			{
				throw new HostNotFoundException("Host '" + destinationAddress + "' cannot be found.", ex);
			}
		}
		/// <summary>
		/// Returns the AgentContext of the agent.
		/// </summary>
		/// <returns>AgentContext of the agent</returns>
		public IAgentContext GetContext()
		{
			return (IAgentContext) this.agentHost;
		}


		/// <summary>
		/// Used to get a reference to the managed agent.
		/// </summary>
		/// <returns>A reference to the managed agent</returns>
		public EtherYatri.Agent GetAgent()
		{
			return this.agent;
		}
		#endregion
		

		#region Public Properties
		/// <summary>
		/// The id of the managed agent.
		/// </summary>
		public AgentId  Id
		{
			get
			{
				return this.agentId;
			}
			set
			{
				this.agentId = value; // Looks dangerous! Use internal instead!
			}
		}
		

		/// <summary>
		/// The agent's state.
		/// </summary>
		public byte[] AgentState
		{
			get
			{
				// Get the bytes of agent's state
				MemoryStream agentStateStream = new MemoryStream();
				IFormatter formatter = new BinaryFormatter();
				formatter.Serialize(agentStateStream, this.agent);
				byte[] agentState = agentStateStream.GetBuffer();
				agentStateStream.Close();

				return agentState;
			}
		}


		/// <summary>
		/// The agent's code.
		/// </summary>
		public byte[] AgentCode
		{
			get
			{
				// Load the bytes of agent's assembly
				FileStream fs = System.IO.File.OpenRead(this.agent.GetType().Assembly.Location);
				byte[] assemblyBytes = new Byte[fs.Length];
				fs.Read(assemblyBytes, 0, assemblyBytes.Length);
				fs.Close();

				return assemblyBytes;
			}
		}
		#endregion
	}
}

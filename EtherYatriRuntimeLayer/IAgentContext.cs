using System;

namespace EtherYatri
{
	/// <summary>
	/// Agent context is like a room wherein agents can meet each other. Every host
	/// is associated with one agent context.
	/// </summary>
	public interface IAgentContext
	{
		/// <summary>
		/// The address of the local host.
		/// </summary>
		string LocalHostAddress	{get; }

		/// <summary>
		/// Sets a property with the specified key and value in the properties
		/// collection of the agent context. Make sure that the key implements
		/// System.Object.GetHashCode method and System.Object.Equals appropriately. 
		/// For example: the System.String class.
		/// </summary>
		/// <param name="key">the key of the property to add</param>
		/// <param name="value">the value of the property</param>
		void SetProperty(object key, object value);

		
		/// <summary>
		/// Gets the value associated with the key, stored in the properties
		/// collection of the agent context.
		/// </summary>
		/// <param name="key">the key of the property</param>
		/// <returns>value associated with the key</returns>
		object GetProperty(object key);
		
		
		/// <summary>
		/// An agent can create a new agent on its host using this method.
		/// </summary>
		AgentProxy CreateAgent(string agentAssemblyPath, string agentTypeName, object init);

		EtherYatri.AgentProxy CreateProxy(string url,Guid id);



	}
}

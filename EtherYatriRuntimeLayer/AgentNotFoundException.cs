using System;
using System.Runtime.Serialization;

namespace EtherYatri
{
	[Serializable]
	public class AgentNotFoundException : Exception
	{
		/// <summary>
		/// Creates an instance of AgentNotFound exception with the
		/// specified error-message.
		/// </summary>
		/// <param name="message">error-message</param>
		public AgentNotFoundException(string message) : base(message)
		{
		}

		
		public AgentNotFoundException(string message, Exception inner) : base(message,inner) 
		{
		}


		public AgentNotFoundException()
		{
		}


		protected AgentNotFoundException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}

	}
}

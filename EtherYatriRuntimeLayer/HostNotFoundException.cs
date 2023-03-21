using System;
using System.Runtime.Serialization;

namespace EtherYatri
{
	[Serializable]
	public class HostNotFoundException : System.Exception
	{
		/// <summary>
		/// Creates an instance of AgentNotFound exception with the
		/// specified error-message.
		/// </summary>
		/// <param name="message">error-message</param>
		public HostNotFoundException(string message) : base(message)
		{
		}
		
		public HostNotFoundException(string message, Exception inner) : base(message,inner) 
		{
		}

		public HostNotFoundException()
		{
		}

		protected HostNotFoundException(SerializationInfo info, StreamingContext context)
		{
		}
	}
}

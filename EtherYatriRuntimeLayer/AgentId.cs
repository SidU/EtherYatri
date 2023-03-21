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
	/// Encapsulates an Agent's globally unique identifier. 
	/// </summary>
	[Serializable]
	public class AgentId
	{
		#region Private Fields
		/// <summary>
		/// Reference to a Guid object.
		/// </summary>
		private Guid guid;
		#endregion


		#region Constructors
		/// <summary>
		/// Constructor.
		/// </summary>
		public AgentId()
		{
			this.guid = Guid.NewGuid();
		}

		public AgentId(string id)
		{
			this.guid = new Guid(id);
		}

		public AgentId(System.Guid id)
		{
			this.guid = id;
		}
		#endregion
		

		#region Public Methods
		/// <summary>
		/// Returns hash code of this AgentId object. This is needed since the
		/// users of this class would keep AgentId objects in a dictionary.
		/// </summary>
		/// <returns>hash code of this AgentId object.</returns>
		public override int GetHashCode()
		{
			return this.guid.GetHashCode();
		}

		
		/// <summary>
		/// To check if this AgentId object is equal to another. Since users of this
		/// class would be keeping AgentId objects in a dictionary, this method would
		/// be invoked by dictionary class to check if two AgentId objects are equal.
		/// </summary>
		/// <param name="obj">the AgentId object to be compared to.</param>
		/// <returns>true if the two are equal, false otherwise.</returns>
		public override bool Equals(object obj)
		{
			if (obj == null)
				return false;

			return this.guid == ((AgentId)obj).guid;
		}

		
		/// <summary>
		/// AgentId stringized.
		/// </summary>
		/// <returns>AgentId object stringized.</returns>
		public override string ToString()
		{
			return this.guid.ToString();
		}
		#endregion

		
		#region Public Properties
		/// <summary>
		/// The Guid object associated with this AgentId object.
		/// </summary>
		public Guid Id
		{
			get
			{
				return this.guid;
			}
		}
		#endregion
	}
}

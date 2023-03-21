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
using System.Runtime.Serialization;
using System.Reflection;

namespace EtherYatri
{
	/// <summary>
	/// During deserialization AgentBinder binds the agent-type to the actual
	/// user defined type of the agent.
	/// </summary>
	internal class AgentBinder : SerializationBinder
	{
		private string agentAssemblyPath;

		
		public AgentBinder(string agentAssemblyPath)
		{
			this.agentAssemblyPath = agentAssemblyPath;
		}


		/// <summary>
		/// An object implementing IFormatter calls this method during
		/// deserialization. We load and return the agent's type from
		/// the appropriate assembly.
		/// </summary>
		/// <param name="assemblyName">strong name of agent's assembly</param>
		/// <param name="typeName">full typename of the agent</param>
		/// <returns></returns>
		public override Type BindToType(string assemblyName, string typeName)
		{
			return Assembly.LoadFrom(this.agentAssemblyPath).GetType(typeName);
		}
	}
}

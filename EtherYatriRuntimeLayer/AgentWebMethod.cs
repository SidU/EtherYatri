/*************************************************************************************
 * 
 * (c) 2003 Siddharth Uppal <siddharthuppal@yahoo.co.in>
 * All rights reserved.
 * 
 * Visit EtherYatri Homepage: http://www.geocities.com/siddharthuppal/EtherYatri.htm
 * 
 *************************************************************************************/

using System;

namespace EtherYatri
{
	/// <summary>
	/// Clients must mark those methods of their agent class
	/// which they wish to allow to be invoked by remote agents with 
	/// this attribute.
	/// </summary>
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
	public sealed class AgentWebMethodAttribute : Attribute
	{
		public AgentWebMethodAttribute()
		{
		}
	}
}

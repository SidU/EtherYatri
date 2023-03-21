using System;

namespace AgentHost2003
{
	public sealed class AboutProductInfo
	{
		private AboutProductInfo()
		{
		}

		private static string name = "WINAH";
		private static string description = "EtherYatri.NET Windows AgentHost";
		private static string company = "Siddharth Uppal";
		private static string copyright = "(c) 2003 Siddharth Uppal <siddharthuppal@yahoo.co.in>. All rights reserved.";
		private static string version = "0.5.4";

		public static string Name
		{
			get
			{
				return name;
			}
		}

		public static string Description
		{
			get
			{
				return description;
			}
		}

		public static string Company
		{
			get
			{
				return company;
			}
		}

		public static string Copyright
		{
			get
			{
				return copyright;
			}
		}

		public static string Version
		{
			get
			{
				return version;
			}
		}
	}
}

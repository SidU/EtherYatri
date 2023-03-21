using System;
using EtherYatri;

namespace Test_EtherYatri
{
	/// <summary>
	/// Summary description for HelloWorldAgent.
	/// </summary>
	public class HelloWorldAgent : EtherYatri.Agent
	{
		/// <summary>
		/// An agent does its main work in the Run method.
		/// </summary>
		public override void Run()
		{
			Console.WriteLine("Hello World!");
		}
	}
}

using System;

namespace PostSetupAppSpawner
{
	class Starter
	{
		[STAThread]
		static void Main(string[] args)
		{
			System.Diagnostics.Process.Start(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\AgentHost2003.exe", "8000");
		}
	}
}

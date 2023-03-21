using System;

namespace DllRegister
{
	class Register
	{
		[STAThread]
		static void Main(string[] args)
		{
			if (args.Length != 1)
			{
				Console.WriteLine("Error: Invalid input format.");
				return;
			}
			
			string dllPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\EtherYatri.dll";

			switch(args[0])
			{
				case "-i":
				case "-install": System.Diagnostics.Process.Start("gacutil.exe", "-i " + dllPath);
								 break;
				case "-u":
				case "-uninstall": System.Diagnostics.Process.Start("gacutil.exe", "-u EtherYatri.dll");
								 break;
				default: Console.WriteLine("Error: Invalid option.");
						 break;
			}
			
		}
	}
}

/**
 * July 15, 2003 Siddharth Uppal:
 * XCopy and XDelete were written so that the setup doesn't need to be re-written if
 * in the future, integration of EtherYatri.NET with other languages is implemented.
 */

using System;
using Microsoft.Win32;
using System.Windows.Forms;
using System.IO;

namespace EtherYatriFileCopier
{
	public class InstallEY
	{
		public static string GetVsInstallationPath()
		{
			// Determine location of devenv.exe
			RegistryKey regKey = Registry.ClassesRoot.OpenSubKey("Applications").OpenSubKey("devenv.exe").OpenSubKey("shell").OpenSubKey("edit").OpenSubKey("command");
			if (regKey == null) // VS.NET isn't installed, so throw an exception.
				throw new Exception("Visual Studio.NET isn't installed. EtherYatri installation cannot continue...");

			string devenvPath = (string) regKey.GetValue(""); // Get default value.

			devenvPath = devenvPath.Substring(1, devenvPath.Length - 7);
			
			return devenvPath.Substring(0, devenvPath.Length - @"\Common7\IDE\devenv.exe".Length);
		}
		

		/// <summary>
		/// XCopies the contents of directory sourceDirName into directory destDirName.
		/// </summary>
		/// <param name="sourceDirName"></param>
		/// <param name="destDirName"></param>
		public static void XCopy(string sourceDirName, string destDirName)
		{
			string[] directoryEntries = Directory.GetFileSystemEntries(sourceDirName);
			
			foreach(string entry in directoryEntries)
			{
				if (Directory.Exists(entry))	// if entry is a directory
					XCopy(entry, destDirName + "\\" + Path.GetFileName(entry));
				else							// otherwise entry is a file
				{
					Console.WriteLine("Creating file '" + destDirName + "\\" + Path.GetFileName(entry));
					Directory.CreateDirectory(destDirName);
					File.Copy(entry, destDirName + "\\" + Path.GetFileName(entry), true);
				}
			}
		}

		
		/// <summary>
		/// Assumes that the directory trees below directory sourceDirName and destDirName
		/// are identical and deletes all files that occur at the leaves of tree destDirName.
		/// However the sub-directories in the directory tree of destDirName are left undeleted.
		/// </summary>
		/// <param name="sourceDirName"></param>
		/// <param name="destDirName"></param>
		public static void XDelete(string sourceDirName, string destDirName)
		{
			string[] directoryEntries = Directory.GetFileSystemEntries(sourceDirName);
			
			foreach(string entry in directoryEntries)
			{
				if (Directory.Exists(entry))		// if entry is a directory
					XDelete(entry, destDirName + "\\" + Path.GetFileName(entry));
				else								// if entry is a file
				{
					Console.WriteLine("Deleting file '" + destDirName + "\\" + Path.GetFileName(entry));
					File.Delete(destDirName + "\\" + Path.GetFileName(entry));
				}
			}
		}

		
		public static void Install()
		{
			Console.WriteLine("EtherYatri.NET VS.NET Integration");
			Console.WriteLine("\nCopying the necessary files. Please wait...");
			InstallEY.XCopy("InstallationFiles", InstallEY.GetVsInstallationPath());
		}


		public static void UnInstall()
		{
			Console.WriteLine("EtherYatri.NET VS.NET Integration");
			Console.WriteLine("\nRemoving the necessary files. Please wait...");
			InstallEY.XDelete("InstallationFiles", InstallEY.GetVsInstallationPath());
		}


		public static void Main(string[] args)
		{
			try
			{
				// Change directory first
				string dir = System.IO.Path.GetDirectoryName(typeof(InstallEY).Assembly.Location);
				System.Environment.CurrentDirectory = dir;
			
				if (args.Length != 1)
					throw new Exception("EtherYatri.NET Toolkit Installation Failed. Please specify /i to install or /u to un-install the toolkit.");
			
				switch (args[0])
				{
					case "/i":
					case "/install":	InstallEY.Install();
						break;
					case "/u":
					case "/uninstall":	InstallEY.UnInstall();
						break;
					default: throw new Exception("EtherYatri.NET Toolkit Installation Failed. Please specify /i to install or /u to un-install the toolkit.");
				}
			}
			
			catch (Exception ex)
			{
				MessageBox.Show("EtherYatri.NET Toolkit installation failed because " + ex.Message + ".", "EtherYatri.NET Install Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}



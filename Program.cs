using System;
using System.Runtime.InteropServices;
using System.Timers;
using Gtk;

namespace DS4Display
{
	class MainClass
	{

		public static void Main(string[] args)
		{
			Application.Init();
			MainWindow win = new MainWindow();
			win.Show();
			Application.Run();
		}

	}
}

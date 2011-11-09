using System;
using Gtk;

namespace SudokuSharp
{
	
	
		
	class MainClass
	{
		
		public static void Main (string[] args)
		{
			Application.Init();
			Window unitTest = new MainDialog();
			unitTest.Show();
			Application.Run();
		}
		public static void onDeleteEvent(object sender, DeleteEventArgs a)
		{
			Application.Quit();
		}
	}
}

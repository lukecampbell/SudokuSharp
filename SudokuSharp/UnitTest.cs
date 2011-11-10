
#define __DEBUG__
using System;
using Gtk;

namespace SudokuSharp
{
	
	
		
	class UnitTest
	{
		
		public static void Main (string[] args)
		{
			SudokuSquare s =new SudokuSquare();
			Console.WriteLine(s.Count);
			try {
				s.TurnOff(2);
			} catch (FormatException e) {
				Console.Error.WriteLine(e.Message);
			}
			Console.WriteLine(s);
			Console.WriteLine(s.Count);
		}
		public static void onDeleteEvent(object sender, DeleteEventArgs a)
		{
			Application.Quit();
		}
	}
}

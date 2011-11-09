
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
			try {
				s.TurnOff(2);
			} catch (FormatException e) {
				Console.Error.WriteLine(e.Message);
			}
			Console.WriteLine(s);
		}
		public static void onDeleteEvent(object sender, DeleteEventArgs a)
		{
			Application.Quit();
		}
	}
}

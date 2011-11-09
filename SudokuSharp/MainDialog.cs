using System;
using Gtk;

namespace SudokuSharp
{
	public class MainDialog : Window
	{
		private SudokuSquare[] squares;
		private Button closeButton = new Button();
		public MainDialog () : base("Sudoku")
		{
			init();
			DeleteEvent+=new DeleteEventHandler(OnDeleteEvent);
			closeButton.Clicked += new EventHandler(OnCloseEvent);

			
		}
		private void init()
		{
			squares = new SudokuSquare[81];
			closeButton = Button.NewWithMnemonic("_Close");
			for(int i=0;i<81;i++)
			{
				squares[i] = new SudokuSquare();
				squares[i].Val =' ';
			}
			VBox vbox = new VBox(true, 2);
			for(int row=0;row<9;row++)
			{
				HBox hbox = new HBox(true, 2);
				for(int col=0;col<9;col++)
				{
					hbox.PackStart(squares[row*9 + col]);
				}
				hbox.Show();
				vbox.PackStart(hbox,true,true,0);
			}
			vbox.PackStart(closeButton,false,false,0);
			closeButton.Show();
			vbox.Show();
			Add(vbox);
			Show();
		}
		private static void OnCloseEvent(object sender, EventArgs a)
		{
			Application.Quit();
		}
		private static void OnDeleteEvent(object sender, DeleteEventArgs a)
		{
			Application.Quit();
		}
	}
}


using System;
using Gtk;

namespace SudokuSharp
{
	public class SudokuSquare : Frame
	{
		private Label label;
		private Entry entry;
		private EventBox eventBox;
		private HBox overlap;
		
		private char val_;
		/*
		 * Automatically sets the label to visible when changed
		 */
		public char Val
		{
			get { return val_; }
			set { 
				val_ = value;
				label.Text = val_.ToString();
				MakeLabelVisible();
				
			}
		}
		/*
		 * Initializes square to value specified preferred space i.e. blank
		 */
		public SudokuSquare (char val) : this()
		{
			Val = val;
		}
		/*
		 * Builds the Square
		 */
		public SudokuSquare () : base()
		{
			init();
		}
		private void MakeLabelVisible()
		{
			entry.Hide();
			label.Show();
			
		}
		private void MakeEntryVisible()
		{
			label.Hide();
			entry.Show();
			
		}
		private void init()
		{
			label = new Label("");
			entry = new Entry();
			entry.WidthChars = 3;
			eventBox = new EventBox();
			overlap = new HBox(true,0);
			Shadow = ShadowType.In;
			overlap.PackStart(label);
			overlap.PackStart(entry);
			eventBox.Add(overlap);
			eventBox.Show();
			Add(eventBox);
			SetSizeRequest(50,50);
			Val = ' ';
			ShowAll();
			MakeLabelVisible();
			eventBox.ButtonPressEvent+= new ButtonPressEventHandler(keyPressEvent);
			entry.Activated += new EventHandler(onActivate);
			
			
		}
		private static void keyPressEvent(object sender, ButtonPressEventArgs a)
		{
			EventBox caller = (EventBox) sender;
			SudokuSquare square = (SudokuSquare) caller.Parent;
			square.MakeEntryVisible();
			square.entry.GrabFocus();
		}
		private static void onActivate(object sender, EventArgs a)
		{
			Entry caller = (Entry) sender;
			HBox hisParent = (HBox) caller.Parent;
			EventBox boxesParent = (EventBox) hisParent.Parent;
			SudokuSquare square = (SudokuSquare) boxesParent.Parent;
			
			char v = ' ';
			try {
				v = ParseEntryInput(caller.Text);
			} catch (FormatException e) {
				Console.WriteLine(e.Message);
				square.Val = ' ';
				return;
			}
			square.Val = v;
	
		}
		public static char ParseEntryInput(string input)
		{
			char firstChar = input[0];
			if(firstChar == ' ')
				return firstChar;
			if(firstChar >= '0' && firstChar <= '9')
				return firstChar;
			throw new FormatException("SudokuSquare.ParseEntryInput(): badly formatted input");
			
		}
	}
}




using System;
using System.Collections;

namespace SudokuSharp
{
	public class SudokuSquare
	{
		private uint bitMap=0x3FE;
		
		public uint Count { get; private set; }
		
		// IList<Cluster> clusters
		
		private char val_;
		public char SquareValue {
			get { return val_; }
			set {
				if ( value == '-' || value == ' ' || value=='0')
					val_ = '-';
				else if (value > '0' && value <= '9')
					val_ = value;
				else 
					throw new FormatException("SudokuSquare.SquareValue: bad format");
			}
		}
		public string PossibilitiesString 
		{
			get {
				string ret = "(";
				for(int i=1;i<=9;i++)
				{
					uint map = (uint)((bitMap >> i) & 0x01);
					if((map)==0)
						ret+=' ';
					else
						ret+=(char)(i+'0');
				}
				ret+=")";
				return ret;
			}
		}
		public int Row { get; set; }
		public int Col { get; set; }
		
		public SudokuSquare () : this(0,0,'-')
		{
			
		}
		public SudokuSquare(int row, int col, char val) 
		{
			Row = row;
			Col = col;
			SquareValue = val; /* May throw exception, handled by caller */
			Count = 9;
		}
		
		public void TurnOff(uint n)
		{
			if(n<1 || n>9)
				throw new FormatException("SudokuSquare.TurnOff(): n is out of range 1-9");
			uint mask = ((uint)0x01 << (int)n);
			if((mask & bitMap)!=0)
			{
				bitMap &= ~mask;
				if(Count>0)
					Count--;
			}
		}
		public override string ToString ()
		{
			 string ret = "Square [" + 
				Row + "," +
				Col + "] " +
				PossibilitiesString +
				" : " + SquareValue;
			return ret;
		}
	}
}


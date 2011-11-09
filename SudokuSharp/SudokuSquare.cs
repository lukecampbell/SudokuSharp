#define __DEBUG__

using System;

namespace SudokuSharp
{
	public class SudokuSquare
	{
		private uint bitMap=0x3FE;
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
					uint map = (uint)((bitMap >> 9) & 0x01);
					if(map==0)
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
		
		public SudokuSquare ()
		{
			
		}
		
		public void TurnOff(uint n)
		{
			if(n<1 || n>9)
				throw new FormatException("SudokuSquare.TurnOff(): n is out of range 1-9");
			uint mask = ((uint)0x01 << (int)n);
#if __DEBUG__
			Console.WriteLine("Mask: "+mask);	
#endif
			bitMap = bitMap & ~mask;
		}
		public override string ToString ()
		{
			 return PossibilitiesString;
		}
	}
}


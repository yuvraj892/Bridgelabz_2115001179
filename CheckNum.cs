using System;
	class CheckNum
	{
		public static void Main(String []args)
		{
			Console.Write("Enter Number: ");
			int num= Convert.ToInt32(Console.ReadLine());
			bool NegNum =num<0;
			bool posNum=num>0;
			bool zero=num=0;
				Console.WriteLine("negative number"+ NegNum);
				Console.WriteLine("Positive number"+ posNum);
				Console.WriteLine("Zero" +zero);
		}
		
	}
using System;
	class CheckNaturalNum
	{
		public static void Main(String []args)
		{
			printNum();
		}
		public static void printNum()
		{
			Console.Write("Enter the number: ");
			int num = Convert.ToInt32(Console.ReadLine());
			if(num>0)
			{
				int sum = num*(num+1)/2);
				Console.WriteLine(string.Format("the sum of {0} natural num is {1}",num,sum))'
				
			}
			else{
				Console.WriteLine(string.Format("the string num {0} is not a Natural number",num));
			}
		}
	}
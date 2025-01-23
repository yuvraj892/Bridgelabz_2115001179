using System;
	class SpringSeason
	{
		public static void Main(String []args)
		{
			//take input from the user
			Console.Write("Month: ");
			int month= Convert.ToInt32(Console.ReadLine());
			Console.Write("Day: ");
			int day= Convert.ToInt32(Console.ReadLine());
			//mark the days btw 20march to 20June as spring season
			if ((month==3 && day>=20 && day<=31)||//march 20-31
				(month==4 && day>=1 && day<=30)||//April 1-30
				(month==5 && day>=1 && day<=31)||//May 1-31
				(month==6 && day>=1 && day<=20))//considering 20June is the last day
				Console.WriteLine("Its a Spring Season");
				//if not then print Its not a Spring Season
		}
		else{
			Console.WriteLine("Its not a Spring Season");
		}
	}

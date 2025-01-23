using System;
	class VotingAge
	{
		public static void Main(String []args)
		{
			//take input from the user
			Console.Write("Enter your Age: ");
			int age= Convert.ToInt32(Console.ReadLine());
			//check whether the age is greater than 18 or not
			if (age>=18){
				Console.WriteLine("The person can vote");
				//if not then print person cant vote
		}
		else{
			Console.WriteLine("The person cant vote");
		}
	}

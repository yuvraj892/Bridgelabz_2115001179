using System;
class fabbonacii{
	static void Main(){
		//taking input
		Console.WriteLine("Enter a number");
		int n = Convert.ToInt32(Console.ReadLine());
		int sum = 0;
		for (int i=0;i<=n;i++){
		    sum += i;
		}
		Console.WriteLine(sum);
	}
}
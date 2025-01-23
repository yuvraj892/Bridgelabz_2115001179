using System;
class firstSmallest{
	static void Main(){
	Console.Write("Enter the number:");
	int number= Convert.ToInt32(Console.ReadLine());
	if (number%5==0){
	Console.WriteLine("Yes, the nnumber is divisible by 5");
	}
	else{
	Console.WriteLine("no it is not divisible by 5")
	}
	}
}
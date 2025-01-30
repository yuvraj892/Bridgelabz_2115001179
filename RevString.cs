using System;
class RevString{
	public static void Main(String[] args){
		String str= Console.ReadLine();
		String rev="";
		for(int i=str.Length-1; i>=0; i--){
			rev+= str[i];
		}
		Console.WriteLine("Actual String is " + str + " and the reverse string is " + rev);
	}
}
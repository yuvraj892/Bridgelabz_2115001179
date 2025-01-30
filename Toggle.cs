using System;
class Toggle{
	public static void Main(String[] args){
		Console.WriteLine("Enter String");
		String str= Console.ReadLine();
		String str1="";
		for(int i=0; i<str.Length; i++){
			if(str[i]>=65 && str[i]<=90){
				str1+= (char)(str[i] + 32);
			}
			else{
				str1+= (char)(str[i]-32);
			}
		}
		Console.WriteLine("Actual String " + str + " and string after toggling is " + str1);
	}
}
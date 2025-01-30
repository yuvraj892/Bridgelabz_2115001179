using System;
class RemoveChar{
	public static void Main(String[] args){
		
		Console.WriteLine("Enter a string");
		String str= Console.ReadLine();
		Console.WriteLine("Enter character to remove");
		char c= Convert.ToChar(Console.ReadLine());
		
		String res="";
		
		for(int i=0; i< str.Length; i++){
			if(c!= str[i]){
				res+= str[i];
			}
		}
		
		Console.WriteLine("Modified String " + res);
	}
}
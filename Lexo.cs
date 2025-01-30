using System;

class Lexo{
	
	public static void Main(String[] args){
		
		Console.WriteLine("Enter String");
		String str= Console.ReadLine();
		Console.WriteLine("Enter Second String");
		String str1= Console.ReadLine();
		String firstString="", secondString="";
		int flag=0;
		int p1=0, p2=0;
		while(p1<str.Length && p2<str1.Length){
			flag= str[p1++] - str1[p2++];
			if(flag<0){
				firstString= str;
				secondString= str1;
				break;
			}
			else if(flag>0){
				firstString= str1;
				secondString= str;
				break;
			}
			else{
				continue;
			}
		}
		
		Console.WriteLine(firstString + " comes before " + secondString + " in lexographical order");
	}
}
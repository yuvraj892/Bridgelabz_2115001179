using System;
class pallindromicStr{
	public static void Main(String[] args){
		String str= Console.ReadLine();
		int start=0, end= str.Length-1, flag=0;
		while(start<=end){
			if(str[start++]!=str[end--]){
				flag= -1;
			}
		}
		if(flag==-1){
			Console.WriteLine("Not string is not Pallindromic");
		}
		else{
			Console.WriteLine("Yes string is pallindromic");
		}
	}
}
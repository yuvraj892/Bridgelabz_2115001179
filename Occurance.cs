using System;
class Occurance{
	public static void Main(String[] args){
		Console.WriteLine("Enter String");
		String str= Console.ReadLine();
		Console.WriteLine("Enter the subtring to check");
		String subs= Console.ReadLine();
		int count=0;
		for(int i= 0; i<str.Length; i++){
			if(subs[0]==str[i]){
				int flag=0;
				int p= i+1;
				for(int j=1; j<subs.Length; j++){
					if(subs[j]!=str[p++]){
						flag=-1;
						break;
					}
				}
				if(flag==0){
					count++;
				}
			}
		}
		
		
		Console.WriteLine("String after removing duplicates " + count);
	}
}
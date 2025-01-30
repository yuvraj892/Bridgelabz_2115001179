using System;
class LongestWord{
	
	public static void Main(String[] args){
		
		String str= Console.ReadLine();
		str+=" ";
		String res="";
		int start=0;
		
		for(int i=0; i<str.Length; i++){
			if(str[i]==32){
				if(res.Length < (i-start)){
					res="";
					for(int j= start; j< i; j++){
						res+= str[j];
					}
				}
				start= i+1;
			}
		}
		Console.WriteLine("Actual String is " + str + " and the longest string is " + res);
	}
}
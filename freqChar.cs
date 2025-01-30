using System;
class freqChar{
	public static void Main(String[] args){
		
		Console.WriteLine("Enter a string");
		String str= Console.ReadLine();
		
		int freq=0, maxfreq=0;
		char c='a';
		
		for(int i= 0; i<str.Length-1; i++){
			for(int j= i+1; j< str.Length; j++){
				if(str[i]==str[j]){
					freq++;
				}
			}
			if(maxfreq<freq){
				maxfreq= freq;
				c= str[i];
			}
		}
		Console.WriteLine("Most frequent character= " + c);
	}
}
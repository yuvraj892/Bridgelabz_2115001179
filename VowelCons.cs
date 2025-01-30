using System;
class VowelCons{
	
	public static void Main(String[] args){
		String str= Console.ReadLine();
		int vowel=0;
		int cons=0;
		for(int i=0; i< str.Length; i++){
			if(str[i]=='a' || str[i]=='e' || str[i]=='i' || str[i]=='o' || str[i]=='u'){
				vowel++;
			}
			else{
				cons++;
			}
		}
		Console.WriteLine("Number of vowels are " + vowel + " and number of consonants are " + cons);
	}
}
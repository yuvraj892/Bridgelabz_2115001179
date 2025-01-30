using System;

class RemoveDuplicates{
	
	public static void Main(String[] args){
		
		String str= Console.ReadLine();
		String str1="";
		
		for(int i= 0; i<str.Length; i++){
			
            char ch= str[i];
            bool found= false;
			
            for(int j= 0; j<str1.Length; j++){
                if (str1[j]==ch){
                    found = true;
                    break;
                }
            }

            if(!found){
                str1 += ch;
            }
        }				
		Console.WriteLine("String after removing duplicates " + str1);
	}
}
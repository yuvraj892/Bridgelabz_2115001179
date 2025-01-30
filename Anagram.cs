using System;

class Anagram{
	
	public static void Main(String[] args){
		
		Console.WriteLine("Enter String 1 ");
		String str1= Console.ReadLine();
		Console.WriteLine("Enter String 2 ");
		String str2= Console.ReadLine();
		
		int flag=0;
		
		if(str1.Length != str2.Length){
			Console.WriteLine("Not Anagram");
		}
		else{
			
			char[] arr1= str1.ToCharArray();
			char[] arr2= str2.ToCharArray();

			//sorting both the string
			for(int i= 0; i<arr1.Length-1; i++){
				for(int j=0; j< arr1.Length-i-1; j++){
					if(arr1[j]>arr1[j+1]){
						char temp= arr1[j];
						arr1[j]= arr1[j + 1];
						arr1[j+1]= temp;
					}

					if(arr2[j]>arr2[j+1]){
						char temp= arr2[j];
						arr2[j]= arr2[j + 1];
						arr2[j+1]= temp;
					}
				}
			}
			for(int i=0; i< arr1.Length; i++){
				if(arr1[i]!=arr2[i]){
					Console.WriteLine("Not Anagram");
					flag=-1;
					break;
				}
			}
		}
		
		if(flag==0)
			Console.WriteLine("Strings are Anagram");
	}
}
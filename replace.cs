using System;

class replace{
	
    public static string ReplaceWord(string str, string oldWord, string newWord){
		
        string result= "";
        int i= 0;
        
        while(i<str.Length){
			
            int j= 0, start= i;
            while(j<oldWord.Length && start<str.Length && str[start]==oldWord[j]){
                j++;
                start++;
            }

            //when word is matched replacing it
            if(j==oldWord.Length){
                result+= newWord;
                i+= oldWord.Length;
            }
            else{
                result += str[i];
                i++;
            }
        }
        return result;
    }

    public static void Main(String[] args){
		
        Console.WriteLine("Enter a string");
        String str = Console.ReadLine();
        Console.WriteLine("Enter word to replace");
        String oldWord = Console.ReadLine();
        Console.WriteLine("Enter new word");
        String newWord = Console.ReadLine();
        
        String res = ReplaceWord(str, oldWord, newWord);
        
        Console.WriteLine("Updated sentence is " + res);
    }
}
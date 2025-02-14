using System;
class Sort{
    public static int[] CountingSort(int[]arr){
        int n=arr.Length;
        int M=0;
        //Find the maximum data
        for(int i=0;i<n;i++){
            M=Math.Max(M,arr[i]);
        }
        int [] count=new int[M+1];
        //Output array
        int [] output = new int[n];
        //Store the count of each age
        for(int i=0;i<n;i++){
            count[arr[i]]++;
        }
        //Cumulative sum of count
        for(int i=1;i<M+1;i++){
            count[i]+=count[i-1];
        }
        //putting elements to ordered position
        for(int i=0;i<n;i++){
            output[count[arr[i]]-1]=arr[i];
            count[arr[i]]--;
        }

    return output;
    }
static void Main(string[] args){
        Console.Write("Enter the number of Students:");
        int number= Convert.ToInt32(Console.ReadLine());
        int[] ages = new int [number];
        int index=0;
        //to get input marks
        while(index<number){
            Console.Write($"Enter the Student {index+1} Age:");
            ages[index]= Convert.ToInt32(Console.ReadLine());
            index++;
        }
        //call the method
        int[] resultages=CountingSort(ages);
        //Display output
        Console.WriteLine("Final List after Counting sort: ");
        foreach(int result in resultages){
            Console.Write($"{result}, ");
        }
    }
}

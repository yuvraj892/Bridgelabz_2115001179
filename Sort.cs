using System;
class Sort{
    //Method to sort array using bubble sort
    public static void BubbleSort(ref int[] arr){
        int n= arr.Length;
        bool swapped;
        Console.WriteLine("Bubble Sort Process: ");
        for(int i=0;i<n-1;i++){
            swapped=false;
            for(int j=0;j<n-i-1;j++){
                //Condition to swap
                if(arr[j]>arr[j+1]){
                    int temp=arr[j];
                    arr[j]=arr[j+1];
                    arr[j+1]=temp;
                    swapped=true;
                }

            }
            //Display output after each round
            foreach(int mark in arr){
                Console.Write($"{mark}, ");
            }
            Console.WriteLine();
            //break condition if we swapped no elements
            if(!swapped){
                return;
            }    
            }
        }
    //Main method
    static void Main(string[] args){
        Console.Write("Enter the number of Students:");
        int number= Convert.ToInt32(Console.ReadLine());
        int[] marks = new int [number];
        int index=0;
        //to get input marks
        while(index<number){
            Console.Write($"Enter the marks {index+1}:");
            marks[index]= Convert.ToInt32(Console.ReadLine());
            index++;
        }
        //call the method
        BubbleSort(ref marks);
        //Display output
        Console.WriteLine("Final List after Bubble sort: ");
        foreach(int mark in marks){
            Console.Write($"{mark}, ");
        }
        

    }
}

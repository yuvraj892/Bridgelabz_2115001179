using System;
class Sort{
    //Selection sort method
    public static void SelectionSort(ref int[] arr){
        for(int i=0;i<arr.Length;i++){
            int minIndex=i;
            //loop to find the minimum element  
            for(int j=i+1;j<arr.Length;j++){
                if(arr[minIndex]>arr[j]){
                    minIndex=j;
                }
            }
            //swap the minimum element with current element
            int temp=arr[i];
            arr[i]=arr[minIndex];
            arr[minIndex]=temp;
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
        SelectionSort(ref marks);
        //Display output
        Console.WriteLine("Final List after Quick sort: ");
        foreach(int mark in marks){
            Console.Write($"{mark}, ");
        }
    }
}
    


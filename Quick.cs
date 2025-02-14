using System;
class Sort{
    //method to find the ordered position of pivot element in array and return it
    public static int Partition(ref int[] arr,int low,int high){
        int pivot = arr[high];
        int i=low-1;
        for(int j=low;j<high;j++){
            //Swap the elements if they are smaller than pivot
            //else move forward
            if(arr[j]<pivot){
                i++;
                Swap(ref arr,i,j);
            }
        }
        //swap pivot with the first big element
        Swap(ref arr,i+1,high);
        return i+1;
    }
    //method to call the recursion of Quicksort
    public static void QuickSort(ref int[] arr,int low,int high){
        if(low<high){
            //give the pivot element its position in array
            int pi= Partition(ref arr,low,high);
            QuickSort(ref arr,low,pi-1);
            QuickSort(ref arr,pi+1,high);
        }
    }
    //method to swap the elements
    public static void Swap(ref int[] arr, int i, int j) {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }
    //Main method
     static void Main(string[] args){
        Console.Write("Enter the number of Products:");
        int number= Convert.ToInt32(Console.ReadLine());
        int[] products = new int [number];
        int index=0;
        //to get input marks
        while(index<number){
            Console.Write($"Enter the Product {index+1} Price:");
            products[index]= Convert.ToInt32(Console.ReadLine());
            index++;
        }
        //call the method
        QuickSort(ref products,0,products.Length-1);
        //Display output
        Console.WriteLine("Final List after Quick sort: ");
        foreach(int price in products){
            Console.Write($"{price}, ");
        }
    }
}
    


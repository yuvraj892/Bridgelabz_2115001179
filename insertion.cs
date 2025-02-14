using System;
class Sort{
    public static void InsertionSort(ref int[] arr){
        int n= arr.Length;
        for (int i=1;i<n;i++){
            int key= arr[i];
            int j=i-1;
            //swap till elements are greater than key
            while(j>=0 && arr[j]>key){
                arr[j+1]=arr[j];
                j--;
            }
            //put key in position
            arr[j+1]=key;
            foreach(int mark in arr){
                Console.Write($"{mark}, ");
            }
            Console.WriteLine();

        }
    }
    static void Main(string[] args){
        Console.Write("Enter the number of Employees:");
        int number= Convert.ToInt32(Console.ReadLine());
        int[] employees = new int [number];
        int index=0;
        //to get input marks
        while(index<number){
            Console.Write($"Enter the Employee {index+1} Id:");
            employees[index]= Convert.ToInt32(Console.ReadLine());
            index++;
        }
        //call the method
        InsertionSort(ref employees);
        //Display output
        Console.WriteLine("Final List after Insertion sort: ");
        foreach(int id in employees){
            Console.Write($"{id}, ");
        }
    }
}

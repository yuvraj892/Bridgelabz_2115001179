using System;
using System.Diagnostics;
class Search{
    //Linear search method
    static int LinearSearch(int[] arr,int target){
        for (int i=0;i<arr.Length;i++){
            if (arr[i]==target){
                return i;
            }
        }
        return -1;
    }
    //Binary search method
    static int BinarySearch(int[] arr,int target){
        // Array.Sort(arr);
        int left=0;
        int right=arr.Length-1;
        while(left<right){
            int mid=left+(right-left)/2;
            if(arr[mid]==target){
                return mid;
            }
            else if(arr[mid]<target){
                left=mid+1;
            }
            else{
                right=mid;
            }
        }
        return -1;

    }
    //Main method
    static void Main(string [] args){
        int[]sizes= {1000,10000,100000,1000000,10000000};
        foreach (int size in sizes){
        int [] arr= new int[size];
        Random rm = new Random();
        //create an array
        for(int i=0;i<size;i++){
            arr[i]=rm.Next(0,size);
        }
        //Stopwatch for Linear search
        Stopwatch sw1= Stopwatch.StartNew();
        int index= LinearSearch(arr,arr[arr.Length-1]);
        sw1.Stop();
        //Display output
        Console.WriteLine($"Time for Linear Search : {sw1.ElapsedMilliseconds}ms");
        //Sort array for binary search
        Array.Sort(arr);
        //Stopwatch for Binary Search
        Stopwatch sw2= Stopwatch.StartNew();
        int index2= BinarySearch(arr,arr[arr.Length-1]);
        sw2.Stop();
        //Display output
        Console.WriteLine($"Time for Binary Search : {sw2.ElapsedMilliseconds}ms");
        }


    }
}

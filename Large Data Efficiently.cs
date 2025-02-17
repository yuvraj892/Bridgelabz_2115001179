using System;
using System.Diagnostics;
class Compare{
    //Bubble sort
    public static void BubbleSort( int[] arr){
        int n= arr.Length;
        bool swapped;
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
            //break condition if we swapped no elements
            if(!swapped){
                return;
            }    
        }
    }
    //Method to call the recursive method to divide and merge
    public static void MergeSort( int[] arr,int low,int high){
        if (low<high){
            int mid= low + (int)((high-low)/2);
            MergeSort( arr,low, mid);
            MergeSort( arr,mid+1,high);
            Merge( arr,low,mid,high);
        }
    }
    //method to merge the left and right part
    public static void Merge( int[] arr,int low,int mid,int high){
        int n1= mid-low+1;
        int n2= high-mid;
        int [] left= new int[n1];
        int [] right= new int[n2];
        int i,j;
        //copy data of left and right part in separate array
        for(i=0;i<n1;i++){
            left[i]=arr[low+i];
        } 
        for(j=0;j<n2;j++){
            right[j]=arr[mid+1+j];
        }
        i=0;
        j=0;
        int k=low;
        //put value in original array
        while(i<n1&&j<n2){
            int ele= left[i]>=right[j]?right[j++]:left[i++];
            arr[k++]=ele;
        }
        while(i<n1){
            arr[k++]=left[i++];
        }
        while(j<n2){
            arr[k++]=right[j++];
        }
    }
    //method to find the ordered position of pivot element in array and return it
    public static int Partition( int[] arr,int low,int high){
        int pivot = arr[high];
        int i=low-1;
        for(int j=low;j<high;j++){
            //Swap the elements if they are smaller than pivot
            //else move forward
            if(arr[j]<pivot){
                i++;
                Swap( arr,i,j);
            }
        }
        //swap pivot with the first big element
        Swap( arr,i+1,high);
        return i+1;
    }
    //method to call the recursion of Quicksort
    public static void QuickSort(int[] arr,int low,int high){
        if(low<high){
            //give the pivot element its position in array
            int pi= Partition(arr,low,high);
            QuickSort(arr,low,pi-1);
            QuickSort(arr,pi+1,high);
        }
    }
    //method to swap the elements
    public static void Swap(int[] arr, int i, int j) {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }
    //Main method
    static void Main(string [] args){
        int[]sizes= {1000,10000,100000};
        foreach (int size in sizes){
        int [] arr= new int[size];
        Random rm = new Random();
        //create an array
        for(int i=0;i<size;i++){
            arr[i]=rm.Next(0,size);
        }
        //Stopwatch for QuickSort
        Stopwatch sw1= Stopwatch.StartNew();
        BubbleSort(arr);
        sw1.Stop();
        //Display output
        Console.WriteLine($"Time for BubbleSort : {sw1.ElapsedMilliseconds}ms");
        //Stopwatch for MergeSort
        Stopwatch sw2= Stopwatch.StartNew();
        MergeSort(arr,0,arr.Length-1);
        sw2.Stop();
        //Display output
        Console.WriteLine($"Time for MergeSort : {sw2.ElapsedMilliseconds}ms");
        //Stopwatch for QuickSort
        Stopwatch sw3= Stopwatch.StartNew();
        QuickSort(arr,0,arr.Length-1);
        sw3.Stop();
        //Display output
        Console.WriteLine($"Time for Quicksort : {sw3.ElapsedMilliseconds}ms");
        }


    }
}
 
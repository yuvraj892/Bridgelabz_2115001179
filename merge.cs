using System;
class Sort{
    //Method to call the recursive method to divide and merge
    public static void MergeSort(ref int[] arr,int low,int high){
        if (low<high){
            int mid= low + (int)((high-low)/2);
            MergeSort(ref arr,low, mid);
            MergeSort(ref arr,mid+1,high);
            Merge(ref arr,low,mid,high);
            foreach(int marks in arr){
                Console.Write($"{marks}, ");
            }
            Console.WriteLine();
        }
    }
    //method to merge the left and right part
    public static void Merge(ref int[] arr,int low,int mid,int high){
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
    static void Main(string[] args){
        Console.Write("Enter the number of Books:");
        int number= Convert.ToInt32(Console.ReadLine());
        int[] books = new int [number];
        int index=0;
        //to get input marks
        while(index<number){
            Console.Write($"Enter the Book {index+1} Price:");
            books[index]= Convert.ToInt32(Console.ReadLine());
            index++;
        }
        //call the method
        MergeSort(ref books,0,books.Length-1);
        //Display output
        Console.WriteLine("Final List after Merge sort: ");
        foreach(int price in books){
            Console.Write($"{price}, ");
        }
    }
}

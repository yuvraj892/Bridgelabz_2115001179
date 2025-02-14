using System;
class Sort{
    // Function to heapify a subtree rooted at index i
    public static void Heapify(int[] arr, int n, int i){
        int largest = i; // Initialize largest as root
        int left = 2 * i + 1; // Left child index
        int right = 2 * i + 2; // Right child index
        // If left child is larger than root
        if (left < n && arr[left] > arr[largest])
            largest = left;
        // If right child is larger than the largest so far
        if (right < n && arr[right] > arr[largest])
            largest = right;
        // If the largest is not root, swap and continue heapifying
        if (largest != i){
            Swap(arr, i, largest);
            Heapify(arr, n, largest);
        }
    }
    // Function to perform heap sort
    public static void HeapSort(int[] arr){
        int n = arr.Length;
        // Step 1: Build a Max Heap (Rearrange array)
        for (int i = n / 2 - 1; i >= 0; i--)
            Heapify(arr, n, i);
        // Step 2: Extract elements from the heap one by one
        for (int i = n - 1; i > 0; i--){
            // Move current root (largest) to the end
            Swap(arr, 0, i);
            // Call max heapify on the reduced heap
            Heapify(arr, i, 0);
        }
    }
    // Function to swap two elements
    public static void Swap(int[] arr, int i, int j){
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }
    // Main function
    static void Main(string[] args){
        Console.Write("Enter the number of Applicants:");
        int number= Convert.ToInt32(Console.ReadLine());
        int[] applicants = new int [number];
        int index=0;
        //to get input marks
        while(index<number){
            Console.Write($"Enter the Applicant {index+1} Salary:");
            applicants[index]= Convert.ToInt32(Console.ReadLine());
            index++;
        }
        //call the method
        HeapSort(applicants);
        //Display output
        Console.WriteLine("Final List after Merge sort: ");
        foreach(int salary in applicants ){
            Console.Write($"{salary}, ");
        }
    }
}

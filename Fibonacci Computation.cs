using System;
using System.Diagnostics;
class Fibonacci{
    //recursive method for fibonacci
    static int Recursive(int n){
        if(n<=1)return n;
        return Recursive(n-1)+Recursive(n-2);
    }
     //iterative method for fibonacci
    static int Iterative(int n){
        int a=0,b=1,sum;
        for(int i=2;i<=n;i++){
            sum=a+b;
            a=b;
            b=sum;
        }
        return b;
    }
    //Main method
    static void Main(string [] args){
        int[]sizes= {10,20,30,40,50};
        foreach (int size in sizes){
        //Stopwatch for Recursive Fibonacci
        Stopwatch sw1= Stopwatch.StartNew();
        int ans1=Recursive(size);
        sw1.Stop();
        //Display output
        Console.WriteLine($"Time for Recursive Fibonacci: {sw1.ElapsedMilliseconds} ms,answer{ans1}");
        //Stopwatch for Iterative Fibonacci
        Stopwatch sw2= Stopwatch.StartNew();
        int ans2= Iterative(size);
        sw2.Stop();
        //Display output
        Console.WriteLine($"Time for Iterative Fibonacci: {sw2.ElapsedMilliseconds} ms,answer {ans2}");
        }
}}

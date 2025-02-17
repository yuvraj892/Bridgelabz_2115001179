using System;
using System.Text;
using System.Diagnostics;

class Performance{
    static void Main(){
        int[] iterations={1000,10000,100000};
        foreach(int iteration in iterations){
        // Testing String Performance
        Stopwatch sw1 =Stopwatch.StartNew();
        string str = "";
        for (int i = 0; i < iteration; i++){
            str += " Performance Test";
        }
        sw1.Stop();
        Console.WriteLine("String Time: " + sw1.ElapsedMilliseconds + " ms");

        // Testing StringBuilder Performance
        Stopwatch sw2= Stopwatch.StartNew();
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < iteration; i++){
            sb.Append(" Performance Test");
        }
        sw2.Stop();
        Console.WriteLine("StringBuilder Time: " + sw2.ElapsedMilliseconds + " ms");
    }}
}

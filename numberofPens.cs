using System;
    class numberOfPens{
        static void Main(){
            int noOfPens = 14;
            int noOfStudents = 3;
            int GivenPens= noOfPens/noOfStudents;
            int Pensleft= noOfPens%noOfStudents;
            Console.WriteLine("The Pen Per Student is "+GivenPens+ " and the remaining pen not distributed is " + Pensleft);
}
    }
using System;
    class ProfitandLoss{
        static void Main(){
            int costPrice= 129;
            int sellingPrice = 191;
            double profit = sellingPrice - costPrice;
            double profitPercentage= (profit/costPrice) *100;
            Console.WriteLine("The Cost Price is INR " + costPrice+ "and Selling Price is INR "+ sellingPrice);
            Console.WriteLine("The Profit is INR " + profit + "and the Profit Percentage is " +profitPercentage);
        }
	}
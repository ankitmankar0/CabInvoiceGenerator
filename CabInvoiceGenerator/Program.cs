﻿using System;

namespace CabInvoiceGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Cab Invoice Generator");


            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double fare = invoiceGenerator.CalculateFare(2.0, 5);
            Console.WriteLine($"Fare : {fare}");

            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };
            InvoiceSummary totalFare = invoiceGenerator.CalculateFare(rides);
            Console.WriteLine("\nTotal Fare Of Journey for multiple rides : " + totalFare);
        }
    }
}

using CabInvoiceGenerator;
using NUnit.Framework;

namespace CabInvoiceGeneratorTest
{
    public class Tests
    {
        InvoiceGenerator invoiceGenerator = null;

        // UC1 : Test case for checking total fare function.
        [Test]
        public void GivenDistanceAndTimeShouldReturnTotalFare()
        {
            
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double distance = 2.0;
            int time = 5;

            // Calculating Fare
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 25;

            // Asserting Values
            Assert.AreEqual(expected, fare);
        }


        // UC2 : Test case for calculate fare function for multiple rides summary.

        [Test]
        public void GivenMultipleRidesShouldReturnInvoiceSummary()
        {
           
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };

            //Act
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 30.0);

            //Assert
            Assert.AreEqual(expectedSummary, summary);
        }

        // UC3 : TestCase for Checking Calculate Fare Function For Minimum Time And Distance

        [Test]
        public void GivenLessDistanceOrTimeShouldReturnMinimumFare()
        {
            //Creating Instance of InvoiceGenerator for Normal Ride
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double distance = 0.1;
            int time = 1;

            //Calculating Fare
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 5;

            //Asserting values
            Assert.AreEqual(expected, fare, time);
        }

        // UC4 : Given Invalid RideType Should Throw Custom Exception

        [Test]
        public void GivenInvalidRideTypeShouldThrowCustomException()
        {
            //Creating Instance of InvoiceGenerator
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double distance = 2.0;
            int time = 5;
            string expected = "Invalid Ride Type";
            try
            {
                //Calculating Fare
                double fare = invoiceGenerator.CalculateFare(distance, time);
            }
            catch (CabInvoiceException exception)
            {
                //Asserting Values
                Assert.AreEqual(expected, exception);
            }
        }
        // UC5 : Test case for checking total fare function for Premium Ride.

        [Test]
        public void GivenDistanceAndTimeShouldReturnTotalFareForPremiumRide()
        {
            // Creating Instance of InvoiceGenerator For Normal Ride
            invoiceGenerator = new InvoiceGenerator(RideType.PREMIUM);
            double distance = 2.0;
            int time = 5;

            // Calculating Fare
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 40;

            // Asserting Values
            Assert.AreEqual(expected, fare);
        }

    }
}
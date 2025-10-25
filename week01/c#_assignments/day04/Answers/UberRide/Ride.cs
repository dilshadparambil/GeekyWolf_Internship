using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UberRide
{
    internal class Ride
    {
        static int totalRides;
        static double totalEarnings;
        static double baseFare;
        static double surgeMultiplier;

        public string RideId { get; set; }
        public string DriverName { get; set; }
        public string PassengerName { get; set; }
        public double DistanceKm { get; set; }
        public double Fare { get; set; }

        static Ride()
        {
            Console.WriteLine("Uber System Initialized. Ready to book rides...\n");
            totalRides = 1000;
            totalEarnings = 0;
            baseFare = 50.0;
            surgeMultiplier = 1.0;
        }
        public Ride(string driverName,string passengerName,double distance)
        {
            this.RideId = $"Ride_{totalRides}";
            totalRides++;
            this.DriverName = driverName;
            this.PassengerName = passengerName;
            this.DistanceKm = distance;
            this.Fare = baseFare + (this.DistanceKm * 15 * surgeMultiplier);
            totalEarnings += this.Fare;
            
        }
        public static void SetSurgeMultiplier(double multiplier)
        {
            if (multiplier >= 1.0)
            {
                surgeMultiplier = multiplier;
                Console.WriteLine("After surge...\n");
            } 
        }

        public static void ShowRideSummary()
        {
            Console.WriteLine($"Total Rides = {totalRides-1000}\nTotal Earnings = {string.Format("{0:0.00}", totalEarnings)}\n");
        }
        public void ShowRideDetails()
        {
            Console.WriteLine($"ride ID : {RideId}\ndriver : {DriverName}\npassenger : {PassengerName}\ndistance : {DistanceKm}km\nfare : {string.Format("{0:0.00}", Fare)}\n");
        }

    }
}

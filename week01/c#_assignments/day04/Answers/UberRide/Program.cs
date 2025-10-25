using UberRide;

Ride r1 = new Ride("gopal","dilshad",50);
Ride r2 = new Ride("gopal","rashi",37);

r1.ShowRideDetails();
r2.ShowRideDetails();

Ride.ShowRideSummary();

Ride.SetSurgeMultiplier(2.8);

Ride r3 = new Ride("gopal", "raihan", 69.4);
r3.ShowRideDetails();

Ride.ShowRideSummary();
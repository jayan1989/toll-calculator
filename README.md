# Technologies Used

1.	.Net 6 Web API has been used to build an API which returns calculated toll fee
2.	Autofac - This is an IoC container which handles injecting dependencies to classes and autowire implementations to interfaces (ex – see the dependency module class in code).
3.	Microsoft.VisualStudio.TestTools.UnitTesting with NSubstitute has been used to write unit tests 

# Changes and Fixes

1.	Corrected the same hour toll fee calculation in **TollCalculatorService**.
2.	Validated dates passing for calculation in **TollCalculatorService**:
   -  Checked whether all the dates are on same day 
   -	Checked for any future date
3.	Implemented factory method to create instance of vehicle class depending on the vehicle type. Implementation can be found in **VehicleFactory** class.
4.	SOLID principles have been used throughout the solution.

# Improvements which can be done in future

1.	Implement a global exception handler
2.	Add logging
3.	Toll fees and holidays can be taken from a database
4.	Implement API authentication using Identityserver4 

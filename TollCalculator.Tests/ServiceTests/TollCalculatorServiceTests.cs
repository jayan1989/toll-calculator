using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using TollCalculator.API.Data;
using TollCalculator.API.Infrastructure.Dtos;
using TollCalculator.API.Infrastructure.Enums;
using TollCalculator.API.Models;
using TollCalculator.API.Models.Factories;
using TollCalculator.API.Services;

namespace TollCalculator.Tests.ServiceTests
{
    [TestClass]
    public class TollCalculatorServiceTests
    {
        private ITollCalculatorService _tollCalculatorService;
        private VehicleFactory _vehicleFactory;
        private ITollFeeService _tollFeeService;
        private VehicleDelegate _vehicleDelegate;

        public TollCalculatorServiceTests()
        {
            _vehicleDelegate = Substitute.For<VehicleDelegate>();
            _vehicleFactory = new VehicleFactory(_vehicleDelegate);
            _tollFeeService = new TollFeeService(new DateService(new HolidaysDataStore()));

            _tollCalculatorService = new TollCalculatorService(_vehicleFactory, _tollFeeService);
        }

        [TestMethod]
        public void GivenGetTollFeeIsCalled_WhenVehicleIsEmergency_ThenFeeShouldBeZero()
        {
            //Arrange
            var tollFeeRequest = new TollFeeRequestDto
            {
                VehicleType = VehicleType.Emergency,
                Dates = new List<DateTime>()
            };
            _vehicleDelegate(Arg.Any<VehicleType>()).Returns(new Emergency());

            //Act
            var result = _tollCalculatorService.GetTollFee(tollFeeRequest);

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void GivenGetTollFeeIsCalled_WhenFeeExceedsSixtySEK_ThenShouldReturnSixty()
        {
            //Arrange
            var tollFeeRequest = new TollFeeRequestDto
            {
                VehicleType = VehicleType.Car,
                Dates = new List<DateTime>
                {
                    new DateTime(2022, 5, 30, 6, 35, 0),
                    new DateTime(2022, 5, 30, 7, 5, 0),
                    new DateTime(2022, 5, 30, 8, 5, 0),
                    new DateTime(2022, 5, 30, 15, 5, 0),
                    new DateTime(2022, 5, 30, 16, 5, 0),
                    new DateTime(2022, 5, 30, 17, 5, 0)
                }
            };
            _vehicleDelegate(Arg.Any<VehicleType>()).Returns(new Car());

            //Act
            var result = _tollCalculatorService.GetTollFee(tollFeeRequest);

            //Assert
            Assert.AreEqual(60, result);
        }

        [TestMethod]
        public void GivenGetTollFeeIsCalled_WhenMultipleFeesAreInSameHour_ThenShouldReturnHighestFee()
        {
            //Arrange
            var tollFeeRequest = new TollFeeRequestDto
            {
                VehicleType = VehicleType.Car,
                Dates = new List<DateTime>
                {
                    new DateTime(2022, 5, 30, 6, 2, 0),
                    new DateTime(2022, 5, 30, 8, 2, 0),
                    new DateTime(2022, 5, 30, 8, 35, 0),
                    new DateTime(2022, 5, 30, 8, 40, 0)
                }
            };
            _vehicleDelegate(Arg.Any<VehicleType>()).Returns(new Car());

            //Act
            var result = _tollCalculatorService.GetTollFee(tollFeeRequest);

            //Assert
            Assert.AreEqual(21, result);
        }

        [TestMethod]
        public void GivenGetTollFeeIsCalled_WhenDateIsHoliday_ThenFeeShouldBeZero()
        {
            //Arrange
            var tollFeeRequest = new TollFeeRequestDto
            {
                VehicleType = VehicleType.Car,
                Dates = new List<DateTime>
                {
                    new DateTime(2022, 5, 28, 6, 2, 0)                   
                }
            };
            _vehicleDelegate(Arg.Any<VehicleType>()).Returns(new Car());

            //Act
            var result = _tollCalculatorService.GetTollFee(tollFeeRequest);

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void GivenGetTollFeeIsCalled_WhenPassesAreInDifferentDays_ThenThrowValidationException()
        {
            //Arrange
            var tollFeeRequest = new TollFeeRequestDto
            {
                VehicleType = VehicleType.Car,
                Dates = new List<DateTime>
                {
                    new DateTime(2022, 4, 28, 6, 2, 0),
                    new DateTime(2022, 5, 28, 6, 2, 0)
                }
            };
            _vehicleDelegate(Arg.Any<VehicleType>()).Returns(new Emergency());

            //Act

            //Assert
            Assert.ThrowsException<ArgumentException>(() => _tollCalculatorService.GetTollFee(tollFeeRequest));
        }

        [TestMethod]
        public void GivenGetTollFeeIsCalled_WhenDateIsFutureDate_ThenThrowValidationException()
        {
            //Arrange
            var tollFeeRequest = new TollFeeRequestDto
            {
                VehicleType = VehicleType.Car,
                Dates = new List<DateTime>
                {
                    new DateTime(2022, 4, 28, 6, 2, 0),
                    new DateTime(2022, 6, 28, 6, 2, 0)
                }
            };
            _vehicleDelegate(Arg.Any<VehicleType>()).Returns(new Emergency());

            //Act

            //Assert
            Assert.ThrowsException<ArgumentException>(() => _tollCalculatorService.GetTollFee(tollFeeRequest));
        }
    }
}

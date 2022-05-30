using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TollCalculator.API.Data;
using TollCalculator.API.Services;

namespace TollCalculator.Tests.ServiceTests
{
    [TestClass]
    public class TollFeeServiceTests
    {
        private ITollFeeService _tollFeeService;
        public TollFeeServiceTests()
        {
            _tollFeeService = new TollFeeService(new DateService(new HolidaysDataStore()));
        }

        [TestMethod]
        public void GivenGetTollFeeForDateIsCalled_WhenDateIsHoliday_ThenFeeShouldBeZero()
        {
            //Arrange
            var date = new DateTime(2021, 5, 29, 6, 3, 2);

            //Act
            var result = _tollFeeService.GetTollFeeForDate(date);

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void GivenGetTollFeeForDateIsCalled_WhenTimeIsOutsideTollFeeTimeRange_ThenFeeShouldBeZero()
        {
            //Arrange
            var date = new DateTime(2021, 5, 29, 5, 0, 0);

            //Act
            var result = _tollFeeService.GetTollFeeForDate(date);

            //Assert
            Assert.AreEqual(0, result);
        }
    }
}

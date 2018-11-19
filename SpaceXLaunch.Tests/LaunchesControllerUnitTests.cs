using System;
using Xunit;
using FluentAssertions;
using Moq;
using SpaceXLaunch.Api.Controllers;
using LaunchData.Lib.Services;
using LaunchData.Lib.LaunchData;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LaunchData.Lib.Models;
using System.Threading.Tasks;

namespace SpaceXLaunch.Tests
{
    public class LaunchesControllerUnitTests
    {
        [Fact]
        public async Task Launches_Get_All()
        {
            // arrange
            var controller = new LaunchesController(new LaunchDataService(new GetLaunchData()));

            // act
            var result = await controller.GetLaunches();

            // assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var launches = okResult.Value.Should().BeAssignableTo<IEnumerable<Launch>>().Subject;
        }

        [Fact]
        public async Task Launches_Get_All_From_Mock()
        {
            // arrange
            var mockService = new Mock<ILaunchDataService>();

            // generate random number to arbitrarily compare response to mock data
            Random rnd = new Random();
            int idx = rnd.Next(0, 3);

            List<Launch> launches = new List<Launch>
            {
                new Launch
                {
                    Id = "xxx-yyyy-zzz",
                    Name = "First Launch",
                    Status = "active"
                },
                new Launch
                {
                    Id = "aaa-bbbb-ccc",
                    Name = "Second Launch",
                    Status = "retired"
                },
                new Launch
                {
                    Id = "qqq-rrrr-sss",
                    Name = "Third Launch",
                    Status = "under construction"
                }
            };

            mockService.Setup(s => s.GetLaunchData()).Returns(
                () => Task.FromResult(launches)
            );

            var controller = new LaunchesController(mockService.Object);

            // act
            var result = await controller.GetLaunches();

            // assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var actual = okResult.Value.Should().BeAssignableTo<List<Launch>>().Subject;
            actual.Count.Should().Be(3);
            actual[idx].Id.Should().Be(launches[idx].Id);
        }
    }
}

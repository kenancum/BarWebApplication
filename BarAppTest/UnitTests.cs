using System;
using System.Linq;
using System.Threading.Tasks;
using BarApp.Models;
using BarApp.Services;
using BarStoreApi.Controllers;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Moq;
using NUnit.Framework;

namespace BarAppTest
{
    [TestFixture]
    public class Tests
    {
        private BarsController _controller;
        private Mock<IBarService> _barServiceMock;

        [SetUp]
        public void Setup()
        {
            _barServiceMock = new Mock<IBarService>();
            _controller = new BarsController(_barServiceMock.Object);
        }

        [Test]
        public async Task Get_ShouldReturnListOfBars()
        {
            // Arrange
            var bars = new List<Bar>
            {
                new Bar { Id = "1", Name = "Test Bar 1", Address = "123 Main St", OpeningTime = "9:00", ClosingTime = "11:00" },
                new Bar { Id = "2", Name = "Test Bar 2", Address = "234 Main St", OpeningTime = "10:00", ClosingTime = "10:00" }
            };
            _barServiceMock.Setup(x => x.GetAsync()).ReturnsAsync(bars);

            // Act
            var result = await _controller.Get();

            // Assert
            Assert.IsInstanceOf<List<Bar>>(result);
            Assert.AreEqual(bars, result);
        }
        [Test]
        public async Task Create_ValidBar_ReturnsCreatedResult()
        {
            // Arrange
            var newBar = new Bar { Id = "1", Name = "Test Bar", Address = "123 Main St", OpeningTime = "9:00", ClosingTime = "11:00" };
            var serviceMock = new Mock<IBarService>();
            serviceMock.Setup(x => x.CreateAsync(newBar)).Returns(Task.CompletedTask);
            var controller = new BarsController(serviceMock.Object);

            // Act
            var result = await controller.Post(newBar);

            // Assert
            Assert.IsInstanceOf<CreatedAtActionResult>(result);
            var createdResult = (CreatedAtActionResult)result;
            Assert.AreEqual("Get", createdResult.ActionName);
            Assert.AreEqual("1", createdResult.RouteValues["id"]);
            Assert.AreEqual(newBar, createdResult.Value);
            serviceMock.Verify(x => x.CreateAsync(newBar), Times.Once());
        }
        [Test]
        public async Task GetById_ShouldReturnBar()
        {
            // Arrange
            var barId = "1";
            var bar = new Bar { Id = barId, Name = "Test Bar 1", Address = "123 Main St", OpeningTime = "9:00", ClosingTime = "11:00" };
            _barServiceMock.Setup(x => x.GetAsync(barId)).ReturnsAsync(bar);

            // Act
            var result = await _controller.Get(barId);

            // Assert
            var okResult = result.Result as OkObjectResult;
            var returnedBar = result.Value;
            Assert.IsNotNull(returnedBar);
            Assert.AreEqual(bar, returnedBar);
        }
        [Test]
        public async Task Post_ShouldReturnCreatedAtActionResult()
        {
            // Arrange
            var newBar = new Bar { Name = "Test Bar", Address = "123 Main St", OpeningTime = "9:00 AM", ClosingTime = "11:00 PM" };
            _barServiceMock.Setup(x => x.CreateAsync(newBar)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Post(newBar);

            // Assert
            Assert.IsInstanceOf<CreatedAtActionResult>(result);
            var createdResult = (CreatedAtActionResult)result;
            Assert.AreEqual("Get", createdResult.ActionName);
            Assert.AreEqual(newBar, createdResult.Value);
            _barServiceMock.Verify(x => x.CreateAsync(newBar), Times.Once());
        }
        [Test]
        public async Task Put_ShouldReturnNotFound()
        {
            // Arrange
            var barId = "1";
            var updatedBar = new Bar { Name = "Updated Bar" };
            _barServiceMock.Setup(x => x.GetAsync(barId)).ReturnsAsync((Bar)null);

            // Act
            var result = await _controller.Update(barId, updatedBar);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }
        [Test]
        public async Task Put_ShouldReturnNoContent()
        {
            // Arrange
            var barId = "1";
            var currentBar = new Bar { Id = barId, Name = "Bar 1" };
            var updatedBar = new Bar { Name = "Updated Bar" };
            _barServiceMock.Setup(x => x.GetAsync(barId)).ReturnsAsync(currentBar);
            _barServiceMock.Setup(x => x.UpdateAsync(barId, updatedBar)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Update(barId, updatedBar);

            // Assert
            Assert.IsInstanceOf<NoContentResult>(result);
            _barServiceMock.Verify(x => x.UpdateAsync(barId, updatedBar), Times.Once());
        }
        [Test]
        public async Task Delete_ShouldReturnNotFound()
        {
            // Arrange
            var barId = "1";
            _barServiceMock.Setup(x => x.GetAsync(barId)).ReturnsAsync((Bar)null);

            // Act
            var result = await _controller.Delete(barId);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }
        [Test]
        public async Task Delete_ShouldReturnNoContent()
        {
            // Arrange
            var barId = "1";
            var bar = new Bar { Id = barId, Name = "Bar 1" };
            _barServiceMock.Setup(x => x.GetAsync(barId)).ReturnsAsync(bar);
            _barServiceMock.Setup(x => x.RemoveAsync(barId)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Delete(barId);

            // Assert
            Assert.IsInstanceOf<NoContentResult>(result);
            _barServiceMock.Verify(x => x.RemoveAsync(barId), Times.Once());
        }

    }
}
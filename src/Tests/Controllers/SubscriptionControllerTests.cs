using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volxyseat.Api.Controllers;
using Volxyseat.Domain.Core.Data;
using Volxyseat.Domain.Models.SubscriptionModel;
using Xunit;

namespace SubscriptionControllerTests.Controllers
{
    public class SubscriptionControllerTests
    {
        private readonly Mock<ISubscriptionRepository> _subscriptionMock;
        private readonly SubscriptionController _controller;
        private readonly Mock<IUnitOfWork> _uow;
        private readonly Mock<IMapper> _mapper;

        public SubscriptionControllerTests()
        {
            _subscriptionMock = new Mock<ISubscriptionRepository>();
            _uow = new Mock<IUnitOfWork>();
            _mapper = new Mock<IMapper>();
            _controller = new SubscriptionController(_subscriptionMock.Object, _uow.Object, _mapper.Object);
        }

        [Fact]
        public async Task GetById_WhenCalled_ReturnOkResult()
        {
            var id = Guid.NewGuid();
            var result = await _controller.GetById(id);
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task GetById_WhenCalledWithValidId_OkResult()
        {
            // Arrange
            var id = Guid.Parse("dbd2616a-8ece-48b8-9c8a-59383cc0cbbe");
            var subscription = new Subscription
            {
                Id = id,
            };

            _subscriptionMock.Setup(repo => repo.GetById(id))
                             .ReturnsAsync(subscription);

            // Act
            var result = await _controller.GetById(id);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }
    }
}

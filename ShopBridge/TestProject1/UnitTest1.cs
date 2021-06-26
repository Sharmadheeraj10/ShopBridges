using Moq;
using System;
using System.Net;
using WebApp.Controllers;
using WebApp.Services;
using Xunit;

namespace TestProject1
{
    public class UnitTest1
    {
       
        [Fact]
        public void TestCase3()
        {
            var repositoryMock = new Mock<IInventoryService>();
            var Experience = new Mock<IExceptionService>();
            InventoryAPIController IAPI = new InventoryAPIController(repositoryMock.Object, Experience.Object);
           
            Assert.NotEqual("Error Encountered", IAPI.Get().ToString());
        }
        [Theory]
        [InlineData(1)]
        public void TestCase4(int Id)
        {
            var repositoryMock = new Mock<IInventoryService>();
            var Experience = new Mock<IExceptionService>();
            InventoryAPIController IAPI = new InventoryAPIController(repositoryMock.Object, Experience.Object);

            Assert.NotEqual("Error Encountered", IAPI.Get(Id).ToString());
        }
        

    }
}

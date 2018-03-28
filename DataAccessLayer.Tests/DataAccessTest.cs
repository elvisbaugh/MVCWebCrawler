using System;
using NUnit.Framework;
using Moq;
using DataAccessLayer.Interface;
using System.Net;

namespace DataAccessLayer.Tests
{
    public class DataAccessTest
    {
        [TestCase("https://hirespace.com", 200, TestName = "Make request to url to get 200 StatusCode")]
        public void Make_Request_For_OK_StatusCode(string url, HttpStatusCode expectedStatus)
        {
            //Arrange
            var mockUrl = new Mock<IWebSiteAddress>();
            mockUrl.Setup(x => x.Url()).Returns(url);

            //Act
            var getResponse = new FetchWebsite(mockUrl.Object);

            //Assert
            Assert.AreEqual(expectedStatus, getResponse.StatusCode());

        }

        [TestCase("https://hirespace.com", TestName = "Request to get back a list of urls")]
        public void Check_If_Start_Urls_Return(string url)
        {
            //Arrange
            var mockUrl = new Mock<IWebSiteAddress>();
            mockUrl.Setup(x => x.Url()).Returns(url);

            //Act
            var getResponse = new WebLinks(mockUrl.Object);

            //Assert
            Assert.IsNotEmpty(getResponse.ReturnStartUrls());
        }
    }
}

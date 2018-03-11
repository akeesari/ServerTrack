using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prodapt.ServerTrack.Api.Controllers;
using Prodapt.ServerTrack.Api.DataContract;
using System.Net;
using System.Net.Http;
using System.Web.Http;
namespace Prodapt.ServerTrack.Api.Tests.Controllers
{
    [TestClass]
    public class ServerTrackControllerTest
    {
        [TestMethod]
        public void InsertServerLoad_Test()
        {
            // Arrange
            var controller = new ServerTrackController();
            var request = new InsertServerLoadRequest
            {
                ServerName = "PDS1",
                CpuLoad = 80,
                RamLoad = 90,
            };
            // Act
          var response =  controller.InsertServerLoad(request);

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(response.Result.StatusCode ,System.Net.HttpStatusCode.Created);

        }
    }
}

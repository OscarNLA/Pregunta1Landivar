using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pr1LandivarAPI.Controllers;
using Pr1LandivarAPI.Models;

namespace UnitTestPregunta1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodGet()
        {
            //Arrange
            LandivarsController landivarController = new LandivarsController();

            //Act
            var Resultado = landivarController.GetLandivars();

            //Assert
            Assert.IsNotNull(Resultado);
        }

        [TestMethod]
        public void TestMethodPost()
        {
            //Arrange
            LandivarsController landivarController = new LandivarsController();
            Landivar Esperado = new Landivar()
            {
                LandivarID = 1,
                FriendofLandivar = "Pedro",
                Place = Places.Santa_Cruz,
                Email = "pedro@hotmail.com",
                Birthdate = DateTime.Today
            };

            //Act
            var Resultado = landivarController.PostLandivar(Esperado);
            var creado = Resultado as CreatedAtRouteNegotiatedContentResult<Landivar>;

            //Assert
            Assert.IsNotNull(creado);
            Assert.AreEqual("DefaultApi", creado.RouteName);
            Assert.AreEqual(Esperado.FriendofLandivar, creado.Content.FriendofLandivar);
        }

        [TestMethod]
        public void TestMethodPut()
        {
            //Arrange
            LandivarsController landivarController = new LandivarsController();
            Landivar landivar = new Landivar()
            {
                LandivarID = 1,
                FriendofLandivar = "Victor",
                Place = Places.Santa_Cruz,
                Email = "victor@hotmail.com",
                Birthdate = DateTime.Today
            };

            //Act
            IHttpActionResult actionResultPost = landivarController.PostLandivar(landivar);
            var result = landivarController.PutLandivar(landivar.LandivarID, landivar) as StatusCodeResult;


            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }

        [TestMethod]
        public void TestMethodDelete()
        {
            //Arrange
            LandivarsController landivarController = new LandivarsController();
            Landivar landivar = new Landivar()
            {
                LandivarID = 1,
                FriendofLandivar = "Enrique",
                Place = Places.Santa_Cruz,
                Email = "enrique@hotmail.com",
                Birthdate = DateTime.Today
            };

            //Act
            IHttpActionResult actionResultPost = landivarController.PostLandivar(landivar);
            IHttpActionResult actionResultDelete = landivarController.DeleteLandivar(landivar.LandivarID);

            //Assert
            Assert.IsInstanceOfType(actionResultDelete, typeof(OkNegotiatedContentResult<Landivar>));
        }
    }
}
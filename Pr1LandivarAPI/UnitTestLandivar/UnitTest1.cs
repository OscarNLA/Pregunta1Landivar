using System;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pr1LandivarAPI.Controllers;
using Pr1LandivarAPI.Models;

namespace UnitTestLandivar
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodGet()
        {
            //arrange
            LandivarsController landivarsController = new LandivarsController();
            //act
            var Resultado = landivarsController.GetLandivars();
            //assert
            Assert.IsNotNull(Resultado);

        }
        [TestMethod]
        public void TestMethodPost()
        {
            //arrange
            LandivarsController landivarsController = new LandivarsController();
            Landivar Esperado = new Landivar()
            {
                LandivarID = 1,
                FriendofLandivar = "Oscar Landivar",
                Place = Places.Santa_Cruz,
                Email = "oscarnlandivara@gmail.com",
                Birthdate = DateTime.Now

            };
            //act
            var Resultado = landivarsController.PostLandivar(Esperado);
            var creado = Resultado as CreatedAtRouteNegotiatedContentResult<Landivar>;

            //assert
            Assert.IsNotNull(creado);
            Assert.AreEqual("DefaultApi", creado.RouteName);
            Assert.IsNotNull(creado.RouteValues["id"]);

        }

    }
}

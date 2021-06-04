using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using VxTel.App.Controllers;
using VxTel.Application.Interfaces;
using VxTel.Entities.Entities;
using Xunit;

namespace VxTel.Test
{
    public class PlanoControllerTest
    {
        [Fact]
        public async Task List_Return_Product_Result()
        {
            var mockService = new Mock<IPlanoService>();
            mockService.Setup(s => s.List())
                .ReturnsAsync((List<Plano>)null);

            var controller = new PlanosController(mockService.Object);

            var result = await controller.Get();

            Assert.IsType<OkObjectResult>(result.Result);

        }

        [Fact]
        public async Task GetEntityById_Return_Product_Result()
        {
            var mockService = new Mock<IPlanoService>();
            mockService.Setup(s => s.GetEntityById(It.IsAny<int>()))
                .ReturnsAsync((Plano)null);

            var controller = new PlanosController(mockService.Object);

            var result = await controller.Get();

            Assert.IsType<OkObjectResult>(result.Result);

        }

        [Fact]
        public async Task Add_Product()
        {
            var plano = new Plano();
            var mockService = new Mock<IPlanoService>();
            mockService.Setup(s => s.Add(plano));

            var controller = new PlanosController(mockService.Object);

            var result = controller.Post(plano);

            Assert.IsType<OkObjectResult>(result);

        }

        [Fact]
        public async Task Update_Product()
        {
            var plano = new Plano();
            var mockService = new Mock<IPlanoService>();
            mockService.Setup(s => s.Update(plano));

            var controller = new PlanosController(mockService.Object);

            var result = controller.Put(plano.Id, plano);

            Assert.IsType<OkObjectResult>(result);

        }

        [Fact]
        public async Task Delete_Product()
        {
            var mockService = new Mock<IPlanoService>();
            mockService.Setup(s => s.Delete(1));

            var controller = new PlanosController(mockService.Object);

            var result = controller.Delete(1);

            Assert.IsType<OkResult>(result);

        }
    }
}

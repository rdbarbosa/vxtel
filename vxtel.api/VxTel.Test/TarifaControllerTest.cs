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
    public class TarifaControllerTest
    {
        [Fact]
        public async Task List_Return_Product_Result()
        {
            var mockService = new Mock<ITarifaService>();
            mockService.Setup(s => s.List())
                .ReturnsAsync((List<Tarifa>)null);

            var controller = new TarifasController(mockService.Object);

            var result = await controller.Get();

            Assert.IsType<OkObjectResult>(result.Result);

        }

        [Fact]
        public async Task GetEntityById_Return_Product_Result()
        {
            var mockService = new Mock<ITarifaService>();
            mockService.Setup(s => s.GetEntityById(It.IsAny<int>()))
                .ReturnsAsync((Tarifa)null);

            var controller = new TarifasController(mockService.Object);

            var result = await controller.Get();

            Assert.IsType<OkObjectResult>(result.Result);

        }

        [Fact]
        public async Task Add_Product()
        {
            var tarifa = new Tarifa();
            var mockService = new Mock<ITarifaService>();
            mockService.Setup(s => s.Add(tarifa));

            var controller = new TarifasController(mockService.Object);

            var result = controller.Post(tarifa);

            Assert.IsType<OkObjectResult>(result);

        }

        [Fact]
        public async Task Update_Product()
        {
            var tarifa = new Tarifa();
            var mockService = new Mock<ITarifaService>();
            mockService.Setup(s => s.Update(tarifa));

            var controller = new TarifasController(mockService.Object);

            var result = controller.Put(tarifa.Id, tarifa);

            Assert.IsType<OkObjectResult>(result);

        }

        [Fact]
        public async Task Delete_Product()
        {
            var mockService = new Mock<ITarifaService>();
            mockService.Setup(s => s.Delete(1));

            var controller = new TarifasController(mockService.Object);

            var result = controller.Delete(1);

            Assert.IsType<OkResult>(result);

        }
    }
}

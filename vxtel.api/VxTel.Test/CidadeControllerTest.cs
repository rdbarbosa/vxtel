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
    public class CidadeControllerTest
    {
        [Fact]
        public async Task List_Return_Product_Result()
        {
            var mockService = new Mock<ICidadeService>();
            mockService.Setup(s => s.List())
                .ReturnsAsync((List<Cidade>)null);

            var controller = new CidadesController(mockService.Object);

            var result = await controller.Get();

            Assert.IsType<OkObjectResult>(result.Result);

        }

        [Fact]
        public async Task GetEntityById_Return_Product_Result()
        {
            var mockService = new Mock<ICidadeService>();
            mockService.Setup(s => s.GetEntityById(It.IsAny<int>()))
                .ReturnsAsync((Cidade)null);

            var controller = new CidadesController(mockService.Object);

            var result = await controller.Get();

            Assert.IsType<OkObjectResult>(result.Result);

        }

        [Fact]
        public async Task Add_Product()
        {
            var cidade = new Cidade();
            var mockService = new Mock<ICidadeService>();
            mockService.Setup(s => s.Add(cidade));

            var controller = new CidadesController(mockService.Object);

            var result = controller.Post(cidade);

            Assert.IsType<OkObjectResult>(result);

        }

        [Fact]
        public async Task Update_Product()
        {
            var cidade = new Cidade();
            var mockService = new Mock<ICidadeService>();
            mockService.Setup(s => s.Update(cidade));

            var controller = new CidadesController(mockService.Object);

            var result = controller.Put(cidade.Id, cidade);

            Assert.IsType<OkObjectResult>(result);

        }

        [Fact]
        public async Task Delete_Product()
        {
            var mockService = new Mock<ICidadeService>();
            mockService.Setup(s => s.Delete(1));

            var controller = new CidadesController(mockService.Object);

            var result = controller.Delete(1);

            Assert.IsType<OkResult>(result);

        }
    }
}

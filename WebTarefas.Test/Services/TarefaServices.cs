using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTarefas.Domain.Models;
using WebTarefas.Infra.Repositories;
using WebTarefas.Services.TarefaServices;

namespace WebTarefas.Test.Services
{
    public class TarefaServicesTests
    {
        [Fact]
        public async Task AddAsync_TarefaNomeInvalido()
        {
            var mockRepository = new Mock<ITarefaRepository>();
            var service = new TarefaService(mockRepository.Object);

            var tarefa = new Tarefa
            {
                Name = "", // Nome inválido
                IsComplete = false,
                CreatedAt = DateTime.Now
            };

            await Assert.ThrowsAsync<ArgumentException>(() => service.AddAsync(tarefa));
        }

        [Fact]
        public async Task AddAsync_TarefaNomeNulo()
        {
            var mockRepository = new Mock<ITarefaRepository>();
            var service = new TarefaService(mockRepository.Object);

            var tarefa = new Tarefa
            {
                Name = null, // Nome nulo
                IsComplete = false,
                CreatedAt = DateTime.Now
            };

            await Assert.ThrowsAsync<ArgumentException>(() => service.AddAsync(tarefa));
        }

        [Fact]
        public async Task AddAsync_TarefaNomeMaiorQuePermitido()
        {
            var mockRepository = new Mock<ITarefaRepository>();
            var service = new TarefaService(mockRepository.Object);

            var tarefa = new Tarefa
            {
                Name = @"222222222222222222222222223
                        333333333333333333344444444444444444
                        333333333333333333344444444444444444
                        333333333333333333344444444444444444
                        4444444444442333333333333333333333333333333
                        33333333333333334222222222222", // Nome muito grande
                IsComplete = false,
                CreatedAt = DateTime.Now
            };

            await Assert.ThrowsAsync<ArgumentException>(() => service.AddAsync(tarefa));
        }

        [Fact]
        public async Task AddAsync_TarefaValida()
        {
            var mockRepository = new Mock<ITarefaRepository>();
            var service = new TarefaService(mockRepository.Object);

            var tarefa = new Tarefa
            {
                Name = "Tarefa válida",
                IsComplete = false,
                CreatedAt = DateTime.Now
            };

            await service.AddAsync(tarefa);

            mockRepository.Verify(r => r.AddAsync(It.IsAny<Tarefa>()), Times.Once);
        }
    }
}

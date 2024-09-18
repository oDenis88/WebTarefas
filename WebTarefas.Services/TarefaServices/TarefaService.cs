using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTarefas.Domain.Models;
using WebTarefas.Infra.Repositories;

namespace WebTarefas.Services.TarefaServices
{
    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository _repository;

        public TarefaService(ITarefaRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Tarefa>> GetAllAsync() => _repository.GetAllAsync();

        public Task<Tarefa> GetByIdAsync(int id) => _repository.GetByIdAsync(id);

        public async Task AddAsync(Tarefa tarefa)
        {
            if (string.IsNullOrEmpty(tarefa.Name) || tarefa.Name.Length > 100)
                throw new ArgumentException("Nome da tarefa inválido.");

            await _repository.AddAsync(tarefa);

        }

        public async Task UpdateAsync(Tarefa tarefa)
        {
            if (string.IsNullOrEmpty(tarefa.Name) || tarefa.Name.Length > 100)
                throw new ArgumentException("Nome da tarefa inválido.");

            await _repository.UpdateAsync(tarefa);
        }

        public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
    }
}

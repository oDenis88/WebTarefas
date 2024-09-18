using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTarefas.Domain.Models;

namespace WebTarefas.Infra.Repositories
{
    public interface ITarefaRepository
    {
        Task<IEnumerable<Tarefa>> GetAllAsync();
        Task<Tarefa> GetByIdAsync(int id);
        Task AddAsync(Tarefa tarefa);
        Task UpdateAsync(Tarefa tarefa);
        Task DeleteAsync(int id);
    }
}

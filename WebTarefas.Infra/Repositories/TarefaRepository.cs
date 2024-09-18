using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTarefas.Domain.Models;
using WebTarefas.Infra.Context;

namespace WebTarefas.Infra.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly AppDbContext _context;

        public TarefaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tarefa>> GetAllAsync()
        {
            return await _context.Tarefas.ToListAsync();
        }

        public async Task<Tarefa> GetByIdAsync(int id)
        {
            return await _context.Tarefas.FindAsync(id);
        }

        public async Task AddAsync(Tarefa tarefa)
        {
            _context.Tarefas.Add(tarefa);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Tarefa tarefa)
        {
            _context.Entry(tarefa).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _context.Tarefas.FindAsync(id);
            if (item != null)
            {
                _context.Tarefas.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}

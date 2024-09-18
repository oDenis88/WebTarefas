using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTarefas.Domain.Models
{
    public class Tarefa : BaseEntity
    {
        [Required(ErrorMessage = "O nome da tarefa é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome da tarefa não pode ter mais de 100 caracteres.")]
        public string? Name { get; set; } 

        public bool IsComplete { get; set; }
    }
}

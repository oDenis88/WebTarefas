using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTarefas.Domain.Models;

namespace WebTarefas.Test.Domain
{
    public class TarefaTests
    {
        [Fact]
        public void Tarefa_NomeValido()
        {
            var tarefa = new Tarefa
            {
                Name = "Tarefa Teste",
                IsComplete = false,
                CreatedAt = DateTime.Now
            };

            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(tarefa);
            bool isValid = Validator.TryValidateObject(tarefa, validationContext, validationResults, true);

            Assert.True(isValid);
        }

        [Fact]
        public void Tarefa_NomeInvalido()
        {
            var tarefa = new Tarefa
            {
                Name = "", // Nome inválido
                IsComplete = false,
                CreatedAt = DateTime.Now
            };

            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(tarefa);
            bool isValid = Validator.TryValidateObject(tarefa, validationContext, validationResults, true);

            Assert.False(isValid);
            Assert.Contains(validationResults, v => v.ErrorMessage.Contains("O nome da tarefa é obrigatório."));
        }

        [Fact]
        public void Tarefa_NomeNulo()
        {
            var tarefa = new Tarefa
            {
                Name = null, // Nome nulo
                IsComplete = false,
                CreatedAt = DateTime.Now
            };

            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(tarefa);
            bool isValid = Validator.TryValidateObject(tarefa, validationContext, validationResults, true);

            Assert.False(isValid);
            Assert.Contains(validationResults, v => v.ErrorMessage.Contains("O nome da tarefa é obrigatório."));
        }

        [Fact]
        public void Tarefa_NomeMuitoGrande()
        {
            var tarefa = new Tarefa
            {
                Name = @"AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
                        BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB
                        CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC
                        DDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD
                        EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE
                        FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF
                        HHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH
                        IIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII", // Nome que excede o limite

                IsComplete = false,
                CreatedAt = DateTime.Now
            };

            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(tarefa);
            bool isValid = Validator.TryValidateObject(tarefa, validationContext, validationResults, true);

            Assert.False(isValid);
            Assert.Contains(validationResults, v => v.ErrorMessage.Contains("O nome da tarefa não pode ter mais de 100 caracteres."));
        }
    }
}


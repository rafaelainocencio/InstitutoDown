using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public DateTime DataDeNascimento { get; set; }

        public virtual List<Candidatura> Candidaturas { get; set; }

        public virtual List<Matricula> Matriculas { get; set; }
    }
}

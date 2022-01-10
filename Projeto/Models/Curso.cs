using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Models
{
    public class Curso
    {
           [Key]
            public int Id { get; set; }
            public string Nome { get; set; }
            public string Descricao { get; set; }
            public string Imagem { get; set; }

        public virtual List<Matricula> Matriculas { get; set; }
        public virtual List<Candidatura> Candidaturas { get; set; }
    }
    }

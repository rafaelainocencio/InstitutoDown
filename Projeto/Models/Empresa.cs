using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Models
{
    public class Empresa
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Ramo { get; set; }
        public Boolean Parceira { get; set; }

        public virtual List<Candidatura> Candidaturas { get; set; }
        public virtual List<Vaga> Vagas { get; set; }
    }
}

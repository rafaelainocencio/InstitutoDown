using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Models
{
    public class Vaga
    {
        [Key]
        public int Id { get; set; }
        public string Cargo { get; set; }
        public decimal Salario { get; set; }
        public string Descricao { get; set; }

        [ForeignKey("Empresa")]
        public int IdEmpresa { get; set; }
        public virtual Empresa Empresa { get; set; }

        public string Beneficios { get; set; }
        public string CargaHoraria { get; set; }

        public virtual List<Candidatura> Candidaturas { get; set; }
    }
}

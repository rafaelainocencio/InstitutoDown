using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Models
{
    public class Candidatura
    {
        [Key]
        public int Id{ get; set; }

        [ForeignKey("Empresa")]
        public int IdEmpresa { get; set; }
        public virtual Empresa Empresa { get; set; }

        [ForeignKey("Curso")]
        public int IdCurso { get; set; }
        public virtual Curso Curso { get; set; }

        [ForeignKey("Vaga")]
        public int IdVaga { get; set; }
        public virtual Vaga Vaga { get; set; }

        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }
        public virtual Usuario Usuario { get; set; }
        
    }
}

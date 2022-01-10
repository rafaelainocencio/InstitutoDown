using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Models
{
    public class Matricula
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Curso")]
        public int IdCurso { get; set; }
        public virtual Curso Curso { get; set; }

        [ForeignKey("Usuario")]
        public int IdUsuario { get; set; }
        public virtual Usuario Usuario { get; set; }

    }
}

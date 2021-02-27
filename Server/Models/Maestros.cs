using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppNetS22021.Server.Models
{
    public class Maestros
    {
        [Key]
        public int MaestroId { get; set; }
        public string Nombre { get; set; }

        [InverseProperty("onLineMaestros")]
        public ICollection<Cursos> onLineCursos { get; set; }

        [InverseProperty("presencialMaestros")]
        public ICollection<Cursos>  presencialCursos { get; set; }

    }
}

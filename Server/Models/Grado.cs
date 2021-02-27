﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppNetS22021.Server.Models
{
    public class Grado
    {
        [Key]
        public int GradoId { get; set; }
        public string GradoNombre { get; set; }
        public string Seccion { get; set; }
    }
}

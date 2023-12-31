﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.EntidadesDeNegocio
{
    public class Colaborador
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Proyecto")]
        [ForeignKey("Proyecto")]
        public int IdProyecto { get; set; }

        [Display(Name = "Usuario")]
        [ForeignKey("Usuario")]
        [Required(ErrorMessage = "El ID de Usuario es obligatorio")]
        public int IdUsuario { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "El Estado del colaborador es obligatorio")]
        public byte Estado { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }

        [ValidateNever]
        public Proyecto Proyecto { get; set; }

        [ValidateNever]
        public Usuario Usuario { get; set; }

        [ValidateNever]
        public List<Tarea> Tarea { get; set; }
    }
    public enum Estatus_Colaborador
    {
        ACTIVO = 1,
        INACTIVO = 2
    }
}

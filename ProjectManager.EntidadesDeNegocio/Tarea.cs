using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.EntidadesDeNegocio
{
    public class Tarea
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Proyecto")]
        [ForeignKey("Proyecto")]
        public int IdProyecto { get; set; }
       


        [Display(Name = "Colavorador")]
        [ForeignKey("Colaborador")]
        [Required(ErrorMessage = "El ID de Colaborador es Obligatorio")]
        public int IdColaborador { get; set; }
       


        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El Nombre del proyecto es Obligatorio")]
        public string Nombre { get; set; }

        [Display(Name = "Descriptión")]
        [Required(ErrorMessage = "La Descripción es Obligatorio")]
        public string Descripcion { get; set; }

        [Display(Name = "Priodidad")]
        [Required(ErrorMessage = "La Prioridad de la tarea es obligatoria")]
        public int Prioridad { get; set; }

        [Display(Name = "Esfuerzo")]
        [Required(ErrorMessage = "El Esfuerzo de la tarea es obligatorio")]
        public int Esfuerzo { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "El Estado de la tarea es obligatorio")]
        public byte Estado { get; set; }
        [NotMapped]
        public int Top_Aux { get; set; }

        [ValidateNever]
        public Proyecto Proyecto { get; set; }
        public Colaborador Colaborador { get; set; }
    }
    public enum Estado_Tarea
    {
        ACTIVO = 1,
        INACTIVO = 0
    }
}


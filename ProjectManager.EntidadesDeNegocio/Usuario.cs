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
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Rol")]
        [Required(ErrorMessage = "El Rol es obligatorio")]
        [Display(Name = "Rol")]
        public int IdRol { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(100, ErrorMessage = "El largo maximo es 100 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es requerido")]
        [MaxLength(100, ErrorMessage = "El largo maximo es 100 caracteres")]
        public string Apellido { get; set; }

        public DateTime FechaRegistro { get; set; }


        [Required(ErrorMessage = "El Login es requerido")]
        [MaxLength(150, ErrorMessage = "El largo maximo es 150 caracteres")]
        public string Login { get; set; }


        [Required(ErrorMessage = "El Password es requerido")]
        [MaxLength(150, ErrorMessage = "El largo maximo es 150 caracteres")]
        public string Password { get; set; }


        public byte Estado { get; set; }

        //propiedad de navegación
      

        [NotMapped]
        public int Top_Aux { get; set; } //propiedad auxiliar para tarer un número específico
                                         //de registros en las consultas.

        [NotMapped]
        [Required(ErrorMessage = "Confirmar el password")]
        [StringLength(50, ErrorMessage = "Password debe estar entre 6 a 50 caracteres", MinimumLength = 6)]
        [Compare("Password", ErrorMessage = "Password y confirmar password deben de ser iguales")]
        [Display(Name = "Confirmar password")]
        public string confirmPassword_aux { get; set; }

        [ValidateNever]
        public Rol Rol { get; set; }

        [ValidateNever]
        public Proyecto Proyecto { get; set; }

        [ValidateNever]
        public List<Colaborador> Colaborador { get; set; }
    }

    public enum Estatus_Usuario
    {
        ACTIVO = 1,
        INACTIVO = 2
    }
}


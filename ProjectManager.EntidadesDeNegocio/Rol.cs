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
    public  class Rol
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "Nombre es Obligatorio")]
        [StringLength(100, ErrorMessage = "Maximo 100 Caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Estado es requerido")]
        public byte Estado { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }

        [ValidateNever]
        public List<Usuario> Usuario { get; set; }

    }

    public enum Estatus_Rol
    {
        ACTIVO = 1,
        INACTIVO = 2
    }
}

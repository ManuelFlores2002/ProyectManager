using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.EntidadesDeNegocio
{
    public class Proyecto
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Usuario")]
        public int IdAdministrador { get; set; }
        public Usuario Usuario { get; set; }

        [Required(ErrorMessage = "Nombre es Obligatorio")]
        [StringLength(150, ErrorMessage = "Maximo 150 Caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Descripcion es Obligatorio")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Estado es requerido")]
        public byte Estado { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }
    }
    public enum Estatus_Proyecto
    {
        ACTIVO = 1,
        INACTIVO = 2
    }
}

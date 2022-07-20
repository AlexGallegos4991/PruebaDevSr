using System.ComponentModel.DataAnnotations;

namespace PracticaBrive.Models
{
    public class Sucursal
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Nombre Obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Ciudad Obligatorio")]
        public string Ciudad { get; set; }

        [Required(ErrorMessage = "Estado Obligatorio")]
        public string Estado { get; set; }
    }
}

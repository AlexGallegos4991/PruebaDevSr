using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticaBrive.Models
{
    public class Producto
    {
        [Key]
        public int CodigoDeBarras { get; set; }

        [Required(ErrorMessage = "Nombre Obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Cantidad Obligatorio")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "Precio Obligatorio")]
        public decimal Precio { get; set; }

        [Required]
        public int idSucursal { get; set; }
        [ForeignKey("idSucursal")]
        public Sucursal Sucursal { get; set; }
    }
}

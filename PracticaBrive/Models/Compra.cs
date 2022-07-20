using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticaBrive.Models
{
    public class Compra
    {
        [Key]
        public int Id { get; set; }

        public DateTime FechaDeCompra { get; set; }

        [Required(ErrorMessage ="Nombre Obligatorio")]
        public string Nombre { get; set; }

        [Required]
        public int idProducto { get; set; }
        [ForeignKey("idProducto")]
        public Producto Producto { get; set; }
    }
}

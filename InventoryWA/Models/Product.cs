using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace InventoryWA.Models
{
    public class Product
    {
        [Key, Column(Order = 0)]
        public int Id { get; set; }

        [Key, Column(Order = 1)]
        public int Categie_Id { get; set; }

        [MaxLength(10, ErrorMessage = "No se permiten mas de 10 caracteres para el código de producto."), Required(ErrorMessage = "Campo código es requerido."), Index(IsUnique =true)]
        public string Codigo { get; set; }
        
        [Required(ErrorMessage = "Debe de ingresar una descripción.")]
        public string Descripcion { get; set; }
        public string Detalle { get; set; }

        //Including master tables Foreign Key
        [ForeignKey("Categie_Id")]
        public virtual Categorie Categorie { get; set; }
    }
}

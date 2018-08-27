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

        [MaxLength(10, ErrorMessage = "Not allow more than 10 characters."), Required(ErrorMessage = "field codigo is required."), Index(IsUnique =true)]
        public string Codigo { get; set; }
        
        public string Descripcion { get; set; }
        public string Detalle { get; set; }

        //including master tables Foreign Key
        [ForeignKey("Categie_Id")]
        public virtual Categorie Categorie { get; set; }
    }
}

using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryWA.Models
{
    public class Categorie
    {
        [Key, Column(Order = 0), DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("ID"), Required(ErrorMessage = "This value is required")]
        public int Id { get; set; }

        [DisplayName("Codigo"), Index("CodigoCategoriaIndex", IsUnique = true), Column(Order = 1)]
        [StringLength(5, MinimumLength = 3, ErrorMessage = "El codigo debe de ser entre 3 y 5 caracteres."), Required(ErrorMessage = "Ingrese codigo")]
        public string Code { get; set; }

        [DisplayName("Nombre"), Index("NombreCategoriaIndex", IsUnique = true), Column(Order = 2)]
        [StringLength(35, MinimumLength = 2, ErrorMessage = "Nombre de la categoria debe ser entre 6 y 15 caracteres"), Required(ErrorMessage = "Ingrese nombre de categoria")]
        public string Nombre { get; set; }
        
        [Column(Order = 3)]
        public int Miselaneos_Id { get; set; }

        //Including master tables Foreign Key
        [ForeignKey("Miselaneos_Id")]
        public virtual Miscelaneo Miscelaneo { get; set; }
        

        //Icluding foreign table
        public virtual ICollection<Product> Product { get; set; }

        

    }
}
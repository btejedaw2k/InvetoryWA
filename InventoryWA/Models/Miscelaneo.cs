using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryWA.Models
{
    public class Miscelaneo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "ID"), Required(ErrorMessage = "This value is required")]
        public int Id { get; set; }

        [DisplayName("Codigo"), Index("CodigoMiscelaneoIndex", IsUnique = true)]
        [StringLength(5, MinimumLength = 3, ErrorMessage = "El codigo debe de ser entre 3 y 5 caracteres."), Required(ErrorMessage = "Ingrese codigo")]
        public string Codigo { get; set; }

        [DisplayName("Nombre"), Index("NombreMiscelaneIndex", IsUnique = true)]
        [StringLength(35, MinimumLength = 2, ErrorMessage = "Nombre de la categoria debe ser entre 6 y 15 caracteres"), Required(ErrorMessage = "Ingrese nombre de categoria")]
        public string Descripcion { get; set; }

        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 9999999999999999.99)]
        public decimal Value { get; set; }

        // Include foreign table
        public virtual ICollection<Categorie> Categories { get; set; }
    }
}
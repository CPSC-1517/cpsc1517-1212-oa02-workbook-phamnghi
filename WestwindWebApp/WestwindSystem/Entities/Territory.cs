#nullable disable
using System.ComponentModel.DataAnnotations;    // for [Key]
using System.ComponentModel.DataAnnotations.Schema; // for [Table]
namespace WestwindSystem.Entities
{
    [Table("Territories")]
    public class Territory
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage ="TerritoryID is required")]
        [StringLength(maximumLength:20, ErrorMessage ="")]
        public string TerritoryID { get; set; }
        public string TerritoryDescription { get; set; }
        public int RegionID { get; set; }
    }
}
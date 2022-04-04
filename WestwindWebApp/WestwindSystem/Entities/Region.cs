using System.ComponentModel.DataAnnotations.Schema; //for table
using System.ComponentModel.DataAnnotations; //for Key, Required, StringLength

namespace WestwindSystem.Entities
{
    [Table("Regions")]
    public class Region
    {
        [Key]
        public int RegionID { get; set; } 

        [Required(ErrorMessage = "Region Description is required")]
        [StringLength(50, ErrorMessage = " Region Description is limited 50 characters")]

        public string RegionDescription { get; set; }
    }
}

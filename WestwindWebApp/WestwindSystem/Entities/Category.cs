using System.ComponentModel.DataAnnotations.Schema; //[Table], [Column]
using System.ComponentModel.DataAnnotations; //[Key], [Required], [StringLength]


namespace WestwindSystem.Entities
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage ="CategoryName is required")]
        [StringLength(15, ErrorMessage ="CategoryName must be 15 or less characters")]

        //[Column("CategoryName")]
        public string CategoryName { get; set; } = null!;

        [Column(TypeName = "ntext")]
        public string? Description { get; set; }
    }
}

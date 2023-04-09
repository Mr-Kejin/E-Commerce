using System.ComponentModel.DataAnnotations;

namespace GoodWillStones.Models
{
    public class Category
    {
        [Key]
        public int Category_ID { get; set; }
        [Required]
        public string  Name { get; set; }
        public int DisplayOrder { get; set; }
    }
}

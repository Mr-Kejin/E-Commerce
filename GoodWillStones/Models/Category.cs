using System.ComponentModel.DataAnnotations;

namespace GoodWillStones.Models
{
    public class Category
    {
        [Key]
        public int lCategory_ID { get; set; }
        [Required]
        public string  sDescription { get; set; }
        public int sDisplayOrder { get; set; }
    }
}

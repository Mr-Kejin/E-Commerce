using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GoodWillStones.Models
{
    public class Category
    {
        [Key]
        public int lCategory_ID { get; set; }
        [Required]
        [MaxLength(50)]
        [DisplayName("Name")]
        public string sDescription { get; set; }
        [DisplayName("Display Order")]
        [Range(1, 100)]
        public int sDisplayOrder { get; set; }
        //public DateTime dtCreated { get; set; } we must update the time when we have created it 

    }
}

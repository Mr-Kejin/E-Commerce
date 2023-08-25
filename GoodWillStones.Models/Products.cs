using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodWillStones.Models
{
    public class Products
    {
        [Key]
        public int Product_ID { get; set; }
        [Required]
        [DisplayName("Name")]
        public string? sProductName { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string? sDescription { get; set; }
        [Required]
        [Display(Name = "List Price")]
        [Range(1, 100000)]
        public Double ListPrice { get; set; }
        // need to add few image and category model


        // bellow is the configration for bulk buyers
        // cost will be resuded if someone is buying in bulk

        [Required]
        [Display(Name = " Price for 1-50")]
        [Range(1, 100000)]
        public Double Price { get; set; }

        [Required]
        [Display(Name = "Price for 50-100")]
        [Range(1, 100000)]
        public Double Price50 { get; set; }

        [Required]
        [Display(Name = "Price above 100")]
        [Range(1, 100000)]
        public Double ListPrice100 { get; set; }
    }
}

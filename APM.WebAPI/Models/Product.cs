using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APM.WebAPI.Models
{
    public class Product
    {
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ProductCode { get; set; }
        public int ProductId { get; set; }
        [Required(ErrorMessage ="Product Name is required",AllowEmptyStrings =false)]
        [MinLength(6,ErrorMessage="Product length Minimum length is 6 character")]
        [MaxLength(18, ErrorMessage = "Product length Maximum length is 18 character")]
        public string ProductName { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmFresh.Model
{
    public class Product
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Please Enter a value")]
        public string Name { get; set; }
        public string Slug { get; set; }
        [Required, MinLength(4, ErrorMessage = "Please Enter a value")]
        public string Description { get; set; }
        public string Count { get; set; }
        public long CategoryId { get; set; }
        public Category Category { get; set; }
        public string Image { get; set; }
    }
}

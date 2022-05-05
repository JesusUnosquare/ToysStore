using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TG_Model.Models
{
    public class Product
    {
        public int Id { get; set; }
        [MaxLength(length:50)]
        public string Name { get; set; }
        [MaxLength(length: 100)]
        public string Description { get; set; }
        [Range(minimum: 0, maximum: 100)]
        public int AgeRestriction { get; set; }
        [MaxLength(length: 50)]
        public string Company { get; set; }
        [Range(minimum:1, maximum:1000)]
        public decimal Price { get; set; }
        [MaxLength(length:300)]
        public string? ImageLink { get; set; }   
    }
}

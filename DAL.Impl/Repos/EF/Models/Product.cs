using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.Models;

namespace DAL.Impl.Repos.EF.Models
{
    internal class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ProductId { get; set; }
        public ClothingType Type { get; set; }
        public string ProductName { get; set; }

        [ForeignKey("Brand")]
        public Guid BrandId { get; set; }
        public Size Size { get; set; }

        public virtual Brand Brand { get; set; }
    }
}

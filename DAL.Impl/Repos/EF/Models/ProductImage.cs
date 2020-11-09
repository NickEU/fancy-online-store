using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Impl.Repos.EF.Models
{
    internal class ProductImage
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ProductImageId { get; set; }
        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
        // TODO: this sucks, better off storing SHA256 in DB 
        // TODO: and storing images in a folder on server or on CDN
        public byte[] Image { get; set; }

        public virtual Product Product { get; set; }
    }
}

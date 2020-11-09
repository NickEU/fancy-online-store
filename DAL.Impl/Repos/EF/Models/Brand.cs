using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Impl.Repos.EF.Models
{
    internal class Brand
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid BrandId { get; set; }

        public string BrandName { get; set; }
        public string HQLocation { get; set; }
        public byte[] Image { get; set; }
    }
}
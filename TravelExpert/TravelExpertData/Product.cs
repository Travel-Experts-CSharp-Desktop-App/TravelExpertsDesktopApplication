using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TravelExpertData
{
    public partial class Product
    {
        public Product()
        {
            BookingProduct = new HashSet<BookingProduct>();
            ProductSupplier = new HashSet<ProductSupplier>();
        }

        [Key]
        public int ProductId { get; set; }
        [Required]
        [StringLength(50)]
        public string ProdName { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal ProdFee { get; set; }

        [InverseProperty("Product")]
        public virtual ICollection<BookingProduct> BookingProduct { get; set; }
        [InverseProperty("Product")]
        public virtual ICollection<ProductSupplier> ProductSupplier { get; set; }
    }
}

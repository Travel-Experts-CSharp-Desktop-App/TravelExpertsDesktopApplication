using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TravelExpertData
{
    public partial class ProductSupplier
    {
        [Key]
        public int ProductSupplierId { get; set; }
        [Column("ProductID")]
        public int ProductId { get; set; }
        [Column("SupplierID")]
        public int SupplierId { get; set; }

        [ForeignKey(nameof(ProductId))]
        [InverseProperty("ProductSupplier")]
        public virtual Product Product { get; set; }
        [ForeignKey(nameof(SupplierId))]
        [InverseProperty("ProductSupplier")]
        public virtual Supplier Supplier { get; set; }
    }
}

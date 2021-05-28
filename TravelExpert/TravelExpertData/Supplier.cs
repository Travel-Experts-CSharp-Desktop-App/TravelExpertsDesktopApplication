using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TravelExpertData
{
    public partial class Supplier
    {
        public Supplier()
        {
            ProductSupplier = new HashSet<ProductSupplier>();
        }

        [Key]
        public int SupplierId { get; set; }
        [StringLength(255)]
        public string SupName { get; set; }
        [StringLength(255)]
        public string SupAdress { get; set; }
        [StringLength(255)]
        public string SupCountry { get; set; }
        [StringLength(255)]
        public string SupCity { get; set; }
        [StringLength(255)]
        public string SupEmail { get; set; }
        [StringLength(50)]
        public string SupPhoneNumber { get; set; }

        [InverseProperty("Supplier")]
        public virtual ICollection<ProductSupplier> ProductSupplier { get; set; }
    }
}

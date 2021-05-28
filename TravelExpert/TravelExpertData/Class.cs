using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TravelExpertData
{
    public partial class Class
    {
        public Class()
        {
            Booking = new HashSet<Booking>();
        }

        [Key]
        [StringLength(5)]
        public string ClassId { get; set; }
        [Required]
        [StringLength(20)]
        public string ClassName { get; set; }
        [StringLength(50)]
        public string ClassDesc { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal? ClassFee { get; set; }

        [InverseProperty("Class")]
        public virtual ICollection<Booking> Booking { get; set; }
    }
}

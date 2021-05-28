using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TravelExpertData
{
    public partial class Booking
    {
        public Booking()
        {
            BookingProduct = new HashSet<BookingProduct>();
        }

        [Key]
        public int BookingId { get; set; }
        //[Column(TypeName = "datetime")]
        public DateTime? BookingDate { get; set; }
        public int? CustomerId { get; set; }
        public int? PackageId { get; set; }
        [Required]
        [StringLength(5)]
        public string ClassId { get; set; }

        [ForeignKey(nameof(ClassId))]
        [InverseProperty("Booking")]
        public virtual Class Class { get; set; }
        [ForeignKey(nameof(CustomerId))]
        [InverseProperty("Booking")]
        public virtual Customer Customer { get; set; }
        [ForeignKey(nameof(PackageId))]
        [InverseProperty("Booking")]
        public virtual Package Package { get; set; }
        [InverseProperty("Booking")]
        public virtual ICollection<BookingProduct> BookingProduct { get; set; }
    }
}

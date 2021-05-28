using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TravelExpertData
{
    public partial class BookingProduct
    {
     

        [Key]
        [Column("BPID")]
        public int Bpid { get; set; }
        [Column("ProductID")]
        public int ProductId { get; set; }
        [Column("BookingID")]
        public int BookingId { get; set; }

        public decimal FeeAmt { get; set; }

        [ForeignKey(nameof(BookingId))]
        [InverseProperty("BookingProduct")]
        public virtual Booking Booking { get; set; }
        [ForeignKey(nameof(ProductId))]
        [InverseProperty("BookingProduct")]
        public virtual Product Product { get; set; }
       
    }
}

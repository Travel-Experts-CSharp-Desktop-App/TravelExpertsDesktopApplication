using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TravelExpertData
{
    public partial class Agent
    {
        public Agent()
        {
            Customer = new HashSet<Customer>();
        }

        [Key]
        public int AgentId { get; set; }
        [StringLength(20)]
        public string AgtFirstName { get; set; }
        [StringLength(20)]
        public string AgtLastName { get; set; }
        [StringLength(20)]
        public string AgtBusPhone { get; set; }
        [StringLength(50)]
        public string AgtEmail { get; set; }
        [StringLength(20)]
        public string AgtPosition { get; set; }
        public int? AgencyId { get; set; }
        [StringLength(50)]
        public string AgentPassword { get; set; }

        [ForeignKey(nameof(AgencyId))]
        [InverseProperty("Agent")]
        public virtual Agency Agency { get; set; }
        [InverseProperty("Agent")]
        public virtual ICollection<Customer> Customer { get; set; }
    }
}

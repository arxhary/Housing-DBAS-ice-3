using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Housing.Models
{
    public partial class Ticket
    {
        public Ticket()
        {
            ResidentTickets = new HashSet<ResidentTicket>();
        }

        [Key]
        [Column("TicketID")]
        public int TicketId { get; set; }
        [Required]
        [StringLength(180)]
        public string Complaint { get; set; }

        [InverseProperty(nameof(ResidentTicket.Ticket))]
        public virtual ICollection<ResidentTicket> ResidentTickets { get; set; }
    }
}

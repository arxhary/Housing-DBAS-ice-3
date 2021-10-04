using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Housing.Models
{
    [Table("Resident_Ticket")]
    public partial class ResidentTicket
    {
        [Key]
        [Column("ResidentTicketID")]
        public int ResidentTicketId { get; set; }
        [Column("UnitID")]
        public int UnitId { get; set; }
        [Column("TicketID")]
        public int TicketId { get; set; }
        [StringLength(25)]
        public string TicketStatus { get; set; }

        [ForeignKey(nameof(TicketId))]
        [InverseProperty("ResidentTickets")]
        public virtual Ticket Ticket { get; set; }
        [ForeignKey(nameof(UnitId))]
        [InverseProperty(nameof(Resident.ResidentTickets))]
        public virtual Resident Unit { get; set; }
    }
}

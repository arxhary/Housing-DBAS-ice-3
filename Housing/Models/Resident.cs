using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Housing.Models
{
    [Table("Resident")]
    public partial class Resident
    {
        public Resident()
        {
            ResidentTickets = new HashSet<ResidentTicket>();
        }

        [Key]
        [Column("UnitID")]
        public int UnitId { get; set; }
        [Required]
        [StringLength(25)]
        public string Name { get; set; }
        [Required]
        [StringLength(25)]
        public string Surname { get; set; }
        [Required]
        [StringLength(50)]
        public string EmailAddress { get; set; }
        [Required]
        [StringLength(12)]
        public string CellNumber { get; set; }
        public int YearMovedIn { get; set; }

        [InverseProperty(nameof(ResidentTicket.Unit))]
        public virtual ICollection<ResidentTicket> ResidentTickets { get; set; }
    }
}

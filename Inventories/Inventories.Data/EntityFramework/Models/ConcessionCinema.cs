using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Inventories.Data.EntityFramework.Models
{
    public partial class ConcessionCinema
    {
        [Key]
        public int Id { get; set; }
        public int Hopk { get; set; }

        [ForeignKey(nameof(CinemaId))]
        public Cinema Cinema { get; set; }
        public int CinemaId { get; set; }

        public int SalesServerId { get; set; }
        public int Price { get; set; }

        [ForeignKey(nameof(StatusId))]
        public int StatusId { get; set; }
        public Status Status { get; set; }

        public int Stock { get; set; }
    }
}

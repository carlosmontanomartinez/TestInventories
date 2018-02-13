using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventories.Data.EntityFramework.Models
{
    public class PromotionPrice
    {
        [Key]
        public int Id { get; set; }
        public int Price { get; set; }

        [ForeignKey(nameof(ConsesionCinemaId))]
        public int ConsesionCinemaId { get; set; }
        public ConsessionCinema ConsesionCinema { get; set; }

        public DateTime StartDate
        {
            get;
            set;
        }

        public DateTime EndDate
        {
            get;
            set;
        }}
}

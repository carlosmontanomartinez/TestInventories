using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Inventories.Data.EntityFramework.Models
{
    public class Cinema
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int InternalId { get; set; }
        public string VistaId { get; set; }
        public string EndPoint { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Manager { get; set; }
        public bool IsActive { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public bool CheckAlcohol { get; set; }
        [NotMapped]
        public int CatalogTypeId { get; set; }
        [NotMapped]
        public int DeliveryTypeId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Inventories.Data.EntityFramework.Models
{
    public class Status
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcCarStore.Models
{
    public class Cart
    {
        [Key]
        public int RecordID { get; set; }
        public string CartId { get; set; }
        public int CarID { get; set; }
        public int Count { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual Car Car { get; set; }

    }
}
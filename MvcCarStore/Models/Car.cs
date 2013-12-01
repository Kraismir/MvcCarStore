using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCarStore.Models
{
    [Bind]
    public class Car
    {
        [ScaffoldColumn(false)]
        public int CarID { get; set; }

        public int BrandID { get; set; }

        [Required(ErrorMessage = "A model is always required!")]
        [StringLength(100)]
        public string Model { get; set; }

        [Required(ErrorMessage = "Year is required!")]
        public int Year { get; set; }

        public string Color { get; set; }

        [Required(ErrorMessage = "Price is required!")]
        public decimal Price { get; set; }

        [DisplayName("Car Picture URL")]
        public string CarPicUrl { get; set; }

        [DisplayName("Brand")]
        //[ForeignKey("BrandID")]
        public virtual Brand BrandName { get; set; }
    }
}
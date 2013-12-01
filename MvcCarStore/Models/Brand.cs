using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcCarStore.Models
{
    public class Brand
    {
        public int BrandID { get; set; }

        public string CarBrand { get; set; }

        public List<Car> Cars { get; set; }
    }
}
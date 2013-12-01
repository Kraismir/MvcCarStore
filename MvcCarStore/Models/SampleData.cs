using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MvcCarStore.Models;

namespace MvcCarStore.Models
{
    public class SampleData : DropCreateDatabaseIfModelChanges<CarStoreEntities>
    {
        protected override void Seed(CarStoreEntities context)
        {
            var brandList = new List<Brand>
            {
                new Brand {CarBrand = "Porshe"},
                new Brand {CarBrand = "BMW"},
                new Brand {CarBrand = "Lamborghini"},
                new Brand {CarBrand = "Renault"},
                new Brand {CarBrand = "Dodge"},
                new Brand {CarBrand = "Volkswagen"},
                new Brand {CarBrand = "Mercedes"},
                new Brand {CarBrand =  "Ford"}
            };

            new List<Car>
            {
                new Car { BrandName = brandList.Single( b => b.CarBrand == "Porshe"), Model = "911 Turbo", Color = "Black", Year = 2005, Price = 50, CarPicUrl = "/Content/Images/placeholder.gif"},
                new Car { BrandName = brandList.Single( b => b.CarBrand == "Lamborghini"), Model = "Aventador LP7004", Color = "Blue", Year = 2000, Price = 29, CarPicUrl = "/Content/Images/placeholder.gif"},
                new Car { BrandName = brandList.Single( b => b.CarBrand == "BMW"), Model = "330i", Color = "Black", Year = 2010, Price = 22, CarPicUrl = "/Content/Images/placeholder.gif"},
                new Car { BrandName = brandList.Single( b => b.CarBrand == "Lamborghini"), Model = "Murcielago LP6704", Color = "Yellow", Year = 2008, Price = 30, CarPicUrl = "/Content/Images/placeholder.gif"},
                new Car { BrandName = brandList.Single( b => b.CarBrand == "Dodge"), Model = "Viper SRT10", Color = "Grey/Blue", Year = 1968, Price = 26, CarPicUrl = "/Content/Images/placeholder.gif"},
                new Car { BrandName = brandList.Single( b => b.CarBrand == "Dodge"), Model = "Viper GTS Coupe", Color = "Red", Year = 2005, Price = 26, CarPicUrl = "/Content/Images/placeholder.gif"},
                new Car { BrandName = brandList.Single( b => b.CarBrand == "BMW"), Model = "X5", Color = "Red", Year = 1995, Price = 26, CarPicUrl = "/Content/Images/placeholder.gif"},
                new Car { BrandName = brandList.Single( b => b.CarBrand == "Porshe"), Model = "964 TURBO", Color = "White", Year = 1990, Price = 26, CarPicUrl = "/Content/Images/placeholder.gif"},
                new Car { BrandName = brandList.Single( b => b.CarBrand == "Renault"), Model = "Twingo Gordini R.S Kit", Color = "Black", Year = 2007, Price = 34, CarPicUrl = "/Content/Images/placeholder.gif"},
                new Car { BrandName = brandList.Single( b => b.CarBrand == "Volkswagen"), Model = "Beetle Convertible", Color = "Blue", Year = 1960, Price = 26, CarPicUrl = "/Content/Images/placeholder.gif"},
                new Car { BrandName = brandList.Single( b => b.CarBrand == "Ford"), Model = "Model T Convertible", Color = "Black", Year = 1908, Price = 360, CarPicUrl = "/Content/Images/placeholder.gif"},
                new Car { BrandName = brandList.Single( b => b.CarBrand == "Mercedes"), Model = "Benz SLK Class", Color = "Red", Year = 2005, Price = 27, CarPicUrl = "/Content/Images/placeholder.gif"},
                new Car { BrandName = brandList.Single( b => b.CarBrand == "Ford"), Model = "Model T Pickup", Color = "Black", Year = 1925, Price = 101, CarPicUrl = "/Content/Images/placeholder.gif"},

            }.ForEach(a => context.Cars.Add(a));
        }
    }
}
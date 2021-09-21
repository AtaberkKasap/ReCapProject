using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Brand> brands = new List<Brand>
            {
                new Brand{BrandId = 1, BrandName = "Volvo"},
                new Brand{BrandId = 2, BrandName = "Renault"}
            };

            List <Car> cars = new List<Car> { 
                new Car{CarId = 1, BrandId = 1, ColorId = 1, DailyPrice = 800, Description = "S90", ModelYear = "2020" },
                new Car{CarId = 2, BrandId = 1, ColorId = 1, DailyPrice = 1000, Description = "XC90", ModelYear = "2020" },
                new Car{CarId = 3, BrandId = 2, ColorId = 2, DailyPrice = 200, Description = "Clio", ModelYear = "2005"}
            };

            BrandManager brandManager = new BrandManager(new InMemoryBrandDal(brands));
            CarManager carManager = new CarManager(new InMemoryCarDal(cars));

            var carListWithBrandNames = from c in carManager.GetAll()
                                        join b in brandManager.GetBrands()
                                        on c.BrandId equals b.BrandId
                                        select new CarDetailsDto { CarId = c.CarId, BrandId = c.BrandId, BrandName = b.BrandName, ColorId = c.ColorId, DailyPrice = c.DailyPrice, Description = c.Description, ModelYear = c.ModelYear};

            foreach (var item in carListWithBrandNames)
            {
                Console.WriteLine($"{item.BrandName} {item.Description}");
            }
        }
    }
}

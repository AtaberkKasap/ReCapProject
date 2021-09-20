using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            List <Car> cars = new List<Car> { 
                new Car{CarId = 1, BrandId = 1, ColorId = 1, DailyPrice = 800, Description = "S90", ModelYear = "2020" },
                new Car{CarId = 2, BrandId = 1, ColorId = 1, DailyPrice = 1000, Description = "XC90", ModelYear = "2020" },
            };
            CarManager carManager = new CarManager(new InMemoryCarDal(cars));
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}

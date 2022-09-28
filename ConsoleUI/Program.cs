using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            RentalManager rentalManager = new RentalManager(new EfRentDal());
           var  kiralık = rentalManager.Add(new Rental
            {
                CarId = 3,
                CustomerId = 1,
                RentDate = DateTime.Now,
                ReturnDate = new DateTime(2020, 02, 23)
            }
            );
            Console.WriteLine(kiralık.Messages);

            // UserManager userManager = new UserManager(new EfUserDal());

            //User user1 = new User()
            //{   Id = 2,
            //    FirstName = "Bilbo",
            //    LastName = "Baggins",
            //    Email = "bilbo.baggins@gmail.com",
            //    Password = "nilospajam",

            //};


            //Console.WriteLine(userManager.Update(user1).Messages); 




            // EfCarDal efCarDal = new EfCarDal();
            // CarManager carManager = new CarManager(efCarDal);

            // Car car1 = new Car()
            // {
            //     BrandId = 1,
            //     ColorId = 1,
            //     ModelYear = 2020,
            //     DailyPrice = -10,
            //     Description = "Az hasarlı araba"

            // };
            //IResult result= carManager.Add(car1);
            // Console.WriteLine(result.Success);


            //foreach (var car in efCarDal.GetCarsDetails() )
            //{
            //    Console.WriteLine(car.BrandName); 
            //}





            //Car car2 = new Car()
            //{
            //    BrandId = 2,
            //    ColorId = 2,
            //    ModelYear = 2022,
            //    DailyPrice = 1000,
            //    Description = "Sıfır model araba"
            //};
            //Car car3 = new Car()
            //{
            //    BrandId = 3,
            //    ColorId = 3,
            //    ModelYear = 2023,
            //    DailyPrice = 2000,
            //    Description = "Sıfır model sport araba"
            //};

            //carManager.Add(car1);
            //carManager.Add(car2);
            //carManager.Add(car3);


            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine(car.Description); 
            //}

            //Console.WriteLine("------------------------------------------------------");

            //Console.WriteLine(carManager.GetById(1).Description);
            //Console.WriteLine("---------------------------------------------------------------");


            //foreach (var car in carManager.GetCarsByBrandId(1))
            //{
            //    Console.WriteLine(car.ModelYear);
            //}

            //Console.WriteLine("-------------------------------------------------------------------");

            //foreach (var car in carManager.GetCarsByColorId(2))
            //{
            //    Console.WriteLine(car.DailyPrice);
            //}

            //Console.WriteLine("-------------------------------------------------------------------");

            //Car carUpdate = new Car()
            //{
            //    Id = 1,
            //    Description = "güncelleme deneme",
            //    ModelYear = 1996,
            //   // DailyPrice = 50,
            //    ColorId=1,
            //    BrandId=1
            //};


            //carManager.Update(carUpdate);

            //Car carDelete = new Car()
            //{
            //    Id = 2

            //};

            //carManager.Delete(carDelete);


        }
    }
}

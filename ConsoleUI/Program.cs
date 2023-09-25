using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI;

class Program
{
    static void Main(string[] args)
    {
        //CarTest();
        //BrandTest();
        //ColorTest();
        //ListCar(); 
        //CustomerTest();
        //UserTest();
        RentalTest();
    }

    private static void RentalTest()
    {
        RentalManager rentalManager = new RentalManager(new EfRentalDal());

        Rental rental = new Rental { CarId = 1, CustomerId = 1, RentDate = DateTime.Now}; 
         var result = rentalManager.Add(rental);
        Console.WriteLine(result.Message);
    }

    private static void CustomerTest()
    {
        CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

        Customer customer = new Customer { UserId = 1, CompanyName = "deneme" };

        var result = customerManager.Add(customer); 
        Console.WriteLine(result.Message);
    }


    private static void ListCar()
    {
        CarManager carManager = new CarManager(new EfCarDal());

        Car car1 = new Car {CarId = 2, BrandId = 1, CarName = "Yaris", ColorId = 2, DailyPrice= 3432, Description = "New Car" ,ModelYear = 2021};
        var result1 =  carManager.Add(car1);

        if(result1.Success)
        {
            Console.WriteLine(result1.Message);
        }
        else
        {
            Console.WriteLine(result1.Message);
        }


        var result = carManager.GetAll();
        if (result.Success == true)
        {
            foreach (var car in result.Data)
            {
                //Console.WriteLine("Car Name : " + car.CarName + "\n" + "Brand Name : " + car.BrandName + "\n" + "Color Name : " + car.ColorName
                //+ "\n" + "Daily Price : " + car.DailyPrice); 
                Console.WriteLine(car.CarName);
            }
            
        }
        else
        {
            Console.WriteLine("Hata");
        }
    }

    private static void BrandTest()
    {
        BrandManager brandManager = new BrandManager(new EfBrandDal());


        Brand brand =  new Brand {BrandId = 2, 
            BrandName = "Tesla" };

        brandManager.Add(brand); 

        /* foreach (var brand in brandManager.GetByBrandId(1))
         {
             Console.WriteLine(brand.BrandName);  
         }*/
    }

    private static void ColorTest()
    {/*
        ColorManager colorManager = new ColorManager(new EfColorDal());

        foreach (var color in colorManager.GetByColorId(1))
        {
            Console.WriteLine(color.ColorName);
        }*/
    }

    private static void CarTest()
    {/*
        CarManager carManager = new CarManager(new EfCarDal());

        foreach (var car in carManager.GetByCarId(1))
        {
            Console.WriteLine(car.CarName);
        }*/

    }
}




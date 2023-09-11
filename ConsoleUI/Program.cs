using Business.Concrete;
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
        ListCar();
    }

    private static void ListCar()
    {
        CarManager carManager = new CarManager(new EfCarDal());

        foreach (var car in carManager.GetCarDetails())
        {
            Console.WriteLine("Car Name : " + car.CarName + "\n" + "Brand Name : " + car.BrandName + "\n" + "Color Name : " + car.ColorName
                + "\n" + "Daily Price : " + car.DailyPrice);
        }
    }

    private static void BrandTest()
    {
        BrandManager brandManager = new BrandManager(new EfBrandDal());


        Brand brand =  new Brand {BrandId = 2, '
            BrandName = "Tesla" };

        brandManager.Add(brand); 

        /* foreach (var brand in brandManager.GetByBrandId(1))
         {
             Console.WriteLine(brand.BrandName);  
         }*/
    }

    private static void ColorTest() 
    {
        ColorManager colorManager = new ColorManager(new EfColorDal());

        foreach (var color in colorManager.GetByColorId(1))
        {
            Console.WriteLine(color.ColorName);
        }
    }

    private static void CarTest()
    {
        CarManager carManager = new CarManager(new EfCarDal());

        foreach (var car in carManager.GetByCarId(1))
        {
            Console.WriteLine(car.CarName);
        }

    }
}




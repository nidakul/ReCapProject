using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI;

class Program
{
    static void Main(string[] args)
    {
        CarTest();
    }

    private static void CarTest()
    {
        CarManager carManager = new CarManager(new EfCarDal());

        foreach (var car in carManager.GetCarDetails())
        {
            Console.WriteLine(car.CarName + "/" + car.BrandName);
        }

        foreach (var car in carManager.GetCarsByColorId(1))
        {
            Console.WriteLine(car.Description);
        }
    }
}




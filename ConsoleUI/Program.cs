using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI;

class Program
{
    static void Main(string[] args)
    {
        CarManager carManager = new CarManager(new EfCarDal());

        foreach (var car in carManager.GetByCarId(1))
        {
            Console.WriteLine(car.BrandId);
        }

        
    }
}




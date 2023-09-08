using Business.Concrete;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI;

class Program
{
    static void Main(string[] args)
    {
        CarManager carManager = new CarManager(new InMemoryCarDal());

        foreach (var car in carManager.GetById(1))
        {
            Console.WriteLine(car.BrandId);
        }

        
    }
}


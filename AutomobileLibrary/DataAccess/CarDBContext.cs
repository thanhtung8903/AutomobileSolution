using AutomobileLibrary.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileLibrary.DataAccess
{
    public class CarDBContext
    {
        private static List<Car> CarList = new List<Car>()
        {
            new Car() { CarId = 1, CarName = "CRV", Manufacturer = "Honda", Price = 30000, ReleaseYear = 2021 },
            new Car() { CarId = 2, CarName = "Ford Focus", Manufacturer = "Ford", Price = 15000, ReleaseYear = 2020 },
        };

        private static CarDBContext instance = null;
        private static readonly object instanceLock = new object();

        private CarDBContext() { }

        public static CarDBContext Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CarDBContext();
                    }
                    return instance;
                }
            }
        }

        public List<Car> GetCarList => CarList;

        public Car GetCarById(int carId)
        {
            Car car = CarList.SingleOrDefault(CarList => CarList.CarId == carId);
            return car;
        }

        public void AddNew(Car car)
        {
            Car pro = GetCarById(car.CarId);
            if (pro == null)
            {
                CarList.Add(car);
            }
            else
            {
                throw new Exception("Car already exists");
            }
        }

        public void Update(Car car)
        {
            Car c = GetCarById(car.CarId);
            if (c != null)
            {
                var index = CarList.IndexOf(c);
                CarList[index] = car;
            } else
            {
                throw new Exception("Car not found");
            }
        }

        public void Remove(int CarId)
        {
            Car p = GetCarById(CarId);
            if (p != null)
            {
                CarList.Remove(p);
            }
            else
            {
                throw new Exception("Car not found");
            }
        }
    }
}

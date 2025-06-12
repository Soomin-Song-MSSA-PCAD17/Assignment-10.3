using Assignment_10._3.Data;
using Assignment_10._3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_10._3.Services
{
    public class CRUD
    {
        public void CreateCar(Car car)
        {
            Records.context.Add(car);
            Records.context.SaveChanges();
        }
        public Car FindCar(string vin)
        {
            return Records.context.CarSet.Find(vin);
        }
        public void UpdateCar(Car updatedCar)
        {
            var car = FindCar(updatedCar.Vin);
            if (car == null) { return; }
            car.Price = updatedCar.Price;
            Records.context.SaveChanges();
        }
        public void DeleteCar(string vin)
        {
            var car = FindCar(vin);
            if(car==null) { return; }
            Records.context.CarSet.Remove(car);
            Records.context.SaveChanges();
        }
    }
}

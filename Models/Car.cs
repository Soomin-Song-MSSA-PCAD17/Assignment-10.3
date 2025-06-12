using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Assignment_10._3.Models
{
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Vin { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public double Price { get; set; }

        public Car(string vin, string make, string model, string year, double price)
        {
            Vin = vin;
            Make = make;
            Model = model;
            Year = year;
            Price = price;
        }
        public override string ToString()
        {
            return $"{Vin}";
        }
    }
}

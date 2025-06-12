using Assignment_10._3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_10._3.Services
{
    public class Api
    {
        HttpClient client;
        public Api()
        {
            client = new();
            client.DefaultRequestHeaders.Accept.Clear();
        }

        static async Task DecodeVinAsync(HttpClient client, string vin)
        {
            var json = await client.GetStringAsync(
                $"https://vpic.nhtsa.dot.gov/api/vehicles/decodevinvalues/{vin}?format=json");

            Console.Write(json);
        }
    }
}

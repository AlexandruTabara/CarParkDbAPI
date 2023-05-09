using CarParkDbAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParkDbAPI
{
   public partial class DataLayerSingleton
    {
        public void Seed()
        {
            using var carsDbContext = new CarDBContext();

            var vw = new Producator { Nume = "VW", Adresa = "Wolfsburg" };
            var golf = new Autovehicul
            {
                Nume = "Golf",
                Producator = vw,
                CarteTehnica = new CarteTehnica
                {
                    AnFabricatie = 2007,
                    CC = 1395,
                    SerieDeSasiu = Guid.NewGuid().ToString(),
                }
            };

            var polo = new Autovehicul
            {
                Nume = "Polo",
                Producator = vw,
                CarteTehnica = new CarteTehnica
                {
                    AnFabricatie = 2014,
                    CC = 1598,
                    SerieDeSasiu = Guid.NewGuid().ToString(),
                }
            };

            var tiguan = new Autovehicul
            {
                Nume = "Tiguan",
                Producator = vw,
                CarteTehnica = new CarteTehnica
                {
                    AnFabricatie = 2011,
                    CC = 1390,
                    SerieDeSasiu = Guid.NewGuid().ToString(),
                }
            };

            carsDbContext.Add(golf);
            carsDbContext.Add(polo);
            carsDbContext.Add(tiguan);

            carsDbContext.SaveChanges();
        }
    }
}

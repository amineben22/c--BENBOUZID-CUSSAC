using AB.AC.MyAirport.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace MyAirport.AB.AC
{
    class Program
    {

        public static readonly ILoggerFactory MyLoggerFactory
    = LoggerFactory.Create(builder => { builder.AddConsole(); });
        static void Main(string[] args)
        {



            var optionsBuilder = new DbContextOptionsBuilder<AirportContext>();
            optionsBuilder.UseLoggerFactory(MyLoggerFactory);
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["AirportDB"].ConnectionString);

            using (var db = new AirportContext(optionsBuilder.Options))
            {

                //CREATE
                var vol = new Vol { 
                    CIE = "vol",
                    LIG = "air"
                };
                db.Vols.Add(vol);
                db.SaveChanges();

                // Read
                var vol1 = db.Vols
                    .First();

                var baggage = new Bagage
                {
                    ID_VOL = vol1.ID_VOL,
                    CODE_IATA = "QSDSQD",
                    DATE_CREATION = new DateTime(2012, 12, 25, 10, 30, 50)
                };
                db.Bagages.Add(baggage);
                db.SaveChanges();

                var baggage2 = new Bagage
                {
                    ID_VOL = vol1.ID_VOL,
                    CODE_IATA = "FDSFZ",
                    DATE_CREATION = new DateTime(2012, 12, 25, 10, 30, 50)
                };
                db.Bagages.Add(baggage2);
                db.SaveChanges();

                // Read
                var bag = db.Bagages
                    .First();

                // Update
                bag.CODE_IATA = "FSDFA";
                bag.SSUR = "SDFDSS";
                db.SaveChanges();

                // Delete
                db.Remove(bag);


                // Read
                var voll = db.Vols
                    .First();

                Console.WriteLine(voll.Bagages.Count);



                db.SaveChanges();





            }
            
        }
    }
}

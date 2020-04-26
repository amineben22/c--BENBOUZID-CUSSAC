using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AB.AC.MyAirport.EF


{
    public class AirportContext : DbContext
    {

        public AirportContext(DbContextOptions<AirportContext> options)
        : base(options)
        { }

        /*
         public static readonly ILoggerFactory MyLoggerFactory
    = LoggerFactory.Create(builder => { builder.AddConsole(); });
    */

        public DbSet<Vol>? Vols { get; set; } = null!;
        public DbSet<Bagage>? Bagages { get; set; } = null;

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {*/
            /*optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=Airport;Integrated Security=True");
                */

          /*  optionsBuilder.UseLoggerFactory(MyLoggerFactory);
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["AirportDB"].ConnectionString);
        }*/
    }
}

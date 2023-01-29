﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyEticketApplication.Models;

namespace MyEticketApplication.Data
{
    public class ApplicationDbContext:IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<RouteFrom> RouteFroms { get; set; }    
        public DbSet<RouteTo> RouteToFroms { get;set; }
        public DbSet<TransportType> TransportTypes { get; set; }
        public DbSet<TransportInfo> TransportInfo { get; set; }
        public DbSet<Agent> Agents { get; set; }
    }
}

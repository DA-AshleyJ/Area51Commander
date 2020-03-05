using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Commander.Services;
using System.Threading.Tasks;
using Discord;
using Microsoft.EntityFrameworkCore;
using Commander.Entities;

namespace Commander.Services
{
    public class Reports : DbContext
    {
        public Reports(DbContextOptions<Reports> options) : base(options) { }

        public DbSet<Item> jobid { get; set; }

    }
}

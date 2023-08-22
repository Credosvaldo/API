﻿using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Infraestrutura
{
    public class ConnectionContex : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(
              "Server=localhost;" +
              "Port=5432;Database=employee_sample;" +
              "User Id=postgres;" +
              "Password=123;");

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using dotnet_ticket.Models;

namespace dotnet_ticket.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Models.Ticket> Tickets => Set<Models.Ticket>();
        public DbSet<User> Users => Set<Models.User>();
        public DbSet<Priority> Priorities => Set<Models.Priority>();
        public DbSet<Status> Statuses => Set<Models.Status>();
        public DbSet<UserType> UserTypes => Set<Models.UserType>();
    }
}
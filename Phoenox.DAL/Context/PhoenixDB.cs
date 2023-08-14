using Microsoft.EntityFrameworkCore;
using Phoenix.DAL.Entityes;

namespace Phoenix.DAL.Context
{
    public class PhoenixDB : DbContext
    {
        public PhoenixDB(DbContextOptions<PhoenixDB> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Massage> Massages  { get; set; }
        public DbSet<Client> Clients  { get; set; }
        public DbSet<Master> Masters  { get; set; }
        public DbSet<Visit> Visits  { get; set; }
    }
}

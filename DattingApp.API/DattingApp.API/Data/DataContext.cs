using DattingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DattingApp.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions option) : base (option)  { }
        public DbSet<Value> Values { get; set; }
    }
}
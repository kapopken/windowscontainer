using Microsoft.EntityFrameworkCore;
using WindowsContainer.App.Models;

namespace WindowsContainer.App
{
    public class DBTodo : DbContext
    {
        public DBTodo(DbContextOptions<DBTodo> options) : base(options)
        {
        }
        public DbSet<Todo> Todo { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=tcp:127.0.0.1,5433;Initial Catalog=TodoDB;User Id=sa;Password=Pass@word");
        //}
    }
}

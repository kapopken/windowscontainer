using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    public class Todo
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

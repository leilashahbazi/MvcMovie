using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcMovie;
using MvcMovie.Models.DataBase;
namespace MvcMovie.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<Article> Article { get; set; }
        public DbSet<contactwithus> contactwithus { get; set; }
        public DbSet<News> News { get; set; }
    }
}
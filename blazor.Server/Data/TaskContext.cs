using blazor.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blazor.Server.Data
{
    public class TaskContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("TasksInMemoryDatabase");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskEntity>().HasData(
                new TaskEntity { Id = 1, Text = "Make a to do list", Done = true },
                new TaskEntity { Id = 2, Text = "Check off first thing on the 'to do' list", Done = true },
                new TaskEntity { Id = 3, Text = "Realize you already accomplished 2 things on the list", Done = true },
                new TaskEntity { Id = 4, Text = "Reward yourself with a " + char.ConvertFromUtf32(0x1F37A), Done = false }
            );
        }

        public DbSet<TaskEntity> Tasks { get; set; }
    }
}

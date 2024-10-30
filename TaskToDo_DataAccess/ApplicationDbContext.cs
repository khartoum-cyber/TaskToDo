﻿using Microsoft.EntityFrameworkCore;

namespace TaskToDo_DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<ToDoTask> Tasks { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}

﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace MRJCommerce.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
    }
}

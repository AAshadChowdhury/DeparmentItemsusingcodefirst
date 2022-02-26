using CoreShortProject.Models.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreShortProject.Context
{
    public class MyDBContext:DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> g)
            : base(g)
        {
        }
        public DbSet<dept2> dept2 { get; set; }
        public DbSet<items2> items2 { get; set; }
    }

}

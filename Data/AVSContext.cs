using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AV_Soft.Model;

namespace AV_Soft.Data
{
    public class AVSContext : DbContext
    {
        public AVSContext (DbContextOptions<AVSContext> options)
            : base(options)
        {
        }

        public DbSet<Tab1> Tab1 { get; set; }

        public DbSet<Tab2> Tab2 { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace my_gantt.Models
{
    public class GanttContext : DbContext
    {
        public GanttContext(DbContextOptions<GanttContext> options)
            : base(options)
        {
        }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Link> Links { get; set; }
    }
}

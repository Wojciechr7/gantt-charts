using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace my_gantt.Models
{
    public static class GanttSeeder
    {
        public static void Seed(GanttContext context)
        {
            if (context.Tasks.Any())
            {
                return;   // DB has been seeded
            }

            using (var transaction = context.Database.BeginTransaction())
            {
                List<Task> tasks = new List<Task>()
               {
                  new Task()
                    {
                       Id = 1,
                       Text = "Project #2",
                       StartDate = DateTime.Today.AddDays(-3),
                       Duration = 3,
                       Progress = 0.4m,
                       ParentId = null
                    },
                    new Task()
                    {
                       Id = 2,
                       Text = "Task #1",
                       StartDate = DateTime.Today.AddDays(-3),
                       Duration = 2,
                       Progress = 0.6m,
                       ParentId = 1
                    },
                    new Task()
                    {
                       Id = 3,
                       Text = "Task #2",
                       StartDate = DateTime.Today.AddDays(-2),
                       Duration = 1,
                       Progress = 0.6m,
                       ParentId = 1
                    },
                    new Task()
                    {
                        Id = 4,
                        Text = "Walenie w chuja",
                        StartDate = DateTime.Today.AddDays(-3),
                        Duration = 6,
                        Progress = 0.4m,
                        ParentId = null
                    },
                    new Task()
                    {
                        Id = 5,
                        Text = "Siedzenie",
                        StartDate = DateTime.Today.AddDays(-3),
                        Duration = 1,
                        Progress = 0.6m,
                        ParentId = 4
                    },
                    new Task()
                    {
                        Id = 6,
                        Text = "Dłubanie w nosiee",
                        StartDate = DateTime.Today.AddDays(-2),
                        Duration = 3,
                        Progress = 0.6m,
                        ParentId = 4
                    },
                    new Task()
                    {
                    Id = 7,
                    Text = "Ziewanie",
                    StartDate = DateTime.Today.AddDays(1),
                    Duration = 2,
                    Progress = 0.6m,
                    ParentId = 4
               }
               };

                tasks.ForEach(s => context.Tasks.Add(s));
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Tasks ON;");
                context.SaveChanges();

                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Tasks OFF;");
                List<Link> links = new List<Link>()
               {
                   new Link() {Id = 1, SourceTaskId = 1, TargetTaskId = 2, Type = "1"},
                   new Link() {Id = 2, SourceTaskId = 2, TargetTaskId = 3, Type = "0"},
                   new Link() {Id = 3, SourceTaskId = 4, TargetTaskId = 5, Type = "1"},
                   new Link() {Id = 4, SourceTaskId = 5, TargetTaskId = 6, Type = "0"},
                   new Link() {Id = 5, SourceTaskId = 6, TargetTaskId = 7, Type = "0"}
               };

                links.ForEach(s => context.Links.Add(s));
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Links ON;");
                context.SaveChanges();
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Links OFF;");
                transaction.Commit();
            }
        }
    }
}

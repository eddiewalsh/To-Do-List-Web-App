using Microsoft.EntityFrameworkCore;
using ToDoListApp.Models;

namespace ToDoListApp.Data
{
    public class ToDoListContext : DbContext
    {
        public ToDoListContext(DbContextOptions options) : base(options) { }
        public DbSet<Jobs> JobList { get; set; }

        /// <summary>
        /// This function is called to return the Job that matches the ID passed
        /// </summary>
        /// <param name="Id">The ID of the job we are searching for</param>
        public Jobs? GetJobsByID(int Id)
        {
            return JobList.FromSqlRaw($"SELECT * FROM JobList WHERE Id = {Id}", Id).FirstOrDefault();
        }

        /// <summary>
        /// We get all our jobs present in the db and organise it first by 'isCompleted' than
        /// by 'CreatedAt'
        /// </summary>
        public List<Jobs> GetAllFromDB()
        {
            return JobList.OrderBy(job => job.isCompleted)
                          .ThenByDescending(job => job.CreatedAt)
                          .ToList();
        }

        /// <summary>
        /// Seed Data
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Jobs>().HasData(
                new Jobs()
                {
                    Id = 10,
                    JobTitle = "Charcuterie",
                    JobDescription = "For indecfugiat. Temporibus, voluptatibus.",
                    isCompleted = false,
                    CreatedAt = DateTime.Now
                });
        }
    }
}

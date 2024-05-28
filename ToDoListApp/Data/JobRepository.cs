using ToDoListApp.Models;

namespace ToDoListApp.Data
{
    public class JobRepository : IJobRepository
    {
        private readonly ToDoListContext todolistContext;
        public JobRepository(ToDoListContext context)
        {
            todolistContext = context;
        }

        public void Add(Jobs job)
        {
            todolistContext.JobList.Add(job);
            todolistContext.SaveChanges();
        }

        public void Delete(Jobs job)
        {
            todolistContext.JobList.Remove(job);
            todolistContext.SaveChanges();
        }

        public List<Jobs> GetAll()
        {
            return todolistContext.GetAllFromDB();
        }

        public Jobs? GetById(int id)
        {
            return todolistContext.GetJobsByID(id);
        }

        public void Update(Jobs job)
        {
            todolistContext.JobList.Update(job);
            todolistContext.SaveChanges();
        }
    }
}

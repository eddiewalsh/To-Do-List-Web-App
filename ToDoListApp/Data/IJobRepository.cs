using ToDoListApp.Models;

namespace ToDoListApp.Data
{
    public interface IJobRepository
    {
        public void Add(Jobs job);
        public void Update(Jobs job);
        public Jobs? GetById(int id);
        public List<Jobs> GetAll();
        public void Delete(Jobs job);
    }
}

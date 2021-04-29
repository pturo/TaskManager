using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Models;

namespace TaskManager.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskManagerContext _context;

        public TaskRepository(TaskManagerContext context)
        {
            _context = context;
        }

        public TaskModel Get(int id) => _context.Tasks.SingleOrDefault(x => x.Id == id);

        public IQueryable<TaskModel> GetAllActive() => _context.Tasks.Where(x => !x.Done);

        public void Add(TaskModel taskModel)
        {
            _context.Tasks.Add(taskModel);
            _context.SaveChanges();
        }

        public void Update(int id, TaskModel taskModel)
        {
            var result = _context.Tasks.SingleOrDefault(x => x.Id == id);
            if(result != null)
            {
                result.Name = taskModel.Name;
                result.Description = taskModel.Description;
                result.Done = taskModel.Done;

                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var result = _context.Tasks.SingleOrDefault(x => x.Id == id);
            if(result != null)
            {
                _context.Tasks.Remove(result);
                _context.SaveChanges();
            }
        }
    }
}

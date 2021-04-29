using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Models;

namespace TaskManager.Repositories
{
    public interface ITaskRepository
    {
        TaskModel Get(int id);
        IQueryable<TaskModel> GetAllActive();
        void Add(TaskModel taskModel);
        void Update(int id, TaskModel taskModel);
        void Delete(int id);
    }
}

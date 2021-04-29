using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Models;
using TaskManager.Repositories;

namespace TaskManager.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskRepository _taskRepotitory;

        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepotitory = taskRepository;
        }

        // GET: Task
        public ActionResult Index()
        {
            return View(_taskRepotitory.GetAllActive());
        }

        // GET: Task/Details/5
        public ActionResult Details(int id)
        {
            return View(_taskRepotitory.Get(id));
        }

        // GET: Task/Create
        public ActionResult Create()
        {
            return View(new TaskModel());
        }

        // POST: Task/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TaskModel taskModel)
        {
            _taskRepotitory.Add(taskModel);

            return RedirectToAction(nameof(Index));
        }

        // GET: Task/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_taskRepotitory.Get(id));
        }

        // POST: Task/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TaskModel taskModel)
        {
            _taskRepotitory.Update(id, taskModel);

            return RedirectToAction(nameof(Index));
        }

        // GET: Task/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_taskRepotitory.Get(id));
        }

        // POST: Task/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, TaskModel taskModel)
        {
            _taskRepotitory.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        // GET: Task/Done/5
        public ActionResult Done(int id)
        {
            TaskModel task = _taskRepotitory.Get(id);
            task.Done = true;
            _taskRepotitory.Update(id, task);

            return RedirectToAction(nameof(Index));
        }
    }
}

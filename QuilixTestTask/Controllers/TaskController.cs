using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Qulix.Web.Models;
using Qulix.Data.Repository;
using Qulix.Data.Common;

namespace Qulix.Web.Controllers
{
    public class TaskController : Controller
    {
        private ITaskRepository _taskRepository = new TaskRepository();

        public ActionResult TaskList()
        {
            ICollection<ITask> tasks = _taskRepository.GetAllEnities();
            List<TaskModel> taskModels = tasks.Select(x => new TaskModel(x)).ToList();
            return View(taskModels);
        }


        // GET: Task/Create
        public ActionResult Create()
        {
            TaskCreateModel model = new TaskCreateModel();
            return View(model);
        }

        // POST: Task/Create
        [HttpPost]
        public ActionResult Create(TaskCreateModel model)
        {
            try
            {
                _taskRepository.Create(model);
                return RedirectToAction("TaskList");
            }
            catch
            {
                return View();
            }
        }

        // GET: Task/Edit/5
        public ActionResult Edit(int id)
        {
            ITask task = _taskRepository.FindById(id);
            TaskCreateModel model = new TaskCreateModel(task);
            return View(model);
        }

        // POST: Task/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TaskCreateModel model)
        {
            try
            {
                _taskRepository.Update(id, model);
                return RedirectToAction("TaskList");
            }
            catch
            {
                return View();
            }
        }

        // GET: Task/Delete/5
        public ActionResult Delete(int id)
        {
            TaskModel model = new TaskModel(_taskRepository.FindById(id));
            return View(model);
        }

        // POST: Task/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, TaskModel model)
        {
            try
            {
                _taskRepository.DeleteById(id);
                return RedirectToAction("TaskList");
            }
            catch
            {
                return View();
            }
        }
    }
}

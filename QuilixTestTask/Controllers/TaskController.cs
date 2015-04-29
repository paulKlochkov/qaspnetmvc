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
        private IPersonRepository _personRepository = new PersonRepository();
        //GET: /Task/TaskList
        public ActionResult TaskList()
        {
            ICollection<ITask> tasks = _taskRepository.GetAllEnities();
            TaskListModel taskListModel = new TaskListModel(tasks);
            taskListModel.PersonCount = _personRepository.Count();
            return View(taskListModel);
        }


        // GET: Task/Create
        public ActionResult Create()
        {
            TaskCreateEditModel model = new TaskCreateEditModel();
            return View(model);
        }

        // POST: Task/Create
        [HttpPost]
        public ActionResult Create(TaskCreateEditModel model)
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
            TaskCreateEditModel model = new TaskCreateEditModel(task);
            return View(model);
        }

        // POST: Task/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TaskCreateEditModel model)
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

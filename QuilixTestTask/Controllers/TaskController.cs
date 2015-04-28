using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Qulix.Web.Models;

namespace Qulix.Web.Controllers
{
    public class TaskController : Controller
    {
        // GET: Task
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TaskList()
        {
            List<TaskModel> tasks = new List<TaskModel>(StaticDS.Tasks.Count);
            foreach (var task in StaticDS.Tasks)
            {
                tasks.Add(new TaskModel(task));
            }
            return View(tasks);
        }
        // GET: Task/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
                // TODO: Add insert logic here
                StaticDS.Tasks.Add(new Qulix.Data.Common.Task
                {
                    EndDate = model.EndDate,
                    StartDate = model.StartDate,
                    Name = model.Name,
                    Status = model.Status,
                    Executor = StaticDS.Persons.FirstOrDefault(x => x.PersonId == model.ExecutorId)
                });
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
            return View(StaticDS.Tasks.FirstOrDefault(x => x.TaskId == id));
        }

        // POST: Task/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TaskModel model)
        {
            try
            {
                // TODO: Add update logic here
                var obj = StaticDS.Tasks.FirstOrDefault(x => x.TaskId == id);

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
            var obj = new TaskModel(StaticDS.Tasks.FirstOrDefault(x => x.TaskId == id));
            return View(obj);
        }

        // POST: Task/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, TaskModel model)
        {
            try
            {
                // TODO: Add delete logic here
                var obj = StaticDS.Tasks.FirstOrDefault(x => x.TaskId == id);
                StaticDS.Tasks.Remove(obj);
                return RedirectToAction("TaskList");
            }
            catch
            {
                return View();
            }
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quilix.Web.Models;

namespace Quilix.Web.Controllers
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

            return View(StaticDS.Tasks);
        }
        // GET: Task/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Task/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Task/Create
        [HttpPost]
        public ActionResult Create(TaskModel model)
        {
            try
            {
                // TODO: Add insert logic here

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
            var obj = StaticDS.Tasks.FirstOrDefault(x => x.TaskId == id);
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
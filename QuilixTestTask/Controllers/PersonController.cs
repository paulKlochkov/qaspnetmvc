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
    public class PersonController : Controller
    {
        //TODO Use DI in futurre
        private IPersonRepository _personRepository = new PersonRepository();


        public ActionResult PersonList()
        {
            IEnumerable<IPerson> persons = _personRepository.GetAllEnities();
            List<PersonModel> personRowModel = persons.Select(x => new PersonModel(x)).ToList();
            return View(personRowModel);
        }



        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        public ActionResult Create(PersonModel model)
        {
            try
            {
                _personRepository.Create(model);
                return RedirectToAction("PersonList");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            IPerson person = _personRepository.FindById(id);
            PersonModel model = new PersonModel(person);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(int id, PersonModel model)
        {
            try
            {
                _personRepository.Update(id, model);
                return RedirectToAction("PersonList");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int id)
        {
            PersonModel model = new PersonModel(_personRepository.FindById(id));
            return View(model);
        }

        // POST: Person/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection model)
        {
            try
            {
                // TODO: Add delete logic here
                _personRepository.DeleteById(id);
                return RedirectToAction("PersonList");
            }
            catch
            {
                return View();
            }
        }
    }
}

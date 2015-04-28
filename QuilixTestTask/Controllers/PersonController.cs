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
                // TODO: Add insert logic here

                return RedirectToAction("PersonList");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int id)
        {
            IPerson person = _personRepository.FindById(id);
            PersonModel model = new PersonModel(person);
            return View(model);
        }

        // POST: Person/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PersonModel model)
        {
            try
            {
                // TODO: Add update logic here
                var person = StaticDS.Persons.FirstOrDefault(x => x.PersonId == id);
                person.LastName = model.LastName;
                person.SecondName = model.SecondName;
                person.FirstName = model.FirstName;
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
            var person = StaticDS.Persons.FirstOrDefault(x => x.PersonId == id);
            return View(person);
        }

        // POST: Person/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var person = StaticDS.Persons.FirstOrDefault(x => x.PersonId == id);
                StaticDS.Persons.Remove(person);
                return RedirectToAction("PersonList");
            }
            catch
            {
                return View();
            }
        }
    }
}

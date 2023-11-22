using EmpSystem.BL.Interface;
using EmpSystem.BL.Repository;
using EmpSystem.DAL.Database;
using EmpSystem.DAL.Entities;
using EmpSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Intrinsics.Arm;

namespace EmpSystem.Controllers
{
    public class DepartmentController : Controller
    {

        //using Dependancy injection 
        //And Losely coupling to acchive Dependancy inversion Principle 
        //which High level Class (Department Contrroller ) doesnt Depend directly to the low level Class (DepartmentRep) There is An interface Between theme
        private IDepartmentRep department;
        public DepartmentController(IDepartmentRep department)
        {
            this.department = department;
        }
        public IActionResult Index()
        {
            var data = department.Get();
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(DepartmentsVM Dpt)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    department.add(Dpt);
                    return RedirectToAction("Index", "Department");
                }

                return View(Dpt);
            }
            catch (Exception ex)
            {
                EventLog log = new EventLog();
                log.Source = "Admin Dashboard";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);

                return View(Dpt);
            }


        }
        public IActionResult Edit(int id)
        {
            var data= department.GetById(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(DepartmentsVM Dpt)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    department.Edit(Dpt);
                    return RedirectToAction("Index", "Department");
                }

                return View(Dpt);
            }
            catch (Exception ex)
            {
                EventLog log = new EventLog();
                log.Source = "Admin Dashboard";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);

                return View(Dpt);
            }


        }
        public IActionResult Delete(int id)
        {
            var data = department.GetById(id);
            return View(data);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            try
            {
                    department.Delete(id);
                    return RedirectToAction("Index", "Department");
               

            }
            catch (Exception ex)
            {
                EventLog log = new EventLog();
                log.Source = "Admin Dashboard";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);

                return View();
            }


        }
    }
}

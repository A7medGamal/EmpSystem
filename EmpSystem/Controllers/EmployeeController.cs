using EmpSystem.BL.Interface;
using EmpSystem.DAL.Entities;
using EmpSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace EmpSystem.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeRep employee;
        private IDepartmentRep department;
        private ICountryRep country;
        private ICityRep city;
        private IDistrictRep district;
        public EmployeeController(IEmployeeRep employee, IDepartmentRep department , ICountryRep country, ICityRep city, IDistrictRep district)
        {
            this.employee = employee;
            this.department = department;
            this.country = country;
            this.city = city;
            this.district = district;
        }
        public IActionResult Index()
        {
            var data = employee.Get();
            return View(data);
        }
        public IActionResult Create()
        {
            var data = department.Get();
            var countrydata=country.Get();
            ViewBag.DepartmentList = new SelectList(data, "Id", "DepatmentName");
            ViewBag.CountryList = new SelectList(countrydata, "Id", "CountryName");
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeVM emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    employee.add(emp);
                    return RedirectToAction("Index", "Employee");
                }
                var countrydata = country.Get();
                var data = department.Get();
                ViewBag.DepartmentList = new SelectList(data, "Id", "DepatmentName");
               // ViewBag.CountryList = new SelectList(countrydata, "Id", "CountryName");

                return View(emp);
            }
            catch (Exception ex)
            {
                EventLog log = new EventLog();
                log.Source = "Admin Dashboard";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);

                return View(emp);
            }


        }
        public IActionResult Edit(int id)
        {
            var data = employee.GetById(id);
            var deptdata = department.Get();
            ViewBag.DepartmentList = new SelectList(deptdata, "Id", "DepatmentName",data.DepartmentId);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(EmployeeVM emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    employee.Edit(emp);
                    return RedirectToAction("Index", "Employee");
                }
                var deptdata = department.Get();
                ViewBag.DepartmentList = new SelectList(deptdata, "Id", "DepatmentName", emp.DepartmentId);

                return View(emp);
            }
            catch (Exception ex)
            {
                EventLog log = new EventLog();
                log.Source = "Admin Dashboard";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);

                return View(emp);
            }


        }
        public IActionResult Delete(int id)
        {
            var data = employee.GetById(id);
            var deptdata = department.Get();
            ViewBag.DepartmentList = new SelectList(deptdata, "Id", "DepatmentName", data.DepartmentId);
            return View(data);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            try
            {
                employee.Delete(id);
                return RedirectToAction("Index", "Employee");


            }
            catch (Exception ex)
            {
                EventLog log = new EventLog();
                log.Source = "Admin Dashboard";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);

                return View();
            }


        }
        [HttpPost]
        public JsonResult GetCityDataByCountryId(int cntryId)
        {
            var data = city.Get().Where(a => a.CountryId == cntryId);
            return Json(data);
        }
        [HttpPost]
        public JsonResult GetDistrictDataByCityId(int ctyId)
        {
            var data = district.Get().Where(a => a.CityId == ctyId);
            return Json(data);
        }
    }
}

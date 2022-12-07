using EmployeeApp.Helper;
using EmployeeApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace EmployeeApp.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeAPI _api = new EmployeeAPI();

        List<SelectListItem> Desig = new List<SelectListItem>()
        {
            new SelectListItem{Text="Team Lead",Value="Team Lead"},
            new SelectListItem{Text="Sr. Developer",Value="Sr. Developer"},
            new SelectListItem{Text="Jr. Developer",Value ="Jr. Developer"}
        };

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<EmpData> employees = new List<EmpData>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/EmpDatas");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                employees = JsonConvert.DeserializeObject<List<EmpData>>(results);
            }
            return View(employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Designa = Desig;
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmpData EmpObj)
        {
            if (!ModelState.IsValid)
            {
                TempData["AlertMessage"] = "Model State Error";
                ViewBag.Designa = Desig;
                return View("Create");
            }

            HttpClient client=_api.Initial();

            var postTask = client.PostAsJsonAsync<EmpData>("api/EmpDatas",EmpObj);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                TempData["Create"] = "Record Created Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Designa = Desig;
            if (id == null)
            {
                return NotFound();
            }
            var employee = new EmpData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/EmpDatas/{id}");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                employee = JsonConvert.DeserializeObject<EmpData>(results);
            }
            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(EmpData EmpObj,int id)
        {
            if (!ModelState.IsValid)
            {
                TempData["AlertMessage"] = "Model State Error";
                ViewBag.Designa = Desig;
                return View("Edit");
            }

            ViewBag.Designa = Desig;
            if (!ModelState.IsValid)
            {
                TempData["AlertMessage"] = "Model State Error";
                ViewBag.Designa = Desig;
                return View("Edit");
            }

            HttpClient client = _api.Initial();

            var postTask = client.PutAsJsonAsync<EmpData>($"api/EmpDatas/{id}", EmpObj);
            postTask.Wait();

            var result = postTask.Result;

            TempData["Create"] = "Record Edited Successfully";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Details(int id)
        {
            var employee = new EmpData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/EmpDatas/{id}");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                employee = JsonConvert.DeserializeObject<EmpData>(results);
            }
            return PartialView("_DisplayEmployeePartial", employee);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var employee=new EmpData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.DeleteAsync($"api/EmpDatas/{id}");

            TempData["Create"] = "Record Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
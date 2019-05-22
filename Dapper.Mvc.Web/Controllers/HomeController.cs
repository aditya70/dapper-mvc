using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dapper.Mvc.Web.Models;
using Dapper.Mvc.Web.Repository;

namespace Dapper.Mvc.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [ActionName("Details")]
        public async Task<IActionResult> GetEmployeeById()
        {
            var result =await _employeeRepository.GetById(10);
           return View(result);
            
        }


        [ActionName("Employee")]
        public async Task<IActionResult> GetAllEmployee()
        {
            var result = await _employeeRepository.GetAllEmployees();
            return View(result);

        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}

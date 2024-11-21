using DotNetCoreApplication.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreApplication.Controllers
{ 
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployee _iEmp;

        public HomeController(ILogger<HomeController> logger, IEmployee iEMP)
        {
            _logger = logger;
            _iEmp = iEMP; ;


        }

        public IActionResult Index()
        {
            var item = _iEmp.GetAllEmployee();
            return View(item);
        }

       public IActionResult Details(int ID)
        {
            var Items = _iEmp.GetEmployee(ID);
            return View(Items); ;
        }

        
    }
}

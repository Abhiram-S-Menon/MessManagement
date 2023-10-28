using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Repository.IRepository;

namespace WebApplication2.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdminController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(DateTime dateInput)
        {
            var date1 = dateInput.Date;
            var orders = _unitOfWork.Detail.GetAll(u => u.Date.Date == date1,includeProperties:"MessMember");
            if (orders.Any()) // Check if there are records in the collection
            {
                return View("Display", orders);
            }
            else
            {
                TempData["error"] = "No Records found";
                return View();
            }

        }
    }
}

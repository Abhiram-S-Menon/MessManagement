using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using WebApplication2.Models;
using WebApplication2.Repository.IRepository;
using WebApplication2.Utility;

namespace WebApplication2.Controllers
{
    [Authorize(Roles=SD.Role_Member)]
    public class MessMember : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public MessMember(IUnitOfWork unitOfWork)
        {
            _unitOfWork= unitOfWork;
        }
        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;

            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            
            var memberfromdb = _unitOfWork.MessMember.Get(u => u.Id == userId);
            ViewBag.dues = memberfromdb.Dues;

            return View();
        }
        [HttpPost]
        public IActionResult Index(Detail detail)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;

            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            detail.MemberId = userId;
            var memberfromdb = _unitOfWork.MessMember.Get(u => u.Id == detail.MemberId);
            Detail detailfromdb=_unitOfWork.Detail.Get(u => u.MemberId == userId && u.Date==detail.Date);
            if(detailfromdb==null)
			{
				_unitOfWork.Detail.Add(detail);
				
                TempData["success"] = "Registration Successfull! Enjoy Meals in Usha Mess";
                memberfromdb.Dues += 40;
                _unitOfWork.MessMember.Update(memberfromdb);
                _unitOfWork.Save();
                ViewBag.dues = memberfromdb.Dues;


            }
            else
            {
                TempData["error"] = "Already Registered for selected day";
            }

			return View();



		}

    }
}

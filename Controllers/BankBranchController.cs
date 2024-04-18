using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class BankBranchController : Controller
    {
        static List<BankBranch> bankBranches = [
            new BankBranch{Id = 1, LocationName= "Bayan", LocationURL = "https://www.bing.com/maps?osid=72dc0185-4f4e-49da-bb46-9840dc70c549&cp=29.298765~48.028203&lvl=14.273868&pi=0&v=2&sV=2&form=S00027", BranchManager= "Noura", EmployeeCount= "5"},
             new BankBranch{Id = 2, LocationName= "Mishref", LocationURL = "https://www.bing.com/maps?osid=72dc0185-4f4e-49da-bb46-9840dc70c549&cp=29.298765~48.028203&lvl=14.273868&pi=0&v=2&sV=2&form=S00027", BranchManager= "Faten", EmployeeCount= "2"}
            ];
        public IActionResult Index()
        {
            return View(bankBranches);

        }

        [HttpGet]

        public IActionResult create()
        {
            return View();

        }

        [HttpPost]

        public IActionResult Create(NewBranchForm form)

        {
            if (ModelState.IsValid)
            {

                var id = form.Id;
                var LocationName = form.LocationName;
                var LocationURL = form.LocationURL;
                var EmployeeCount = form.EmployeeCount;
                var BranchManger = form.BranchManager;

                bankBranches.Add(new BankBranch { Id = id, LocationName = LocationName, LocationURL = LocationURL, EmployeeCount = EmployeeCount });

                return RedirectToAction("Index");
            }
            return View(form);

        }
        public IActionResult Details(int id)

        {

            var bankBranch = bankBranches.FirstOrDefault(bankBranch => bankBranch.Id == id);
            {


                if( bankBranches == null) {
                    return RedirectToAction("Index");
                }
               

            }

            return View(bankBranch);
        }
    }


}




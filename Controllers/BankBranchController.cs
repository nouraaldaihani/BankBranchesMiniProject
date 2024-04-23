using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class BankBranchController : Controller
    {
        private readonly BankContext _context;

        public BankBranchController(BankContext context)
        {
            _context = context;
        }


        static List<BankBranch> bankBranches = [
            new BankBranch{Id = 1, LocationName= "Bayan", LocationURL = "https://www.bing.com/maps?osid=72dc0185-4f4e-49da-bb46-9840dc70c549&cp=29.298765~48.028203&lvl=14.273868&pi=0&v=2&sV=2&form=S00027", BranchManager= "Noura", EmployeeCount= "5"},
             new BankBranch{Id = 2, LocationName= "Mishref", LocationURL = "https://www.bing.com/maps?osid=72dc0185-4f4e-49da-bb46-9840dc70c549&cp=29.298765~48.028203&lvl=14.273868&pi=0&v=2&sV=2&form=S00027", BranchManager= "Faten", EmployeeCount= "2"}
            ];
        public IActionResult Index()
        {
           
                var viewModel = new BankDashboardViewModel();
                using (var context = _context)
            {
                viewModel.BranchList = context.BankBranches.ToList();
                viewModel.TotalEmployees = _context.Employees.Count();
                return View(viewModel);
            }

        }


        [HttpGet]

        public IActionResult Create()
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

                using (var context = _context)
                {
                    var bank = new BankBranch { Id = id, LocationName = LocationName, BranchManager = BranchManger, LocationURL = LocationURL, EmployeeCount = EmployeeCount };

                    context.BankBranches.Add(bank);
                    context.SaveChanges();

                    return RedirectToAction("Index");
                }

                // bankBranches.Add(new BankBranch { Id = id, LocationName = LocationName, LocationURL = LocationURL, EmployeeCount = EmployeeCount });
            }

            return View(form);

        }
        public IActionResult Details(int id)

        {
            using (var context = _context)
            {


                var bank = context.BankBranches.Include(r => r.Employees).FirstOrDefault(bankBranch => bankBranch.Id == id);
                if (bank != null)

                {


                    return View(bank);
                }
                return RedirectToAction("Index");


            }
        }


        [HttpPost]

        public IActionResult Edit(int id, EditBranchForm newBranch)

        {
            using (var context = _context)
            {
                var bank = context.BankBranches.Find(id);
                if (bank != null)
                {
                    bank.LocationURL = newBranch.LocationURL;
                    bank.BranchManager = newBranch.BranchManager;
                    bank.EmployeeCount = newBranch.EmployeeCount;
                    bank.LocationName = newBranch.LocationName;
                    context.SaveChanges();
                    return RedirectToAction("Index");

                }

                return View();

            }
        }
        [HttpGet]

        public IActionResult Edit(int id)

        {
            using (var context = _context)
            {
                var bank = context.BankBranches.Find(id);
                if (bank == null)

                {
                    return NotFound();

                }
                var form = new EditBranchForm();
                form.LocationName = bank.LocationName;
                form.BranchManager = bank.BranchManager;
                form.EmployeeCount = bank.EmployeeCount;
                form.LocationURL = bank.LocationURL;
                form.Id = bank.Id;
                return View(form);


            }
        }
        [HttpGet]
        public IActionResult AddEmployee(int Id)
        {
            return View();
        }



        [HttpPost]

        public IActionResult AddEmployee(int Id, AddEmployeeForm form)
        {
            if (ModelState.IsValid)

            {
                var database = _context;
                var bank = database.BankBranches.Find(Id);
                var newemployee = new Employee();

                //newemployee.Id = Id;
                newemployee.Name = form.Name;
                newemployee.CivilId = form.CivilId;
                newemployee.Position = form.Position;

                bank.Employees.Add(newemployee);

                database.SaveChanges();
            }


            return View(form);

        }
    }
}





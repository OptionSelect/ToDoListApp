using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoListApp.Models;

namespace ToDoListApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly todolistContext _context;

        public HomeController(todolistContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Index(string newToDoName)
        {
            var currentToDo = new ToDoModel{
                TaskName = newToDoName
            };
            
            _context.ToDos.Add(currentToDo);
            _context.SaveChanges();

            return View(_context.ToDos.ToList());
        }


        public IActionResult Index()
        {
            return View(_context.ToDos.ToList());
        }

        [HttpPost]
         public IActionResult Complete(int id)
        {
            var current = _context.ToDos.SingleOrDefault(m => m.ID == id);

            current.CompleteTask();
            _context.SaveChanges();

            return Redirect("Index");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

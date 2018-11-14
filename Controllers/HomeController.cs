using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoListProject.Models;

namespace TodoListProject.Controllers
{
    public class HomeController : Controller
    {
      public ActionResult Index()
        {
            using (var taskcontext = new TaskContext())
            {
                var taskvalue = new Task() { value = "task1" };
                taskcontext.Tasks.Add(taskvalue);
                taskcontext.SaveChanges();
            }
            return View();
        }
        public ActionResult GetTasks()
        {
            List<Task> taskList = null;
            using (var taskcontext = new TaskContext())
            {
               taskList = taskcontext.Tasks.ToList();
            }
            return View(taskList);
        }
    }
}
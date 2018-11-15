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
        [HttpPost]
        public ActionResult AddTask(string todoValue)
        {
           
            using (var taskcontext = new TaskContext())
            {
                var taskvalue = new Task() { value = todoValue };
                taskcontext.Tasks.Add(taskvalue);
                taskcontext.SaveChanges();
            }
            return RedirectToAction("GetTasks");
        }
        [HttpPost]
        public ActionResult DeleteTask(int id)
        {
            using (var taskcontext = new TaskContext())
            {
                var deleteTask = taskcontext.Tasks.Find(id);
                taskcontext.Tasks.Remove(deleteTask);
                taskcontext.SaveChanges();
            }
            return RedirectToAction("GetTasks");
        }
        public ActionResult EditTask(int id)
        {
             
            

            return View();
        }
    }
}

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
            using (TaskContext taskcontext = new TaskContext())
            {
                taskList = taskcontext.Tasks.ToList();
            }
            return View(taskList);
        }
        [HttpPost]
        public ActionResult AddTask(string todoValue)
        {

            using (TaskContext taskcontext = new TaskContext())
            {
                Task taskvalue = new Task() { value = todoValue };
                taskcontext.Tasks.Add(taskvalue);
                taskcontext.SaveChanges();
            }
            return RedirectToAction("GetTasks");
        }
        [HttpPost]
        public ActionResult DeleteTask(int id)
        {
            using (TaskContext taskcontext = new TaskContext())
            {
                Task deleteTask = taskcontext.Tasks.Find(id);
                taskcontext.Tasks.Remove(deleteTask);
                taskcontext.SaveChanges();
            }
            return RedirectToAction("GetTasks");
        }
        [HttpPost]
        public ActionResult EditTask(int id)
        {
            Task editTask;
            using (TaskContext taskcontext = new TaskContext())
            {
                editTask = taskcontext.Tasks.Find(id);
            }
            return View(editTask);
        }
        [HttpPost]
        public ActionResult EditTaskHelper(string editValue, string editId)
        {
            Task edittask;
            using (TaskContext taskcontext = new TaskContext())
            {
                
                int id = Convert.ToInt32(editId);
                edittask = taskcontext.Tasks.Find(id);
                edittask.value = editValue;
                taskcontext.SaveChanges();
            }
            return RedirectToAction("GetTasks");
        }
    }
}

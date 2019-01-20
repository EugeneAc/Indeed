using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Indeed.Controllers
{
    public class HomeController : Controller
    {
        private ITaskProcessingService taskProcServise;

        public ActionResult Index()
        {
            taskProcServise.ProcessingQueue.GetTasksInQueue();
            return View();
        }

        [HttpPost]
        public int SetTm(int tm)
        {
            taskProcServise.Tm_milliseconds = tm;
            return taskProcServise.Tm_milliseconds;
        }

        [HttpPost]
        public int SetTd(int td)
        {
            taskProcServise.Td_milliseconds = td;
            return taskProcServise.Td_milliseconds;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
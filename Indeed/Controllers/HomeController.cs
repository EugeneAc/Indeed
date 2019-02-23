using Core.Abstracts;
using Core.ConcreteClases;
using Core.Interfaces;
using Indeed.Models;
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

        public HomeController(ITaskProcessingService taskProcServise)
        {
            this.taskProcServise = taskProcServise;
        }

        public ActionResult Index()
        {
            var model = taskProcServise.ProcessingQueue.GetAllTasksInQueue();
            return View(model);
        }

        public ActionResult SetTm(int tm)
        {
            taskProcServise.Tm_milliseconds = tm;
            return new RedirectResult("Settings");
        }

        public ActionResult SetTd(int td)
        {
            taskProcServise.Td_milliseconds = td;
            return new RedirectResult("Settings");
        }

        public ActionResult Employees()
        {
            var model = new List<AbstractEmployee>();
            model.AddRange(taskProcServise.Operators);
            model.AddRange(taskProcServise.Managers);
            model.AddRange(taskProcServise.Directors);

            return View(model);
        }

        public ActionResult Settings()
        {
            var model = new SettingsModel()
            {
                Tm = taskProcServise.Tm_milliseconds,
                Td = taskProcServise.Td_milliseconds
            };

            return View(model);
        }
    }
}
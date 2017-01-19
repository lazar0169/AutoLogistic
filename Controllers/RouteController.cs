using AutoLogistic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoLogistic.Controllers
{
    public class RouteController : Controller
    {
        // GET: Route
        public ActionResult Index()
        {
            var routes = Repository.GetAllRoutes();
            return View(routes);
        }

        public ActionResult Filter(RoutesViewModel model)
        {
            var routes = Repository.GetFilteredRoutes(model.FilterName, model.Filter);
            return View("Index", routes);
        }
    }
}
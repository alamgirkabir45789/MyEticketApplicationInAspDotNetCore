using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyEticketApplication.Models;
using MyEticketApplication.Repositories.IRepository;
using MyEticketApplication.ViewModels;

namespace MyEticketApplication.Controllers
{
    public class RouteFromController : Controller
    {
        private readonly IRouteFromRepository _routeFromRepository;

        public RouteFromController(IRouteFromRepository routeFromRepository)
        {
            _routeFromRepository = routeFromRepository;
        }
        public IActionResult Index()
        {
            var data=_routeFromRepository.GetAllFromRoute();
            return View(data);
        }

        public IActionResult Create( )
        {

            var data = _routeFromRepository.GetAllRouteToInfo();
            ViewData["data"] = new SelectList(data, "RouteToId", "RouteToName");

            return View();
        }

        [HttpPost]
        public IActionResult Create(RouteFrom routeFrom,RouteTo routeTo)
        {
             //ViewData["RouteCode"] = new SelectList(_context.Routes, "Code", "Code", routeTo.RouteCode);
            
            if (ModelState.IsValid)
            {

            _routeFromRepository.AddRouteFrom(routeFrom,routeTo);
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int RouteFromId)
        {
            if(RouteFromId == 0)
            {
                return NotFound();
            }
            _routeFromRepository.DeleteRouteFrom(RouteFromId);
            return RedirectToAction("Index");
        }
    }
}

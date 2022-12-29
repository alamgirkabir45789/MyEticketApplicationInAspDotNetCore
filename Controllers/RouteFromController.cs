using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyEticketApplication.Models;
using MyEticketApplication.Repositories.IRepository;
using MyEticketApplication.ViewModel;

namespace MyEticketApplication.Controllers
{
    public class RouteFromController : Controller
    {
        private readonly IRouteFromRepository _routeFromRepository;
        private readonly IRouteToRepository _routeToRepository;


        public RouteFromController(IRouteFromRepository routeFromRepository,IRouteToRepository routeToRepository)
        {
            _routeFromRepository = routeFromRepository;
            _routeToRepository = routeToRepository;
        }
        public IActionResult Index()
        {
            ViewBag.data = _routeFromRepository.GetAllFromRoute();          
          
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
        public IActionResult Create()
        {
            
            ViewData["RouteToDdl"] = _routeToRepository
         .GetRouteToInfo()
         .Select(c => new SelectListItem() { Text = c.RouteToName, Value = c.RouteToId.ToString() })
         .ToList();
          
            return View();
        }
        [HttpPost]
        public IActionResult Create(RouteFrom routeFrom)
        {

            if (routeFrom.RouteToId !=null)
            {
                var data = new RouteFrom()
                {
                    RouteFromName = routeFrom.RouteFromName,
                    RouteToId= routeFrom.RouteToId,
                };
                _routeFromRepository.AddRouteFrom(data);
                return RedirectToAction("Index");

            }
            else
            {
                return View();
            }           
           
        }

        public IActionResult Edit(int routeFromId)
        {
            var routeFrom=_routeFromRepository.GetRouteFromById (routeFromId);
            ViewData["RouteToDdl"] = _routeToRepository
         .GetRouteToInfo()
         .Select(c => new SelectListItem() { Text = c.RouteToName, Value = c.RouteToId.ToString() })
         .ToList();
            return View(routeFrom);
        }
        [HttpPost]
        public IActionResult Edit(RouteFrom routeFrom)
        {
            if(routeFrom.RouteFromId !=null)
            {
                var data = new RouteFrom()
                {
                    RouteFromId= routeFrom.RouteFromId,
                    RouteFromName = routeFrom.RouteFromName,
                    RouteToId = routeFrom.RouteToId,
                };
                _routeFromRepository.UpdateRouteFrom(data);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}

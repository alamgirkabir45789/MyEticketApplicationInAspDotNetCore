using Microsoft.AspNetCore.Mvc;
using MyEticketApplication.Models;
using MyEticketApplication.Repositories.IRepository;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyEticketApplication.Controllers
{
    public class RouteToController : Controller
    {
        private readonly IRouteToRepository _routeToRepository;
        public RouteToController(IRouteToRepository routeToRepository)
        {
            _routeToRepository = routeToRepository;
        }

        public IActionResult Index()
        {
            var routeToInfo=_routeToRepository.GetRouteToInfo();
            return View(routeToInfo);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RouteTo routeTo)
        {
            if (routeTo.RouteToName !=null)
            {
                _routeToRepository.AddRouteTo(routeTo);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int RouteToId)
        {
            if(RouteToId == 0)
            {
                return NotFound();
            }
                _routeToRepository.DeleteRouteTo(RouteToId);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int RouteToId)
        {
            if (RouteToId == 0)
            {
                return NotFound();
            }
            var routeTo = _routeToRepository.GetRouteToByRouteId(RouteToId);
            return View(routeTo);
        }
        [HttpPost]
        public IActionResult Edit ( RouteTo routeTo)
        {
            if (routeTo.RouteToId != null)
            {
                RouteTo data = new RouteTo()
                {
                    RouteToId = routeTo.RouteToId,
                    RouteToName = routeTo.RouteToName
                };
                _routeToRepository.UpdateRouteTo(data);
                return RedirectToAction("Index");

            }
            else
            {
                return NotFound();
            }
          
          
        }
    }
}

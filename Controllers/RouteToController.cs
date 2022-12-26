using Microsoft.AspNetCore.Mvc;
using MyEticketApplication.Models;
using MyEticketApplication.Repositories.IRepository;

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
            if (ModelState.IsValid)
            {
                _routeToRepository.AddRouteTo(routeTo);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}

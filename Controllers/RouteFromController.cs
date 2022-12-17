using Microsoft.AspNetCore.Mvc;
using MyEticketApplication.Repositories.IRepository;

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

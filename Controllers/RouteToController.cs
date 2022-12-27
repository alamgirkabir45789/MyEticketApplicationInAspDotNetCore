using Microsoft.AspNetCore.Mvc;
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
            var data=_routeToRepository.GetRouteToInfo();
            return View(data);
        }
    }
}

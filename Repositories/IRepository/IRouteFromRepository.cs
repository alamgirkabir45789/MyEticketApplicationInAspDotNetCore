using MyEticketApplication.Models;

namespace MyEticketApplication.Repositories.IRepository
{
    public interface IRouteFromRepository
    {
        IEnumerable<RouteFrom> GetAllFromRoute();
        RouteFrom GetRouteFromById(int id);  
        RouteFrom DeleteRouteFrom(int id);
        RouteFrom AddRouteFrom(RouteFrom routeFrom);
        RouteFrom UpdateRouteFrom(RouteFrom routeFrom);
    }
}

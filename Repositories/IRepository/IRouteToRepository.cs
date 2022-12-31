using MyEticketApplication.Models;

namespace MyEticketApplication.Repositories.IRepository
 {
    public interface IRouteToRepository
    {
    IEnumerable<RouteTo> GetRouteToInfo();
        RouteTo AddRouteTo(RouteTo routeTo);
        RouteTo DeleteRouteTo(int RouteToId);
        RouteTo GetRouteToByRouteId(int RouteToId);
        RouteTo UpdateRouteTo(RouteTo routeTo);
    }
}

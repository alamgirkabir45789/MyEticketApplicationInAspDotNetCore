using MyEticketApplication.Data;
using MyEticketApplication.Models;
using MyEticketApplication.Repositories.IRepository;

namespace MyEticketApplication.Repositories.Repository
{
    public class RouteToRepository : IRouteToRepository
    {
        private readonly ApplicationDbContext _context;
        public RouteToRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public RouteTo AddRouteTo(RouteTo routeTo)
        {
            _context.RouteToFroms.Add(routeTo);
            _context.SaveChanges();
            return routeTo;
        }

        public RouteTo DeleteRouteTo(int RouteToId)
        {
            var routeTo=_context.RouteToFroms.FirstOrDefault(f=>f.RouteToId== RouteToId);
            _context.RouteToFroms.Remove(routeTo);
            _context.SaveChanges();
            return routeTo;
        }

        public RouteTo GetRouteToByRouteId(int RouteToId)
        {
            var routeTo = _context.RouteToFroms.FirstOrDefault(f => f.RouteToId == RouteToId);
            return routeTo;
        }

        public IEnumerable<RouteTo> GetRouteToInfo()
        {
            return _context.RouteToFroms;
        }

        public RouteTo UpdateRouteTo(RouteTo routeTo)
        {
           _context.RouteToFroms.Update(routeTo);
             _context.SaveChanges();
            return routeTo;
            
        }
    }
}

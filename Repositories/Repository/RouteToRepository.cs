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

        public IEnumerable<RouteTo> GetRouteToInfo()
        {
            return _context.RouteToFroms;
        }

        
    }
}

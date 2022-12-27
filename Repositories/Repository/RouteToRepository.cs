using MyEticketApplication.Data;
using MyEticketApplication.Models;
using MyEticketApplication.Repositories.IRepository;

namespace MyEticketApplication.Repositories.Repository
{
    public class RouteToRepository : IRouteToRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public RouteToRepository(ApplicationDbContext dbContext)
        {
            _dbContext= dbContext;
        }
        public IEnumerable<RouteTo> GetRouteToInfo()
        {
            return _dbContext.RouteToFroms.ToList();
        }
    }
}

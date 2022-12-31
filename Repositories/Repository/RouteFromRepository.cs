using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using MyEticketApplication.Data;
using MyEticketApplication.Models;
using MyEticketApplication.Repositories.IRepository;

namespace MyEticketApplication.Repositories.Repository
{
    public class RouteFromRepository: IRouteFromRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public RouteFromRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<RouteFrom> GetAllFromRoute()
        {
            return _dbContext.RouteFroms.Include(r => r.RouteTo).AsNoTracking().ToList();
        }
        public RouteFrom GetRouteFromById(int id)
        {


            return _dbContext.RouteFroms.SingleOrDefault(i => i.RouteFromId == id);
        }
        public RouteFrom DeleteRouteFrom(int id)
        {
            RouteFrom routeFrom = _dbContext.RouteFroms.Find(id);
            if (routeFrom != null)
            {
                _dbContext.RouteFroms.Remove(routeFrom);
                _dbContext.SaveChanges();
            }
            return routeFrom;
        }

        public RouteFrom AddRouteFrom(RouteFrom routeFrom)
        {

            _dbContext.RouteFroms.Add(routeFrom);
            _dbContext.SaveChanges();
            return routeFrom;
        }
        public RouteFrom UpdateRouteFrom(RouteFrom routeFrom)
        {

            _dbContext.RouteFroms.Update(routeFrom);
            _dbContext.SaveChanges();
            return routeFrom;
        }

    }
}

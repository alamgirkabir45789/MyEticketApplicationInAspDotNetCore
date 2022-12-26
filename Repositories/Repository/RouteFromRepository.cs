using Microsoft.AspNetCore.Http.HttpResults;
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
            return _dbContext.RouteFroms;
        }
        public RouteFrom GetRouteFromById(int id)
        {
            return _dbContext.RouteFroms.SingleOrDefault(i => i.RouteFromId == id);
        }
        public RouteFrom DeleteRouteFrom(int id)
        {
            RouteFrom routeFrom = _dbContext.RouteFroms.Find(id);
            if(routeFrom != null)
            {
                _dbContext.RouteFroms.Remove(routeFrom);
                _dbContext.SaveChanges();                                                                                                                                                                                                                                           
            }
            return routeFrom;
        }

        public RouteFrom AddRouteFrom(RouteFrom routeFrom,RouteTo routeTo)
        {
            var routeToId = new RouteTo();
            var data = new RouteFrom()
            {
                RouteFromName = routeFrom.RouteFromName,
                RouteTo = routeToId?.RouteToId
            };
            _dbContext.RouteFroms.Add(data);
            _dbContext.SaveChanges();
            return routeFrom;
        }

        public IEnumerable<RouteTo> GetAllRouteToInfo()
        {
            return _dbContext.RouteToFroms;
        }

       

    }
}

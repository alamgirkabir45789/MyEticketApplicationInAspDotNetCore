﻿using MyEticketApplication.Models;

namespace MyEticketApplication.Repositories.IRepository
{
    public interface IRouteToRepository
    {
        IEnumerable<RouteTo> GetRouteToInfo();
    }
}

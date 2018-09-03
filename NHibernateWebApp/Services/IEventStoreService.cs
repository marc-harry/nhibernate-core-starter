using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NHibernateWebApp.Services
{
    public interface IEventStoreService
    {
        Task SendEventAsync<T>(T eventData);
        Task<IEnumerable<T>> ReadEventsAsync<T>(int pageSize = 10, long pageNumber = 1);
    }
}

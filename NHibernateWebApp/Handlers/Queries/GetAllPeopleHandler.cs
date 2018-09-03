using MediatR;
using NHibernateWebApp.Database;
using NHibernateWebApp.Models;
using NHibernateWebApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NHibernateWebApp.Handlers.Queries
{
    public class GetAllPeopleHandler : IRequestHandler<GetAllPeople, List<Person>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEventStoreService _eventStoreService;

        public GetAllPeopleHandler(IUnitOfWork unitOfWork, IEventStoreService eventStoreService)
        {
            _unitOfWork = unitOfWork;
            _eventStoreService = eventStoreService;
        }

        public Task<List<Person>> Handle(GetAllPeople request, CancellationToken cancellationToken)
        {
            var persons = _unitOfWork.Session.Query<Person>().ToList();

            var events = _eventStoreService.ReadEventsAsync<Person>().Result;


            return Task.FromResult(events.ToList());
        }
    }
}

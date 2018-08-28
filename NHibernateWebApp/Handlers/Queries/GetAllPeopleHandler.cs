using MediatR;
using NHibernateWebApp.Database;
using NHibernateWebApp.Models;
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

        public GetAllPeopleHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<List<Person>> Handle(GetAllPeople request, CancellationToken cancellationToken)
        {
            var persons = _unitOfWork.Session.Query<Person>().ToList();

            return Task.FromResult(persons);
        }
    }
}

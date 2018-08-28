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
    public class GetPersonByIdHandler : IRequestHandler<GetPersonById, Person>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPersonByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Person> Handle(GetPersonById request, CancellationToken cancellationToken)
        {
            var person = await _unitOfWork.Session.GetAsync<Person>(request.Id);
            return person;
        }
    }
}

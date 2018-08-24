using MediatR;
using NHibernateWebApp.Database;
using NHibernateWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NHibernateWebApp.Handlers.Commands
{
    public class AddNewPersonHandler : AsyncRequestHandler<AddNewPerson>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddNewPersonHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected override Task Handle(AddNewPerson request, CancellationToken cancellationToken)
        {
            var person = new Person { Name = request.Name };

            if (!string.IsNullOrWhiteSpace(request.AddressLine1)
                && !string.IsNullOrWhiteSpace(request.Postcode))
            {
                person.Address = new Address
                {
                    AddressLineOne = request.AddressLine1,
                    AddressLineTwo = request.AddressLine2,
                    City = request.City,
                    Postcode = request.Postcode
                };
            }

            _unitOfWork.Session.Save(person);

            return Task.CompletedTask;
        }
    }
}

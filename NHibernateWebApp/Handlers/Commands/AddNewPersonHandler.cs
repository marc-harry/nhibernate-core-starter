using MediatR;
using NHibernateWebApp.Database;
using NHibernateWebApp.Models;
using NHibernateWebApp.Services;
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
        private readonly IEventStoreService _eventStoreService;

        public AddNewPersonHandler(IUnitOfWork unitOfWork, IEventStoreService eventStoreService)
        {
            _unitOfWork = unitOfWork;
            _eventStoreService = eventStoreService;
        }

        protected override async Task Handle(AddNewPerson request, CancellationToken cancellationToken)
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

            await _eventStoreService.SendEventAsync(person);
        }
    }
}

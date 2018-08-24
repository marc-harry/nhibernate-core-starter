using MediatR;
using NHibernateWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NHibernateWebApp.Handlers.Queries
{
    public class GetPersonById : IRequest<Person>
    {
        public long Id { get; set; }
    }
}

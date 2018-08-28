using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NHibernateWebApp.Database;
using NHibernateWebApp.DataContracts;
using NHibernateWebApp.Handlers.Commands;
using NHibernateWebApp.Handlers.Queries;

namespace NHibernateWebApp.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IMediator _mediator;

        public ValuesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            var people = await _mediator.Send(new GetAllPeople());
            return people.Select(p => p.Name);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<string> Get(long id)
        {
            var person = await _mediator.Send(new GetPersonById { Id = id });
            return person?.Name;
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody]AddNewPerson addPerson)
        {
            await _mediator.Send(addPerson);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

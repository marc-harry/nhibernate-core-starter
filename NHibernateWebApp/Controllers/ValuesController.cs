using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NHibernateWebApp.Database;
using NHibernateWebApp.DataContracts;
using NHibernateWebApp.Models;

namespace NHibernateWebApp.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ValuesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var persons = _unitOfWork.Session.Query<Person>().ToList();

            return persons.Select(p => p.Name);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(long id)
        {
            var person = _unitOfWork.Session.Get<Person>(id);
            return person?.Name;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]AddPerson addPerson)
        {
            var person = new Person { Name = addPerson.Name };

            if (!string.IsNullOrWhiteSpace(addPerson.AddressLine1)
                && !string.IsNullOrWhiteSpace(addPerson.Postcode))
            {
                person.Address = new Address
                {
                    AddressLineOne = addPerson.AddressLine1,
                    AddressLineTwo = addPerson.AddressLine2,
                    City = addPerson.City,
                    Postcode = addPerson.Postcode
                };
            }

            _unitOfWork.Session.Save(person);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NHibernateWebApp.Models
{
    public class Address : BaseEntity
    {
        public virtual string AddressLineOne { get; set; }
        public virtual string AddressLineTwo { get; set; }
        public virtual string City { get; set; }
        public virtual string Postcode { get; set; }
    }
}

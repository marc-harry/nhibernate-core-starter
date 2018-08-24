using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NHibernateWebApp.Models
{
    public class Person : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual Address Address { get; set; }
    }
}

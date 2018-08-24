using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NHibernateWebApp.Models
{
    public class BaseEntity
    {
        public virtual long Id { get; set; }
        public virtual DateTime? CreatedDate { get; set; }
    }
}

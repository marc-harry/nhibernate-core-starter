using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NHibernateWebApp.Database
{
    public interface IUnitOfWork
    {
        ISession Session { get; }
        void Complete();
    }
}

using NHibernate;
using System;

namespace NHibernateWebApp.Database
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly NHibernateConfiguration _configuration;
        private ISession _session;

        public UnitOfWork(NHibernateConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ISession Session
        {
            get
            {
                if (_session == null)
                {
                    _session = _configuration.GetConfiguration().BuildSessionFactory().OpenSession();
                    _session.Transaction.Begin();
                }
                return _session;
            }
        }

        public void Complete()
        {
            if (_session != null)
            {
                try
                {
                    if (_session.Transaction.IsActive)
                    {
                        _session.Transaction.Commit();
                    }
                }
                catch
                {
                    _session.Transaction.Rollback();
                    throw;
                }
                finally
                {
                    _session.Clear();
                }
            }
        }

        public void Dispose()
        {
            try
            {
                Complete();
            }
            finally
            {
                _session?.Dispose();
            }
        }
    }
}

using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;
using NHibernateWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NHibernateWebApp.Database
{
    public class NHibernateConfiguration
    {
        private Configuration _configuration = null;

        public Configuration GetConfiguration()
        {
            if (_configuration != null)
            {
                return _configuration;
            }

            Configuration cfg = new Configuration();
            cfg.DataBaseIntegration(db =>
            {
                db.ConnectionString = "Server=localhost;Integrated Security=SSPI;Database=nhibernatetestdb";
                db.Dialect<MsSql2012Dialect>();
                db.Driver<Sql2008ClientDriver>();
            });

            var mapper = new ConventionModelMapper();

            Type baseEntityType = typeof(BaseEntity);
            mapper.IsEntity((t, _) => baseEntityType.IsAssignableFrom(t) && baseEntityType != t && !t.IsInterface);
            mapper.IsRootEntity((t, _) => baseEntityType == t.BaseType);
            mapper.Class<BaseEntity>(t => t.Id(e => e.Id, m => m.Generator(new IdentityGeneratorDef())));
            mapper.BeforeMapManyToOne += (i, p, m) => m.Cascade(Cascade.Persist);
            mapper.BeforeMapList += (i, p, m) => m.Cascade(Cascade.Persist);
            mapper.BeforeMapSet += (i, p, m) => m.Cascade(Cascade.Persist);
            mapper.BeforeMapBag += (i, p, m) => m.Cascade(Cascade.Persist);

            var mapping = mapper.CompileMappingFor(typeof(BaseEntity).Assembly.ExportedTypes.Where(t => typeof(BaseEntity).IsAssignableFrom(t)));

            cfg.AddMapping(mapping);

            _configuration = cfg;

            var updateSchema = new SchemaUpdate(_configuration);
            updateSchema.Execute(false, true);

            return _configuration;
        }
    }
}

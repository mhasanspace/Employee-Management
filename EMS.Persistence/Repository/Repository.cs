using EMS.Persistence.DBaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Persistence.Repository
{
    public class Repository<TEntity> : RepositoryBase<EmsDbContext, TEntity> where TEntity : class
    {
        public Repository(EmsDbContext context) : base(context)
        {

        }
    }
}

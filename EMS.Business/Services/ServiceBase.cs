using EMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Business.Services
{
    public abstract class ServiceBase
    {
        protected readonly IUnitOfWork UnitOfWorkSB;

        public ServiceBase(IUnitOfWork unitOfWork)
        {
            UnitOfWorkSB = unitOfWork;
        }
    }
}

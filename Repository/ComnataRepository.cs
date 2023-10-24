using Entities.Models;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Contracts.Contracts;

namespace Repository
{
    public class ComnataRepository : RepositoryBase<Comnata>, IcomnataRepository
    {
        public ComnataRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public void AnyMethodFromCompanyRepository()
        {
            throw new NotImplementedException();
        }
    }
    public class HumanRepository : RepositoryBase<Human>, IhumanRepository
    {
        public HumanRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public void AnyMethodFromEmployeeRepository()
        {
            throw new NotImplementedException();
        }
    }
}

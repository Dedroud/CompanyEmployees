using Entities.Models;
using Entities;
using static Contracts.Contracts;

namespace Repository
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public void AnyMethodFromCompanyRepository()
        {
            throw new NotImplementedException();
        }
    }
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public void AnyMethodFromEmployeeRepository()
        {
            throw new NotImplementedException();
        }
    }
}

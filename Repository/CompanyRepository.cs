using Entities.Models;
using Entities;
using Contracts;

namespace Repository
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }
        public IEnumerable<Company> GetAllCompanies(bool trackChanges) =>
FindAll(trackChanges)
 .OrderBy(c => c.Name)
 .ToList();

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

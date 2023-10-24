
using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Contracts.Contracts;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private ICompanyRepository _companyRepository;
        private IEmployeeRepository _employeeRepository;
        private IcomnataRepository _comnataRepository;
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public ICompanyRepository Company
        {
            get
            {
                if (_companyRepository == null)
                    _companyRepository = new CompanyRepository(_repositoryContext);
                return _companyRepository;
            }
        }
        public IEmployeeRepository Employee
        {
            get
            {

                if (_employeeRepository == null)
                    _employeeRepository = new EmployeeRepository(_repositoryContext);
                return _employeeRepository;
            }
        }


        public IcomnataRepository student
        {
            get
            {
                if (_comnataRepository == null)
                    _comnataRepository = new ComnataRepository(_repositoryContext);
                return _comnataRepository;
            }
        }

        public IcomnataRepository Comnata => throw new NotImplementedException();

        public IhumanRepository Human => throw new NotImplementedException();

        ILoggerManager IRepositoryManager.LoggerManager => throw new NotImplementedException();

        public void Save() => _repositoryContext.SaveChanges();
    }
}


using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private ICompanyRepository _companyRepository;
        private IEmployeeRepository _employeeRepository;
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


        public ILoggerManager LoggerManager => throw new NotImplementedException();

        ICompanyRepository IRepositoryManager.Company => throw new NotImplementedException();

        IEmployeeRepository IRepositoryManager.Employee => throw new NotImplementedException();

        ILoggerManager IRepositoryManager.LoggerManager => throw new NotImplementedException();

        Contracts.IComnataRepository IRepositoryManager.Comnata => throw new NotImplementedException();

        IHumanRepository IRepositoryManager.Human => throw new NotImplementedException();

        public void Save() => _repositoryContext.SaveChanges();

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        void IRepositoryManager.Save()
        {
            throw new NotImplementedException();
        }

        Task IRepositoryManager.SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}

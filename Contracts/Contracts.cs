using Entities.Models;
using System.Linq.Expressions;



namespace Contracts
{
    public interface IHumanRepository 
    {

    }

    public interface IComnataRepository 
    {

    }

    public interface ICompanyRepository
    {
        void AnyMethodFromCompanyRepository();
        IEnumerable<Company> GetAllCompanies(bool trackChanges);
        Company GetCompany(Guid companyId, bool trackChanges);
    }

    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees(Guid companyId, bool trackChanges);
        Employee GetEmployee(Guid companyId, Guid id, bool trackChanges);
    }

    public interface ILoggerManager
    {
        void LogInfo(string message);
        void LogWarn(string message);
        void LogDebug(string message);
        void LogError(string message);
    }

    public interface IRepositoryManager
    {
        ICompanyRepository Company { get; }
        IEmployeeRepository Employee { get; }
        IComnataRepository Comnata { get; }
        IHumanRepository Human { get; } 
        ILoggerManager LoggerManager { get; }
        void Save();
    }
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll(bool trackChanges);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }

}

    


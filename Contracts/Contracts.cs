using Entities.Models;
using Entities.RequestFeatures;
using System.Diagnostics;
using System.Linq.Expressions;



namespace Contracts
{

    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetAllCompaniesAsync(bool trackChanges);
        Task<Company> GetCompany(Guid companyId, bool trackChanges);
        void CreateCompany(Company company);
        Task<IEnumerable<Company>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
        void DeleteCompany(Company company);
    }

    public interface IEmployeeRepository
    {
        Task<PagedList<Employee>> GetEmployeesAsync(Guid companyId, EmployeeParameters employeeParameters, bool trackChanges);
        Task<Employee> GetEmployeeAsync(Guid companyId, Guid id, bool trackChanges);
        void CreateEmployeeForCompany(Guid companyId, Employee employee);
        void DeleteEmployee(Employee employee);
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
        ILoggerManager LoggerManager { get; }
        IComnataRepository Comnata { get; }
        IHumanRepository Human { get; }
        void Save();
        Task SaveAsync();
    }
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll(bool trackChanges);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
    public interface IHumanRepository
    {
        Task<PagedList<Human>> GetHumanAsync(Guid gradeId, HumanParameters HumanParameters, bool trackChanges);
        Task<Human> GetHumanAsync(Guid gradeId, Guid id, bool trackChanges);
        void CreateHumanForComnata(Guid gradeId, Human Human);
        void DeleteHuman(Human Human);
        Task GetComnataAsync(Guid comnataId, bool trackChanges);
    }
    public interface IComnataRepository
    {
        Task<IEnumerable<Comnata>> GetAllComnatasAsync(bool trackChanges);
        Task<Comnata> GetComnataAsync(Guid ComnataId, bool trackChanges);
        void CreateComnata(Comnata Comnata);
        Task<IEnumerable<Comnata>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
        void DeleteComnata(Comnata Comnata);
    }

    public class HumanParameters : EmployeeParameters
    {

    }

}

    


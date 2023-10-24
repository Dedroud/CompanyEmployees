using System.Linq.Expressions;
using static Contracts.Contracts;

namespace Contracts
{
    public class Contracts
    {
        public interface IhumanRepository
        {

        }
        public interface IcomnataRepository
        {

        }
        public interface ICompanyRepository
        {
            void AnyMethodFromCompanyRepository();
        }
        public interface IEmployeeRepository
        {
            void AnyMethodFromEmployeeRepository();
        }

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
        IcomnataRepository Comnata { get; }
        IhumanRepository Human { get; }
        ILoggerManager LoggerManager { get; }
        void Save();
    }
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll(bool trackChanges);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression,
        bool trackChanges);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);

    }


}
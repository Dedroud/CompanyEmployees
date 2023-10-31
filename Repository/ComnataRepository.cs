using Entities.Models;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities.RequestFeatures;

namespace Repository
{
    public class ComnataRepository : RepositoryBase<Comnata>, IComnataRepository
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

    internal interface IComnataRepository
    {
    }

    public class HumanRepository : RepositoryBase<Human>, IHumanRepository
    {
        public HumanRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public void AnyMethodFromEmployeeRepository()
        {
            throw new NotImplementedException();
        }

        public Task GetComnataAsync(Guid comnataId, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        void IHumanRepository.CreateHumanForComnata(Guid gradeId, Human Human)
        {
            throw new NotImplementedException();
        }

        void IHumanRepository.DeleteHuman(Human Human)
        {
            throw new NotImplementedException();
        }

        Task<PagedList<Human>> IHumanRepository.GetHumanAsync(Guid gradeId, HumanParameters HumanParameters, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        Task<Human> IHumanRepository.GetHumanAsync(Guid gradeId, Guid id, bool trackChanges)
        {
            throw new NotImplementedException();
        }
    }
}

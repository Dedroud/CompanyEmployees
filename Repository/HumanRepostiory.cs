using Entities.RequestFeatures;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Contracts;
using Microsoft.EntityFrameworkCore;



namespace Repository
{
    public class HumanRepostiory : RepositoryBase<Human>, IHumanRepository
    {
        public HumanRepostiory(RepositoryContext repositoryContext) : base(repositoryContext) { }
        public async Task<PagedList<Human>> GetHumanAsync(Guid ComnataId, HumanParameters HumanParameters, bool trackChanges)
        {
            var Human = await FindByCondition(e => e.ComnataId.Equals(ComnataId) && e.Age >= HumanParameters.MinAge && e.Age <= HumanParameters.MaxAge, trackChanges)
                .OrderBy(e => e.Name)
                .ToListAsync();
            return PagedList<Human>
                .ToPagedList(Human, HumanParameters.PageNumber, HumanParameters.PageSize);
        }


        public async Task<Human> GetHumanAsync(Guid ComnataId, Guid id, bool trackChanges) => await FindByCondition(e => e.ComnataId.Equals(ComnataId) && e.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();
        public void CreateHumanForComnata(Guid ComnataId, Human Human)
        {
            Human.ComnataId = ComnataId;
            Create(Human);
        }
        public void DeleteComnata(Human Human)
        {
            Delete(Human);
        }

        Task<PagedList<Human>> IHumanRepository.GetHumanAsync(Guid gradeId, HumanParameters HumanParameters, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        Task<Human> IHumanRepository.GetHumanAsync(Guid gradeId, Guid id, bool trackChanges)
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

        public Task GetComnataAsync(Guid comnataId, bool trackChanges)
        {
            throw new NotImplementedException();
        }
    }
}

using AutoMapper;
using CompanyEmployees.ActionFilters;
using CompanyEmployees.ModelBinders;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CompanyEmployees.Controllers
{
    [Route("api/Comnata")]
    [ApiController]
    public class ComnataController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public ComnataController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetComnatas()
        {
            var Comnatas = await _repository.Comnata.GetAllComnatasAsync(trackChanges: false);
            var ComnataDto = _mapper.Map<IEnumerable<ComnataDto>>(Comnatas);
            return Ok(ComnataDto);
        }
        [HttpGet("{id}", Name = "ComnataById")]
        public async Task<IActionResult> GetComnata(Guid id)
        {
            var Comnata = await _repository.Comnata.GetComnataAsync(id, trackChanges: false);
            if (Comnata == null)
            {
                _logger.LogInfo($"Comnata with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var ComnataDto = _mapper.Map<ComnataDto>(Comnata);
                return Ok(ComnataDto);
            }
        }
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateComnata([FromBody] ComnataForCreationDto Comnata)
        {
            var ComnataEntity = _mapper.Map<Comnata>(Comnata);
            _repository.Comnata.CreateComnata(ComnataEntity);
            await _repository.SaveAsync();
            var ComnataToReturn = _mapper.Map<ComnataDto>(ComnataEntity);
            return CreatedAtRoute("ComnataById", new { id = ComnataToReturn.Id },
            ComnataToReturn);
        }
        [HttpGet("collection/({ids})", Name = "ComnataCollection")]
        public async Task<IActionResult> GetComnataCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            if (ids == null)
            {
                _logger.LogError("Parameter ids is null");
                return BadRequest("Parameter ids is null");
            }
            var ComnataEntities = await _repository.Comnata.GetByIdsAsync(ids, trackChanges: false);
            if (ids.Count() != ComnataEntities.Count())
            {
                _logger.LogError("Some ids are not valid in a collection");
                return NotFound();
            }
            var ComnatasToReturn =
           _mapper.Map<IEnumerable<ComnataDto>>(ComnataEntities);
            return Ok(ComnatasToReturn);
        }
        [HttpPost("collection")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateComnataCollection([FromBody] IEnumerable<ComnataForCreationDto> ComnataCollection)
        {
            var ComnataEntities = _mapper.Map<IEnumerable<Comnata>>(ComnataCollection);
            foreach (var Comnata in ComnataEntities)
            {
                _repository.Comnata.CreateComnata(Comnata);
            }
            await _repository.SaveAsync();
            var ComnataCollectionToReturn =
            _mapper.Map<IEnumerable<ComnataDto>>(ComnataEntities);
            var ids = string.Join(",", ComnataCollectionToReturn.Select(c => c.Id));
            return CreatedAtRoute("ComnataCollection", new { ids },
           ComnataCollectionToReturn);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComnata(Guid id)
        {
            var Comnata = await _repository.Comnata.GetComnataAsync(id, trackChanges: false);
            if (Comnata == null)
            {
                _logger.LogInfo($"Comnata with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            _repository.Comnata.DeleteComnata(Comnata);
            await _repository.SaveAsync();
            return NoContent();
        }
        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidateComnataExistsAttribute))]
        public async Task<IActionResult> UpdateComnata(Guid id, [FromBody] ComnataForUpdateDto Comnata)
        {
            var ComnataEntity = HttpContext.Items["Comnata"] as Comnata;
            _mapper.Map(Comnata, ComnataEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}

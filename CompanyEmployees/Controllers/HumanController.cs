using AutoMapper;
using Azure;
using CompanyEmployees.ActionFilters;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CompanyEmployees.Controllers
{
    [Route("api/Comnata/{gradeId}/Human")]
    [ApiController]
    public class HumanController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private object ComnataId;

        public HumanController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetHumanForComnata(Guid ComnataId, [FromQuery] HumanParameters HumanParameters)
        {
            if (!HumanParameters.ValidAgeRange)
                return BadRequest("Max age can't be less than min age.");
            var Comnata = await _repository.Comnata.GetComnataAsync(ComnataId, trackChanges: false);
            if (Comnata == null)
            {
                _logger.LogInfo($"Comnata with id: {ComnataId} doesn't exist in the database.");
                return NotFound();
            }
            var HumanFromDb = await _repository.Human.GetHumanAsync(ComnataId, HumanParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(HumanFromDb.MetaData));
            var HumanDto = _mapper.Map<IEnumerable<HumanDto>>(HumanFromDb);
            return Ok(HumanDto);
        }
        [HttpGet("{id}", Name = "GetHumanForComnata")]
        public async Task<IActionResult> GetHumanForComnata(Guid ComnataId, Guid id)
        {
            var Comnata = await _repository.Comnata.GetComnataAsync(ComnataId, trackChanges: false);
            if (Comnata == null)
            {
                _logger.LogInfo($"Human with id: {ComnataId} doesn't exist in the database.");
                return NotFound();
            }
            var HumanDb = await _repository.Human.GetHumanAsync(ComnataId, id, trackChanges: false);
            if (HumanDb == null)
            {
                _logger.LogInfo($"Human with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            var Human = _mapper.Map<HumanDto>(HumanDb);
            return Ok(Human);
        }
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateHumanForComnata(Guid ComnataId, [FromBody] HumanForCreationDto Human)
        {
            var Comnata = await _repository.Comnata.GetComnataAsync(ComnataId, trackChanges: false);
            if (Comnata == null)
            {
                _logger.LogInfo($"Comnata with id: {ComnataId} doesn't exist in the database.");
                return NotFound();
            }
            var HumanEntity = _mapper.Map<Human>(Human);
            _repository.Human.CreateHumanForComnata(ComnataId, HumanEntity);
            await _repository.SaveAsync();
            var HumanToReturn = _mapper.Map<HumanDto>(HumanEntity);
            return CreatedAtRoute("GetHumantForComnata", new
            {
                ComnataId,
                id = HumanToReturn.Id
            }, HumanToReturn);
        }
        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ValidateHumanForComnataExistsAttribute))]
        public async Task<IActionResult> DeleteHumanForComnata(Guid ComnataId, Guid id)
        {
            var HumanForGrade = HttpContext.Items["Human"] as Human;
            _repository.Human.DeleteHuman(HumanForGrade);
            await _repository.SaveAsync();
            return NoContent();
        }
        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidateHumanForComnataExistsAttribute))]
        public async Task<IActionResult> UpdateHumanForComnata(Guid comnataId, Guid id, [FromBody] HumanForUpdateDto Human)
        {
            var HumanEntity = HttpContext.Items["Human"] as Human;
            _mapper.Map(Human, HumanEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
        [HttpPatch("{id}")]
        [ServiceFilter(typeof(ValidateHumanForComnataExistsAttribute))]
        public async Task<IActionResult> PartiallyUpdateHumanForComnata(Guid comnataId, Guid id, [FromBody] JsonPatchDocument<HumanForUpdateDto> patchDoc)
        {
            var grade = await _repository.Comnata.GetComnataAsync(comnataId, trackChanges: false);
            if (grade == null)
            {
                _logger.LogInfo($"Comnata with id: {comnataId} doesn't exist in the database.");
                return NotFound();
            }
            var HumanEntity = HttpContext.Items["Human"] as Human;
            if (HumanEntity == null)
            {
                _logger.LogInfo($"Human with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            var studentToPatch = _mapper.Map<HumanForUpdateDto>(HumanEntity);
            patchDoc.ApplyTo(studentToPatch, (Microsoft.AspNetCore.JsonPatch.Adapters.IObjectAdapter)ModelState);
            TryValidateModel(studentToPatch);
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the patch document");
                return UnprocessableEntity(ModelState);
            }
            _mapper.Map(studentToPatch, HumanEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}

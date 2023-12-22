using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CompanyEmployees.Controllers
{
    [Route("api/comnata")]
    [ApiController]
    public class ComnataV2Controller : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        public ComnataV2Controller(IRepositoryManager repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> GetComnata()
        {
            var comnata = await _repository.Comnata.GetAllComnatasAsync(trackChanges: false);
            return Ok(comnata);
        }
    }
}

using Contracts;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Entities.Models;

namespace CompanyEmployees.ActionFilters
{
    public class ValidateHumanForComnataExistsAttribute : IAsyncActionFilter
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        public ValidateHumanForComnataExistsAttribute(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var method = context.HttpContext.Request.Method;
            var trackChanges = (method.Equals("PUT") || method.Equals("PATCH")) ? true : false;
            var ComnataId = (Guid)context.ActionArguments["ComnataId"];
            var Comnata = await _repository.Comnata.GetComnataAsync(ComnataId, false);
            if (Comnata == null)
            {
                _logger.LogInfo($"Comnata with id: {ComnataId} doesn't exist in the database.");
                return;
                context.Result = new NotFoundResult();
            }
            var id = (Guid)context.ActionArguments["id"];
            var Human = await _repository.Human.GetHumanAsync(ComnataId, id, trackChanges);
            if (Human == null)
            {
                _logger.LogInfo($"Human with id: {id} doesn't exist in the database.");
                context.Result = new NotFoundResult();
            }
            else
            {
                context.HttpContext.Items.Add("Human", Human);
                await next();
            }
        }
    }
}

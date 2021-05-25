using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Scheduler.Service.Api.Controllers
{
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        private readonly ICollection<string> _errors = new List<string>();

        protected new IActionResult Response(object result = null)
        {
            if (IsOperationValid())
            {
                return Ok(result);
            }

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Messages", _errors.ToArray() }
            }));
        }

        protected new IActionResult Response(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(e => e.Errors);
            foreach (var error in errors)
            {
                AddError(error.ErrorMessage);
            }

            return Response();
        }

        protected new IActionResult Response(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                AddError(error.ErrorMessage);
            }

            return Response();
        }

        protected bool IsOperationValid()
        {
            return !_errors.Any();
        }

        protected void AddError(string error)
        {
            _errors.Add(error);
        }

        protected void ClearErrors()
        {
            _errors.Clear();
        }
    }

}
using E_Commerce.Application.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiBaseController : ControllerBase
    {
        public static ActionResult<T> ToActionResult<T>(Result<T> result)
        {
            if (result.IsSuccess)
            {
                return new OkObjectResult(result.Data);
            }   
            return ToProblem(result.Errors);

        }
        public static ActionResult ToActionResult(Result result)
        {
            if (result.IsSuccess)
            {
                return new OkResult();
            }
            return ToProblem(result.Errors);

        }

        public static ObjectResult ToProblem(IReadOnlyList<Error> Errors)
        {
            var firstError = Errors.First();
            var status = firstError.Type switch
            {
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.UnAuthorized => StatusCodes.Status401Unauthorized,
                ErrorType.Forbidden => StatusCodes.Status403Forbidden,
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                _ => StatusCodes.Status500InternalServerError

            };
            var problemDetails = new ProblemDetails
            {
                Status = status,
                Title = firstError.Code,
                Detail = firstError.Description,
                Extensions =
                {
                    ["errors"] = Errors
                }
            };
            return new ObjectResult(problemDetails)
            {
                StatusCode = status
            };
        }
    }
}

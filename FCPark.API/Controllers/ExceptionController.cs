using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;

namespace FCPark.API.Controllers
{
    public class ExceptionController : Controller
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        [Route("api/exception")]
        public IActionResult LogError()
        {
            var exFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            if (exFeature != null)
            {
                //Get the path where the eroor occured
                string path = exFeature.Path;

                //Get the Exception
                Exception ex = exFeature.Error;

                //Log in a flat fire or other storage
                Log.Error(ex, path);

                var error = new { ErrorMessage = ex.Message, ErrorPath = path };

                return BadRequest(error);

            }

            return BadRequest();
        }
    }
}

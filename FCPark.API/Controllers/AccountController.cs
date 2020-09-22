using FCPark.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FCPark.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : Controller
    {

        /// POST api/Login
        /// <summary>
        /// Autenticar na API
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     POST /Login
        ///     {
        ///        {
        ///           "userID": "admin_fcpark",
        ///           "password": "AdminFcPark2020!",
        ///           "grantType": "password"
        ///         }
        ///     }
        ///
        /// </remarks>
        /// <param name="credenciais"></param>
        /// <returns>Retorna JWT Token.</returns>
        /// <response code="201">Retorna um token válido.</response>
        /// <response code="400">Se o login for recusado.</response>  
        [AllowAnonymous]
        [HttpPost]
        public object Post(
            [FromBody]AccessCredentials credenciais,
            [FromServices]AccessManager accessManager)
        {
            if (accessManager.ValidateCredentials(credenciais))
            {
                return accessManager.GenerateToken(credenciais);
            }
            else
            {
                return new
                {
                    Authenticated = false,
                    Message = "Falha ao autenticar"
                };
            }
        }
    }
}

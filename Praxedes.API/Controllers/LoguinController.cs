using Praxedes.ADO.Maestros.Modelo;
using Praxedes.ADO.ToAPI;
using Praxedes.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace Praxedes.API.Controllers
{
    /// <summary>
    /// login controller class for authenticate users
    /// </summary>
    [AllowAnonymous]
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        /// <summary>
        /// Metodo que responde en Linea
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("echoping")]
        public IHttpActionResult EchoPing()
        {
            return Ok(true);
        }
        /// <summary>
        /// Valida Usuario
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("echouser")]
        public IHttpActionResult EchoUser()
        {
            var identity = Thread.CurrentPrincipal.Identity;
            return Ok($" IPrincipal-user: {identity.Name} - IsAuthenticated: {identity.IsAuthenticated}");
        }
        /// <summary>
        /// Autenticar Usuario
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("authenticate")]
        public IHttpActionResult Authenticate(LoguinRequest login)
        {
            if (login == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            LoguinRequestBack log = new LoguinRequestBack();
            log.Username = login.Username;
            log.Password = login.Password;
            bool isCredentialValid = new Service().ValidarUsuario(log);
            if (isCredentialValid)
            {
                var token = TokenGenerator.GenerateTokenJwt(login.Username);
                new Service().RegistrarToken(log, token);
                return Ok(token);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}

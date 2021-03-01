using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Praxedes.API.Models
{
    /// <summary>
    /// Controlador del loguin
    /// </summary>
    public class LoguinRequest
    {
        /// <summary>
        /// Usuario
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Contraseña
        /// </summary>
        public string Password { get; set; }
    }
}
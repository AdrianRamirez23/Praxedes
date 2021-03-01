using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Praxedes.API.Models
{
    /// <summary>
    /// Clase grupo familiar
    /// </summary>
    public class GrupoFamiliar
    {
        /// <summary>
        /// Variable login
        /// </summary>
        public LoguinRequest loguin { get; set; }
        /// <summary>
        /// Usuario ppal
        /// </summary>
        public string Usuario { get; set; }
        /// <summary>
        /// Cedula de integrante del grupo familiar
        /// </summary>
        public string Cedula { get; set; }
        /// <summary>
        /// Nombres de integrante del grupo familiar
        /// </summary>
        public string Nombres { get; set; }
        /// <summary>
        /// Apellidos de integrante del grupo familiar
        /// </summary>
        public string Apellidos { get; set; }
        /// <summary>
        /// Genero de integrante del grupo familiar
        /// </summary>
        public string Genero { get; set; }
        /// <summary>
        /// Parentesco de integrante del grupo familiar
        /// </summary>
        public string Parentesco { get; set; }
        /// <summary>
        /// Edad de integrante del grupo familiar
        /// </summary>
        public int Edad { get; set; }
        /// <summary>
        /// Menor de edad validacion
        /// </summary>
        public string MenorEdad { get; set; }
        /// <summary>
        /// Fecha de Nacimiento de integrante del grupo familiar
        /// </summary>
        public DateTime FechaNacimiento { get; set; }
    }
}
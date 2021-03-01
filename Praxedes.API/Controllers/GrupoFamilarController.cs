using Praxedes.ADO.Maestros.Modelo;
using Praxedes.ADO.ToAPI;
using Praxedes.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Praxedes.API.Controllers
{
    /// <summary>
    /// Controlador de grupo familiar
    /// </summary>
    [Authorize]
    [RoutePrefix("GrupoFamiliar")]
    public class GrupoFamilarController : ApiController
    {
        ///GET:api/GrupoFamiliar/ListarGrupoFamiliar
        /// <summary>
        /// Lista grupo familiar por usuario
        /// <param name="log"></param>
        /// </summary>
        /// <returns></returns>
        [Route("ListarGrupoFamiliar")]
        [HttpGet]
        public List<GrupoFamiliar> ListarGrupoFamiliar(LoguinRequest log)
        {
            try
            {
                LoguinRequestBack login = new LoguinRequestBack();
                login.Username = log.Username;
               
                List<GrupoFamiliarBack> FamBack = new List<GrupoFamiliarBack>();
                List<GrupoFamiliar> ListFam = new List<GrupoFamiliar>();
                FamBack = new Service().ListarGrupoFamiliar(login);

                foreach (GrupoFamiliarBack Fam in FamBack)
                {
                    GrupoFamiliar Famg = new GrupoFamiliar();
                    Famg.Usuario = Fam.Usuario;
                    Famg.Cedula = Fam.Cedula;
                    Famg.Nombres = Fam.Nombres;
                    Famg.Apellidos = Fam.Apellidos;
                    Famg.Genero = Fam.Genero;
                    Famg.Parentesco = Fam.Parentesco;
                    Famg.Edad = Fam.Edad;
                    Famg.MenorEdad = Fam.MenorEdad;
                    Famg.FechaNacimiento = Fam.FechaNacimiento;
                     
                    ListFam.Add(Famg);
                }
                return ListFam;
            }
            catch (Exception ex)
            {
                throw(ex);
            }
        }

        ///POST:api/GrupoFamiliar/CrearGrupoFamiliar
        /// <summary>
        /// Crea una nuevo integrante grupo familiar
        /// </summary>
        /// <param name="Fam"></param>
        /// <returns></returns>
        [Route("CrearGrupoFamiliar")]
        [HttpPost]
        public IHttpActionResult CrearGrupoFamiliar(GrupoFamiliar Fam)
        {
            try
            {
                if (Fam.Edad<18 && string.IsNullOrEmpty(Fam.FechaNacimiento.ToString()))
                {
                    return NotFound();
                }
                else
                {
                    GrupoFamiliarBack Famg = new GrupoFamiliarBack();

                    Famg.Usuario = Fam.Usuario;
                    Famg.Cedula = Fam.Cedula;
                    Famg.Nombres = Fam.Nombres;
                    Famg.Apellidos = Fam.Apellidos;
                    Famg.Genero = Fam.Genero;
                    Famg.Parentesco = Fam.Parentesco;
                    Famg.Edad = Fam.Edad;
                    Famg.MenorEdad = Fam.MenorEdad;
                    Famg.FechaNacimiento = Fam.FechaNacimiento;

                    new Service().CrearGrupoFamiliar(Famg);

                    return Ok();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        ///PUT:api/GrupoFamiliar/EditarGrupoFamiliar
        /// <summary>
        /// Edita un integrante grupo familiar
        /// </summary>
        /// <param name="Fam"></param>
        /// <returns></returns>
        [Route("EditarGrupoFamiliar")]
        [HttpPut]
        public IHttpActionResult EditarComunicacion(GrupoFamiliar Fam)
        {
            try
            {
                if (string.IsNullOrEmpty(Fam.Usuario))
                {
                    return NotFound();
                }
                else
                {
                    GrupoFamiliarBack Famg = new GrupoFamiliarBack();

                    Famg.Usuario = Fam.Usuario;
                    Famg.Cedula = Fam.Cedula;
                    Famg.Nombres = Fam.Nombres;
                    Famg.Apellidos = Fam.Apellidos;
                    Famg.Genero = Fam.Genero;
                    Famg.Parentesco = Fam.Parentesco;
                    Famg.Edad = Fam.Edad;
                    Famg.MenorEdad = Fam.MenorEdad;
                    Famg.FechaNacimiento = Fam.FechaNacimiento;

                    new Service().EditarGrupoFamiliar(Famg);

                    return Ok();
                }
            }
            catch (Exception ex)
            {

                throw(ex);
            }
        }
        ///DELETE:api/GrupoFamiliar/EliminarGrupoFamiliar
        /// <summary>
        /// Elimina una integrante del grupo familiar
        /// </summary>
        /// <param name="Fam"></param>
        /// <returns></returns>
        [Route("EliminarGrupoFamiliar")]
        [HttpDelete]
        public IHttpActionResult EliminarGrupoFamiliar(GrupoFamiliar Fam)
        {
            try
            {
                if (string.IsNullOrEmpty(Fam.Cedula))
                {
                    return NotFound();
                }
                else
                {
                    GrupoFamiliarBack Famg = new GrupoFamiliarBack();

                    Famg.Usuario = Fam.Usuario;
                    Famg.Cedula = Fam.Cedula;

                    new Service().EliminarGrupoFamiliar(Famg);

                    return Ok();
                }  
            }
            catch (Exception ex)
            {
                throw(ex);
            }
        }
    }
}

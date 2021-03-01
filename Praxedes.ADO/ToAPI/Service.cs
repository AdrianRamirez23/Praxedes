using Praxedes.ADO.Maestros.Modelo;
using Praxedes.ADO.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praxedes.ADO.ToAPI
{
    public class Service
    {
        public bool ValidarUsuario(LoguinRequestBack log)
        {
            return new LoguinBL().ValidarUsuario(log);
        }
        public void RegistrarToken(LoguinRequestBack log, string Token)
        {
            new LoguinBL().RegistrarToken(log, Token);
        }
        public List<GrupoFamiliarBack> ListarGrupoFamiliar(LoguinRequestBack log)
        {
            return new GrupoFamiliarBL().ListarGrupoFamiliar(log);
        }
        public void CrearGrupoFamiliar(GrupoFamiliarBack fam)
        {
            new GrupoFamiliarBL().CrearGrupoFamiliar(fam);
        }
        public void EditarGrupoFamiliar(GrupoFamiliarBack fam)
        {
            new GrupoFamiliarBL().EditarGrupoFamiliar(fam);
        }
        public void EliminarGrupoFamiliar(GrupoFamiliarBack fam)
        {
            new GrupoFamiliarBL().EliminarGrupoFamiliar(fam);
        }
    }
}

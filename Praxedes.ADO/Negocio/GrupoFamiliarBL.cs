using Praxedes.ADO.Maestros.ADO;
using Praxedes.ADO.Maestros.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praxedes.ADO.Negocio
{
    class GrupoFamiliarBL
    {
        internal List<GrupoFamiliarBack> ListarGrupoFamiliar(LoguinRequestBack log)
        {
            return new GrupoFamiliarADO().ListarGrupoFamiliar(log);
        }
        internal void CrearGrupoFamiliar(GrupoFamiliarBack fam)
        {
            new GrupoFamiliarADO().CrearGrupoFamiliar(fam);
        }
        internal void EditarGrupoFamiliar(GrupoFamiliarBack fam)
        {
            new GrupoFamiliarADO().EditarGrupoFamiliar(fam);
        }
        internal void EliminarGrupoFamiliar(GrupoFamiliarBack fam)
        {
            new GrupoFamiliarADO().EliminarGrupoFamiliar(fam);
        }
    }
}

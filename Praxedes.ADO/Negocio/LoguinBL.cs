using Praxedes.ADO.Maestros.ADO;
using Praxedes.ADO.Maestros.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praxedes.ADO.Negocio
{
    class LoguinBL
    {
        internal bool ValidarUsuario(LoguinRequestBack log)
        {
            return new LoguinADO().ValidarUsuario(log);
        }
        public void RegistrarToken(LoguinRequestBack log, string Token)
        {
            new LoguinADO().RegistrarToken(log, Token);
        }
    }
}

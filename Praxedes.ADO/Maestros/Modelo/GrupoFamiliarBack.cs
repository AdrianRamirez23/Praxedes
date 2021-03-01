using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praxedes.ADO.Maestros.Modelo
{
    public class GrupoFamiliarBack
    {
        public string Usuario { get; set; }
        public string Cedula { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Genero { get; set; }
        public string Parentesco { get; set; }
        public int Edad { get; set; }
        public string MenorEdad { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class Medico_RegistroEnfDiagnostico
    {
        public int IdCita { get; set; }
        public int IdEnfermedad {  get; set; }
        public string NotaDiagnostico { get; set; }
        public string FaseEnfermedad { get; set; }
        public string FechaDiagnostico { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class Medico_MedPaciente
    {
        public int IdMedicamento { get; set; }
        public string Dosis { get; set; }
        public string Instrucciones { get; set; }
        public string FechaPrescrita { get; set; }
        public int IdPaciente { get; set; }
        public int IdCita { get; set; }
    }
}

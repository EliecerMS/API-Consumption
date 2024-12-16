using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos
{
    public class Medico_CrearCita
    {
        public string FechaCita { get; set; }
        public string Motivo { get; set; }
        public string Especialidad { get; set; }
        public int IdMedico { get; set; }
        public int IdPaciente { get; set; }
    }
}

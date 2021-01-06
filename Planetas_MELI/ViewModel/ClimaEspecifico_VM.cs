using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planetas_MELI.ViewModel
{
    public class ClimaEspecifico_VM
    {
        public ClimaEspecifico_VM(string Estado, int Cantidad_Dias)
        {
            this.Estado = Estado;
            this.Cantidad_Dias = Cantidad_Dias;
        }
        public string Estado { get; set; }
        public int Cantidad_Dias { get; set; }
    }
}

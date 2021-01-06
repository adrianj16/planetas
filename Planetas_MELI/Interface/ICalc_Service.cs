using Planetas_MELI.Model;
using Planetas_MELI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planetas_MELI.Interface
{
    //Interface usada para implementar los metodos encapsulados
    interface ICalc_Service 
    {
        void Init(Planeta planeta1, Planeta planeta2, Planeta planeta3);
        List<Clima_VM> getPronostico();
        List<Clima_VM> getPronostico(string Estado);
        Clima_VM getPronostico(int Dia);
        ClimaEspecifico_VM getClimaEspecifico(string Estado);
    }
}

using Planetas_MELI.Interface;
using Planetas_MELI.Model;
using Planetas_MELI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planetas_MELI.Service
{
    public class Calc_Service : ICalc_Service
    {
        ///Variables necesarias para la logica de negocio
        ///Se coloca año como 360 dado que con 360grados vuelve al inicio sistema sexagesimal
        ///10 años 3600 dias
        private List<Clima> Pronostico;
        private const int Ano = 3600; 
        private Planeta planeta1;
        private Planeta planeta2;
        private Planeta planeta3;

        public void Init(Planeta planeta1, Planeta planeta2, Planeta planeta3)
        {
            this.planeta1 = planeta1;
            this.planeta2 = planeta2;
            this.planeta3 = planeta3;
            this.Pronostico = new List<Clima>();
            for (int i = 0; i <= Ano; i++)
            {
                Pronostico.Add(getClima(i));
            }
            CalcularTormentas();
        }

        //Obtiene la cantidad de Dias de un clima especifico
        public ClimaEspecifico_VM getClimaEspecifico(string Estado)
        {
            return new ClimaEspecifico_VM(Estado, Pronostico.Where(x => x.getEstado() == Estado).Count());
        }

        //Devuelve el listado de Pronosticos Actual
        public List<Clima_VM> getPronostico()
        {
            return Pronostico.Select(x => new Clima_VM(x)).ToList();
        }

        //Devuelve el listado de pronosticos filtrado por estado
        public List<Clima_VM> getPronostico(string Estado)
        {
            return Pronostico.Where(x=> x.getEstado().Contains(Estado)).Select(x => new Clima_VM(x)).ToList();
        }

        //Devuelve el pronostico de un dia especifico
        public Clima_VM getPronostico(int Dia)
        {
            return Pronostico.Where(x => x.getDia() == Dia).Select(x => new Clima_VM(x)).FirstOrDefault();
        }

        //Se usa para calcular los dias de tomenta usando la formula de perimetro maximo presentada en el enunciado
        public void CalcularTormentas()
        {
            Clima pronosticoMaximoPerimetro = Pronostico.OrderByDescending(x => x.getTriangulo().getPerimetro()).FirstOrDefault();
            double perimetroMaximo = pronosticoMaximoPerimetro.getTriangulo().getPerimetro();
            Pronostico.Where(x => x.getTriangulo().getPerimetro() == perimetroMaximo).ToList().ForEach(x => x.setEstado("Tormenta"));                    }

        //Se usa para determinar el clima de cada uno de los dias
        public Clima getClima(int dia)
        {
            Triangulo triangulo = new Triangulo(planeta1.getPosicion(dia), planeta2.getPosicion(dia), planeta3.getPosicion(dia));
            Posicion Sol = new Posicion(0, 0);

            if (triangulo.getArea() == 0)
            {
                if (triangulo.ContienePosicion(Sol))
                {
                    return new Clima(dia, "Sequia", triangulo);
                }

                return new Clima(dia, "Optima", triangulo);
            }
            else if (triangulo.ContienePosicion(Sol))
            {
                return new Clima(dia, "Lluvia", triangulo);
            }
            else
            {
                return new Clima(dia, "Soleado", triangulo);
            }
        }
    }
}

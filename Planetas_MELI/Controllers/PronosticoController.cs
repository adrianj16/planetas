using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Planetas_MELI.Interface;
using Planetas_MELI.Model;
using Planetas_MELI.Service;
using Planetas_MELI.ViewModel;

namespace Planetas_MELI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class PronosticoController : ControllerBase
    {
        //Inicializo la Interface con el Servicio para poder acceder a los datos.
        ICalc_Service Service = new Calc_Service();

        //Inicializo el controlador y cargo la data de planetas
        //Inicializo el servicio cargandole la data de los 3 planetas

        //NOTA:
        //Se coloca con signo negativo a los que tiene avance de signo positivo 
        //debido a que los grados aumentan en sentido antihorario
        //usando el sistema sexagesimal que es el mas parecido a la rotacion de un planeta respecto al eje
        public PronosticoController()
        {
            Planeta ferengi = new Planeta("Ferengi", 500, 1, -1);
            Planeta betasoide = new Planeta("Betasoide", 2000, 3, -1);
            Planeta vulcano = new Planeta("Vulcano", 1000, 5, 1);
            Service.Init(ferengi, betasoide, vulcano);
        }

        //Pronostico
        //URL: http://localhost/Pronostico
        //Result: todos los pronosticos que ocurriran dentro de los proximos 10 años
        [HttpGet]
        [Route("Pronostico")]
        public ActionResult<List<Clima_VM>> Get()
        {
            return Service.getPronostico();
        }


        //Pronostico de Estados Especificos
        //URL: http://localhost/Estado/{Estado}
        //Ejemplo: http://localhost/Estado/Lluvia
        //Parametro: Estado
        //Result: Todos los pronosticos en el estado recibido por parametros de los proximos 10 años
        //Estados:
        //Lluvia, Soleado, Optima, Tormenta, Sequia
        [HttpGet]
        [Route("Estado/{Estado}")]
        public ActionResult<List<Clima_VM>> Get(string Estado)
        {
            return Service.getPronostico(Estado);
        }

        //Pronostico por dia
        //URL: http://localhost:PUERTO/Pronostico/{Dia}
        //Ejemplo: http://localhost:PUERTO/Pronostico/100
        //Parametro: Dia
        //Result: El pronostico del dia recibido por parametro
        [HttpGet]
        [Route("Pronostico/{Dia}")]
        public ActionResult<Clima_VM> Get(int Dia)
        {
            return Service.getPronostico(Dia);
        }

        //Cantidad Dias por estado
        //URL: http://localhost/Cantidad_Dias/{Estado}
        //Ejemplo: http://localhost/Cantidad_Dias/Lluvia
        //Parametro: Estado
        //Result: Cantidad de Dias en el estado recibido por parametros de los proximos 10 años
        [HttpGet("Cantidad_Dias/{Estado}")]        
        public ActionResult<ClimaEspecifico_VM> Cantidad_Dias(string Estado)
        {
            return Service.getClimaEspecifico(Estado);
        }      
    }
}
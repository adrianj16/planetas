using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planetas_MELI.Model
{
    public class Clima
    {
        private string Estado;

        private int Dia;

        private Triangulo triangulo; 

        public Clima(int Dia, String Estado, Triangulo triangulo) : base()
        {
            this.Dia = Dia;
            this.Estado = Estado;
            this.triangulo = triangulo;
        }

        public int getDia()
        {
            return this.Dia;
        }

        public void setDia(int Dia)
        {
            this.Dia = Dia;
        }

        public string getEstado()
        {
            return this.Estado;
        }

        public void setEstado(string Estado)
        {
            this.Estado = Estado;
        }

        public Triangulo getTriangulo()
        {
            return this.triangulo;
        }

        public void setTriangulo(Triangulo triangulo)
        {
            this.triangulo = triangulo;
        }
      
        public override string ToString()
        {
            return "Clima [Estado="+ this.Estado + ", Dia="+ this.Dia + "]";
        }
    }
}

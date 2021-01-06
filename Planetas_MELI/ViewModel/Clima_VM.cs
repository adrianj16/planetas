using Planetas_MELI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planetas_MELI.ViewModel
{
    public class Clima_VM
    {
        public Clima_VM(Clima c) : base()
        {
            this.Dia = c.getDia();
            this.Estado = c.getEstado();
            this.Triangulo = new Triangulo_VM(c.getTriangulo());
        }

        public string Estado { get; set; }
        public int Dia { get; set; }
        public Triangulo_VM Triangulo { get; set; }

    }
    public class Triangulo_VM
    {
        public Triangulo_VM(Triangulo t) : base()
        {
            this.p1 = new Posicion_VM(t.getP1());
            this.p2 = new Posicion_VM(t.getP2());
            this.p3 = new Posicion_VM(t.getP3());
            this.Area = t.getArea();
            this.ContieneAlSol = t.ContienePosicion(new Posicion(0, 0));
            this.Perimetro = t.getPerimetro();
        }
        public Posicion_VM p1 { get; set; }
        public Posicion_VM p2 { get; set; }
        public Posicion_VM p3 { get; set; }
        public float Area { get; set; }
        public bool ContieneAlSol { get; set; }     
        public double Perimetro { get; set; }       
    }

    public class Posicion_VM
    {
        public Posicion_VM(Posicion p)
        {
            this.x = p.getX();
            this.y = p.getY();
        }
        public double x { get; set; }
        public double y { get; set; }
    }
    
}

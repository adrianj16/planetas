using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planetas_MELI.Model
{
    public class Triangulo
    {
        private Posicion p1;

        private Posicion p2;

        private Posicion p3;

        public Triangulo(Posicion p1, Posicion p2, Posicion p3) : base()
        {
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
        }

        public Posicion getP1() { return p1; }
        public Posicion getP2() { return p2; }
        public Posicion getP3() { return p3; }

        //Se usa la forma del determinante de una matriz para determinar el area del triangulo
        public float getArea()
        {
            return Convert.ToSingle((((p1.getX() * p2.getY()) + (p2.getX() * p3.getY()) + (p3.getX() * p1.getY())) - ((p1.getX() * p3.getY()) + (p3.getX() * p2.getY()) + (p2.getX() * p1.getY()))) / 2);
        }


        //Se usa la verificacion de suma de area de tiangulos para verificar si el triangulo contiene un punto especifico
        public bool ContienePosicion(Posicion p)
        {
            Triangulo tr1 = new Triangulo(p, this.p2, this.p3);
            Triangulo tr2 = new Triangulo(this.p1, p, this.p3);
            Triangulo tr3 = new Triangulo(this.p1, this.p2, p);
            return ((tr1.getArea() + (tr2.getArea() + tr3.getArea()))== this.getArea());
        }

        //Se obtiene el perimetro para los calculos de perimetro maximo usando la formula de distancia de los lados del triangulo
        public double getPerimetro()
        {
            double xy = this.p1.Distancia(this.p2);
            double yz = this.p2.Distancia(this.p3);
            double xz = this.p3.Distancia(this.p1);
            return (xy+ yz + xz);
        }
    }
}

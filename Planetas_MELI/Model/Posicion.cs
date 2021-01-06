using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planetas_MELI.Model
{
    public class Posicion
    {
        private double x;

        private double y;

        public Posicion(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double getX()
        {
            return this.x;
        }

        public void setX(double x)
        {
            this.x = x;
        }

        public double getY()
        {
            return this.y;
        }

        public void setY(double y)
        {
            this.y = y;
        }

        //Se calcula la distancia usando la formula de raiz cuadrada de la suma de (x2 - x1) al cuadrado y (y2 -y1) al cuadrado
        public double Distancia(Posicion p)
        {
            return Math.Sqrt((Math.Pow((p.getX() - this.x), 2) + Math.Pow((p.getY() - this.y), 2)));
        }

        
        public override string ToString()
        {
            return "Posicion [x="+ this.x + ", y="+ this.y + "]";
        }
    }
}

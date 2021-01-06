using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planetas_MELI.Model
{
    public class Planeta
    {
        private string Nombre;

        private float Distancia_Solar;

        private int Velocidad_Rotacion;

        private int Sentido;

        public Planeta(string Nombre, float Distancia_Solar, int Velocidad_Rotacion, int Sentido)
        {
            this.Nombre = Nombre;
            this.Distancia_Solar = Distancia_Solar;
            this.Velocidad_Rotacion = Velocidad_Rotacion;
            this.Sentido = Sentido;
        }        

        public string getNombre()
        {
            return this.Nombre;
        }

        public void setNombre(string Nombre)
        {
            this.Nombre = Nombre;
        }

        public float getDistancia_Solar()
        {
            return this.Distancia_Solar;
        }

        public void setDistancia_Solar(float Distancia_Solar)
        {
            this.Distancia_Solar = Distancia_Solar;
        }

        public int getVelocidad_Rotacion()
        {
            return this.Velocidad_Rotacion;
        }

        public void setVelocidadAngularPorDia(int velocidadAngularPorDia)
        {
            this.Velocidad_Rotacion = velocidadAngularPorDia;
        }

        public int getSentido()
        {
            return this.Sentido;
        }

        public void setSentido(int Sentido)
        {
            this.Sentido = Sentido;
        }

        //Se usan ecuaciones para determinar el radial a partir de la posicion en grados.
        //Una vez con el radial se calcula en punto en las cordenadas cartesianas usando: 
        //Seno de la posicion en radial para el eje y por la distancia respecto al sol
        //Coseno de la posicion en radial para el eje x por la distancia respecto al sol
        public Posicion getPosicion(int dia)
        {
            double posicionEnGrados = ((dia * (this.Velocidad_Rotacion * this.Sentido)) % 360);
            double posicionEnRadial = (posicionEnGrados * Math.PI) / 180;
            double x = (Math.Cos(posicionEnRadial) * this.Distancia_Solar);
            double y = (Math.Sin(posicionEnRadial) * this.Distancia_Solar);
            return new Posicion(x, y);
        }
    }
}

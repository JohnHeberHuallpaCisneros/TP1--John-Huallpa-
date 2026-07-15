/*
Realizar un programa que represente una simulación de copos de nieve cayendo en la consola
utilizando el símbolo "*" para cada copo.

El programa debe cumplir con las siguientes condiciones:

Definir una clase Configuracion que almacene parámetros de la simulación,
como la cantidad de filas, columnas y la velocidad de caída de los copos.

Definir una clase Copo que modele el comportamiento de un copo de nieve.
Cada copo debe tener una posición en la consola y un método para mostrarse y desplazarse hacia abajo.

Usar una lista para administrar todos los copos activos durante la simulación.

Implementar una lógica que controle la caída de los copos de nieve,
evitando que se superpongan en la misma posición.

Al completarse una fila con copos en todas las columnas, 
esta debe eliminarse para permitir que continúe la simulación.

El programa debe ejecutarse en un ciclo continuo, simulando de manera animada la caída de los copos.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen0._5
{
     class Configuracion
    {
        private int filas;
        private int columnas;
        private int velocidad;

        public int Filas
        {
            set { filas = value; }
            get { return filas; }
        }
        public int Columnas
        {
            set { columnas = value; }
            get { return columnas; }
        }
        public int Velocidad
        {
            set { velocidad = value; }
            get { return velocidad; }
        }
        public Configuracion(int filas, int columnas, int velocidad)
        {
            this.filas = filas;
            this.columnas = columnas;
            this.velocidad = velocidad;
        }
        public Configuracion() : this(22, 10, 150)
        {

        }
    }
}

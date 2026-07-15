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
     class Copo
    {
        private int fila;
        private int columna;
        public int Fila
        {
            set { fila = value; }
            get { return fila; }
        }
        public int Columna
        {
            set { columna = value; }
            get { return columna; }

        }
        public Copo(int fila, int columna)
        {
            this.fila = fila;
            this.columna = columna;
        }
        public Copo(int columna) : this(0, columna)
        {

        }
        public void Mostrar()
        {
            Console.SetCursorPosition(columna, fila);
            Console.Write("*");
        }
        public void Bajar()
        {
            Fila++;
        }
    }
}

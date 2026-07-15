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
     class Simulacion
    {
        private List<Copo> copos;
        private Configuracion config;
        private Random generador;
        private bool[,] posiocupado;

        public Simulacion(Configuracion config)
        {
            this.config = config;
            copos = new List<Copo>();
            generador = new Random();
            posiocupado = new bool[config.Filas, config.Columnas];
        }
        public void GenerarCopo()
        {
            int columna = generador.Next(0, config.Columnas);
            Copo c = new Copo(columna);
            copos.Add(c);
        }
        public bool Ocupada(int fila, int columna)
        {
            return posiocupado[fila, columna];
        }
        public void ActualizarAbajo()
        {
            foreach (Copo copo in copos)
            {
                bool llegoAlFondo = copo.Fila >= config.Filas - 1;
                bool hayAlgoAbajo = !llegoAlFondo && Ocupada(copo.Fila + 1, copo.Columna);

                if (llegoAlFondo || hayAlgoAbajo)
                {
                    copo.Mostrar();
                    posiocupado[copo.Fila, copo.Columna] = true;
                }
                else
                {
                    Console.SetCursorPosition(copo.Columna, copo.Fila);
                    Console.Write(" ");
                    copo.Bajar();
                    copo.Mostrar();
                }
            }
            for (int f = 0; f < config.Filas; f++)
            {
                if (FilaCompletada(f))
                {
                    EliminarFila(f);
                }
            }
        }
        public bool FilaCompletada(int fila)
        {
            for (int i = 0; i < config.Columnas; i++)
            {
                if (!posiocupado[fila, i])
                {
                    return false;
                }
            }
            return true;
        }
        public void BorrarFila(int fila)
        {
            for (int c = 0; c < config.Columnas; c++)
            {
                Console.SetCursorPosition(c, fila);
                Console.Write(" ");
            }
        }
        public void EliminarFila(int filaCompleta)
        {
            BorrarFila(filaCompleta);
            copos.RemoveAll(c => c.Fila == filaCompleta);

            for (int f = filaCompleta; f > 0; f--)
            {
                for (int c = 0; c < config.Columnas; c++)
                {
                    posiocupado[f, c] = posiocupado[f - 1, c];
                }
            }
            for (int c = 0; c < config.Columnas; c++)
            {
                posiocupado[0, c] = false;
            }
            foreach (Copo copo in copos)
            {
                if (copo.Fila < filaCompleta)
                {
                    Console.SetCursorPosition(copo.Columna, copo.Fila);
                    Console.Write(" ");
                    copo.Bajar();
                    copo.Mostrar();
                }
            }

        }
    }
}

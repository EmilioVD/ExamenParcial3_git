using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examen_Parcial_3.Mascotas;

namespace Examen_Parcial_3.Mascotas
{
    class Interfaz_mascota
    {
        
    }
    
    public abstract class Mascota
    {
        private static int contadorId = 1;

        public string Id { get; private set; }
        public string Nombre { get; private set; }
        public int Edad { get; set; }
        public Temperamento Temperamento { get; private set; }
        public Persona Dueño { get; private set; }

        protected Mascota(string nombre, Especie especie, Temperamento temperamento)
        {
            Id = $"{especie} - {contadorId++}";
            Nombre = nombre;
            Temperamento = temperamento;
        }

        public abstract void HacerRuido();

        public void CambiarDueño(Persona nuevoDueño)
        {
            if (Dueño != null)
            {
                Console.WriteLine($"{Nombre} ha cambiado su dueño a {nuevoDueño.Nombre}.");
            }

            Dueño = nuevoDueño;
        }
    }
    
}

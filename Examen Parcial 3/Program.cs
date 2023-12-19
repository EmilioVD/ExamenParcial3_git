using Examen_Parcial_3.Mascotas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Parcial_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Inicio");

            static List<Persona> personas = new List<Persona>();
            static List<Mascota> mascotas = new List<Mascota>();

            static void Main()
            {
                while (true)
                {
                    MostrarMenuPrincipal();
                    int opcion = LeerEntero("Seleccione una opción: ");

                    switch (opcion)
                    {
                        case 1:
                            AdministrarCentro();
                            break;
                        case 2:
                            AdministrarAdopciones();
                            break;
                        case 3:
                            AdministrarBienestarAnimal();
                            break;
                        case 4:
                            SimularInteracciones();
                            break;
                        case 5:
                            Console.WriteLine("Programa finalizado.");
                            return;
                        default:
                            Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                            break;
                    }
                }
            }










        }
    }
}

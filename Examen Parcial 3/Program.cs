using Examen_Parcial_3.Mascotas;
using Examen_Parcial_3.Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Parcial_3
{
    class Program
    {
            List<Class_Persona> personas = new List<Class_Persona>();
            List<Mascota> mascotas = new List<Mascota>();

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
            static void MostrarMenuPrincipal()
            {
                Console.WriteLine("Menú Principal:");
                Console.WriteLine("1 - Administración del centro");
                Console.WriteLine("2 - Administración de adopciones");
                Console.WriteLine("3 - Administración de bienestar animal");
                Console.WriteLine("4 - Simulación de interacciones");
                Console.WriteLine("5 - Finalizar programa");
            }

        static void AdministrarCentro()
        {
            while (true)
            {
                MostrarMenuAdministracionCentro();
                int opcion = LeerEntero("Seleccione una opción: ");

                switch (opcion)
                {
                    case 1:
                        AdministrarPersonas();
                        break;
                    case 2:
                        AdministrarMascotas();
                        break;
                    case 3:
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

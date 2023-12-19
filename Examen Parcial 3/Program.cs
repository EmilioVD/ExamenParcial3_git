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
            static List<Class_Persona> personas = new List<Class_Persona>();
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
                        Console.WriteLine("PORFAVOR SELECCIONA UNA OPCION VALIDA");
                        break;
                }
            }
        }

        static void MostrarMenuAdministracionCentro()
        {
            Console.WriteLine("Menú de Administración del Centro:");
            Console.WriteLine("1 - Administración de personas");
            Console.WriteLine("2 - Administración de mascotas");
            Console.WriteLine("3 - Regresar a menú anterior");
        }

        static void AdministrarPersonas()
        {
            while (true)
            {
                MostrarMenuAdministracionPersonas();
                int opcion = LeerEntero("Seleccione una opción: ");

                switch (opcion)
                {
                    case 1:
                        MostrarPersonasRegistradas();
                        break;
                    case 2:
                        RegistrarPersonaNueva();
                        break;
                    case 3:
                        BuscarPersonasPorNombre();
                        break;
                    case 4:
                        ExaminarPersona();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("PORFAVOR SELECCIONE UNA OPCION VALIDA");
                        break;
                }
            }
        }


        static void MostrarMenuAdministracionPersonas()
        {
            Console.WriteLine("Menú de Administración de Personas:");
            Console.WriteLine("1 - Mostrar todas las personas registradas");
            Console.WriteLine("2 - Registrar persona nueva");
            Console.WriteLine("3 - Buscar personas por nombre");
            Console.WriteLine("4 - Examinar persona");
            Console.WriteLine("5 - Regresar al menú anterior");
        }

        static void MostrarPersonasRegistradas()
        {
            Console.WriteLine("Personas Registradas:");
            foreach (var persona in personas)
            {
                Console.WriteLine($"Id: {persona.Id}, Nombre: {persona.Nombre}");
            }
        }

        static void RegistrarPersonaNueva()
        {
            string nombre = LeerCadena("Porfavor escriba el nombre de la persona: ");
            Persona nuevaPersona = new Persona(nombre);
            personas.Add(nuevaPersona);
            Console.WriteLine($"Se registro a :{nuevaPersona.Nombre} con el ID:{nuevaPersona.Id}.");
        }

        static void BuscarPersonasPorNombre()
        {
            string cadenaBusqueda = LeerCadena("Ingrese el nombre o parte del nombre a buscar: ");
            var personasEncontradas = personas.Where(p => p.Nombre.Contains(cadenaBusqueda)).ToList();

            if (personasEncontradas.Count == 0)
            {
                Console.WriteLine("No se pueddo encontrar ninguna persona con el nombre porporcionado ");
                return;
            }

            Console.WriteLine("Personas encontradas en el sistema:");
            foreach (var persona in personasEncontradas)
            {
                Console.WriteLine($"Id: {persona.Id}, Nombre: {persona.Nombre}");
            }
        }




        static int LeerEntero(string mensaje)
        {
            Console.Write(mensaje);
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int result))
                {
                    return result;
                }
                else
                {
                    Console.Write("PORFAVOR INGRESA UN NUMERO VALIDO: ");
                }
            }
        }

        static string LeerCadena(string mensaje)
        {
            Console.Write(mensaje);
            return Console.ReadLine();
        }

        static bool Confirmar(string mensaje)
        {
            Console.Write($"{mensaje} (Sí/No): ");
            string respuesta = Console.ReadLine().Trim().ToLower();
            return respuesta == "s" || respuesta == "si";
        }

        //Mascotas
        static void AdministrarMascotas()
        {
            while (true)
            {
                MostrarMenuAdministracionMascotas();
                int opcion = LeerEntero("Seleccione una opción: ");

                switch (opcion)
                {
                    case 1:
                        MostrarMascotasRegistradas();
                        break;
                    case 2:
                        RegistrarMascotaNueva();
                        break;
                    case 3:
                        BuscarMascotasPorEspecie();
                        break;
                    case 4:
                        BuscarMascotasPorNombre();
                        break;
                    case 5:
                        ExaminarMascota();
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                        break;
                }
            }
        }
        static void MostrarMenuAdministracionMascotas()
        {
            Console.WriteLine("Menú de Administración de Mascotas:");
            Console.WriteLine("1 - Mostrar todas las mascotas registradas");
            Console.WriteLine("2 - Registrar mascota nueva");
            Console.WriteLine("3 - Buscar mascotas por especie");
            Console.WriteLine("4 - Buscar mascotas por nombre");
            Console.WriteLine("5 - Examinar mascota");
            Console.WriteLine("6 - Volver al menú anterior");
        }

        static void MostrarMascotasRegistradas()
        {
            Console.WriteLine("Mascotas Registradas:");
            foreach (var mascota in mascotas)
            {
                Console.WriteLine($"Id: {mascota.Id}, Nombre: {mascota.Nombre}, Especie: {mascota.GetType().Name}");
            }
        }
        static void RegistrarMascotaNueva()
        {
            string especie = LeerCadena("Ingrese la especie de la mascota (Perro, Gato, Capibara): ");
            Mascota nuevaMascota = CrearMascotaPorEspecie(especie);
            mascotas.Add(nuevaMascota);
            Console.WriteLine($"Se ha registrado a {nuevaMascota.Nombre} con Id {nuevaMascota.Id}.");

            if (Confirmar("¿Desea asignarle un dueño a la mascota?"))
            {
                AsignarDueñoAMascota(nuevaMascota);
            }
        }
        static Mascota CrearMascotaPorEspecie(string especie)
        {
            switch (especie.ToLower())
            {
                case "perro":
                    return new Perro();
                case "gato":
                    return new Mascota.Gato();
                case "capibara":
                    return new Capibara();
                default:
                    Console.WriteLine("Especie no válida. Se creará una mascota genérica.");
                    return new Mascota();
            }
        }

    }
}


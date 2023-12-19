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
            Class_Persona nuevaPersona = new Class_Persona(nombre);
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
                Console.WriteLine($"ID: {persona.Id}, NOMBRE: {persona.Nombre}");
            }
        }

        static void ExaminarPersona()
        {
            int idPersona = LeerEntero("Porfavor INGRESAR el ID de la persona a examinar: ");
            Class_Persona persona = personas.FirstOrDefault(p => p.Id == idPersona);

            if (persona == null)
            {
                Console.WriteLine("NO SE A ENCONTRADO A NINGUNA PERSONA EN EL SISTEMA CON ESE ID ");
                if (Confirmar("¿Desearia buscar por el nombre?"))
                {
                    BuscarPersonasPorNombre();
                    return;
                }
                else
                {
                    return;
                }
            }

            Console.WriteLine($"ESTOS SON LOS DATOS DE LA PERSONA (ID: {persona.Id}, NOMBRE: {persona.Nombre}):");
            var mascotas = persona.ObtenerMascotas();
            if (mascotas.Count > 0)
            {
                Console.WriteLine("MASCOTAS REGISTRADAS:");
                foreach (var mascota in mascotas)
                {
                    Console.WriteLine($"ID: {mascota.Id}, NOMBRE: {mascota.Nombre}, ESPECIE: {mascota.GetType().Name}");
                }
            }
            else
            {
                Console.WriteLine($"El ususario {persona.Nombre} no tiene mascotas registradas");
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
        static void AdministrarAdopciones()
        {
            while (true)
            {
                MostrarMenuAdministracionAdopciones();
                int opcion = LeerEntero("Seleccione una opción: ");

                switch (opcion)
                {
                    case 1:
                        VerMascotasDisponiblesParaAdoptar();
                        break;
                    case 2:
                        AdoptarMascota();
                        break;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                        break;
                }
            }
        }

        static void MostrarMenuAdministracionAdopciones()
        {
            Console.WriteLine("Menú de Administración de Adopciones:");
            Console.WriteLine("1 - Ver mascotas disponibles para adoptar");
            Console.WriteLine("2 - Adoptar mascota");
            Console.WriteLine("3 - Regresar al menú anterior");
        }

        static void VerMascotasDisponiblesParaAdoptar()
        {
            var mascotasDisponibles = mascotas.Where(m => m.Dueño == null).ToList();

            if (mascotasDisponibles.Count == 0)
            {
                Console.WriteLine("No hay mascotas disponibles para adoptar en este momento.");
                return;
            }

            Console.WriteLine("Mascotas disponibles para adoptar:");
            foreach (var mascota in mascotasDisponibles)
            {
                Console.WriteLine($"Id: {mascota.Id}, Nombre: {mascota.Nombre}, Especie: {mascota.GetType().Name}");
            }
        }

        static void AdoptarMascota()
        {
            int idMascota = LeerEntero("Ingrese el Id de la mascota que desea adoptar: ");
            Mascota mascota = mascotas.FirstOrDefault(m => m.Id == idMascota && m.Dueño == null);

            if (mascota == null)
            {
                Console.WriteLine("La mascota no está disponible para adoptar. Verifique el Id y asegúrese de que la mascota no tenga dueño.");
                return;
            }

            Console.WriteLine($"Ha adoptado a {mascota.Nombre} (Id: {mascota.Id}, Especie: {mascota.GetType().Name}).");

            if (Confirmar("¿Desea asignarle un dueño a la mascota?"))
            {
                AsignarDueñoAMascota(mascota);
            }
        }

        static void AdministrarBienestarAnimal()
        {
            while (true)
            {
                MostrarMenuBienestarAnimal();
                int opcion = LeerEntero("Seleccione una opción: ");

                //switch (opcion)
                //{
                //    case 1:
                //        ServicioDeSpa();
                //        break;
                //    case 2:
                //        CorteDePelo();
                //        break;
                //    case 3:
                //        return;
                //    default:
                //        Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                //        break;
                //}
            }
        }
        static void SimularInteracciones()
        {
            int idPersona = LeerEntero("Ingrese el Id de la persona que realizará las interacciones: ");
            var persona = ObtenerPersonaPorId(idPersona);

            if (persona == null)
            {
                Console.WriteLine("La persona no está registrada. Por favor, verifique el Id.");
                return;
            }

            Console.WriteLine($"Simulando interacciones para {persona.Nombre}:");

            foreach (var mascota in persona.ObtenerMascotas())
            {
                Console.WriteLine($"Acariciando a {mascota.Nombre}:");
                if (mascota is IAcariciable acariciable)
                {
                    string respuesta = acariciable.ResponderACaricia();
                    Console.WriteLine($"{persona.Nombre} acaricia a {mascota.Nombre}: {respuesta}");
                }
                else
                {
                    Console.WriteLine($"{persona.Nombre} intenta acariciar a {mascota.Nombre}, pero no es posible.");
                }
            }
        }

        static void MostrarMenuBienestarAnimal()
        {
            Console.WriteLine("Menú de Administración de Bienestar Animal:");
            Console.WriteLine("1 - Servicio de Spa");
            Console.WriteLine("2 - Corte de pelo");
            Console.WriteLine("3 - Regresar al menú anterior");
        }
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
        static void ExaminarMascota()
        {
            int idMascota = LeerEntero("Ingrese el Id de la mascota que desea examinar: ");
            Mascota mascota = mascotas.FirstOrDefault(m => m.Id == idMascota);

            if (mascota == null)
            {
                Console.WriteLine("No se encontró ninguna mascota con ese Id.");
                if (Confirmar("¿Desea buscar por nombre?"))
                {
                    BuscarMascotasPorNombre();
                    return;
                }
                else
                {
                    return;
                }
            }

            Console.WriteLine($"Datos de la mascota (Id: {mascota.Id}, Nombre: {mascota.Nombre}, Especie: {mascota.GetType().Name}, Dueño: {mascota.Dueño?.Nombre ?? "Sin dueño"})");
        }

        static void BuscarMascotasPorNombre()
        {
            string cadenaBusqueda = LeerCadena("Ingrese el nombre o parte del nombre a buscar: ");
            var mascotasEncontradas = mascotas.Where(m => m.Nombre.Contains(cadenaBusqueda)).ToList();

            if (mascotasEncontradas.Count == 0)
            {
                Console.WriteLine("No se encontraron mascotas con ese nombre.");
                return;
            }

            Console.WriteLine("Mascotas encontradas:");
            foreach (var mascota in mascotasEncontradas)
            {
                Console.WriteLine($"Id: {mascota.Id}, Nombre: {mascota.Nombre}, Especie: {mascota.GetType().Name}");
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
                    return new Mascota.Perro();
                case "gato":
                    return new MGato();
                case "capibara":
                    return new Mascota.Capibara();
                default:
                    Console.WriteLine("Especie no válida. Se creará una mascota genérica.");
                    return new Mascotas.Mascota();
            }
        }

        static void AsignarDueñoAMascota(Mascota mascota)
        {
            int idDueño = LeerEntero("Ingrese el Id del dueño de la mascota: ");
            Class_Persona dueño = ObtenerPersonaPorId(idDueño);

            if (dueño == null)
            {
                Console.WriteLine("No se encontró ninguna persona con ese Id.");
                return;
            }

            if (dueño != null)
            {
                mascota.CambiarDueño(dueño);
                dueño.AgregarMascota(mascota);
                Console.WriteLine($"{dueño.Nombre} ahora es el dueño de {mascota.Nombre}.");
            }
        }
        static Class_Persona ObtenerPersonaPorId(int idPersona)
        {
            return personas.FirstOrDefault(p => p.Id == idPersona);
        }

        static void BuscarMascotasPorEspecie()
        {
            string especie = LeerCadena("Ingrese la especie de mascotas que desea buscar: ");
            var mascotasEncontradas = mascotas.Where(m => m.GetType().Name.ToLower() == especie.ToLower()).ToList();

            if (mascotasEncontradas.Count == 0)
            {
                Console.WriteLine($"No se encontraron mascotas de la especie {especie}.");
                return;
            }

            Console.WriteLine($"Mascotas de la especie {especie}:");
            foreach (var mascota in mascotasEncontradas)
            {
                Console.WriteLine($"Id: {mascota.Id}, Nombre: {mascota.Nombre}");
            }
        }




    }
}


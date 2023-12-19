using Examen_Parcial_3.Mascotas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examen_Parcial_3.Mascotas;

namespace Examen_Parcial_3.Persona
{
    public class Class_Persona
    {
        public int Id { get; private set; }
        private string _nombre;
        public string Nombre
        {
            get { return _nombre; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("El nombre no puede estar en blanco.");
                }

                _nombre = value;
            }
        }

        public List<Mascota> Mascotas { get; private set; }

        public Class_Persona(string nombre)
        {
            Id = GenerarIdUnico();
            Nombre = nombre;
            Mascotas = new List<Mascota>();
        }

        public void AgregarMascota(Mascota mascota)
        {
            Mascotas.Add(mascota);
            Console.WriteLine($"{Nombre} agrega a {mascota.Nombre} a sus mascotas.");
            mascota.CambiarDueño(this);
        }

        public Mascota ObtenerMascotaPorId(string id)
        {
            return Mascotas.Find(m => m.Id == id);
        }

        public List<Mascota> ObtenerMascotas()
        {
            return Mascotas;
        }

        public void AcariciarMascotas()
        {
            foreach (var mascota in Mascotas)
            {
                if (mascota is IAcariciable acariciable)
                {
                    Console.Write($"{Nombre} acaricia a {mascota.Nombre}. ");
                    acariciable.ResponderACaricia();
                }
                else
                {
                    Console.WriteLine($"{Nombre} intenta acariciar a {mascota.Nombre}, pero no es posible.");
                }
            }
        }

        private static int contadorPersonas = 0;

        private static int GenerarIdUnico()
        {
            return ++contadorPersonas;
        }
    }
}

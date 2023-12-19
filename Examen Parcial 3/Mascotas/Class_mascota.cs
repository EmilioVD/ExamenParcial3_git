using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examen_Parcial_3.Mascotas;
using Examen_Parcial_3.Persona;

namespace Examen_Parcial_3.Mascotas
{ 
    public abstract class Mascota
    {
        private static int contadorId = 1;

        public string Id { get; private set; }
        public string Nombre { get; private set; }
        public int Edad { get; set; }
        public Temperamento Temperamento { get; private set; }
        public Class_Persona Dueño { get; private set; }

        protected Mascota(string nombre, Especie especie, Temperamento temperamento)
        {
            Id = $"{especie} - {contadorId++}";
            Nombre = nombre;
            Temperamento = temperamento;
        }

        public abstract void HacerRuido();

        public void CambiarDueño(Class_Persona nuevoDueño)
        {
            if (Dueño != null)
            {
                Console.WriteLine($"{Nombre} ha cambiado su dueño a {nuevoDueño.Nombre}.");
            }

            Dueño = nuevoDueño;
        }
    }

    public class Perro : Mascota, IAcariciable, IBailarin
    {
        public Perro(string nombre, Temperamento temperamento) : base(nombre, Especie.Perro, temperamento) { }

        public override void HacerRuido()
        {
            Console.WriteLine("Guau Guau");
        }

        public void MoverCola()
        {
            Console.WriteLine($"{Nombre} mueve la cola ");
        }

        public void Gruñir()
        {
            Console.WriteLine($"{Nombre} gruñe epicamente");
        }

        public void ResponderACaricia()
        {
            MoverCola();
        }

        public void Bailar()
        {
            Console.WriteLine($"{Nombre} no me gusta bailar");
        }
    }

    public class Gato : Mascota, IAcariciable, IBailarin
    {
        public Gato(string nombre, Temperamento temperamento) : base(nombre, Especie.Gato, temperamento) { }

        public override void HacerRuido()
        {
            Console.WriteLine("Miau Miau");
        }

        public void Ronronear()
        {
            Console.WriteLine($"{Nombre} ronronea epicamente");
        }

        public void Rasguñar()
        {
            Console.WriteLine($"{Nombre} rasguña epicamente");
        }

        public void ResponderACaricia()
        {
            if (Temperamento == Temperamento.Amable || Temperamento == Temperamento.Nervioso)
            {
                Ronronear();
            }
            else if (Temperamento == Temperamento.Agresivo)
            {
                Rasguñar();
            }
        }

        public void Bailar()
        {
            Console.WriteLine($"{Nombre} no me gusta bailar");
        }
    }

    public class Capibara : Mascota
    {
        public Capibara(string nombre) : base(nombre, Especie.Capibara, Temperamento.Amable) { }

        public override void HacerRuido()
        {
            Console.WriteLine("Cui Cui");
        }
    }
}

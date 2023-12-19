using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Parcial_3.Mascotas
{
    interface IBailarin
    {
      void Bailar();
    }
    public interface IAcariciable
    {
        void ResponderACaricia();
    }
    public enum Especie
    {
        Perro,
        Gato,
        Capibara,
      
    }

    public enum Temperamento
    {
        Amable,
        Nervioso,
        Agresivo,
        Alegre
    }
}

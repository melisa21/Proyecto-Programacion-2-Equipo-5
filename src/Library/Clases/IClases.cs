using System.Collections.Generic;

namespace Library
{
    public interface IClases : IObservable
    {
        List<Clase> listClase{get;}
        void AgregarClase(Clase clase);
        void SuprimirClase(Clase clase);
    }
}
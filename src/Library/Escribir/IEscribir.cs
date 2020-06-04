
namespace Library
{
    public interface IEscribir
    {
        /// <summary>
        /// El tipo IEscribir se encarga de escribir las entradas escritas por el usuario en un archivo.
        /// se contempla los ditintas posibilidades en las que se puede escribir,
        ///de esta manera se usa el Patrón Polymorphism para resolver y dar esta posibilidad,
        ///en particular escribir en documento posiblemente Markdown o word, o motrar a traves de la consola
        /// </summary>
    
        void Escribir();
    }
}
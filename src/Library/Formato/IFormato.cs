/*******************************
se contempla los ditintos formatos, de esta manera
se usa el Patrón Polymorphism para resolver y dar esta posibilidad
******************/
namespace Library
{
    public interface IFormato
    {
        string formatearEntrada(string entrada);
    }
}
/*******************************
se contempla los ditintos formatos, de esta manera
se usa el Patrón Polymorphism para resolver y dar esta posibilidad
******************/
namespace Library
{
    public interface IFormato
    {
        /// <summary>
        /// Implementar el método para formatear string
        /// </summary>
        /// <param name="entrada">String al que se le quiere dar formato</param>
        /// <returns>string con formato deseado</returns>
        string FormatearEntrada(string entrada);
    }
}
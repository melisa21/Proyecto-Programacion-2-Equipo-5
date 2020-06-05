
namespace Library
{
    public class Vinieta : IFormato
    {
        public string formatearEntrada(string entrada){
            return $"\t\u2022 Entrada formateada tabla = {entrada}";
        }
    }
}
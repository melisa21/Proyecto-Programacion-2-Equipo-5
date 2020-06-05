
namespace Library
{
    public class Vinieta : IFormato
    {
        public string FormatearEntrada(string entrada){
            return $"\t\u2022 Entrada formateada viñeta = {entrada}";
        }
    }
}
using System;
using System.Collections.Generic;

namespace Library
{
    public class AdaptadorEscribir: IEscribir
    {

        public Documento Adaptado{get; set;} 

        public List<Mensaje> ConvertirAFormatoParaDocumento(List<Entrada> itemEntrada)
        {
            List<Mensaje> textoItemsEntrada=null;
            foreach (var item in itemEntrada)
            {
                textoItemsEntrada.Add(item.Contenido);
            }
            return textoItemsEntrada;
        }

        public void Escribir(List<Entrada> listObjetivo, List<Entrada> listPlanificacionDiaria, List<Entrada> listReflexionMetacognitiva, List<Entrada> listReflexionSemanal)
        {
            List<Mensaje> datosEspeciales1 = ConvertirAFormatoParaDocumento(listObjetivo);
            
            this.Adaptado.EscribirDocumento(datosEspeciales1);
        }
    }
}
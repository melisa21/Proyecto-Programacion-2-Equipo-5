using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// EsTA clase debe seguir SINGLETON dado que permite asegurarse de que Bitacora
    /// tenga solo una instancia, al tiempo que proporciona
    /// un punto de acceso global a esta instancia. 
    /// Dada la relevancia de esta clase. Además no necesitamos
    ///  mas de una instancia esto generaria un conflicto
    /// Ademas, teniendo en cuanta EXPERT, esta tiene la informacion
    ///  necesaria para crear las bitacora semanales que se necesitan
    /// Adicionalmente, en base a CREATOR esta debe ser la responsable de crear
    ///  las instancias de la clase BitacoraSemanal
    /// </summary>
    
    [Serializable]
    public class Bitacora
    {
        
        protected List<BitacoraSemanal> bitacoraSemanals = null;
        
        
        public List<BitacoraSemanal> BitacoraSemanals
        {
            get
            {
                return bitacoraSemanals;
            }
        }
      

        //****************************************
        public DateTime FechaFinDeCurso{get; set;}
        //****************************************


        /// <summary>
        /// Bitacora con coleccion de Bitacoras Semanales.
        /// </summary>
        /// <param name="name">Nombre del objeto</param>
        public Bitacora()
        {
            this.bitacoraSemanals = new List<BitacoraSemanal>();
        }


        /// <summary>
        /// La fecha de la Bitacora Semanal va ser la del lunes de cada semana
        /// Se establece la fecha en lunes según cuando se comenzó a usar el programa
        /// </summary>
        /// <param name="fechaHoy">Fecha que se quiere correr al próximo Lunes</param>
        /// <returns>Fecha correspondiente al Lunes próximo</returns>
        public DateTime CorrerFechaALunes(DateTime fechaHoy)
        {
            DateTime fechaBitacoraSemanalInicial=fechaHoy;
            if (fechaHoy.DayOfWeek == DayOfWeek.Tuesday )
                fechaBitacoraSemanalInicial = fechaHoy.AddDays(6);
            if (fechaHoy.DayOfWeek == DayOfWeek.Wednesday )
                fechaBitacoraSemanalInicial = fechaHoy.AddDays(5);
            if (fechaHoy.DayOfWeek == DayOfWeek.Thursday )
                fechaBitacoraSemanalInicial = fechaHoy.AddDays(4);
            if (fechaHoy.DayOfWeek == DayOfWeek.Friday )
                fechaBitacoraSemanalInicial = fechaHoy.AddDays(3);
            if (fechaHoy.DayOfWeek == DayOfWeek.Saturday )
                fechaBitacoraSemanalInicial = fechaHoy.AddDays(2);
            if (fechaBitacoraSemanalInicial.DayOfWeek == DayOfWeek.Sunday )
                fechaBitacoraSemanalInicial = fechaHoy.AddDays(1);
            return fechaBitacoraSemanalInicial;
        }

        /// <summary>
        /// Crea todas las bitacoras semanales ya asignandoles su correpondiente fecha.
        /// </summary>
        public void CrearBitacoraSemanal()
        {
            BitacoraSemanal bitacoraSemanal;
            DateTime fechaFin=this.FechaFinDeCurso.Date;
            DateTime fechaHoy = DateTime.Today;
            DateTime fechaBitacoraSemanalInicial=CorrerFechaALunes(fechaHoy);
            
            for (DateTime fechaBitacoraSemanal=fechaBitacoraSemanalInicial;
                fechaBitacoraSemanal.CompareTo(fechaFin)<=0;
                fechaBitacoraSemanal=fechaBitacoraSemanal.AddDays(7))
            {
                bitacoraSemanal = new BitacoraSemanal(fechaBitacoraSemanal);
                BitacoraSemanals.Add(bitacoraSemanal);
            }
        }

        /// <summary>
        /// Busca la Bitacora Semanal con la correspondiente fecha en la Bitacora.
        /// </summary>
        /// <param name="fechaBuscada">Fecha que se quiere buscar en la Bitacora Semanal</param>
        /// <returns>Posicion De la Bitacora Semanal con esa fecha</returns>
        public int BuscarBitacoraSemanalPorFecha(DateTime fechaBuscada)
        {
            int indice = BitacoraSemanals.FindIndex((BitacoraSemanal b) => b.Fecha.Date.Equals(fechaBuscada.Date));        
            
            return indice;
        }


        /// <summary>
        /// Guarda las entradas en la bitacora semanal corresponidente
        /// </summary>
        /// <param name="msg">contenido de la entrada</param>
        /// <param name="tipoEntrada">"objetivo" "planificaciondiaria" "reflexionsemanal" "reflexionmetacognitiva"</param>
        /// <param name="fecha">fecha de la bitacora semanal a a la que se quiere guardar la entrada</param>
         public void GuardarMensajeEnEntrada(Mensaje msg, TipoEntrada tipoEntrada, DateTime fecha )
        {
            //buscar biracora semenal con fecha 
            int indice = BuscarBitacoraSemanalPorFecha(fecha);
            //guardarmensaje en la encontrada
            
            if (tipoEntrada == TipoEntrada.Objetivo)
            {
                this.BitacoraSemanals[indice].GuardarObjetivo(msg);
            }

            if (tipoEntrada == TipoEntrada.PlanificacionDiaria)
            {
                this.BitacoraSemanals[indice].GuardarPlanificacionDiaria(msg);
            }

            if (tipoEntrada == TipoEntrada.ReflexionSemanal )
            {
                this.BitacoraSemanals[indice].GuardarReflexionSemanal(msg);
            }

            if (tipoEntrada == TipoEntrada.ReflexionMetacognitiva)
            {
                this.BitacoraSemanals[indice].GuardarReflexionMetacognitiva(msg);
            }

            this.BitacoraSemanals[indice].EstadoSiguiente();

        }
    }
}
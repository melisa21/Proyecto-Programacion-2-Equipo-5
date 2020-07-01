using System;
using System.Collections.Generic;

namespace Library
{
    /// <summary>
    /// </summary>
    public class DialogoUsuario
    {
        
        
        public IManipulador Comienzo{get;set;} 
        public IManipulador PideEntrada{get;set;}  
        public IManipulador PideDia{get;set;}  
        public IManipulador PideHora{get;set;}  
        public IManipulador GuardadoNotificacion{get;set;}  
        public IManipulador EscribirBitacora{get;set;} 
        
        public DialogoUsuario()
        {
            Comienzo = new Comienzo();
            PideEntrada= new PideEntrada();
            PideDia= new PideDia();
            PideHora= new PideHora();
            GuardadoNotificacion= new GuardadoNotificacion();
            EscribirBitacora = new EscribirBitacora();
        }
    }
}



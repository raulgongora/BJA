using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bja.Registro
{

    // Events are handled with delegates, so we must establish a FireEventHandler
    //definicion del event handler que retorna el argumento IdentidadEventArgs con un identificador
    // as a delegate:
    public delegate void IdentidadEventHandler(object sender, IdentidadEventArgs fe);

    //usado para retornar un identificador
    public class IdentidadEventArgs : EventArgs
    {
        public IdentidadEventArgs(Int64 id)
        {
            this.id = id;
        }

        // The fire event will have two pieces of information-- 
        // 1) Where the fire is, and 2) how "ferocious" it is.  
        public Int64 id;

    }    //end of class FireEventArgs


    // Events are handled with delegates, so we must establish a FireEventHandler
    //definicion del event handler que retorna el argumento IdentidadEventArgs con un identificador
    // as a delegate:
    public delegate void ObjetoEventHandler(object sender, ObjetoEventArgs fe);

    //usado para retornar un objeto
    public class ObjetoEventArgs : EventArgs
    {
        public ObjetoEventArgs(object item)
        {
            this.item = item;
        }

        // The fire event will have two pieces of information-- 
        // 1) Where the fire is, and 2) how "ferocious" it is.  
        public object item;

    }    //end of class FireEventArgs
}

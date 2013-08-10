using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bja.Entidades
{
    public enum Parentesco
    {
        Padre,
        Abuelo,     //Abuela
        Tio,        //Tia
        Hermano,    //Hermana
        Primo,      //Prima
        Suegro,      //Suegra
        Designado = 50, //Tutor
        Otro = 100  //Otro
    }
}

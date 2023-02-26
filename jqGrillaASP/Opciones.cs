using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jqGrillaASP
{
    ///<summary>
    ///Representa la Posicion (left, center, right).
    ///</summary>
    public enum Posicion { left, center, right }
    ///<summary>
    ///Representa el tipo de dato (json, xml, clientSide, local).
    ///</summary>
    public enum Dato { json, xml, clientSide, local }
    ///<summary>
    ///Representa el tipo de ordenamiento (asc, desc).
    ///</summary>
    public enum Orden { asc, desc }
    public enum Tipo { text, textarea, select, checkbox, password, button, image, file, custom }
    public enum FuncionGrupo { sum, count, avg, min, max }
    internal class Opciones
    {
        public string idx { get; set; }
        public string val { get; set; }
    }
}

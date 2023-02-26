using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jqGrillaASP
{
    public class Grupo
    {
        internal List<Opciones> grupo = new List<Opciones> {
            new Opciones {idx="plusicon", val="'fa fa-chevron-down bigger-110'" },
            new Opciones {idx="minusicon",val= "'fa fa-chevron-up bigger-110'"}
            //,new Opciones {idx="groupText",val= "['<b>{0} - {1}</b>']" }
        };
        ///<summary>
        ///Determina las reglas de edición.
        ///</summary>  
        public Grupo()
        {

        }
        ///<summary>
        ///Determina el nombre de la comuna por el que se agrupara.
        /// setAgruparPor(new []{"columna1","columna2"})
        ///</summary>  
        public Grupo setAgruparPor(string[] valor)
        {
            string tmpVal = "['" + string.Join("','", valor) + "']";
            return setOpcion("groupField", tmpVal);
        }
        ///<summary>
        ///Determina la forma de ordenación  de los registros agrupados.
        /// setOrden(new []{Orden.asc, Orden.desc })
        ///</summary>  
        public Grupo setOrden(Orden[] valor)
        {            
            string tmpVal = "['" + string.Join("','", valor) + "']";
            return setOpcion("groupOrder", tmpVal);
        }
        
        public Grupo setTitulo(string valor)
        {
            string tmpVal = "['" + valor + "']";
            return setOpcion("groupText", tmpVal);            
        }
        public Grupo setColapsado(bool valor)
        {
            return setOpcion("groupCollapse", valor.ToString().ToLower());
        }
        
        public Grupo setOpcion(string nombre, string valor)
        {
            var obj = grupo.FirstOrDefault(x => x.idx == nombre);
            if (obj != null)
            {
                obj.val = valor;
            }
            else
            {
                grupo.Add(new Opciones { idx = nombre, val = valor });
            }
            return this;
        }

    }
}

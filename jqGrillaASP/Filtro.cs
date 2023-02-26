using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jqGrillaASP
{  
    public class Filtro
    {
        internal List<Opciones> filtro = new List<Opciones> {
            new Opciones { idx = "stringResult", val = "true" },
            new Opciones { idx = "searchOnEnter", val = "false" }
        };
        public Filtro()
        {

        }
        public Filtro seAutoBuscar(bool valor)
        {
            return setOpcion("autosearch", valor.ToString().ToLower());
        }
        public Filtro seAntesDeBuscar(string valor)
        {
            return setOpcion("beforeSearch", "js:" + valor);
        }
        public Filtro seDespuesDeBuscar(string valor)
        {
            return setOpcion("afterSearch", "js:" + valor);
        }
        public Filtro setAntesDeLimpiar(string valor)
        {
            return setOpcion("beforeClear", "js:" + valor);
        }
        public Filtro setDespuesDeLimpiar(string valor)
        {
            return setOpcion("afterClear", "js:" + valor);
        }
        public Filtro setBuscarEnter(bool valor)
        {
            return setOpcion("searchOnEnter", valor.ToString().ToLower());
        }
        public Filtro setVerOperador(bool valor)
        {
            return setOpcion("searchOperators", valor.ToString().ToLower());
        }
        public Filtro setTituloOperador(string valor)
        {
            return setOpcion("operandTitle", valor);
        }
        public Filtro setOpcion(string nombre, string valor)
        {
            var obj = filtro.FirstOrDefault(x => x.idx == nombre);
            if (obj != null)
            {
                obj.val = valor;
            }
            else
            {
                filtro.Add(new Opciones { idx = nombre, val = valor });
            }
            return this;
        }
    }
}

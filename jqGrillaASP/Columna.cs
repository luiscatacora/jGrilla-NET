using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace jqGrillaASP
{
    public class Columna
    {
        internal List<Opciones> columna = new List<Opciones>();
        internal string titulo = "";
        ///<summary>
        ///Determina la creación  de columnas en las grilla.
        ///</summary>  
        public Columna(string indice, string nombre)
        {
            if (string.IsNullOrWhiteSpace(indice))
            {
                throw new ArgumentException("Nombre de columna no ingresado.");
            }
            var reserva = new[] { "subgrid", "cb", "rn" };
            if (reserva.Contains(indice))
            {
                throw new ArgumentException("El nombre '" + indice + "' esta reservado.");
            }
            setOpcion("name", indice);
            setOpcion("index", indice);
            titulo = nombre;
        }

        ///<summary>
        ///Determina si la columna sera oculta.
        ///</summary>
        public Columna setOculto(bool valor = true)
        {
            setOpcion("hidden", valor.ToString().ToLower());
            return this;
        }

        ///<summary>
        ///Determina si es editable (true, false).
        ///</summary>
        public Columna setEditable(bool valor = true)
        {
            setOpcion("editable", valor.ToString().ToLower());
            return this;
        }

        ///<summary>
        ///Determina la alineación  del texto(left, center, right).
        ///</summary>
        public Columna setPosicion(Posicion valor)
        {
            setOpcion("align", valor.ToString());
            return this;
        }
        ///<summary>
        ///Asigna la posicion que tendra el campo en la ventada de editar y nuevo.
        ///</summary>
        public Columna setPosicionDialog(int fila, int columna)
        {
            string resp = "js:{rowpos: " + fila.ToString() + ", colpos: " + columna.ToString() + "}";
            setOpcion("formoptions", resp);
            return this;
        }
        //editoptions
        ///<summary>
        ///Asigna valores de un select.
        ///</summary>
        private List<Opciones> editOpcion = new List<Opciones>();
        public Columna setValor(SelectList valor, bool opcion = true)
        {
            if (valor.Count() > 0)
            {
                var val = valor.Select(v => v.Value + ":" + v.Text).ToList();
                //string resp = "js:{value:'" + string.Join(";", val) + "'}";
                //editOpcion.Add(new Opciones { idx = "value", val = "'" + string.Join(";", val) + "'" });
                setEditaOpcion("value", "'" + string.Join(";", val) + "'");
                if (opcion)
                {
                    setOpcion("value", string.Join(";", val));
                    setOpcion("stype", "select");
                    setOpcion("formatter", "select");
                    setTipo(Tipo.select);
                }
                //setOpcion("editoptions", resp);
            }
            return this;
        }
        ///<summary>
        ///Asigna valores de un checkbox.
        ///</summary>
        //valor.columna

        public Columna setValor(string seleccionado, string deseleccionado)
        {            
            setEditaOpcion("value", "'" + seleccionado + ";" + deseleccionado + "'");
            return this;
        }
        public Columna esReadonly()
        {
            setEditaOpcion("readonly", "'readonly'");
            return this;
        }
        //.setOpcion("editoptions","js:{readonly: 'readonly' }")
        ///<summary>
        ///Determina la validacion de los datos en la edicion.
        ///</summary>
        public Columna setRegla(Regla valor)
        {
            string resp;
            resp = Convertir(valor.regla);
            setOpcion("editrules", resp);
            return this;
        }


        ///<summary>
        ///Determina el tipo de dato a ulizar en la edicion (text, textarea, select, checkbox, password, button, image, file, custom)
        ///</summary>
        public Columna setTipo(Tipo valor)//
        {
            setOpcion("edittype", valor.ToString());
            return this;
        }

        ///<summary>
        ///Determina si la columna estará congelado.
        ///</summary>
        public Columna congelar(bool valor = true)//
        {
            setOpcion("frozen", valor.ToString().ToLower());
            return this;
        }

        ///<summary>
        ///Si es true la columna no se mostrara en la ventana modal(true, false).
        ///</summary>
        public Columna noModal(bool valor = true)
        {
            setOpcion("hidedlg", valor.ToString().ToLower());
            return this;
        }

        ///<summary>
        ///Determina si se puede cambiar o no el tamaño de la columna(true, false).
        ///</summary>        
        public Columna noRedimensionar(bool valor = true)
        {
            valor = !(valor);
            setOpcion("resizable", valor.ToString().ToLower());
            return this;
        }

        ///<summary>
        ///Determina si la columna está deshabilitado o habilitado en las búsquedas(true, false).
        ///</summary>        
        public Columna noBuscar(bool valor = true)
        {
            valor = !(valor);
            setOpcion("search", valor.ToString().ToLower());
            return this;
        }

        //searchoptions

        ///<summary>
        ///Determina si la Ordenación está Deshabilitado o Habilitado(true,false).
        ///</summary>    
        public Columna noOrdenar(bool valor = true)
        {
            valor = !(valor);
            setOpcion("sortable", valor.ToString().ToLower());
            return this;
        }

        ///<summary>
        ///Determina si en los registros de la columna no se mostrara un tooltip.
        ///</summary>    
        public Columna noTitulo(bool valor = true)
        {
            valor = !(valor);
            setOpcion("title", valor.ToString().ToLower());
            return this;
        }

        ///<summary>
        ///Determina el ancho de la columna.
        ///</summary>    
        public Columna setAncho(int valor)
        {
            setOpcion("width", valor.ToString());
            return this;
        }
        ///<summary>
        ///Determina que el tipo de calculo que se debe realizar en la columna agrupada será mediante función JavaScript. El valor ingresado puede ser el nombre de la función JavaScript.
        ///</summary>    
        public Columna setFuncionGrupo(string valor)
        {
            setOpcion("summaryType", "js:" + valor);
            return this;
        }
        ///<summary>
        ///Determina el tipo de calculo que se debe realizar en la columna agrupada(sum, count, avg, min, max).
        ///</summary>    
        public Columna setFuncionGrupo(FuncionGrupo valor)
        {
            setOpcion("summaryType", valor.ToString());
            return this;
        }

        ///<summary>
        ///
        ///</summary>    
        public Columna setPlantillaResumen(string valor)
        {
            setOpcion("summaryTpl", valor);
            return this;
        }
        private void setEditaOpcion(string idx, string valor)
        {
            var obj = editOpcion.FirstOrDefault(x => x.idx == idx);
            if (obj != null)
            {
                obj.val = valor;
            }
            else
            {
                editOpcion.Add(new Opciones { idx = idx, val = valor });
            }
        }

        public Columna setOpcion(string nombre, string valor)
        {
            var obj = columna.FirstOrDefault(x => x.idx == nombre);
            if (obj != null)
            {
                obj.val = valor;
            }
            else
            {
                columna.Add(new Opciones { idx = nombre, val = valor });
            }
            return this;
        }

        private string Convertir(List<Opciones> valor, bool script = true)
        {
            string resp;
            var x = valor.Select(v => v.idx + ":" + v.val);
            if (script)
                resp = "js:{" + string.Join(",", x.ToList()) + "}";
            else
                resp = string.Join(",", x.ToList());
            return resp;
        }
        internal List<Opciones> getColumna()
        {
            if (editOpcion.Count() > 0)
            {
                setOpcion("editoptions", Convertir(editOpcion));
                //setOpcion("editoptions", "js:{value: '" + seleccionado + ";" + deseleccionado + "'}");
            }
            return columna;
        }
    }
}

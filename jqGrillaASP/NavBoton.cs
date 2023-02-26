using System.Collections.Generic;

namespace jqGrillaASP
{
    public enum gPosicion
    {
        first,
        last
    }
    public class NavBoton
    {
        private List<string> btnLista = new List<string>();
        private string nombreFuncionClick = "";
        private bool seleccionado = false;
        public NavBoton()
        {

        }
        private string label = "";
        public NavBoton setLabel(string Label)
        {
            label = Label;            
            return this;
        }
        public NavBoton setIcono(string icono)
        {
            btnLista.Add("buttonicon: '" + icono + "'");
            return this;
        }
        public NavBoton setPosicion(gPosicion posicion)
        {
            btnLista.Add("position: '" + posicion.ToString() + "'");
            return this;
        }

        public NavBoton setTitulo(string Titulo)
        {
            btnLista.Add("title: '" + Titulo + "'");
            return this;
        }
        //pointer, hand
        public NavBoton setCursor(string cursor = "pointer")
        {
            btnLista.Add("cursor: '" + cursor + "'");
            return this;
        }
        public NavBoton setId(string ide)
        {
            btnLista.Add("id: '" + ide + "'");
            return this;
        }
        public NavBoton setClick(string nombreFuncion, bool Seleccionado = false)
        {
            nombreFuncionClick = nombreFuncion;
            seleccionado = Seleccionado;
            return this;
        }
        private string separador = "";
        public NavBoton esSeparador()
        {
            separador = " sepclass: 'ui-separator', sepcontent: '', position: 'first' ";
            return this;
            //.navSeparatorAdd
        }
        internal string getBoton(string idGrilla, string ideBarra)
        {
            string resp = "";
            if (separador != "")
            {
                resp = "$('#" + idGrilla + "').navSeparatorAdd('#" + ideBarra + "', {" + separador + "});";
                return resp;
            }
            btnLista.Add("caption: '" + label + "'");
            if (nombreFuncionClick != "")
            {
                string dato = "";
                string codsel = "";
                if (seleccionado)
                {
                    dato = "dato";
                    codsel = " var dsel = jQuery('#" + idGrilla + "').jqGrid('getGridParam','selrow'); var dato = jQuery('#" + idGrilla + "').jqGrid('getRowData', dsel); ";
                }
                btnLista.Add("onClickButton: function() {" + codsel + " " + nombreFuncionClick + "(" + dato + ");}");
            }
            resp = "$('#" + idGrilla + "').navButtonAdd('#" + ideBarra + "', {" + string.Join(",", btnLista) + "});";
            return resp;
        }
    }
}

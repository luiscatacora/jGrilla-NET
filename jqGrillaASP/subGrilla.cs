using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jqGrillaASP
{
    public class subGrilla
    {
        //public Grilla getGrilla = new Grilla();
        private List<Opciones> Opcion = new List<Opciones>()
        {
            //new Opciones{idx="width", val="650" } ,
            new Opciones{idx="hoverrows", val = "true" },
            new Opciones{idx="viewrecords", val = "true" },
            new Opciones{idx="rownumbers", val = "true" },
            new Opciones{idx="datatype", val = "json" },
            //w Opciones{idx="altRows", val="true" },
            new Opciones{idx="rowNum",val = "10" },
            new Opciones{idx="autowidth",val = "true" },
            new Opciones{idx="height",val = "auto" },
            new Opciones{idx="sortorder",val = "desc"},
            new Opciones{idx="postData",val = "ls:"},
            new Opciones{idx="rowList",val = "ls:" },
            new Opciones{idx="prmNames", val = "ls:" },
            new Opciones{idx="loadComplete",val = "js:function() {var table = this; setTimeout(function(){styleCheckbox(table); updateActionIcons(table); updatePagerIcons(table); enableTooltips(table);}, 0); }" }
        };
        private List<Opciones> grupoTitulo = new List<Opciones>();
        private Dictionary<string, List<Opciones>> obOpciones = new Dictionary<string, List<Opciones>>
        {
            {"rowList",new List<Opciones>{
                new Opciones {idx="1", val="10" },
                new Opciones {idx="2", val="50" },
                new Opciones {idx="3", val="250" },
                new Opciones {idx="4", val="500" },
                new Opciones {idx="5", val="1000" },
                new Opciones {idx="99", val="99999999" }
            }},
            {"postData",  new List<Opciones>{
                new Opciones{idx="oper", val="grid"}
            }},

            {"prmNames", new List<Opciones> {
                new Opciones {idx="page", val="page"},
                new Opciones {idx="rows", val="rows"},
                new Opciones {idx="sort", val="sidx"},
                new Opciones {idx="order", val="sord"},
                new Opciones {idx="search", val="search"},
                new Opciones {idx="nd", val="nd"},
                new Opciones {idx="id", val="id"},
                new Opciones {idx="filter", val="filters"},
                new Opciones {idx="searchField", val="searchField"},
                new Opciones {idx="searchOper", val="searchOper"},
                new Opciones {idx="searchString", val="searchString"},
                new Opciones {idx="oper", val="oper"},
                new Opciones {idx="query", val="grid"},
                new Opciones {idx="addoper", val="add"},
                new Opciones {idx="editoper", val="edit"},
                new Opciones {idx="deloper", val="del"},
                new Opciones {idx="excel", val="excel"},
                new Opciones {idx="subgrid", val="subgrid"},
                new Opciones {idx="totalrows", val="totalrows" },
                new Opciones {idx="autocomplete", val="autocmpl"}
            } }
        };
        private List<Opciones> opcionBarra = new List<Opciones>
        {
            new Opciones {idx="cloneToTop", val="true" },
            new Opciones {idx="cloneToTop", val="true"},
            new Opciones {idx="excel", val="false" },
            new Opciones {idx="pdf", val="false"},
            new Opciones {idx="edit", val="true"},
            new Opciones {idx="edittext",val= ""},
            new Opciones {idx="editicon", val="ace-icon fa fa-pencil blue"}, //ace
            new Opciones {idx="add",val= "true"},
            new Opciones {idx="addtext", val=""},
            new Opciones {idx="addicon", val="ace-icon fa fa-plus-circle purple"},//ace
            new Opciones {idx="del", val="true"},
            new Opciones {idx="deltext", val=""},
            new Opciones {idx="delicon",val= "ace-icon fa fa-trash-o red"},
            new Opciones {idx="search", val="true"},
            new Opciones {idx="searchtext", val=""},
            new Opciones {idx="searchicon", val="ace-icon fa fa-search orange"},//ace
            new Opciones {idx="view",val= "true"},
            new Opciones {idx="viewtext",val= "" },
            new Opciones {idx="viewicon", val="ace-icon fa fa-search-plus grey"},//ace
            new Opciones {idx="refresh", val="true"},
            new Opciones {idx="refreshicon", val="ui-icon ace-icon fa fa-refresh green"},//ace
        };
        private List<Opciones> opcionEdit = new List<Opciones>
        {
            new Opciones {idx="width",val="auto" } // new Opciones {idx="closeAfterEdit", val="true"}, new Opciones {idx="reloadAfterSubmit", val="true "}
        };
        private List<Opciones> opcionAdd = new List<Opciones>
        {
            new Opciones {idx="width",val="auto" }
        };
        private List<Opciones> opcionDel = new List<Opciones>
        {
        };
        private List<Opciones> opcionSearch = new List<Opciones>
        {
            new Opciones {idx="multipleSearch",val="true" }
        };
        private List<Opciones> opcionView = new List<Opciones>
        {
            new Opciones {idx="width",val="auto" }
        };


        private readonly string _id;
        private string _pagina;
        ///<summary>
        ///Determina el identificador de la Grilla, el identificador del paginador e inicializa la construcción de la Grilla.
        ///</summary>
        public subGrilla(string id = "grid", string pagina = "pager")
        {
            if (String.IsNullOrWhiteSpace(id) && String.IsNullOrWhiteSpace(pagina))
            {
                throw new ArgumentException("No se tiene una ID o una Pagina");
            }
            _id = id;
            _pagina = pagina;
            setOpcion("pager", "#" + pagina);
        }

        //Metodos de barra de Herramientas
        ///<summary>
        ///Determina las Propiedades Editar en la Barra del Paginador.
        ///</summary>
        public subGrilla setNavEdit(string nombre, string valor)
        {
            return setNav(nombre, valor, "edit");
        }
        public subGrilla setNavEdit(bool edit = true)
        {
            return setNav("edit", edit.ToString().ToLower(), "nav");
        }
        //Metodos de barra de Herramientas
        ///<summary>
        ///Determina las Propiedades Nuevo en la Barra del Paginador.
        ///</summary>
        public subGrilla setNavAdd(string nombre, string valor)
        {
            return setNav(nombre, valor, "add");
        }
        public subGrilla setNavAdd(bool add = true)
        {
            return setNav("add", add.ToString().ToLower(), "nav");
        }
        //Metodos de barra de Herramientas
        ///<summary>
        ///Determina las Propiedades Borrar en la Barra del Paginador.
        ///</summary>
        public subGrilla setNavDel(string nombre, string valor)
        {
            return setNav(nombre, valor, "del");
        }
        public subGrilla setNavDel(bool del = true)
        {
            return setNav("del", del.ToString().ToLower(), "nav");
        }
        ///<summary>
        ///Determina las Propiedades Ver en la Barra del Paginador.
        ///</summary>
        public subGrilla setNavView(string nombre, string valor)
        {
            return setNav(nombre, valor, "view");
        }
        public subGrilla setNavView(bool view = true)
        {
            return setNav("view", view.ToString().ToLower(), "nav");
        }
        ///<summary>
        ///Determina las Propiedades Buscar en la Barra del Paginador.
        ///</summary>
        public subGrilla setNavSeach(string nombre, string valor)
        {
            return setNav(nombre, valor, "seach");
        }
        public subGrilla setNavSeach(bool search = true)
        {
            return setNav("seach", search.ToString().ToLower(), "nav");
        }

        public subGrilla setNavExcel(bool excel = true)
        {
            return setNav("excel", excel.ToString().ToLower(), "nav");
        }

        /*public Grilla setNavBoton(NavBoton boton)
        {

            return this;
        }*/
        ///<summary>
        ///Habilita o deshabilita los botones de la barra de navegacion.
        ///</summary>
        public subGrilla setVerBotonNav()//(bool edit = true, bool add = true, bool del = true, bool view = true, bool search = true, bool excel = true, bool pdf = true)
        {

            return this;
        }
        ///<summary>
        ///Determina las Propiedades de Nuevo, Editar, Borrar y Buscar en la Barra del Paginador.
        ///</summary>
        public subGrilla setNav(string nombre, string valor, string tipo = "nav")
        {
            var obj = opcionBarra.FirstOrDefault(x => x.idx == nombre);
            switch (tipo)
            {
                case "edit":
                    obj = opcionEdit.FirstOrDefault(x => x.idx == nombre);
                    break;
                case "add":
                    obj = opcionAdd.FirstOrDefault(x => x.idx == nombre);
                    break;
                case "del":
                    obj = opcionDel.FirstOrDefault(x => x.idx == nombre);
                    break;
                case "view":
                    obj = opcionView.FirstOrDefault(x => x.idx == nombre);
                    break;
                case "seach":
                    obj = opcionSearch.FirstOrDefault(x => x.idx == nombre);
                    break;
            }
            if (obj != null)
            {
                obj.val = valor;
            }
            else
            {
                switch (tipo)
                {
                    case "edit":
                        opcionEdit.Add(new Opciones { idx = nombre, val = valor });
                        break;
                    case "add":
                        opcionAdd.Add(new Opciones { idx = nombre, val = valor });
                        break;
                    case "del":
                        opcionDel.Add(new Opciones { idx = nombre, val = valor });
                        break;
                    case "view":
                        opcionView.Add(new Opciones { idx = nombre, val = valor });
                        break;
                    case "seach":
                        opcionSearch.Add(new Opciones { idx = nombre, val = valor });
                        break;
                    default:
                        opcionBarra.Add(new Opciones { idx = nombre, val = valor });
                        break;
                }

            }
            return this;
        }
        private string dataUrl = "", addUrl = "", editUrl = "", delUrl = "", urlExcel = "", urlPDF = "";

        //metodos de opciones
        ///<summary>
        ///Determina la URL de donde serán obtenidos los registros.
        ///</summary>
        public subGrilla setUrl(string url)
        {
            dataUrl = url;
            setOpcion("url", url);
            return this;
        }
        ///<summary>
        ///Determina la URL donde serán actualizados los registros.
        ///</summary>
        public subGrilla setUrlEdita(string url)
        {
            editUrl = url;
            setNavEdit("url", url);
            setOpcion("editurl", url);
            return this;
        }
        ///<summary>
        ///Determina la URL donde serán agregados los registros.
        ///</summary>
        public subGrilla setUrlNuevo(string url)
        {
            addUrl = url;
            setNavAdd("url", url);
            return this;
        }
        ///<summary>
        ///Determina la URL donde serán borrados los registros.
        ///</summary>
        public subGrilla setUrlBorrar(string url)
        {
            delUrl = url;
            setNavDel("url", url);
            return this;
        }
        ///<summary>
        ///Determina la URL donde sera generado el archivo excel.
        ///</summary>
        public subGrilla setUrlExcel(string url)
        {
            urlExcel = url;
            return this;
        }
        ///<summary>
        ///Determina la URL donde serán generado el archivo PDF.
        ///</summary>
        public subGrilla setUrlPDF(string url)
        {
            urlPDF = url;
            return this;
        }
        ///<summary>
        ///Determina el tipo de dato con el que serán obtenidos los registros.
        ///</summary>
        public subGrilla setTipoDato(Dato val)
        {
            return setOpcion("datatype", val.ToString());
        }
        ///<summary>
        ///Determina el titulo de la Grilla.
        ///</summary>
        public subGrilla setTitulo(string val)
        {
            return setOpcion("caption", val);
        }

        ////
        ///<summary>
        ///Habilita o Deshabilita el Ordenamiento Multiple
        ///</summary>
        public subGrilla setOrdenMultiple(bool valor = true)
        {
            setOpcion("multiSort", valor.ToString().ToLower());
            return this;
        }
        ///<summary>
        ///Habilita o Deshabilita el Ordenamiento
        ///</summary>
        public subGrilla setOrden(bool valor = true)
        {
            setOpcion("sortable", valor.ToString().ToLower());
            return this;
        }
        ///<summary>
        ///Determina mediante que columna serán ordenados los registros de la grilla
        ///</summary>
        public subGrilla setOrden(string valor)
        {
            setOpcion("sortname", valor);
            return this;
        }
        ///<summary>
        ///Determina mediante que columna serán ordenados los registros y la forma de ordenamiento ascendente o descendente
        ///</summary>
        public subGrilla setOrden(string valor, Orden orden)
        {
            setOpcion("sortname", valor);
            setOpcion("sortorder", orden.ToString());
            return this;
        }
        ///<summary>
        ///Determina la forma de ordenamiento ascendente o descendente
        ///</summary>
        public subGrilla setOrden(Orden valor)
        {
            return setOpcion("sortorder", valor.ToString());
        }

        ///<summary>
        ///Determina el alto de Grilla.
        ///</summary>
        public subGrilla setAlto(int valor)
        {
            return setOpcion("height", valor.ToString());
        }
        ///<summary>
        ///Determina el ancho de Grilla.
        ///</summary>
        public subGrilla setAncho(int valor)
        {
            return setOpcion("width", valor.ToString());
        }
        ///<summary>
        ///Determina si ancho de Grilla es automático.Los valores pueden ser true, false.
        ///</summary>
        public subGrilla setAncho(bool valor = true)
        {
            return setOpcion("autowidth", valor.ToString().ToLower());
        }


        ///<summary>
        ///Determina grilla de tipo cebra (las filas se alternan de color diferente)
        ///</summary>
        public subGrilla filaCebra(bool valor = true)
        {
            return setOpcion("altRows", valor.ToString().ToLower());
        }
        ///<summary>
        ///Determina si la selección de los registros es múltiple
        ///</summary>
        public subGrilla seleccionMultiple(bool valor = true)
        {
            return setOpcion("multiselect", valor.ToString().ToLower());
        }
        ///<summary>
        ///Habilita la Función  Sub Grilla.
        ///</summary>
        ///<summary>
        ///Determina la posición de los registros en la Grilla. Los valores pueden ser left, right, center.
        ///</summary>
        public subGrilla setPosicion(Posicion valor)
        {
            return setOpcion("recordpos", valor.ToString());
        }
        /* ,
     */
        ///<summary>
        ///Habilita o deshabilita la función de registros agrupados.
        ///</summary>
        public subGrilla esAgrupado(bool valor = true)
        {
            return setOpcion("grouping", valor.ToString().ToLower());
        }
        public subGrilla setAgrupar(Grupo valor)
        {
            //valor.grupo
            string tmp = Convertir(valor.grupo);
            setOpcion("grouping", "true");
            return setOpcion("groupingView", tmp);
        }

        public subGrilla setOpcion(string nombre, string valor)
        {
            var obj = Opcion.FirstOrDefault(x => x.idx == nombre);
            if (obj != null)
            {
                obj.val = valor;
            }
            else
            {
                Opcion.Add(new Opciones { idx = nombre, val = valor });
            }
            return this;
        }
        //Metodo para eventos
        ///<summary>
        ///Determina los eventos que se utilizaran. 
        ///Los valores pueden ser: nombre de evento y valor con JavaScript
        ///</summary>
        public subGrilla setEvento(string evento, string valor)
        {
            if (valor.Length > 2 && valor.Substring(0, 3) != "js:")
                valor = "js:" + valor;
            return setOpcion(evento, valor);
        }
        //metodo de convercion a modo jqgrid
        private string Convertir(List<Opciones> valor)
        {
            string resp;
            var x = valor.Select(v => v.idx + ":" + v.val);
            resp = "js:{" + string.Join(",", x.ToList()) + "}";
            return resp;
        }
        private string getConvertir(List<string> dato)
        {
            return "['" + string.Join("','", dato) + "']";
        }
        private string getConvertir(List<List<Opciones>> dato)
        {
            string[] resp = new string[dato.Count()];
            int i = 0;
            foreach (List<Opciones> val in dato)
            {
                resp[i] = getConvertir(val);
                i++;
            }
            return "{" + string.Join("}, {", resp) + "}";
        }
        private string getConvertir(List<Opciones> ope, bool esLis = false)
        {
            string[] tmpResp = new string[ope.Count];
            List<Opciones> tmpValor = new List<Opciones>();
            string resp = "";
            int i = 0;
            Int32 banI = 0, esIdx = 0;
            bool banB = false;

            foreach (Opciones val in ope) //val.Value or val.Key
            {
                Int32.TryParse(val.idx, out esIdx);
                if (val.val == "ls:")
                {
                    tmpValor.Clear();
                    //val.val = null;
                    obOpciones.TryGetValue(val.idx, out tmpValor);
                    //tmpValor.Add(val);
                    tmpResp[i] = val.idx + ": " + this.getConvertir(tmpValor, true);
                }

                else if (Int32.TryParse(val.val, out banI) || bool.TryParse(val.val, out banB))
                {
                    if (esLis)
                        tmpResp[i] = val.val;
                    else
                        tmpResp[i] = val.idx + ": " + val.val;
                }
                else if (val.val.Length > 2 && val.val.Substring(0, 3) == "js:")
                {
                    tmpResp[i] = val.idx + ": " + val.val.Substring(3, val.val.Length - 3);
                }
                else
                {
                    tmpResp[i] = val.idx + ": '" + val.val + "'";
                }
                i++;
            }
            if (esLis)
            {
                if (esIdx == 0)
                {
                    resp = "{" + string.Join(",", tmpResp) + "}";
                }
                else
                {
                    resp = "[" + string.Join(",", tmpResp) + "]";
                }
            }
            else
            {
                resp = string.Join(",", tmpResp);
            }
            return resp;
        }
        private List<List<Opciones>> columna = new List<List<Opciones>>();
        private List<string> colTitulo = new List<string>();
        public subGrilla setColumna(Columna columnas)
        {
            //columnas.ejecEditOpcion();
            columna.Add(columnas.getColumna());
            colTitulo.Add(columnas.titulo);
            return this;
        }

        public subGrilla setAgrupaTitulo(string columnaInicio, int numero, string titulo)
        {
            grupoTitulo.Add(new Opciones { idx = "startColumnName", val = columnaInicio });
            grupoTitulo.Add(new Opciones { idx = "numberOfColumns", val = numero.ToString() });
            grupoTitulo.Add(new Opciones { idx = "titleText", val = titulo });
            return this;
        }
        private List<Opciones> filtro = new List<Opciones>();
        public subGrilla setFiltro(Filtro valor)
        {
            filtro = valor.filtro;
            return this;
        }
        bool editaLinea = false;
        public subGrilla editaEnLineaNav(bool enLinea = true)
        {
            editaLinea = enLinea;
            return this;
        }
        string editLinea = "";
        //string editLineaCol = "";
        public subGrilla editaEnLinea(bool edita = true, bool borrar = true)
        {
            editLinea = @"{name:'myac', width:75, fixed:true, sortable:false, search:false, resize:false,frozen: true,
							formatter:'actions', 
							formatoptions:{ 
								keys:true,
								delbutton: " + borrar.ToString().ToLower() + @",//disable delete button								
								delOptions:{recreateForm: true, beforeShowForm:beforeDeleteCallback},
                                //editbutton:true
								//editformbutton:" + edita.ToString().ToLower() + @", editOptions:{recreateForm: true, beforeShowForm:beforeEditCallback}
							}
						},";
            colTitulo.Insert(0, " ");

            return this;
        }
        private bool esSubGrilla = false;
        public subGrilla setSubGrilla(subGrilla valor)
        {
            esSubGrilla = true;
            setOpcion("subGrid", "true");
            setOpcion("subGridOptions", "js:{plusicon: 'ace-icon fa fa-plus center bigger-110 blue',minusicon: 'ace-icon fa fa-minus center bigger-110 blue',openicon: 'ace-icon fa fa-chevron-right center orange}");
            setOpcion("subGridRowExpanded", "js:" + valor.GeneraGrilla());

            /*
            subGridRowExpanded: function (subgridDivId, rowId) {
                var subgridTableId = subgridDivId + "_t";
                $("#" + subgridDivId).html("<table id='" + subgridTableId + "'></table>");
                $("#" + subgridTableId).jqGrid({
                    datatype: 'local',
                    data: subgrid_data,
                    colNames: ['No','Item Name','Qty'],
                    colModel: [
                        { name: 'id', width: 50 },
                        { name: 'name', width: 150 },
                        { name: 'qty', width: 50 }
                    ]
                });
            },             
     */
            return this;
        }
        private bool token = false;
        public subGrilla usarToken()
        {
            token = true;
            return this;
        }

        internal string GeneraGrilla()
        {
            var resultado = new StringBuilder();
            //$this->opcionesGrilla['colModel'] = $this->columnaGrilla;			
            // $this->opcionesGrilla['pager'] = "#". $pager;
            /*bool[] valor = new[] { true, false, false,true};
            var tmp = valor.Select(x => x).ToArray();
            resultado.AppendLine("//" + string.Join(",", valor));*/
            // resultado.AppendLine("//" + getConvertir(columna));
            //resultado.AppendLine("//" + getConvertir(colTitulo));
            if (token)
                resultado.AppendLine("$.ajaxPrefilter(function (opcion, originalOpcion, jqXHR) {if (opcion.type.toUpperCase() === 'POST') { var token = $('input[name^=__RequestVerificationToken]').first(); if (!token.length) return; var tokenNombre = token.attr('name'); if (opcion.contentType.indexOf('application/json') === 0) { opcion.url += ((opcion.url.indexOf('?') === -1) ? '?' : '&') + token.serialize(); } else if (typeof opcion.data === 'string' && opcion.data.indexOf(tokenNombre) === -1) {opcion.data += (opcion.data ? '&' : '') + token.serialize();}}});");

            if (esSubGrilla)
            {
                resultado.AppendLine(@"function(subGrid_" + this._id + @", rowId) {
						var ideGrilla_" + this._id + @" = " + this._id + @" + '_t';
                        var idePagina_" + this._pagina + @" = '" + this._pagina + @"'
						$('#' + subGrid_" + this._id + @").html('<table id=""' + ideGrilla_" + this._id + @" + '""></table><div id=""' + idePagina_" + this._pagina + @" + '""></div>');
                        ideGrilla_" + this._id + @" ='#'+ideGrilla_" + this._id + @";
                ");

            }
            else
            {
                //resultado.AppendLine("jQuery(document).ready(function () {");
                resultado.AppendLine(@"var ideGrilla_" + this._id + @" = '#" + this._id + "'; var idePagina_" + this._pagina + @" = '#" + this._pagina + "';");

                resultado.AppendLine(@"var columnaPadre_" + this._id + @" = $(ideGrilla_" + this._id + @").closest('[class*=""col-""]'); 
                $(window).on('resize.jqGrid', function () { $(ideGrilla_" + this._id + @").jqGrid('setGridWidth', columnaPadre_" + this._id + @".width());})
                $(document).on('settings.ace.jqGrid', function (ev, event_name, collapsed) {if (event_name === 'sidebar_collapsed' || event_name === 'main_container_fixed') {
                setTimeout(function () {$(ideGrilla_" + this._id + @").jqGrid('setGridWidth', columnaPadre_" + this._id + @".width()); }, 20);}
                })");

                /*resultado.AppendLine(@"$(window).bind('resize', function() {
                    var width = $('.jqGrid_wrapper').width();
                $(ideGrilla_" + this._id + @").setGridWidth(width);
               
                });");*/

            }

            resultado.AppendLine("jQuery(ideGrilla_" + this._id + @").jqGrid({ " + getConvertir(Opcion) + ",");

            // resultado.AppendLine(@"postData: { department: 'value1',__RequestVerificationToken: $('input[name=__RequestVerificationToken]').val()},mtype: 'POST',");
            if (colTitulo.Count > 0)
                resultado.AppendLine("colNames: " + getConvertir(colTitulo) + ",");

            resultado.AppendLine("colModel: [" + editLinea + getConvertir(columna) + "]});");

            resultado.AppendLine("jQuery(ideGrilla_" + this._id + @").jqGrid('navGrid',idePagina_" + this._pagina + @",{");
            resultado.AppendLine(getConvertir(opcionBarra) + "},{");
            resultado.AppendLine(getConvertir(opcionEdit) + "},{");
            resultado.AppendLine(getConvertir(opcionAdd) + "},{");
            resultado.AppendLine(getConvertir(opcionDel) + "},{");
            resultado.AppendLine(getConvertir(opcionSearch) + "},{");
            resultado.AppendLine(getConvertir(opcionView) + "});");

            if (opcionBarra.FirstOrDefault(x => x.idx == "excel" && x.val == "true") != null)
            {
                if (urlExcel == "")
                    urlExcel = dataUrl;
                resultado.AppendLine(@"jQuery(ideGrilla_" + this._id + @").jqGrid('navButtonAdd',idePagina_" + this._pagina + @", {id: 'exporta_xls',caption: '', buttonicon: 'ace-icon fa fa-file-excel-o green', title: 'Exportar a excel', onClickButton:  function(e){
                    try {
                        jQuery(ideGrilla_" + this._id + @").jqGrid('excelExport',{ tag: 'excel', url: '" + urlExcel + @"'});
                    } catch (e) {
                        window.location = '" + urlExcel + @"?oper=excel';
                    }
                }});");
            }
            if (opcionBarra.FirstOrDefault(x => x.idx == "pdf" && x.val == "true") != null)
            {
                if (urlPDF == "") urlPDF = dataUrl;
                resultado.AppendLine(@"jQuery(ideGrilla_" + this._id + @").jqGrid('navButtonAdd',idePagina_" + this._pagina + @", {id: 'exporta_pdf',caption: '', buttonicon: 'ace-icon fa fa-file-pdf-o red', title: 'Exportar a PDF', onClickButton:  function(e){
                    try {
                        jQuery('ideGrilla_" + this._id + @"').jqGrid('excelExport',{ tag: 'pdf', url: '" + urlPDF + @"'});
                    } catch (e) {
                        window.location = '" + urlPDF + @"?oper=pdf';
                    }
                }});");
            }
            if (grupoTitulo.Count() > 0)
            {
                resultado.AppendLine("jQuery(ideGrilla_" + this._id + @").jqGrid('useColSpanStyle: true, setGroupHeaders',{" + getConvertir(grupoTitulo) + "}");
            }

            /* resultado.AppendLine(@"        $('#grid').jqGrid('navButtonAdd', '#pager', {
             caption: 'hhh',
             buttonicon: 'ui-icon-calculator',
             title: 'Choose columns',
             onClickButton: function () {
 alert('');
                 $(this).jqGrid('columnChooser');
             }
         });");         
        
             */
            if (editaLinea)
            {
                string jss = @"aftersavefunc: function (id, res){
                             res = res.responseText.split('#');
                             try {
                                $(this).jqGrid('setCell', id, res[0], res[1]);
                                $('#' + id, '#' + this.p.id).removeClass('jqgrid-new-row').attr('id', res[1]);
                                $(this)[0].p.selrow = res[1];
                             } catch (asr) { }
                        }";
                resultado.AppendLine("jQuery(ideGrilla_" + this._id + @").jqGrid('setFrozenColumns');");
                resultado.AppendLine(@"jQuery(ideGrilla_" + this._id + @").jqGrid('inlineNav', idePagina_" + this._pagina + @", {
                     addicon:'fa fa-plus-square',
                     editicon:'fa fa-pencil-square',
                     saveicon:'fa fa-floppy-o',
                     addParams: {
                        addRowParams: {                            
                            url: '" + addUrl + @"'
                        },
                        " + jss + @"                         
                     },
                     editParams: {                        
                        " + jss + @"                       
                     }
                 });");
            }
            if (filtro.Count() > 0)
            {
                resultado.AppendLine("jQuery(ideGrilla_" + this._id + @").jqGrid('filterToolbar',{" + getConvertir(filtro) + "});");
            }
            // resultado.AppendLine("$(ideGrilla_" + this._id + @").jqGrid('editRow', rowid, { keys: true, extraparam: { __RequestVerificationToken: $('input[name^=__RequestVerificationToken]').val()} } );");

            if (!esSubGrilla)
            {
                resultado.AppendLine(@"
                $(window).triggerHandler('resize.jqGrid');
                //jQuery(ideGrilla_" + this._id + @").jqGrid('filterToolbar',{defaultSearch:true,stringResult:true})
                //jQuery(ideGrilla_" + this._id + @").filterToolbar({});
                function aceSwitch(cellvalue, options, cell) {setTimeout(function () {
                    $(cell).find('input[type=checkbox]').addClass('ace ace-switch ace-switch-5').after('<span class=""lbl""></span>');}, 0);
                }
                function pickDate(cellvalue, options, cell) {
                    setTimeout(function () {$(cell).find('input[type=text]').datepicker({ format: 'yyyy-mm-dd', autoclose: true });}, 0);
                }
                $(idePagina_" + this._pagina + @" + ' option[value=99999999]').text('Todos');
                jQuery(ideGrilla_" + this._id + @").jqGrid('navGrid', idePagina_" + this._pagina + @",{ 	
                        edit: true, editicon: 'ace-icon fa fa-pencil blue',
                        add: true, addicon: 'ace-icon fa fa-plus-circle purple',
                        del: true, delicon: 'ace-icon fa fa-trash-o red',
                        search: true, searchicon: 'ace-icon fa fa-search orange',
                        refresh: true, refreshicon: 'ace-icon fa fa-refresh green',
                        view: true, viewicon: 'ace-icon fa fa-search-plus grey',
                    }, {//closeAfterEdit: true,
                        //width: 700,
                        recreateForm: true,beforeShowForm: function (e) {
                            var form = $(e[0]);
                            form.closest('.ui-jqdialog').find('.ui-jqdialog-titlebar').wrapInner('<div class=""widget-header"" />')
                            style_edit_form(form);
                    }}, {//width: 700,
                        closeAfterAdd: true,recreateForm: true,viewPagerButtons: false,beforeShowForm: function (e) {
                            var form = $(e[0]);
                            form.closest('.ui-jqdialog').find('.ui-jqdialog-titlebar').wrapInner('<div class=""widget-header"" />')
                            style_edit_form(form);}
                    }, {recreateForm: true,
                        beforeShowForm: function (e) {var form = $(e[0]);
                            if (form.data('styled')) return false;
                            form.closest('.ui-jqdialog').find('.ui-jqdialog-titlebar').wrapInner('<div class=""widget-header"" />')
                            style_delete_form(form);
                            form.data('styled', true);
                        }, onClick: function (e) {//alert(1);
                        }}, {
                        recreateForm: true,
                        afterShowSearch: function (e) {
                            var form = $(e[0]);
                            form.closest('.ui-jqdialog').find('.ui-jqdialog-title').wrap('<div class=""widget-header"" />')
                            style_search_form(form);
                        },afterRedraw: function () {style_search_filters($(this));},multipleSearch: true,
                        /**multipleGroup:true,showQuery: true*/
                    },{recreateForm: true,beforeShowForm: function (e) {var form = $(e[0]);
                            form.closest('.ui-jqdialog').find('.ui-jqdialog-title').wrap('<div class=""widget-header"" />')
                }})
                function style_edit_form(form) {
                    form.find('input[name=sdate]').datepicker({ format: 'yyyy-mm-dd', autoclose: true })
                    form.find('input[name=stock]').addClass('ace ace-switch ace-switch-5').after('<span class=""lbl""></span>');
                    //.addClass('ace ace-switch ace-switch-5').wrap('<label class=""inline"" />').after('<span class=""lbl""></span>');
                    var buttons = form.next().find('.EditButton .fm-button');
                    buttons.addClass('btn btn-sm').find('[class*=""-icon""]').hide();//ui-icon, s-icon
                    buttons.eq(0).addClass('btn-primary').prepend('<i class=""ace-icon fa fa-check""></i>');
                    buttons.eq(1).prepend('<i class=""ace-icon fa fa-times""></i>')
                    buttons = form.next().find('.navButton a');
                    buttons.find('.ui-icon').hide();
                    buttons.eq(0).append('<i class=""ace-icon fa fa-chevron-left""></i>');
                    buttons.eq(1).append('<i class=""ace-icon fa fa-chevron-right""></i>');
                }

                function style_delete_form(form) {
                    var buttons = form.next().find('.EditButton .fm-button');
                    buttons.addClass('btn btn-sm btn-white btn-round').find('[class*=""-icon""]').hide();//ui-icon, s-icon
                    buttons.eq(0).addClass('btn-danger').prepend('<i class=""ace-icon fa fa-trash-o""></i>');
                    buttons.eq(1).addClass('btn-default').prepend('<i class=""ace-icon fa fa-times""></i>')
                }

                function style_search_filters(form) {
                    form.find('.delete-rule').val('X');
                    form.find('.add-rule').addClass('btn btn-xs btn-primary');
                    form.find('.add-group').addClass('btn btn-xs btn-success');
                    form.find('.delete-group').addClass('btn btn-xs btn-danger');
                }
                function style_search_form(form) {
                    var dialog = form.closest('.ui-jqdialog');
                    var buttons = dialog.find('.EditTable')
                    buttons.find('.EditButton a[id*=""_reset""]').addClass('btn btn-sm btn-info').find('.ui-icon').attr('class', 'ace-icon fa fa-retweet');
                    buttons.find('.EditButton a[id*=""_query""]').addClass('btn btn-sm btn-inverse').find('.ui-icon').attr('class', 'ace-icon fa fa-comment-o');
                    buttons.find('.EditButton a[id*=""_search""]').addClass('btn btn-sm btn-purple').find('.ui-icon').attr('class', 'ace-icon fa fa-search');
                }

                function beforeDeleteCallback(e) {
                    var form = $(e[0]);
                    if (form.data('styled')) return false;
                    form.closest('.ui-jqdialog').find('.ui-jqdialog-titlebar').wrapInner('<div class=""widget-header"" />')
                    style_delete_form(form);
                    form.data('styled', true);
                }

                function beforeEditCallback(e) {
                    var form = $(e[0]);
                    form.closest('.ui-jqdialog').find('.ui-jqdialog-titlebar').wrapInner('<div class=""widget-header"" />')
                    style_edit_form(form);
                }

                function styleCheckbox(table) {
                    /**
                        $(table).find('input:checkbox').addClass('ace')
                        .wrap('<label />')
                        .after('<span class=""lbl align-top"" />')        
                        $('.ui-jqgrid-labels th[id*=""_cb""]:first-child')
                        .find('input.cbox[type=checkbox]').addClass('ace')
                        .wrap('<label />').after('<span class=""lbl align-top"" />');
                    */
                }

                function updateActionIcons(table) {
                    /**
                    var replacement = {
                        'ui-ace-icon fa fa-pencil' : 'ace-icon fa fa-pencil blue',
                        'ui-ace-icon fa fa-trash-o' : 'ace-icon fa fa-trash-o red',
                        'ui-icon-disk' : 'ace-icon fa fa-check green',
                        'ui-icon-cancel' : 'ace-icon fa fa-times red'
                    };
                    $(table).find('.ui-pg-div span.ui-icon').each(function(){
                        var icon = $(this);
                        var $class = $.trim(icon.attr('class').replace('ui-icon', ''));
                        if($class in replacement) icon.attr('class', 'ui-icon '+replacement[$class]);
                    })
                    */
                }

                function updatePagerIcons(table) {
                    var replacement = {
                        'ui-icon-seek-first': 'ace-icon fa fa-angle-double-left bigger-140',
                        'ui-icon-seek-prev': 'ace-icon fa fa-angle-left bigger-140',
                        'ui-icon-seek-next': 'ace-icon fa fa-angle-right bigger-140',
                        'ui-icon-seek-end': 'ace-icon fa fa-angle-double-right bigger-140'
                    };
                    $('.ui-pg-table:not(.navtable) > tbody > tr > .ui-pg-button > .ui-icon').each(function () {
                        var icon = $(this);
                        var $class = $.trim(icon.attr('class').replace('ui-icon', ''));
                        if ($class in replacement) icon.attr('class', 'ui-icon ' + replacement[$class]);
                    })
                }

                function enableTooltips(table) {
                    $('.navtable .ui-pg-button').tooltip({ container: 'body' });
                    $(table).find('.ui-pg-div').tooltip({ container: 'body' });
                }

                //var selr = jQuery(ideGrilla_" + this._id + @").jqGrid('getGridParam','selrow');

                $(document).one('ajaxloadstart.page', function (e) {
                    $.jgrid.gridDestroy(ideGrilla_" + this._id + @");
                    $('.ui-jqdialog').remove();
                });");
                //resultado.AppendLine(" });");
            }
            return Convert.ToString(resultado);
        }
    }
}

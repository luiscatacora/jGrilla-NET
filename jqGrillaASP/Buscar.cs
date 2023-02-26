using System.Text;
using System.Web.Mvc;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Web;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System;

namespace jqGrillaASP
{
    [ModelBinder(typeof(GrillaModeloBinder))]
    public class Buscar
    {
        public bool EsBusqueda { get; set; }
        public int TamanioPagina { get; set; }
        public int IndicePagina { get; set; }
        public string OrdenColumna { get; set; }
        public string Orden { get; set; }
        public string Operacion { get; set; }
        //public Filtro Where { get; set; }

        public string Filtro { get; set; }
        public string idPadre { get;set;}
    }

    public class GrillaModeloBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            try
            {
                var GET = controllerContext.HttpContext.Request;
                StringBuilder where = new StringBuilder();
                string op, dato, campo, getOp, opera = "", punto="";
                int i = 0;
                int tmpInt;
                decimal tmpDec;
                if (bool.Parse(GET["search"]))
                {
                    Dictionary<string, string> operador = new Dictionary<string, string>
                    {
                        { "eq" , "=" },
                        { "ne" , "<>" },
                        { "lt" , "<" },
                        { "le" , "<=" },
                        { "gt" , ">" },
                        { "ge" , ">=" },
                        { "bw" , " LIKE "},
                        { "bn" , " NOT LIKE "},
                        { "in" , " IN "},
                        { "ni" , " NOT IN"},
                        { "ew" , " LIKE "},
                        { "en" , " NOT LIKE "},
                        { "cn" , " LIKE "},
                        { "nc" , " NOT LIKE "},
                        { "nu" , "IS NULL"},
                        { "nn" , "IS NOT NULL"}
                    };
                    JObject filtro = JObject.Parse(GET["filters"]);
                    opera = filtro.GetValue("groupOp").ToString();
                    foreach (JObject val in filtro.GetValue("rules"))
                    {
                        if (i > 0)
                        {
                            where.Append(opera.ToUpper() + " ");
                        }
                        getOp = val.GetValue("op").ToString();
                        operador.TryGetValue(getOp, out op);
                        dato = val.GetValue("data").ToString();
                        campo = val.GetValue("field").ToString();
                        switch (getOp)
                        {
                            case "bw":
                                where.Append(string.Format("{0}.StartsWith(\"{1}\") ", campo, dato));
                                break;
                            case "bn":
                                where.Append(string.Format("!({0}.StartsWith(\"{1}\")) ", campo, dato));
                                break;
                            case "ew":
                                where.Append(string.Format("{0}.EndsWith(\"{1}\") ", campo, dato));
                                break;
                            case "en":
                                where.Append(string.Format("!({0}.EndsWith(\"{1}\")) ", campo, dato));
                                break;
                            case "cn":
                                where.Append(string.Format("{0}.Contains(\"{1}\") ", campo, dato));
                                break;
                            case "nc":
                                where.Append(string.Format("!({0}.Contains(\"{1}\")) ", campo, dato));
                                break;
                            case "in":
                            case "ni":
                            //where.Append(campo + " " + op);
                            //where.Append(" (\"" + dato + "\")");
                            //break;
                            case "nu":
                            case "nn":
                                where.Append("");
                                break;
                            default:
                                where.Append(campo + " " + op);
                                if (dato == ".")
                                    dato = "0";
                                else
                                {
                                    if (dato.Length > 1)
                                        punto = dato.Substring(dato.Length - 1, 1);
                                    if (punto == ".")
                                        dato += "0";
                                }
                                if (int.TryParse(dato, out tmpInt) || decimal.TryParse(dato, out tmpDec))
                                {
                                    if (dato.Substring(1, 1) == "0")
                                        where.Append(" \"" + dato + "\" ");
                                    else
                                        where.Append(" " + dato + " ");
                                }
                                else
                                {
                                    where.Append(" \"" + dato + "\" ");
                                }
                                break;
                        }
                        i++;
                    }
                }
                else
                {
                    where.Append("1=1");
                }
                return new Buscar
                {
                    EsBusqueda = bool.Parse(GET["search"] ?? "false"),
                    IndicePagina = int.Parse(GET["page"] ?? "1"),
                    TamanioPagina = int.Parse(GET["rows"] ?? "10"),
                    OrdenColumna = (GET["sidx"] ?? "") + " " + (GET["sord"] ?? ""),
                    Orden = GET["sord"] ?? "asc",
                    Filtro = where.ToString(),
                    Operacion = GET["oper"],
                    idPadre = GET["idPadre"] ?? ""
                };
            }
            catch
            {
                return null;
            }
        }
        
    }

    /*public JsonResult getJson(List<string> af)
    {
        int idx = Convert.ToInt32(bs.IndicePagina) - 1;
        int tamanio = bs.TamanioPagina;

        var totalPagina = (int)Math.Ceiling((float)totalRegistro / (float)bs.TamanioPagina);
        if (bs.Orden.ToUpper() == "DESC")
        {
            af = af.OrderByDescending(s => s.CodigoActivoFijo);
            af = af.Skip(idx * tamanio).Take(tamanio);
        }
        else
        {
            af = af.OrderBy(s => s.CodigoActivoFijo);
            af = af.Skip(idx * tamanio).Take(tamanio);
        }
        var jsonData = new
        {
            total = totalPagina,
            bs.IndicePagina,
            records = totalRegistro,
            rows = af
        };
        return Json(jsonData, JsonRequestBehavior.AllowGet);
    }*/
    /*
    [DataContract]
    public class Filtro
    {
        [DataMember]
        public string groupOp { get; set; }
        [DataMember]
        public Regla[] rules { get; set; }

        public static Filtro Create(string jsonData)
        {
            try
            {
                var serializer = new DataContractJsonSerializer(typeof(Filtro));
                System.IO.StringReader reader = new System.IO.StringReader(jsonData);
                System.IO.MemoryStream ms = new System.IO.MemoryStream(Encoding.Default.GetBytes(jsonData));
                return serializer.ReadObject(ms) as Filtro;
            }
            catch
            {
                return null;
            }
        }
    }

    [DataContract]
    public class Regla
    {
        [DataMember]
        public string field { get; set; }
        [DataMember]
        public string op { get; set; }
        [DataMember]
        public string data { get; set; }
    }*/
}

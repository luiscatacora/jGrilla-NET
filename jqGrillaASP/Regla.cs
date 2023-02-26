using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jqGrillaASP
{
    public class Regla
    {
        internal List<Opciones> regla = new List<Opciones>();
        ///<summary>
        ///Determina las reglas de edición.
        ///</summary>  
        public Regla()
        {

        }
        ///<summary>
        ///Determina si se ocultara de la edición.
        ///</summary>  
        public Regla noEdita(bool valor)
        {
            setOpcion("edithidden", valor.ToString().ToLower());
            return this;
        }
        ///<summary>
        ///Valida los registros como obligatorio en la edición.
        ///</summary>  
        public Regla esRequerido(bool valor)
        {
            setOpcion("required", valor.ToString().ToLower());
            return this;
        }
        ///<summary>
        ///Valida el ingreso de valor numérico  en la edición, caso contrario mostrara el error.
        ///</summary>  
        public Regla esNumero(bool valor)
        {
            setOpcion("number", valor.ToString().ToLower());
            return this;
        }
        ///<summary>
        ///Valida el ingreso de valor entero en la edición, caso contrario mostrara el error.
        ///</summary>  
        public Regla esEntero(bool valor)
        {
            setOpcion("integer", valor.ToString().ToLower());
            return this;
        }
        ///<summary>
        ///Valida el ingreso un valor mínimo, caso contrario mostrara el error.
        ///</summary>  
        public Regla esMinimo(int valor)
        {
            setOpcion("minValue", valor.ToString());
            return this;
        }
        ///<summary>
        ///Valida el ingreso un valor máximo, caso contrario mostrara el error.
        ///</summary>  
        public Regla esMaximo(int valor)
        {
            setOpcion("maxValue", valor.ToString());
            return this;
        }
        ///<summary>
        ///Valida el ingreso un e-mail, caso contrario mostrara el error.
        ///</summary>  
        public Regla esEmail(bool valor)
        {
            setOpcion("email", valor.ToString().ToLower());
            return this;
        }
        ///<summary>
        ///Valida el ingreso una URL, caso contrario mostrara el error.
        ///</summary>  
        public Regla esUrl(bool valor)
        {
            setOpcion("url", valor.ToString().ToLower());
            return this;
        }
        ///<summary>
        ///Valida el ingreso un de tipo fecha, caso contrario mostrara el error.
        ///</summary>  
        public Regla esFecha(bool valor)
        {
            setOpcion("date", valor.ToString().ToLower());
            return this;
        }
        ///<summary>
        ///Valida el ingreso un valor de tipo hora, caso contrario mostrara el error.
        ///</summary>  
        public Regla esHora(bool valor)
        {
            setOpcion("time", valor.ToString().ToLower());
            return this;
        }

        //custom
        //custom_func
        public Regla setOpcion(string nombre, string valor)
        {
            var obj = regla.FirstOrDefault(x => x.idx == nombre);
            if (obj != null)
            {
                obj.val = valor;
            }
            else
            {
                regla.Add(new Opciones { idx = nombre, val = valor });
            }
            return this;
        }

    }
}

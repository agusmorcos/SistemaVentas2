using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NDomicilio
    {
        public static string Insertar(string provincia, string localidad, string calle, string numero, string depto)
        {
            DDomicilio Obj = new DDomicilio();
            Obj.Provincia = provincia;
            Obj.Localidad = localidad;
            Obj.Calle = calle;
            Obj.Numero = numero;
            Obj.Depto = depto;
            return Obj.Insertar(Obj);
        }

        public static string Editar(int iddomicilio, string provincia, string localidad, string calle, string numero, string depto)
        {
            DDomicilio Obj = new DDomicilio();
            Obj.Iddomicilio = iddomicilio;
            Obj.Provincia = provincia;
            Obj.Localidad = localidad;
            Obj.Calle = calle;
            Obj.Numero = numero;
            Obj.Depto = depto;
            return Obj.Editar(Obj);
        }

        public static string Eliminar(int iddomicilio)
        {
            DDomicilio Obj = new DDomicilio();
            Obj.Iddomicilio = iddomicilio;
            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new DDomicilio().Mostrar();
        }

        public static DataTable BuscarLocalidad(string textobuscar)
        {
            DDomicilio Obj = new DDomicilio();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarLocalidad(Obj);
        }

        public static DataTable BuscarCalle(string textobuscar)
        {
            DDomicilio Obj = new DDomicilio();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarCalle(Obj);
        }


        public static int UltimoDomicilio()
        {
            DDomicilio Obj = new DDomicilio();
            return Obj.UltimoDomicilio(Obj);
        }
    }
}

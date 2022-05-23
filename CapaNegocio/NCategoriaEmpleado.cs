using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NCategoriaEmpleado
    {
        public static string Insertar(string descripcion, float hsextra, float fijo)
        {
            DCategoriaEmpleado Obj = new DCategoriaEmpleado();
            Obj.Descripcion = descripcion;
            Obj.Hsextra = hsextra;
            Obj.Fijo = fijo;
            return Obj.Insertar(Obj);
        }

        public static string Editar(int idcategoriaempleado, string descripcion, float hsextra, float fijo)
        {
            DCategoriaEmpleado Obj = new DCategoriaEmpleado();
            Obj.IdcategoriaEmpleado = idcategoriaempleado;
            Obj.Descripcion = descripcion;
            Obj.Hsextra = hsextra;
            Obj.Fijo = fijo;
            return Obj.Insertar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new DCategoriaEmpleado().Mostrar();
        }
    }
}

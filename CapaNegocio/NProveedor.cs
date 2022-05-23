using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NProveedor
    {
        public static string Insertar(string razonsocial, string sectorcomercial, string cuitcuil, string telefono, string email , int iddomicilio)
        {
            DProveedor Obj = new DProveedor();
            Obj.RazonSocial = razonsocial;
            Obj.SectorComercial = sectorcomercial;
            Obj.Cuitcuil = cuitcuil;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.Iddomicilio = iddomicilio;
            return Obj.Insertar(Obj);
        }

        public static string Editar(int idproveedor, string razonsocial, string sectorcomercial, string cuitcuil, string telefono, string email, int iddomicilio)
        {
            DProveedor Obj = new DProveedor();
            Obj.Idproveedor = idproveedor;
            Obj.RazonSocial = razonsocial;
            Obj.SectorComercial = sectorcomercial;
            Obj.Cuitcuil = cuitcuil;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.Iddomicilio = iddomicilio;
            return Obj.Editar(Obj);
        }

        public static string Eliminar(int idproveedor)
        {
            DProveedor Obj = new DProveedor();
            Obj.Idproveedor = idproveedor;
            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new DProveedor().Mostrar();
        }

        public static DataTable BuscarRazon(string textobuscar)
        {
            DProveedor Obj = new DProveedor();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarRazon(Obj);
        }

        public static DataTable BuscarCuitcuil(string textobuscar)
        {
            DProveedor Obj = new DProveedor();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarCuitcuil(Obj);
        }
    }
}

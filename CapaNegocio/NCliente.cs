using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NCliente
    {
        public static string Insertar(string apellido, string nombre, string dni, string telefono, string email, int iddomicilio)
        {
            DCliente Obj = new DCliente();
            Obj.Apellido = apellido;
            Obj.Nombre = nombre;
            Obj.Dni = dni;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.Iddomicilio = iddomicilio;
            return Obj.Insertar(Obj);
        }

        public static string Editar(int idcliente, string apellido, string nombre, string dni, string telefono, string email, int iddomicilio)
        {
            DCliente Obj = new DCliente();
            Obj.Idcliente = idcliente;
            Obj.Apellido = apellido;
            Obj.Nombre = nombre;
            Obj.Dni = dni;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.Iddomicilio = iddomicilio;
            return Obj.Editar(Obj);
        }

        public static string Eliminar(int idcliente)
        {
            DCliente Obj = new DCliente();
            Obj.Idcliente = idcliente;
            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new DCliente().Mostrar();
        }

        public static DataTable BuscarApellido(string textobuscar)
        {
            DCliente Obj = new DCliente();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarApellido(Obj);
        }

        public static DataTable BuscarDni(string textobuscar)
        {
            DCliente Obj = new DCliente();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarDni(Obj);
        }

    }
}

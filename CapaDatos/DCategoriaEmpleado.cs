using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DCategoriaEmpleado
    {
        private int _IdcategoriaEmpleado;
        private string _Descripcion;
        private float _Hsextra;
        private float _Fijo;

        public int IdcategoriaEmpleado { get => _IdcategoriaEmpleado; set => _IdcategoriaEmpleado = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public float Hsextra { get => _Hsextra; set => _Hsextra = value; }
        public float Fijo { get => _Fijo; set => _Fijo = value; }

        public DCategoriaEmpleado()
        {

        }

        public DCategoriaEmpleado(int idcategoriamepleado, string descripcion, float hsextra, float fijo)
        {
            this.IdcategoriaEmpleado = idcategoriamepleado;
            this.Descripcion = descripcion;
            this.Hsextra = hsextra;
            this.Fijo = fijo;
        }

        public string Insertar(DCategoriaEmpleado CategoriaEmpleado)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinsertar_categoria_empeleado";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdcategoriaEmpleado = new SqlParameter();
                ParIdcategoriaEmpleado.ParameterName = "@idcategoria_empleado";
                ParIdcategoriaEmpleado.SqlDbType = SqlDbType.Int;
                ParIdcategoriaEmpleado.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdcategoriaEmpleado);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 20;
                ParDescripcion.Value = CategoriaEmpleado.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                SqlParameter ParHsextra = new SqlParameter();
                ParHsextra.ParameterName = "@hsextra";
                ParHsextra.SqlDbType = SqlDbType.Float;
                ParHsextra.Value = CategoriaEmpleado.Hsextra;
                SqlCmd.Parameters.Add(ParHsextra);

                SqlParameter ParFijo = new SqlParameter();
                ParFijo.ParameterName = "@fijo";
                ParFijo.SqlDbType = SqlDbType.Float;
                ParFijo.Value = CategoriaEmpleado.Fijo;
                SqlCmd.Parameters.Add(ParFijo);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se ingresó el registro";
            }

            catch (Exception ex)
            {
                rpta = ex.Message;
            }

            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return rpta;
        }

        public string Editar(DCategoriaEmpleado CategoriaEmpleado)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speditar_categoria_empleado";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdcategoriaEmpleado = new SqlParameter();
                ParIdcategoriaEmpleado.ParameterName = "@idcategoria_empleado";
                ParIdcategoriaEmpleado.SqlDbType = SqlDbType.Int;
                ParIdcategoriaEmpleado.Value = CategoriaEmpleado.IdcategoriaEmpleado;
                SqlCmd.Parameters.Add(ParIdcategoriaEmpleado);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 20;
                ParDescripcion.Value = CategoriaEmpleado.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                SqlParameter ParHsextra = new SqlParameter();
                ParHsextra.ParameterName = "@hsextra";
                ParHsextra.SqlDbType = SqlDbType.Float;
                ParHsextra.Value = CategoriaEmpleado.Hsextra;
                SqlCmd.Parameters.Add(ParHsextra);

                SqlParameter ParFijo = new SqlParameter();
                ParFijo.ParameterName = "@fijo";
                ParFijo.SqlDbType = SqlDbType.Float;
                ParFijo.Value = CategoriaEmpleado.Fijo;
                SqlCmd.Parameters.Add(ParFijo);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se actualizó el registro";
            }

            catch (Exception ex)
            {
                rpta = ex.Message;
            }

            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return rpta;

        }

        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("categoria_empleado");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_categoria_empleado";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }

            catch (Exception ex)
            {
                DtResultado = null;
            }

            return DtResultado;
        }

    }
}

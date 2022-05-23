using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DDomicilio
    {
        private int _Iddomicilio;
        private string _Provincia;
        private string _Localidad;
        private string _Calle;
        private string _Numero;
        private string _Depto;
        private string _TextoBuscar;

        public int Iddomicilio { get => _Iddomicilio; set => _Iddomicilio = value; }
        public string Provincia { get => _Provincia; set => _Provincia = value; }
        public string Localidad { get => _Localidad; set => _Localidad = value; }
        public string Calle { get => _Calle; set => _Calle = value; }
        public string Numero { get => _Numero; set => _Numero = value; }
        public string Depto { get => _Depto; set => _Depto = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        public DDomicilio()
        {

        }

        public DDomicilio(int iddomicilio, string provincia, string localidad, string calle, string numero, string depto)
        {
            this.Iddomicilio = iddomicilio;
            this.Provincia = provincia;
            this.Localidad = Localidad;
            this.Calle = calle;
            this.Numero = numero;
            this.Depto = depto;
        }

        public string Insertar(DDomicilio Domicilio)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinsertar_domicilio";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIddomicilio = new SqlParameter();
                ParIddomicilio.ParameterName = "@iddomicilio";
                ParIddomicilio.SqlDbType = SqlDbType.Int;
                ParIddomicilio.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIddomicilio);

                SqlParameter ParProvincia = new SqlParameter();
                ParProvincia.ParameterName = "@provincia";
                ParProvincia.SqlDbType = SqlDbType.VarChar;
                ParProvincia.Size = 20;
                ParProvincia.Value = Domicilio.Provincia;
                SqlCmd.Parameters.Add(ParProvincia);

                SqlParameter ParLocalidad = new SqlParameter();
                ParLocalidad.ParameterName = "@localidad";
                ParLocalidad.SqlDbType = SqlDbType.VarChar;
                ParLocalidad.Size = 20;
                ParLocalidad.Value = Domicilio.Localidad;
                SqlCmd.Parameters.Add(ParLocalidad);

                SqlParameter ParCalle = new SqlParameter();
                ParCalle.ParameterName = "@calle";
                ParCalle.SqlDbType = SqlDbType.VarChar;
                ParCalle.Size = 50;
                ParCalle.Value = Domicilio.Calle;
                SqlCmd.Parameters.Add(ParCalle);

                SqlParameter ParNumero = new SqlParameter();
                ParNumero.ParameterName = "@numero";
                ParNumero.SqlDbType = SqlDbType.VarChar;
                ParNumero.Size = 20;
                ParNumero.Value = Domicilio.Numero;
                SqlCmd.Parameters.Add(ParNumero);

                SqlParameter ParDepto = new SqlParameter();
                ParDepto.ParameterName = "@depto";
                ParDepto.SqlDbType = SqlDbType.VarChar;
                ParDepto.Size = 10;
                ParDepto.Value = Domicilio.Depto;
                SqlCmd.Parameters.Add(ParDepto);


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

        public string Editar(DDomicilio Domicilio)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speditar_domicilio";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIddomicilio = new SqlParameter();
                ParIddomicilio.ParameterName = "@iddomicilio";
                ParIddomicilio.SqlDbType = SqlDbType.Int;
                ParIddomicilio.Value = Domicilio.Iddomicilio;
                SqlCmd.Parameters.Add(ParIddomicilio);

                SqlParameter ParProvincia = new SqlParameter();
                ParProvincia.ParameterName = "@provincia";
                ParProvincia.SqlDbType = SqlDbType.VarChar;
                ParProvincia.Size = 20;
                ParProvincia.Value = Domicilio.Provincia;
                SqlCmd.Parameters.Add(ParProvincia);

                SqlParameter ParLocalidad = new SqlParameter();
                ParLocalidad.ParameterName = "@localidad";
                ParLocalidad.SqlDbType = SqlDbType.VarChar;
                ParLocalidad.Size = 20;
                ParLocalidad.Value = Domicilio.Localidad;
                SqlCmd.Parameters.Add(ParLocalidad);

                SqlParameter ParCalle = new SqlParameter();
                ParCalle.ParameterName = "@calle";
                ParCalle.SqlDbType = SqlDbType.VarChar;
                ParCalle.Size = 50;
                ParCalle.Value = Domicilio.Calle;
                SqlCmd.Parameters.Add(ParCalle);

                SqlParameter ParNumero = new SqlParameter();
                ParNumero.ParameterName = "@numero";
                ParNumero.SqlDbType = SqlDbType.VarChar;
                ParNumero.Size = 20;
                ParNumero.Value = Domicilio.Numero;
                SqlCmd.Parameters.Add(ParNumero);

                SqlParameter ParDepto = new SqlParameter();
                ParDepto.ParameterName = "@depto";
                ParDepto.SqlDbType = SqlDbType.VarChar;
                ParDepto.Size = 10;
                ParDepto.Value = Domicilio.Depto;
                SqlCmd.Parameters.Add(ParDepto);

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

        public string Eliminar(DDomicilio Domicilio)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speliminar_domicilio";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIddomicilio = new SqlParameter();
                ParIddomicilio.ParameterName = "@idcategoria";
                ParIddomicilio.SqlDbType = SqlDbType.Int;
                ParIddomicilio.Value = Domicilio.Iddomicilio;
                SqlCmd.Parameters.Add(ParIddomicilio);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se eliminó el registro";
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
            
            DataTable DtResultado = new DataTable("domicilio");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_domicilio";
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

        public DataTable BuscarCalle(DDomicilio Domicilio)
        {
            DataTable DtResultado = new DataTable("domicilio");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_domicilio_calle";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 20;
                ParTextoBuscar.Value = Domicilio.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }

            catch (Exception ex)
            {
                DtResultado = null;
            }

            return DtResultado;


        }

        public DataTable BuscarLocalidad(DDomicilio Domicilio)
        {
            DataTable DtResultado = new DataTable("domicilio");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_domicilio_localidad";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 20;
                ParTextoBuscar.Value = Domicilio.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }

            catch (Exception ex)
            {
                DtResultado = null;
            }

            return DtResultado;


        }


        public int UltimoDomicilio(DDomicilio Domicilio)
        {
            SqlConnection SqlCon = new SqlConnection();
            int ultimo=0;
            try
            {

                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spultimo_domicilio";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                

                ultimo =(Int32)SqlCmd.ExecuteScalar();
                
            }

            catch (Exception ex)
            {
                
            }
            
            return ultimo;

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;


namespace CapaDatos
{
    public class DProveedor
    {
        private int _Idproveedor;
        private string _RazonSocial;
        private string _SectorComercial;
        private string _Cuitcuil;
        private string _Telefono;
        private string _Email;
        private int _Iddomicilio;
        private string _TextoBuscar;

        public int Idproveedor { get => _Idproveedor; set => _Idproveedor = value; }
        public string RazonSocial { get => _RazonSocial; set => _RazonSocial = value; }
        public string SectorComercial { get => _SectorComercial; set => _SectorComercial = value; }
        public string Cuitcuil { get => _Cuitcuil; set => _Cuitcuil = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Email { get => _Email; set => _Email = value; }
        public int Iddomicilio { get => _Iddomicilio; set => _Iddomicilio = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        public DProveedor()
        {

        }

        public DProveedor(int idproveedor, string razonsocial, string sectorcomercial, string cuitcuil, string telefono, string email , int iddomicilio, string textobuscar)
        {
            this.Idproveedor = idproveedor;
            this.RazonSocial = razonsocial;
            this.SectorComercial = sectorcomercial;
            this.Cuitcuil = cuitcuil;
            this.Telefono = telefono;
            this.Email = email;
            this.Iddomicilio = iddomicilio;
            this.TextoBuscar = textobuscar;
        }

        public string Insertar(DProveedor Proveedor)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinsertar_proveedor";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdproveedor = new SqlParameter();
                ParIdproveedor.ParameterName = "@idproveedor";
                ParIdproveedor.SqlDbType = SqlDbType.Int;
                ParIdproveedor.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdproveedor);

                SqlParameter ParRazonSocial = new SqlParameter();
                ParRazonSocial.ParameterName = "@razonsocial";
                ParRazonSocial.SqlDbType = SqlDbType.VarChar;
                ParRazonSocial.Size = 50;
                ParRazonSocial.Value = Proveedor.RazonSocial;
                SqlCmd.Parameters.Add(ParRazonSocial);

                SqlParameter ParSectorComercial = new SqlParameter();
                ParSectorComercial.ParameterName = "@sectorcomercial";
                ParSectorComercial.SqlDbType = SqlDbType.VarChar;
                ParSectorComercial.Size = 50;
                ParSectorComercial.Value = Proveedor.SectorComercial;
                SqlCmd.Parameters.Add(ParSectorComercial);

                SqlParameter ParCuitcuil = new SqlParameter();
                ParCuitcuil.ParameterName = "@cuitcuil";
                ParCuitcuil.SqlDbType = SqlDbType.VarChar;
                ParCuitcuil.Size = 20;
                ParCuitcuil.Value = Proveedor.Cuitcuil;
                SqlCmd.Parameters.Add(ParCuitcuil);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 20;
                ParTelefono.Value = Proveedor.Telefono;
                SqlCmd.Parameters.Add(ParTelefono);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 50;
                ParEmail.Value = Proveedor.Email;
                SqlCmd.Parameters.Add(ParEmail);

                SqlParameter ParIddomicilio = new SqlParameter();
                ParIddomicilio.ParameterName = "@iddomicilio";
                ParIddomicilio.SqlDbType = SqlDbType.Int;
                ParIddomicilio.Value = Proveedor.Iddomicilio;
                SqlCmd.Parameters.Add(ParIddomicilio);

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

        public string Editar(DProveedor Proveedor)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speditar_proveedor";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdproveedor = new SqlParameter();
                ParIdproveedor.ParameterName = "@idproveedor";
                ParIdproveedor.SqlDbType = SqlDbType.Int;
                ParIdproveedor.Value = Proveedor.Idproveedor;
                SqlCmd.Parameters.Add(ParIdproveedor);

                SqlParameter ParRazonSocial = new SqlParameter();
                ParRazonSocial.ParameterName = "@razonsocial";
                ParRazonSocial.SqlDbType = SqlDbType.VarChar;
                ParRazonSocial.Size = 50;
                ParRazonSocial.Value = Proveedor.RazonSocial;
                SqlCmd.Parameters.Add(ParRazonSocial);

                SqlParameter ParSectorComercial = new SqlParameter();
                ParSectorComercial.ParameterName = "@sectorcomercial";
                ParSectorComercial.SqlDbType = SqlDbType.VarChar;
                ParSectorComercial.Size = 50;
                ParSectorComercial.Value = Proveedor.SectorComercial;
                SqlCmd.Parameters.Add(ParSectorComercial);

                SqlParameter ParCuitcuil = new SqlParameter();
                ParCuitcuil.ParameterName = "@cuitcuil";
                ParCuitcuil.SqlDbType = SqlDbType.VarChar;
                ParCuitcuil.Size = 20;
                ParCuitcuil.Value = Proveedor.Cuitcuil;
                SqlCmd.Parameters.Add(ParCuitcuil);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 20;
                ParTelefono.Value = Proveedor.Telefono;
                SqlCmd.Parameters.Add(ParTelefono);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 50;
                ParEmail.Value = Proveedor.Email;
                SqlCmd.Parameters.Add(ParEmail);

                SqlParameter ParIddomicilio = new SqlParameter();
                ParIddomicilio.ParameterName = "@iddomicilio";
                ParIddomicilio.SqlDbType = SqlDbType.Int;
                ParIddomicilio.Value = Proveedor.Iddomicilio;
                SqlCmd.Parameters.Add(ParIddomicilio);

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

        public string Eliminar(DProveedor Proveedor)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speliminar_proveedor";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdproveedor = new SqlParameter();
                ParIdproveedor.ParameterName = "@idproveedor";
                ParIdproveedor.SqlDbType = SqlDbType.Int;
                ParIdproveedor.Value = Proveedor.Idproveedor;
                SqlCmd.Parameters.Add(ParIdproveedor);

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
            DataTable DtResultado = new DataTable("proveedor");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_proveedor";
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

        public DataTable BuscarRazon(DProveedor Proveedor)
        {
            DataTable DtResultado = new DataTable("proveedor");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_proveedor_razon";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Proveedor.TextoBuscar;
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

        public DataTable BuscarCuitcuil(DProveedor Proveedor)
        {
            DataTable DtResultado = new DataTable("proveedor");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_proveedor_cuitcuil";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Proveedor.TextoBuscar;
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
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FrmCliente : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;
        private int ultimo;

        public FrmCliente()
        {
            InitializeComponent();
            this.txtIddomicilio.Visible = false;

        }

        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Limpiar()
        {
            this.txtIdcliente.Text = string.Empty;
            this.txtApellido.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtDni.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtIddomicilio.Text = string.Empty;
            this.txtLocalidad.Text = string.Empty;
            this.txtCalle.Text = string.Empty;
            this.txtNumero.Text = string.Empty;
            this.txtDepto.Text = string.Empty;
        }

        private void Habilitar(bool valor)
        {
            this.txtApellido.ReadOnly = !valor;
            this.txtNombre.ReadOnly = !valor;
            this.txtDni.ReadOnly = !valor;
            this.txtTelefono.ReadOnly = !valor;
            this.txtEmail.ReadOnly = !valor;
            this.txtIddomicilio.ReadOnly = !valor;
            this.txtLocalidad.ReadOnly = !valor;
            this.txtCalle.ReadOnly = !valor;
            this.txtNumero.ReadOnly = !valor;
            this.txtDepto.ReadOnly = !valor;

            this.cbProvincia.Enabled = valor;

        }

        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }

            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }
        }

        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
            this.dataListado.Columns[7].Visible = false;
        }

        private void Mostrar()
        {
            this.dataListado.DataSource = NCliente.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void BuscarApellido()
        {
            this.dataListado.DataSource = NCliente.BuscarApellido(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void BuscarDni()
        {
            this.dataListado.DataSource = NCliente.BuscarDni(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarApellido();
            this.BuscarDni();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarApellido();
            this.BuscarDni();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.cbProvincia.SelectedIndex = 22;
            this.txtApellido.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                string rpta1 = "";
                if (this.txtApellido.Text == string.Empty || this.txtNombre.Text == string.Empty || this.txtDni.Text == string.Empty ||
                    this.txtTelefono.Text == string.Empty || this.txtEmail.Text == string.Empty || this.txtLocalidad.Text == string.Empty ||
                    this.txtCalle.Text == string.Empty || this.txtNumero.Text == string.Empty)
                {
                    MensajeError("Faltan datos");
                    errorIcono.SetError(txtApellido, "Ingrese Apellido");
                    errorIcono.SetError(txtNombre, "Ingrese Nombre");
                    errorIcono.SetError(txtDni, "Ingrese DNI");
                    errorIcono.SetError(txtTelefono, "Ingrese Telefono");
                    errorIcono.SetError(txtEmail, "Ingrese Email");
                    errorIcono.SetError(txtLocalidad, "Ingrese Localidad");
                    errorIcono.SetError(txtCalle, "Ingrese Calle");
                    errorIcono.SetError(txtNumero, "Ingrese Numero");
                }
                else
                {

                    if (this.IsNuevo)
                    {

                        rpta1 = NDomicilio.Insertar(Convert.ToString(this.cbProvincia.Text), this.txtLocalidad.Text.Trim().ToUpper(),
                            this.txtCalle.Text.Trim().ToUpper(), this.txtNumero.Text, this.txtDepto.Text.Trim().ToUpper());

                        ultimo = NDomicilio.UltimoDomicilio();
                        this.txtIddomicilio.Text = Convert.ToString(ultimo);

                        rpta = NCliente.Insertar(this.txtApellido.Text.Trim().ToUpper(), this.txtNombre.Text.Trim().ToUpper(),
                            this.txtDni.Text, this.txtTelefono.Text, this.txtEmail.Text, Convert.ToInt32(this.txtIddomicilio.Text));
                    }
                    else
                    {
                        rpta1 = NDomicilio.Editar(Convert.ToInt32(this.txtIddomicilio.Text), Convert.ToString(this.cbProvincia.Text), this.txtLocalidad.Text.Trim().ToUpper(),
                            this.txtCalle.Text.Trim().ToUpper(), this.txtNumero.Text, this.txtDepto.Text.Trim().ToUpper());

                        rpta = NCliente.Editar(Convert.ToInt32(this.txtIdcliente.Text), this.txtApellido.Text.Trim().ToUpper(), this.txtNombre.Text.Trim().ToUpper(),
                            this.txtDni.Text, this.txtTelefono.Text, this.txtEmail.Text, Convert.ToInt32(this.txtIddomicilio.Text));
                    }

                    if (rpta.Equals("OK") && rpta1.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("Se guardó el registro");
                        }
                        else
                        {
                            this.MensajeOk("Se actualizó el registro");
                        }
                    }

                    if (!rpta.Equals("OK"))
                    {
                        this.MensajeError(rpta);
                    }

                    if (!rpta1.Equals("OK"))
                    {
                        this.MensajeError(rpta1);
                    }

                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();
                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtIdcliente.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);

            }
            else
            {
                this.MensajeError("Debe seleccionar un registro a modificar");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdcliente.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idcliente"].Value);
            this.txtApellido.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["apellido"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            this.txtDni.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["dni"].Value);
            this.txtTelefono.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["telefono"].Value);
            this.txtEmail.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["email"].Value);

            this.txtIddomicilio.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["iddomicilio"].Value);
            this.cbProvincia.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["provincia"].Value);
            this.txtLocalidad.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["localidad"].Value);
            this.txtCalle.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["calle"].Value);
            this.txtNumero.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["numero"].Value);
            this.txtDepto.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["depto"].Value);

            this.tabControl1.SelectedIndex = 1;
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {

            if (chkEliminar.Checked)
            {
                this.dataListado.Columns[0].Visible = true;
            }
            else
            {
                this.dataListado.Columns[0].Visible = false;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Desea eliminar los registros?", "Sistema", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string Codigo1;
                    string Rpta = "";
                    string Rpta1 = "";

                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Codigo1 = Convert.ToString(row.Cells[7].Value);
                            Rpta = NCliente.Eliminar(Convert.ToInt32(Codigo));
                            Rpta = NDomicilio.Eliminar(Convert.ToInt32(Codigo1));

                            if (Rpta.Equals("OK") && Rpta1.Equals("OK"))
                            {
                                this.MensajeOk("Se eliminó el registro");
                            }

                            if (!Rpta.Equals("OK"))
                            {
                                this.MensajeError(Rpta);
                            }

                            if (!Rpta1.Equals("OK"))
                            {
                                this.MensajeError(Rpta1);
                            }
                        }
                    }

                    this.Mostrar();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}

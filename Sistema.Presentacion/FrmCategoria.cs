using Sistema.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Presentacion
{
    public partial class FrmCategoria : Form
    {
        private string NombreAnt; /*para actualizacion*/
        public FrmCategoria()
        {
            InitializeComponent();
        }

        private void Listar()
        {
            try
            {
                DgvListado.DataSource = NCategoria.Listar();
                this.Formato();
                this.Limpiar();
                LblTotal.Text = "Total registros: " + Convert.ToString(DgvListado.Rows.Count);
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Buscar()
        {
            try
            {
                DgvListado.DataSource = NCategoria.Buscar(TxtBuscar.Text);
                this.Formato();
                LblTotal.Text = "Total registros: " + Convert.ToString(DgvListado.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Formato()
        {
            DgvListado.Columns[0].Visible = false;
            DgvListado.Columns[1].Visible = false;
            DgvListado.Columns[2].Width = 150;
            DgvListado.Columns[3].Width = 400;
            DgvListado.Columns[3].HeaderText = "Descripción";
            DgvListado.Columns[4].Width = 100;
        }

        private void Limpiar()
        {
            TxtBuscar.Clear();
            TxtNombre.Clear();
            TxtId.Clear();
            TxtDescripcion.Clear();
            BtnInsertar.Visible = true;
            BtnActualizar.Visible = false;
            ErrorIcono.Clear();
        }
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FrmCategoria_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                string Rpta = "";
                if(TxtNombre.Text == string.Empty)
                {
                    this.MensajeError("Falta ingresar algunos datos");
                    ErrorIcono.SetError(TxtNombre, "Ingrese un nombre.");
                }
                else
                {
                    Rpta = NCategoria.Insertar(TxtNombre.Text.Trim(), TxtDescripcion.Text);
                    if (Rpta.Equals("OK"))
                    {
                        this.MensajeOk("Se insertó de forma correcta la categoría");
                        this.Limpiar();
                        this.Listar();
                    }
                    else
                    {
                        this.MensajeError(Rpta);
                    }
                    
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

  
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            TabGeneral.SelectedIndex = 0; /*regresa al tab Listado*/
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                string Rpta = "";
                if (TxtNombre.Text == string.Empty || TxtId.Text == string.Empty)
                {
                    this.MensajeError("Falta ingresar algunos datos");
                    ErrorIcono.SetError(TxtNombre, "Ingrese un nombre");
                }
                else
                {
                    Rpta = NCategoria.Actualizar(Convert.ToInt32(TxtId.Text), this.NombreAnt, TxtNombre.Text.Trim(), TxtDescripcion.Text);
                    if (Rpta.Equals("OK"))
                    {
                        this.MensajeOk("Se actualizó de forma correcta la categoría");
                        this.Limpiar();
                        this.Listar();
                    }
                    else
                    {
                        this.MensajeError(Rpta);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

            private void DgvListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Limpiar();
            BtnActualizar.Visible = true;
            BtnInsertar.Visible = false;
            /*lleno los txt del formulario Mantenimiento con los datos seleccionados con doble click*/
            TxtId.Text = Convert.ToString(DgvListado.CurrentRow.Cells["ID"].Value);
            this.NombreAnt = Convert.ToString(DgvListado.CurrentRow.Cells["Nombre"].Value);
            TxtNombre.Text = Convert.ToString(DgvListado.CurrentRow.Cells["Nombre"].Value);
            TxtDescripcion.Text = Convert.ToString(DgvListado.CurrentRow.Cells["Descripcion"].Value);
            TabGeneral.SelectedIndex = 1;
        }
    }
}

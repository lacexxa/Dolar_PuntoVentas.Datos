using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dolar_PuntoVenta.Entidades;
using Dolar_PuntoVenta.Negocio;

namespace Dolar_PuntoVenta.Presentacion
{
    public partial class Frm_Punto_Venta : Form
    {
        public Frm_Punto_Venta()
        {
            InitializeComponent();
        }

        #region "Mis variables"
        int nCodigo = 0;
        int Estadogurda = 0;
        #endregion

        #region "Mi metodos"

        private void Formato_pv()
        {
            Dgv_Listado.Columns[0].Width = 100;
            Dgv_Listado.Columns[0].HeaderText = "CODIGO_PV";
            Dgv_Listado.Columns[1].Width = 435;
            Dgv_Listado.Columns[1].HeaderText = "PUNTO DE VENTA";
        }


        private void Frm_Punto_Venta_Load(object sender, EventArgs e)
        {
            this.Listado_pv("%");

        }
        private void Listado_pv(string cTexto)
        {
            try
            {
                Dgv_Listado.DataSource = N_Punto_Venta.Listado_pv(cTexto);
                this.Formato_pv();
                lbl_totalregistros.Text = "Total registros:" +Convert.ToString( Dgv_Listado.Rows.Count);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void Estado_BotonesPrincipales(bool lEstado)
        {
            btn_Nuevo.Enabled = lEstado;
            btn_Actualizar.Enabled = lEstado;
            btn_Eliminar.Enabled = lEstado;          
            btn_Reporte.Enabled = lEstado;
            btn_Salir.Enabled = lEstado;

        }
        private void Limpia_texto()
        {
            Txt_descripcion.Text = "";       
        }
        private void Estado_texto (bool lEstado)
        {
            Txt_descripcion.ReadOnly = !lEstado;

        }
        private void Estado_BotonesProceso(bool lEstado) {

            btn_cancelar.Visible = lEstado;
            btn_guardar.Visible = lEstado;
            btn_retornar.Visible = !lEstado;

        }

        #endregion

        private void btn_Nuevo_Click(object sender, EventArgs e)
        {
            this.Estado_BotonesPrincipales(false);
            this.Estado_BotonesProceso(true);
            this.Limpia_texto();
            this.Estado_texto(true);
            Tbc_principal.SelectedIndex = 1;
            Txt_descripcion.Focus();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Limpia_texto();
            this.Estado_texto(false);
            this.Estado_BotonesPrincipales(true);
            this.Estado_BotonesProceso(false);
            Tbc_principal.SelectedIndex = 0;
        }

        private void btn_retornar_Click(object sender, EventArgs e)
        {
            Tbc_principal.SelectedIndex = 0;
        }
    }
}

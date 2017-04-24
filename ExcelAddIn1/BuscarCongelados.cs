using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Respuesta;

namespace ExcelAddIn1
{
    public partial class BuscarCongelados : Form
    {
        private readonly List<Respuesta.Receta.Congelados> _listaCongelados;
        private readonly Action<List<Respuesta.Receta.Congelados>> _callback;
      
        public BuscarCongelados(List<Respuesta.Receta.Congelados> listaCongelados, Action<List<Respuesta.Receta.Congelados>> callback,Array origen,int segundo)
        {

            /*checa en la conversion de jsonResult a List... me suena que por ahi esta tronando porque aqui ya no trae registros*/
            _listaCongelados = listaCongelados;
            _callback = callback;
            InitializeComponent();

            if (segundo == 1)
            {
                txtcantidad.Visible = true;
                lbtclave.Visible = true;
                lbtdescripcion.Visible = true;
                lbcantidad.Visible = true;
            }

            
            //var cg = new Congelados();
            //if (Congelados().tabControl1.SelectedTab == Congelados().tabControl1.TabPages[0])
            //{
            //    txtcantidad.Visible = true;
            //}

            dgvbuscar_congelados.DataSource = origen;
                dgvbuscar_congelados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void btaceptarbcongelados_Click(object sender, EventArgs e)
        {
            /*aqui es donde guardas la lista para mandarla al otro databridview ?*/

            _listaCongelados[dgvbuscar_congelados.CurrentCell.RowIndex].cantidad = double.Parse(txtcantidad.Text);
                _callback(new List<Respuesta.Receta.Congelados> { _listaCongelados[dgvbuscar_congelados.CurrentCell.RowIndex]});
                Close();


            
            //_listaCongelados[dgvbuscar_congelados.CurrentCell.RowIndex].cantidad = double.Parse(tbCantidad.Text);

        }

        private void BuscarCongelados_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void BuscarCongelados_Load(object sender, EventArgs e)
        {
            lbfechaagregar.Text = DateTime.Now.ToShortDateString();
            
        }

        private void dgvbuscar_congelados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //int row = Convert.ToInt16(dgvbuscar_congelados.Rows[e.RowIndex]);
            //int calis = Convert.ToInt16(dgvbuscar_congelados.Rows[e.RowIndex]);
           
            //string descripcion = dgvbuscar_congelados.Rows[e.RowIndex].Cells[2].Value.ToString(); 
            //lbdescripcion.Text = descripcion;
        }

        private void dgvbuscar_congelados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcantidad.Text = @"1";
            txtcantidad.SelectionStart = 0;
            txtcantidad.SelectionLength = txtcantidad.Text.Length;
            txtcantidad.Focus();
            lbdescripcion.Text = dgvbuscar_congelados.CurrentRow.Cells["descripcion"].Value.ToString();
            lbclave.Text = dgvbuscar_congelados.CurrentRow.Cells["clave"].Value.ToString();
            lbclave.Visible = true;
            lbdescripcion.Visible = true;
            //lbdescripcion.Text = dgvbuscar_congelados.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}

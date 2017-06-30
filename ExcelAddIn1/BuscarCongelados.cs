using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

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
            else
            {
                lbcantidad.Visible = true;
                txtcantidad.Visible = true;
                //txtcantidad.Text = dgvbuscar_congelados.CurrentRow.Cells[4].Value.ToString();
            }


            //var cg = new Congelados();
            //if (Congelados().tabControl1.SelectedTab == Congelados().tabControl1.TabPages[0])
            //{
            //    txtcantidad.Visible = true;
            //}

            dgvbuscar_congelados.DataSource = origen;
                dgvbuscar_congelados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        public BuscarCongelados(List<Respuesta.Receta.Congelados> listaCongelados, Action<List<Respuesta.Receta.Congelados>> callback)
        {

            /*checa en la conversion de jsonResult a List... me suena que por ahi esta tronando porque aqui ya no trae registros*/
            _listaCongelados = listaCongelados;
            _callback = callback;
            InitializeComponent();

           
                txtcantidad.Visible = true;
                lbtclave.Visible = true;
                lbtdescripcion.Visible = true;
                lbcantidad.Visible = true;
     


            //var cg = new Congelados();
            //if (Congelados().tabControl1.SelectedTab == Congelados().tabControl1.TabPages[0])
            //{
            //    txtcantidad.Visible = true;
            //}
<<<<<<< HEAD
            dgvbuscar_congelados.DataSource = _listaCongelados.Select(x => new {art_id = x.ArtId, clave = x.Clave, descripcion = x.Descripcion, cantidad = x.Cantidad }).ToArray(); ;
=======


            dgvbuscar_congelados.DataSource = _listaCongelados.Select(x => new {art_id = x.ArtId, clave = x.Clave, descripcion = x.Platillo, cantidad = x.Cantidad }).ToArray(); ;
>>>>>>> origin/master
            dgvbuscar_congelados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }
        private void btaceptarbcongelados_Click(object sender, EventArgs e)
        {

            /* _listaArticulo[dgvListaArticulos.CurrentCell.RowIndex].cantidad = double.Parse(tbCantidad.Text);
            _callback(new List<Articulo> { _listaArticulo[dgvListaArticulos.CurrentCell.RowIndex] });
            Close();*/

            /*aqui es donde guardas la lista para mandarla al otro databridview ?*/

            _listaCongelados[dgvbuscar_congelados.CurrentCell.RowIndex].Cantidad = double.Parse(txtcantidad.Text);
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
<<<<<<< HEAD

            if (dgvbuscar_congelados.CurrentRow != null)return;


=======
<<<<<<< HEAD
            if (dgvbuscar_congelados.CurrentRow != null)return;
=======
<<<<<<< HEAD
=======
<<<<<<< HEAD
            if (dgvbuscar_congelados.CurrentRow != null)return;
=======
<<<<<<< HEAD
>>>>>>> origin/master
>>>>>>> origin/master
>>>>>>> origin/master
            //txtcantidad.Text = dgvbuscar_congelados.CurrentRow.Cells[4].Value.ToString();

        }

        private void dgvbuscar_congelados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //int row = Convert.ToInt16(dgvbuscar_congelados.Rows[e.RowIndex]);
            //int calis = Convert.ToInt16(dgvbuscar_congelados.Rows[e.RowIndex]);
           
            //string descripcion = dgvbuscar_congelados.Rows[e.RowIndex].Cells[2].Value.ToString(); 
            //lbdescripcion.Text = descripcion;
<<<<<<< HEAD
            //txtcantidad.Text = dgvbuscar_congelados.CurrentRow.Cells[4].Value.ToString();
=======

            if (dgvbuscar_congelados.CurrentRow != null) ;

            //txtcantidad.Text = dgvbuscar_congelados.CurrentRow.Cells[4].Value.ToString();

>>>>>>> origin/master
        }
        private void dgvbuscar_congelados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcantidad.Text = @"1";
            txtcantidad.SelectionStart = 0;
            txtcantidad.SelectionLength = txtcantidad.Text.Length;
            txtcantidad.Focus();
            if (dgvbuscar_congelados.CurrentRow != null)
            {
                lbdescripcion.Text = dgvbuscar_congelados.CurrentRow.Cells["descripcion"].Value.ToString();
                lbclave.Text = dgvbuscar_congelados.CurrentRow.Cells["clave"].Value.ToString();
            }
            lbclave.Visible = true;
            lbdescripcion.Visible = true;
            //lbdescripcion.Text = dgvbuscar_congelados.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}

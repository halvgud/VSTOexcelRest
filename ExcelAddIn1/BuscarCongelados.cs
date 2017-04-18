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
        public BuscarCongelados(List<Respuesta.Receta.Congelados> listaCongelados, Action<List<Respuesta.Receta.Congelados>> callback)
        {
            /*checa en la conversion de jsonResult a List... me suena que por ahi esta tronando porque aqui ya no trae registros*/
            _listaCongelados = listaCongelados;
            _callback = callback;
            InitializeComponent();
           dgvbuscar_congelados.DataSource = _listaCongelados.ToArray();
           dgvbuscar_congelados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btaceptarbcongelados_Click(object sender, EventArgs e)
        {
            /*aqui es donde guardas la lista para mandarla al otro databridview ?*/

            //_listaCongelados[dgvbuscar_congelados.CurrentCell.RowIndex].cantidad = double.Parse(tbCantidad.Text);
            _callback(new List<Respuesta.Receta.Congelados> { _listaCongelados[dgvbuscar_congelados.CurrentCell.RowIndex] });
            Close();
        }

        private void BuscarCongelados_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }
    }
}

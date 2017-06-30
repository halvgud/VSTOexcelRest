using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace ExcelAddIn1
{
    public partial class AgregarCongelados : Form
    {
        internal Action<List<Respuesta.Receta.Congelados>> Callback;
        public AgregarCongelados(List<Respuesta.Receta.Congelados> listaCongelados, Action<List<Respuesta.Receta.Congelados>> callback)
        {
            /*checa en la conversion de jsonResult a List... me suena que por ahi esta tronando porque aqui ya no trae registros*/
            Callback = callback;
            InitializeComponent();
            dtgagregarcongelados.DataSource = listaCongelados.ToArray();
            dtgagregarcongelados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}

using System;
using System.Windows.Forms;
using testVSTO2.Prop;

namespace testVSTO2
{
    public partial class SideBarRecetario : UserControl
    {
        public SideBarRecetario()
        {
            InitializeComponent();
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            var br = new BusquedaReceta();
            br.Show();
        }

        private void btBuscarReceta_Click(object sender, EventArgs e)
        {
            Config.Local.Receta.clave = (tbBuscarReceta.Text);
            Opcion.EjecucionAsync(Data.Receta.Lista, jsonResult =>
            {
                BeginInvoke((MethodInvoker) (() =>
                {
                    var brd =
                        new BusquedaRecetaDetalle(Opcion.JsonaListaGenerica<Respuesta.Receta>(jsonResult));
                    brd.Show();
                }));
            });
        }
    }
}

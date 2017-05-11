﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Herramienta;
using Herramienta.Config;
using Respuesta;
using RestSharp;

namespace ExcelAddIn1
{
    public partial class SideBarReporteReceta : UserControl
    {
        public SideBarReporteReceta()
        {
            InitializeComponent();
          
        }

        //esos errores no me avian salido ahorita }
        public List<Respuesta.CbGenerico> _ListproductoList;
        public List<Respuesta.CbGenerico> _ListorderList; 

        private void btGenerarReceta_Click(object sender, EventArgs e)
        {
            //var datosimportar = new Respuesta.Orderbyandgroupby()
            //{
            //    Id = cbproducto.SelectedIndex,
            //    Order = cbOrdenarReceta.SelectedItem.ToString()
            //}
            // ;

            var datosimportar = new Respuesta.CbGenerico()
            {
                Id = cbproducto.SelectedValue.ToString(),
                Nombre = cbOrdenarReceta.SelectedValue.ToString()
            };
            var addIn = Globals.ThisAddIn;
            //me marca este erros al primer opci

            /*en ninguna ejecucion async se pone el parametro de clase como parametro...
             va directo al Data, mira, recuerda que son 2 partes... una inicial y una final
             en la inicial tu le envias, y en la final tu recibes y decides que hacer conesa info*/
           

            Opcion.EjecucionAsync(x =>
            {
                Data.ReporteCocina.VersionExtendida(x, datosimportar); /*de momento pude quedar con esa clase... Pero 
                te recomendaria usar la misma clase que usas para generar tu reporte
                en  la y de abajo es tu resultado, en este caso es un IRestResponse que se va a addIn.ReporteCocina*/
            }, y =>
            {
                BeginInvoke((MethodInvoker)(() =>
                {
                    addIn.ReporteCocina(y);
                }));
            });
     
        }

        private void cbConceptoReceta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        /*por eso era mantener el nombre de la carpeta, aqui le pusiste v2*/
        public void CargarComboBox(IRestResponse json, ComboBox tipoReceta)
        {
            BeginInvoke((MethodInvoker)(() =>
            {
                var bindingSource1 = new BindingSource
                {
                    DataSource = Opcion.JsonaListaGenerica<CbGenerico>(json)
                };
                tipoReceta.DataSource = bindingSource1; 
                tipoReceta.DisplayMember = "Nombre";
                tipoReceta.ValueMember = "Id";
                tipoReceta.Tag = json;
            }));
        }

        private void SideBarReporteReceta_Load(object sender, EventArgs e)
        {
            


            Opcion.EjecucionAsync(Data.ParametroProducto.Lista, x =>
            {
                CargarComboBox(x, cbproducto);
               

            });
            Opcion.EjecucionAsync(Data.ParametroReceta.Lista, x =>
            {
                CargarComboBox(x, cbOrdenarReceta);
                
            });

           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SideBarReporteReceta_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void cbproducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbOrdenarReceta.Enabled = true;

        }

        private void cbOrdenarReceta_SelectedIndexChanged(object sender, EventArgs e)
        {
            btGenerarReceta.Enabled = true;
        }
    }
}

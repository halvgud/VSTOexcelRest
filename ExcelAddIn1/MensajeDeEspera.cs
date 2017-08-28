using System;
using System.Windows.Forms;

namespace ExcelAddIn1
{
    public partial class MensajeDeEspera : Form
    {
        public MensajeDeEspera()
        {
            InitializeComponent();
        }

        private readonly Func<bool> _callback;
        public MensajeDeEspera(Func<bool> callback)
        {
            InitializeComponent();
            _callback = callback;
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            if (_callback())
            {
                Close();
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Capa_LogicaNegocio;
using Capa_Entidades;
using System.Linq;
using System.Threading.Tasks;

namespace Capa_Presentación
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void médicosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMedico frm = new FrmMedico();
            frm.MdiParent = this;
            frm.Show();
        }

        private void pacientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPacientes frm = new FrmPacientes();
            frm.MdiParent = this;
            frm.Show();
        }

        private void historialMedicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmHistorial frm = new FrmHistorial();
            frm.MdiParent = this;
            frm.Show();
        }

        private void medicamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMedicamentos frm = new FrmMedicamentos();
            frm.MdiParent = this;
            frm.Show();
        }

        private void citasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCitas frm = new FrmCitas();
            frm.MdiParent = this;
            frm.Show();
        }

        private void pagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPagos frm = new FrmPagos();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}

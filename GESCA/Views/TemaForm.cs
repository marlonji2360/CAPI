using GESCA.Controllers;
using GESCA.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GESCA.Views
{
    public partial class TemaForm : Form
    {
        int id = 0;
        public TemaForm()
        {
            InitializeComponent();
            TemaController controller = new TemaController();
            BindTemas(controller.MostrarTema());
        }

        public void BindTemas(List<Tema> items)
        {
            dgvTemas.DataSource = null;
            dgvTemas.DataSource = items;
        }

        private void Limpiar()
        {
            txtNombre.Clear();
            id = 0;
            txtNombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Tema tema = new Tema();
            TemaController temaController = new TemaController();
            tema.Nombre = txtNombre.Text;

            if(id == 0)
            {


                id = temaController.InsertarTema(tema);
                tema.IdTema = id;

            }
            else
            {
                tema.IdTema = id;
                temaController.ActualizarTema(tema);
            }
            BindTemas(temaController.MostrarTema());
            Limpiar();

        }

        private void dgvTemas_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(dgvTemas.CurrentRow.Cells["IdTema"].Value.ToString());
            txtNombre.Text = dgvTemas.CurrentRow.Cells["Nombre"].Value == null ? null : dgvTemas.CurrentRow.Cells["Nombre"].Value.ToString();
        }
    }
}

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
    public partial class LugarCapacitacionForm : Form
    {
        int id = 0;
        public LugarCapacitacionForm()
        {
            InitializeComponent();
            LugarLugarCapacitacionController controller = new LugarLugarCapacitacionController();
            BindLugares(controller.MostrarLugarCapacitacion());

        }

        public void BindLugares(List<LugarCapacitacion> items)
        {
            dgvLugares.DataSource = null;
            dgvLugares.DataSource = items;
        }

        private void Limpiar()
        {
            txtLugar.Clear();
            id = 0;
            txtLugar.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            LugarCapacitacion lugarCapacitacion = new LugarCapacitacion();
            LugarLugarCapacitacionController controller = new LugarLugarCapacitacionController();
            lugarCapacitacion.Lugar = txtLugar.Text;

            if (id == 0)
            {


                id = controller.InsertarLugarCapacitacion(lugarCapacitacion);
                lugarCapacitacion.IdLugar = id;

            }
            else
            {
                lugarCapacitacion.IdLugar = id;
                controller.ActualizarLugarCapacitacion(lugarCapacitacion);
            }
            BindLugares(controller.MostrarLugarCapacitacion());
            Limpiar();
        }

        private void dgvLugares_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(dgvLugares.CurrentRow.Cells["IdLugar"].Value.ToString());
            txtLugar.Text = dgvLugares.CurrentRow.Cells["Lugar"].Value == null ? null : dgvLugares.CurrentRow.Cells["Lugar"].Value.ToString();
        }
    }
}

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
using static System.Windows.Forms.MonthCalendar;

namespace GESCA.Views
{
    public partial class CapacitadorForm : Form
    {
        int id = 0;
        public CapacitadorForm()
        {
            InitializeComponent();
            CapacitadorController controller = new CapacitadorController();
            BindCapacitador(controller.MostrarCapacitador());
        }

        public void BindCapacitador(List<Capacitador> items)
        {
            dgvCapacitador.DataSource = null;
            dgvCapacitador.DataSource = items;
        }

        private void Limpiar()
        {
            txtNombreCompleto.Clear();
            txtNombreEmpresa.Clear();
            id = 0;
            txtNombreCompleto.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Capacitador capacitador = new Capacitador();
            CapacitadorController controller = new CapacitadorController();
            capacitador.NombreCompleto = txtNombreCompleto.Text;            
            capacitador.NombreEmpresa = txtNombreEmpresa.Text;
            

            if (id == 0)
            {
                

                id = controller.InsertarCapacitador(capacitador);
                capacitador.IdCapacitador = id;
                
            }
            else
            {
                capacitador.IdCapacitador = id;
                controller.ActualizarCapacitador(capacitador);
            }
            BindCapacitador(controller.MostrarCapacitador());
            Limpiar();
        }

        private void dgvCapacitador_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {   
           
                
            id = int.Parse(dgvCapacitador.CurrentRow.Cells["IdCapacitador"].Value.ToString());
            txtNombreCompleto.Text = dgvCapacitador.CurrentRow.Cells["NombreCompleto"].Value == null ? null : dgvCapacitador.CurrentRow.Cells["NombreCompleto"].Value.ToString();
            txtNombreEmpresa.Text = dgvCapacitador.CurrentRow.Cells["NombreEmpresa"].Value == null ? null : dgvCapacitador.CurrentRow.Cells["NombreEmpresa"].Value.ToString();


        }
    }
}

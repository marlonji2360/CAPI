using ClosedXML.Excel;
using GESCA.Controllers;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GESCA.Views
{
    public partial class ReporteIve : Form
    {
        public ReporteIve()
        {
            InitializeComponent();
        }

        private void cmbTipoBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTipoBusqueda.SelectedItem.ToString())
            {
                case "Fecha":
                    txtValor.Visible = false;
                    lblValor.Visible = false;
                    lblAl.Visible = true;
                    lblDel.Visible = true;
                    dtpDel.Visible = true;
                    dtpAl.Visible = true;
                    break;
                default:
                    txtValor.Visible = true;
                    lblValor.Visible = true;
                    lblAl.Visible = false;
                    lblDel.Visible = false;
                    dtpDel.Visible = false;
                    dtpAl.Visible = false;
                    break;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            switch (cmbTipoBusqueda.SelectedItem.ToString())
            {
                case "Identificador":
                    CapacitacionController controller = new CapacitacionController();
                    dgvCapacitacion.DataSource= controller.BuscarPorCampo("Identificacion", txtValor.Text);
                    break;
                case "Fecha":
                    CapacitacionController controller2 = new CapacitacionController();
                    dgvCapacitacion.DataSource = controller2.BuscarPorFecha(dtpDel.Value,dtpAl.Value);
                    break;
                case "Lugar":
                    CapacitacionController controller3 = new CapacitacionController();
                    dgvCapacitacion.DataSource = controller3.BuscarPorCampo("Lugar", txtValor.Text);
                    break;
                case "Tema":
                    CapacitacionController controller4 = new CapacitacionController();
                    dgvCapacitacion.DataSource = controller4.BuscarPorCampo("Tema", txtValor.Text);
                    break;
                case "Tipo Actividad":
                    CapacitacionController controller5 = new CapacitacionController();
                    dgvCapacitacion.DataSource = controller5.BuscarPorCampo("[Tipo De Actividad]", txtValor.Text);
                    break;
                case "Capacitador":
                    CapacitacionController controller6 = new CapacitacionController();
                    dgvCapacitacion.DataSource = controller6.BuscarPorCampo("Capacitador", txtValor.Text);
                    break;
                case "Duracion":
                    CapacitacionController controller7 = new CapacitacionController();
                    dgvCapacitacion.DataSource = controller7.BuscarPorCampo("[Duracion En Horas]", txtValor.Text);
                    break;
                case "Capacitado":
                    CapacitacionController controller8 = new CapacitacionController();
                    dgvCapacitacion.DataSource = controller8.BuscarPorCampo("Capacitado", txtValor.Text);
                    break;
                case "Puesto":
                    CapacitacionController controller9 = new CapacitacionController();
                    dgvCapacitacion.DataSource = controller9.BuscarPorCampo("[Puesto De Trabajo]", txtValor.Text);
                    break;
            }
        }
        private void ExportarDataTableAExcel(DataTable dataTable)
        {
            if (dataTable.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog
                {
                    Filter = "Excel Workbook (*.xlsx)|*.xlsx",
                    FileName = "Datos.xlsx"
                };

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            wb.Worksheets.Add(dataTable, "Datos");
                            wb.SaveAs(sfd.FileName);
                        }

                        PlayNotificationSound();
                        MessageBox.Show("Datos Exportados Correctamente !!!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        PlayNotificationSound();
                        MessageBox.Show("Error al exportar a Excel: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                PlayNotificationSound();
                MessageBox.Show("No hay datos para Exportar !!!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void PlayNotificationSound()
        {
            bool found = false;
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"AppEvents\Schemes\Apps\.Default\Notification.Default\.Current"))
                {
                    if (key != null)
                    {
                        Object o = key.GetValue(null); // pass null to get (Default)
                        if (o != null)
                        {
                            SoundPlayer theSound = new SoundPlayer((String)o);
                            theSound.Play();
                            found = true;
                        }
                    }
                }
            }
            catch
            { }
            if (!found)
                SystemSounds.Beep.Play(); // consolation prize
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            var dt = dgvCapacitacion.DataSource as DataTable
                        ?? (dgvCapacitacion.DataSource as DataView)?.ToTable();
            ExportarDataTableAExcel(dt);
        }
        private void ExportarDataTableATxt(DataTable dataTable)
        {
            if (dataTable == null || dataTable.Rows.Count < 1)
            {
                PlayNotificationSound();
                MessageBox.Show("No hay suficientes datos para exportar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Archivo de texto (*.txt)|*.txt";
                sfd.FileName = "Resultado.txt";

                if (sfd.ShowDialog() != DialogResult.OK)
                    return;

                string filePath = sfd.FileName;

                try
                {
                    // Si ya existe, eliminarlo
                    if (File.Exists(filePath))
                        File.Delete(filePath);

                    StringBuilder sb = new StringBuilder();

                    // Exportar desde la fila 2 (índice 1)
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        DataRow row = dataTable.Rows[i];
                        var fields = row.ItemArray.Select(field => field?.ToString()?.Replace("\r", "").Replace("\n", "").Trim());
                        sb.AppendLine(string.Join("|", fields));
                    }

                    File.WriteAllText(filePath, sb.ToString(), Encoding.Default);

                    PlayNotificationSound();
                    MessageBox.Show("Datos exportados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (IOException ioEx)
                {
                    PlayNotificationSound();
                    MessageBox.Show("Error de archivo: " + ioEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    PlayNotificationSound();
                    MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnIve_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            switch (cmbTipoBusqueda.SelectedItem.ToString())
            {
                case "Identificador":
                    CapacitacionController controller = new CapacitacionController();
                    dataTable = controller.BuscarPorCampoTxt("Identificacion", txtValor.Text);
                    break;
                case "Fecha":
                    CapacitacionController controller2 = new CapacitacionController();
                    dataTable = controller2.BuscarPorFechaTxt(dtpDel.Value, dtpAl.Value);
                    break;
                case "Lugar":
                    CapacitacionController controller3 = new CapacitacionController();
                    dataTable = controller3.BuscarPorCampoTxt("Lugar", txtValor.Text);
                    break;
                case "Tema":
                    CapacitacionController controller4 = new CapacitacionController();
                    dataTable = controller4.BuscarPorCampoTxt("Tema", txtValor.Text);
                    break;
                case "Tipo Actividad":
                    CapacitacionController controller5 = new CapacitacionController();
                    dataTable = controller5.BuscarPorCampoTxt("[Tipo De Actividad]", txtValor.Text);
                    break;
                case "Capacitador":
                    CapacitacionController controller6 = new CapacitacionController();
                    dataTable = controller6.BuscarPorCampoTxt("Capacitador", txtValor.Text);
                    break;
                case "Duracion":
                    CapacitacionController controller7 = new CapacitacionController();
                    dataTable = controller7.BuscarPorCampoTxt("[Duracion En Horas]", txtValor.Text);
                    break;
                case "Capacitado":
                    CapacitacionController controller8 = new CapacitacionController();
                    dataTable = controller8.BuscarPorCampoTxt("Capacitado", txtValor.Text);
                    break;
                case "Puesto":
                    CapacitacionController controller9 = new CapacitacionController();
                    dataTable = controller9.BuscarPorCampoTxt("[Puesto De Trabajo]", txtValor.Text);
                    break;
            }
           
            ExportarDataTableATxt(dataTable);
        }

        private void btnDiploma_Click(object sender, EventArgs e)
        {
            

            if (dgvCapacitacion.SelectedRows.Count > 0)
            {
                var fila = dgvCapacitacion.SelectedRows[0];
                var valor = fila.Cells["Identificacion"].Value;
                int id = Convert.ToInt32(valor);
                DiplomasForm diplomasForm = new DiplomasForm(id);
                diplomasForm.Show();
            }
        }
    }
}

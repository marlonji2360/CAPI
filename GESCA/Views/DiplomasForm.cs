using DocumentFormat.OpenXml.Wordprocessing;
using GESCA.Controllers;
using GESCA.Data;
using GESCA.Models;
using GESCA.Services;
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
    public partial class DiplomasForm : Form
    {
        private readonly int _idCap;
        private readonly ParticipantesDiplomaRepository _repo = new ParticipantesDiplomaRepository();
        private readonly CapacitacionController _capacitacion = new CapacitacionController();
        private readonly CapacitadorController _capacitador = new CapacitadorController();
        public DiplomasForm(int idCapacitacion)
        {
            InitializeComponent();
            _idCap = idCapacitacion;
        }

        private void DiplomasForm_Load(object sender, EventArgs e)
        {
            dgv.AutoGenerateColumns = true; // o define columnas
            var participantes = _repo.ListByCapacitacion(_idCap);
            dgv.DataSource = participantes;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count == 0) { MessageBox.Show("No hay participantes."); return; }

            using (var fbd = new FolderBrowserDialog { Description = "Carpeta de salida para los diplomas" })
            {
                if (fbd.ShowDialog(this) != DialogResult.OK) return;
                string carpeta = fbd.SelectedPath;

                // Datos de la capacitación (si los quieres en el diploma: tema, fechas, etc.)
                // Trae con tu CapacitacionController/Repo (no incluido aquí por brevedad).
                // Supongamos:
                var datosCap = _capacitacion.BuscarCapacitacionPorId(_idCap);
                var datosCapacitador = _capacitador.BuscarCapacitadorPorIdDiploma(datosCap.IdCapacitacion);
                // datosCap.Tema, .FechaInicial, .FechaFinal, .DuracionHrs, .Lugar, etc.

                var participantes = (dgv.DataSource as List<ParticipanteDiploma>) ?? new List<ParticipanteDiploma>();
                var servicio = new PdfDiplomaService();
                int ok = 0, fail = 0;

                foreach (var p in participantes)
                {
                    try
                    {
                        servicio.GenerarDiplomaDesdePlantilla(
                            plantillaPdfPath: @"C:\Software\CAPI\Formato_para_constancia.pdf", // <-- AJUSTA ESTA RUTA
                            salidaPdfPath: System.IO.Path.Combine(carpeta, $"Diploma_{p.NombreCompleto}.pdf"),
                            nombreCompleto: p.NombreCompleto,
                            puesto: p.Puesto,
                            tema: datosCap.Tema,
                            empresa: p.NombreEmpresa,
                            capacitador: datosCapacitador.NombreCompleto,
                            fechaInicial: datosCap.FechaInicial,
                            fechaFinal: datosCap.FechaFinal,
                            duracionHrs: datosCap.DuracionHrs
                        );
                        ok++;
                    }
                    catch
                    {
                        fail++;
                    }

                }

                MessageBox.Show($"Listo. Generados: {ok}. Fallidos: {fail}.");
            }
        }
    }
}

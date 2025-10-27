using ClosedXML.Excel;
using GESCA.Controllers;
using GESCA.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GESCA.Views
{
    public partial class CapacitacionForm : Form
    {
        int idCapacitacion = 0;
        private readonly BindingList<Capacitador> _seleccionados = new BindingList<Capacitador>();

        public CapacitacionForm()
        {
            InitializeComponent();            
            CatalogosController catalogosController = new CatalogosController();
            BindLugares(catalogosController.Lugares());
            BindCapacitadores(catalogosController.Capacitadores());
            BindTemas(catalogosController.Temas());

            // ---- Configurar grilla de seleccionados ----
            dgvCapacitadores.AutoGenerateColumns = false; // definimos columnas manualmente

            // Columna oculta: Id
            var colId = new DataGridViewTextBoxColumn
            {
                HeaderText = "Id",
                DataPropertyName = "IdCapacitador",
                Name = "IdCapacitador",
                Visible = false
            };
            // Columna visible: Nombre
            var colNombre = new DataGridViewTextBoxColumn
            {
                HeaderText = "Capacitador",
                DataPropertyName = "NombreCompleto",
                Name = "NombreCompleto",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            // (Opcional) Columna botón Quitar
            var colQuitar = new DataGridViewButtonColumn
            {
                HeaderText = "",
                Text = "Quitar",
                UseColumnTextForButtonValue = true,
                Name = "Quitar"
            };

            dgvCapacitadores.Columns.AddRange(colId, colNombre, colQuitar);

            // Enlazar la grilla a la lista
            dgvCapacitadores.DataSource = _seleccionados;

            // Manejar clic del botón "Quitar"
            dgvCapacitadores.CellContentClick += dgvCapacitadores_CellContentClick;

            mtbInicio.TextChanged += (_, __) => RecalcularDuracionHoras();
            mtbFinal.TextChanged += (_, __) => RecalcularDuracionHoras();


        }

        private void RecalcularDuracionHoras()
        {
            // Si usás Mask="00:00" en ambos MaskedTextBox, aprovechá MaskCompleted
            if (!mtbInicio.MaskCompleted || !mtbFinal.MaskCompleted)
            {
                txtDuracion.Clear();
                return;
            }

            if (!TimeSpan.TryParseExact(mtbInicio.Text, "hh\\:mm", CultureInfo.InvariantCulture, out var hi) ||
                !TimeSpan.TryParseExact(mtbFinal.Text, "hh\\:mm", CultureInfo.InvariantCulture, out var hf))
            {
                txtDuracion.Clear();
                return;
            }

            // Diferencia en horas (maneja cruce de medianoche)
            double horas = (hf - hi).TotalHours;
            if (horas < 0) horas += 24;

            // Tu columna DuracionHrs es INT: redondeamos al entero más cercano.
            int dur = (int)Math.Round(horas, MidpointRounding.AwayFromZero);
            txtDuracion.Text = dur.ToString();
        }

        public void BindLugares(List<LugarCapacitacion> items)
        {
            cboLugar.DataSource = items;
            cboLugar.DisplayMember = "Lugar";
            cboLugar.ValueMember = "IdLugar";
        }

        public void BindCapacitadores(List<Capacitador> items)
        {
            cboCapacitador.DataSource = items;
            cboCapacitador.DisplayMember = "NombreCompleto";
            cboCapacitador.ValueMember = "IdCapacitador";
        }

        public void BindTemas(List<Tema> items)
        {
            cboTema.DataSource = items;
            cboTema.DisplayMember = "Nombre";
            cboTema.ValueMember = "IdTema";
        }

        private DataTable LeerExcelEnDataTable(string rutaArchivo)
        {
            DataTable dataTable = new DataTable();

            using (var workbook = new XLWorkbook(rutaArchivo))
            {
                var hoja = workbook.Worksheet(1); // Lee la primera hoja
                bool esPrimeraFila = true;

                foreach (var fila in hoja.RowsUsed())
                {
                    if (esPrimeraFila)
                    {
                        foreach (var celda in fila.Cells())
                        {
                            dataTable.Columns.Add(celda.Value.ToString());
                        }
                        esPrimeraFila = false;
                    }
                    else
                    {
                        DataRow row = dataTable.NewRow();
                        int i = 0;
                        foreach (var celda in fila.Cells(1, dataTable.Columns.Count))
                        {
                            row[i++] = celda.Value.ToString();
                        }
                        dataTable.Rows.Add(row);
                    }
                }
            }

            return dataTable;
        }

        private void GuardarCapacitacionYDetalles()
        {
            Capacitacion capacitacion = new Capacitacion();
            capacitacion.FechaInicial = DateTime.Parse(dtpFechaInicial.Text);
            capacitacion.FechaFinal = DateTime.Parse(dtpFechaFinal.Text);
            capacitacion.DuracionHrs = Int32.Parse(txtDuracion.Text);
            capacitacion.HoraInicio = TimeSpan.Parse(mtbInicio.Text);
            capacitacion.HoraFinal = TimeSpan.Parse(mtbFinal.Text);
            capacitacion.Estado = txtEstado.Text;
            capacitacion.TipoActividad = txtTipoActividad.Text;
            capacitacion.LugarCapacitacion_IdLugar = Int32.Parse(cboLugar.SelectedValue.ToString());
            capacitacion.Tema_IdTema = Int32.Parse(cboTema.SelectedValue.ToString()); // OJO si tu modelo usa TemasDesarrollados_IdTema

            if (idCapacitacion == 0)
            {
                CapacitacionController capacitacionC = new CapacitacionController();
                idCapacitacion = capacitacionC.InsertarCapacitacion(capacitacion);

                DetalleCapacitadorController detCapCtrl = new DetalleCapacitadorController();
                foreach (DataGridViewRow row in dgvCapacitadores.Rows)
                {
                    if (row.IsNewRow) continue;
                    object val = row.Cells["IdCapacitador"].Value;
                    if (val == null || val == DBNull.Value) continue;
                    int idCapacitador = Convert.ToInt32(val);
                    detCapCtrl.InsertarDetalleCapacitador(idCapacitacion, idCapacitador);
                }

                Estudiante estudiante = new Estudiante();
                DetalleEstudiante detalleEstudiante = new DetalleEstudiante();
                DetalleEstudianteController detEstCtrl = new DetalleEstudianteController();

                foreach (DataGridViewRow row in dgvParticipantes.Rows)
                {
                    if (row.IsNewRow) continue;
                    

                    estudiante.Identificacion = row.Cells["Identificacion"].Value?.ToString();
                    estudiante.CodigoEmpleado = row.Cells["CodigoEmpleado"].Value?.ToString();
                    estudiante.Convenio = row.Cells["Convenio"].Value?.ToString();
                    estudiante.NombreEmpresa = row.Cells["NombreEmpresa"].Value?.ToString();
                    estudiante.NombreCompleto = row.Cells["NombreCompleto"].Value?.ToString();
                    estudiante.Ubicacion = row.Cells["Ubicacion"].Value?.ToString();
                    estudiante.Gerencia = row.Cells["Gerencia"].Value?.ToString();
                    estudiante.Puesto = row.Cells["Puesto"].Value?.ToString();

                    decimal nota;
                    if (decimal.TryParse(row.Cells["Nota"].Value?.ToString(), out nota))
                    {
                        detalleEstudiante.Notas = nota;
                    }
                    else
                    {

                        detalleEstudiante.Notas = 0;
                    }
                    detalleEstudiante.Grupo = row.Cells["Grupo"].Value?.ToString();
                    detalleEstudiante.Capacitaciones_IdCapacitaciones = idCapacitacion;

                    detEstCtrl.InsertarDetalleEstudiantes(estudiante, detalleEstudiante);
                }
            }
            else
            {
                capacitacion.IdCapacitacion = idCapacitacion;
                CapacitacionController capacitacionC = new CapacitacionController();
                capacitacionC.ActualizarCapacitacion(capacitacion);

                DetalleCapacitadorController detCapCtrl = new DetalleCapacitadorController();
                DetalleEstudianteController detEstCtrl = new DetalleEstudianteController();
                Estudiante estudiante = new Estudiante();
                DetalleEstudiante detalleEstudiante = new DetalleEstudiante();
                

                detCapCtrl.EliminarPorCapacitacion(idCapacitacion);
                detEstCtrl.EliminarDetalleEstuditanes(idCapacitacion);

                foreach (DataGridViewRow row in dgvCapacitadores.Rows)
                {
                    if (row.IsNewRow) continue;
                    object val = row.Cells["IdCapacitador"].Value;
                    if (val == null || val == DBNull.Value) continue;
                    int idCapacitador = Convert.ToInt32(val);
                    detCapCtrl.InsertarDetalleCapacitador(idCapacitacion, idCapacitador);
                }

                foreach (DataGridViewRow row in dgvParticipantes.Rows)
                {
                    if (row.IsNewRow) continue;
                   
                    estudiante.Identificacion = row.Cells["Identificacion"].Value?.ToString();
                    estudiante.CodigoEmpleado = row.Cells["CodigoEmpleado"].Value?.ToString();
                    estudiante.Convenio = row.Cells["Convenio"].Value?.ToString();
                    estudiante.NombreEmpresa = row.Cells["NombreEmpresa"].Value?.ToString();
                    estudiante.NombreCompleto = row.Cells["NombreCompleto"].Value?.ToString();
                    estudiante.Ubicacion = row.Cells["Ubicacion"].Value?.ToString();
                    estudiante.Gerencia = row.Cells["Gerencia"].Value?.ToString();
                    estudiante.Puesto = row.Cells["Puesto"].Value?.ToString();


                    decimal nota;
                    if (decimal.TryParse(row.Cells["Nota"].Value?.ToString(), out nota))
                    {
                        detalleEstudiante.Notas = nota;
                    }
                    else
                    {
                        
                        detalleEstudiante.Notas = 0;
                    }

                    detalleEstudiante.Grupo = row.Cells["Grupo"].Value?.ToString();
                    detalleEstudiante.Capacitaciones_IdCapacitaciones = idCapacitacion;

                    detEstCtrl.InsertarDetalleEstudiantes(estudiante, detalleEstudiante);
                }
            }

            MessageBox.Show("Información guardada con éxito", "Carga", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnGenerarDiplomas.Enabled = (idCapacitacion > 0);

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // 1) Validar duplicados en dgvParticipantes si hay datos
            var dtPart = dgvParticipantes.DataSource as DataTable;
            if (dtPart != null)
            {
                // Ajusta columnas clave a tu regla de unicidad:
                var duplicados = FindDuplicateRows(dtPart, "Identificacion", "CodigoEmpleado");

                if (duplicados.Rows.Count > 0)
                {
                    var resp = MessageBox.Show(
                        $"Se detectaron {duplicados.Rows.Count} filas duplicadas (clave: Identificación + Código Empleado).\n\n" +
                        $"¿Desea continuar con el guardado de todas formas?",
                        "Duplicados detectados",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (resp == DialogResult.No)
                    {
                        // (Opcional) ofrecer ver duplicados
                        var ver = MessageBox.Show("¿Desea ver los registros duplicados?", "Ver duplicados", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (ver == DialogResult.Yes)
                        {
                            using (var frm = new DuplicadosForm(duplicados))
                            {
                                frm.StartPosition = FormStartPosition.CenterParent;
                                frm.ShowDialog(this);
                            }
                        }
                        return; // NO continúa con el guardado
                    }
                }
            }

            // 2) Si no hay duplicados o el usuario aceptó continuar, procede con tu guardado
            GuardarCapacitacionYDetalles();
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

        private void btnCargarParticipantes_Click(object sender, EventArgs e)
        {
            DataTable tabla = null;

            var openFileDialog = new OpenFileDialog
            {
                Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*",
                Title = "Selecciona un archivo Excel"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var res = MessageBox.Show("¿Desea cargar este archivo?", "Carga", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    string rutaArchivo = openFileDialog.FileName;
                    tabla = LeerExcelEnDataTable(rutaArchivo);

                    if (tabla.Rows.Count > 0)
                    {
                        dgvParticipantes.DataSource = tabla;

                        // === NUEVO: detectar duplicados ===
                        // Ajusta las columnas clave a tu regla de unicidad
                        var duplicados = FindDuplicateRows(tabla, "Identificacion", "CodigoEmpleado","Convenio");

                        if (duplicados.Rows.Count > 0)
                        {
                            var r = MessageBox.Show(
                                $"Se encontraron {duplicados.Rows.Count} filas duplicadas según Identificacion+CodigoEmpleado.\n\n¿Desea verlas?",
                                "Duplicados detectados",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning);

                            if (r == DialogResult.Yes)
                            {
                                using (var frm = new DuplicadosForm(duplicados))
                                {
                                    frm.StartPosition = FormStartPosition.CenterParent;
                                    frm.ShowDialog(this);
                                }
                            }
                        }
                        else
                        {
                            // opcional: informar que no hay duplicados
                            // MessageBox.Show("No se encontraron duplicados.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        PlayNotificationSound();
                        MessageBox.Show("Archivo sin registros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btnAgregarCapacitador_Click(object sender, EventArgs e)
        {
            var cap = cboCapacitador.SelectedItem as Capacitador;
            if (cap == null)
            {
                MessageBox.Show("Seleccione un capacitador.");
                return;
            }

            // Evitar duplicados por Id
            foreach (var x in _seleccionados)
                if (x.IdCapacitador == cap.IdCapacitador)
                {
                    MessageBox.Show("Ese capacitador ya está en la lista.");
                    return;
                }

            _seleccionados.Add(cap); 
        }

        private void dgvCapacitadores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvCapacitadores.Columns[e.ColumnIndex].Name == "Quitar")
            {
                var item = dgvCapacitadores.Rows[e.RowIndex].DataBoundItem as Capacitador;
                if (item != null) _seleccionados.Remove(item);
            }
        }

        private static string NormalizeKey(object val)
        {
            if (val == null || val == DBNull.Value) return string.Empty;
            return val.ToString().Trim().ToUpperInvariant();
        }

        private static DataTable FindDuplicateRows(DataTable source, params string[] keyColumns)
        {
            if (source == null) return null;
            if (keyColumns == null || keyColumns.Length == 0)
                throw new ArgumentException("Debes indicar al menos una columna clave.");

            var repes = source.AsEnumerable()
                .Select(r => new
                {
                    Row = r,
                    Key = string.Join("|", keyColumns.Select(k => NormalizeKey(r[k])))
                })
                .GroupBy(x => x.Key)
                .Where(g => g.Count() > 1)
                .SelectMany(g => g.Select(x => x.Row))
                .ToList();

            return repes.Count > 0 ? repes.CopyToDataTable() : source.Clone();
        }

        private void btnGenerarDiplomas_Click(object sender, EventArgs e)
        {
            if (idCapacitacion <= 0) { MessageBox.Show("Primero guarde la capacitación."); return; }

            using (var frm = new DiplomasForm(idCapacitacion))
            {
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog(this);
            }
        }
    }


}

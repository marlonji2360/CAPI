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
    public partial class DuplicadosForm : Form
    {
        private readonly DataGridView _dgv = new DataGridView { Dock = DockStyle.Fill, ReadOnly = true, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill };

        public DuplicadosForm(DataTable duplicados)
        {
            InitializeComponent();
            Text = "Registros Duplicados";
            Width = 900;
            Height = 600;
            Controls.Add(_dgv);
            _dgv.DataSource = duplicados;
        }

        private void DuplicadosForm_Load(object sender, EventArgs e)
        {

        }
    }
}

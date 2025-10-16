using GESCA.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GESCA
{
    public partial class frmMenu : Form
    {
        private Panel sidebar;
        private Panel content;

        public frmMenu()
        {
            
            Text = "CAPI";
            WindowState = FormWindowState.Maximized;
            Font = new Font("Segoe UI", 9F);

            sidebar = new Panel { Dock = DockStyle.Left, Width = 220, BackColor = Color.FromArgb(245, 245, 245) };
            content = new Panel { Dock = DockStyle.Fill, BackColor = Color.White };

            Controls.Add(content);
            Controls.Add(sidebar);

            BuildSidebar();
            LoadView(new HomeView()); // tu vista inicial
        }

        private void LoadView(Form view)
        {
            // hostear Forms dentro del panel content
            foreach (Control c in content.Controls) c.Dispose();
            content.Controls.Clear();

            view.TopLevel = false;
            view.FormBorderStyle = FormBorderStyle.None;
            view.Dock = DockStyle.Fill;
            content.Controls.Add(view);
            view.Show();
        }

      

        private Button MakeNavButton(string text, Action onClick, ref int y)
        {
            var btn = new Button
            {
                Text = text,
                Width = 200,
                Height = 40,
                Left = 10,
                Top = y,
                FlatStyle = FlatStyle.Flat,
                TextAlign = ContentAlignment.MiddleLeft
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.Click += (s, e) => onClick();
            y += 46;
            return btn;
        }



        private void BuildSidebar()
        {
            int y = 20;
            sidebar.Controls.Add(MakeNavButton("Capacitaciones", () => LoadView(new CapacitacionForm()), ref y));
            sidebar.Controls.Add(MakeNavButton("Reporte IVE", () => LoadView(new ReporteIve()), ref y));
            sidebar.Controls.Add(MakeNavButton("Capacitadores", () => LoadView(new CapacitadorForm()), ref y));
            sidebar.Controls.Add(MakeNavButton("Temas", () => LoadView(new TemaForm()), ref y));
            sidebar.Controls.Add(MakeNavButton("Lugares", () => LoadView(new LugarCapacitacionForm()), ref y));

        }

        private void button1_Click(object sender, EventArgs e)
        {

            //DiplomasForm x = new DiplomasForm(23);
            ReporteIve x = new ReporteIve();
            x.Show();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {

        }
    }
}

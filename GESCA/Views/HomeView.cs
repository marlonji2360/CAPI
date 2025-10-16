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
    public partial class HomeView : Form
    {
        public HomeView()
        {
            Text = "Inicio";
            BackColor = Color.White;
            var lbl = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 16f, FontStyle.Bold),
                Text = "Bienvenido a CAPI",
                Location = new Point(20, 20)
            };
            Controls.Add(lbl);
        }

        private void HomeView_Load(object sender, EventArgs e)
        {

        }
    }
}

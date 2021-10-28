using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fakeLogin {
    public partial class Principal : Form {
        public Principal() {
            InitializeComponent();
        }

        private void mnuefetuarlogin_Click(object sender, EventArgs e) {

            frmLogin frm = new frmLogin();
            frm.MdiParent = this;

            frm.itemcadastros = mnucadastros;
            frm.itemlogin = mnulogin;

            frm.Show();
        }
    }
}

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
    public partial class frmLogin : Form {
        public ToolStripMenuItem itemcadastros { get; set; }
        public ToolStripMenuItem itemlogin { get; set; }
        public frmLogin() {
            InitializeComponent();
        }

        private void btnlogar_Click(object sender, EventArgs e) {

            Usuario objusuario = new Usuario();
            objusuario.Email = txtemail.Text;
            objusuario.Senha = txtsenha.Text;

            if (objusuario.logar()) {
                itemcadastros.Visible = true;
                itemlogin.Visible = false;

                this.Close();
            } else {
                MessageBox.Show("Usuario Invalido");
            }
        }
    }
}

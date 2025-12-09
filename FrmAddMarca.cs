using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaCadastro
{
    public partial class FrmAddMarca : Form
    {
        public FrmAddMarca()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtaddmarca_TextChanged(object sender, EventArgs e)
        {

        }

       // private void button2_Click(object sender, EventArgs e)
       // {

        //}

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Sistema formSistema = new Sistema();
            this.Close();
            formSistema.Show();
        }

        private void BtnConfirmaCadastro_Click(object sender, EventArgs e)
        {
            ConectaBanco con = new ConectaBanco();
            bool retorno = con.insereMarca(txtaddmarca.Text);
            if (retorno == false)
                MessageBox.Show(con.mensagem);
            else 
                MessageBox.Show("Marca adicionada com sucesso!");
            txtaddmarca.Clear();
            txtaddmarca.Focus();
        }
    }
}

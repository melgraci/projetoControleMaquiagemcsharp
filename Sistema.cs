using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SistemaCadastro
{
    public partial class Sistema : Form
    {
        int idAlterar;
        public Sistema()
        {
            InitializeComponent();
            
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCadastra_Click(object sender, EventArgs e)
        {
            marcador.Height = btnCadastra.Height;
            marcador.Top = btnCadastra.Top;
            tabControl1.SelectedTab = tabControl1.TabPages[0];
        }
        

        private void btnBusca_Click(object sender, EventArgs e)
        {
            marcador.Height = btnBusca.Height;
            marcador.Top = btnBusca.Top;
            tabControl1.SelectedTab = tabControl1.TabPages[1];
        }







        private void Sistema_Load(object sender, EventArgs e)
        {
         listaCbMarca();
         lista_gridMaquiagem();
        }

        void lista_gridMaquiagem()
        {
            ConectaBanco con = new ConectaBanco();
            dgMaquiagem.DataSource = con.listaMaquiagem();
            dgMaquiagem.Columns["idmaquiagem"].Visible = false;
        }
        public void listaCbMarca()
        {
            ConectaBanco con = new ConectaBanco();
            DataTable tabelaDados = new DataTable();
            tabelaDados = con.listaMarca();
            cbMarca.DataSource = tabelaDados;
            cbMarca.DisplayMember = "marca";
            cbMarca.ValueMember = "idmarca";

            cbAlteraMarca.DataSource = tabelaDados;
            cbAlteraMarca.DisplayMember = "marca";
            cbAlteraMarca.ValueMember = "idmarca";


        }


        private void txtBusca_TextChanged(object sender, EventArgs e)
        {
           (dgMaquiagem.DataSource as DataTable).DefaultView.RowFilter = 
                string.Format("nome like '%{0}%'", txtBusca.Text);
        }

       private void btnRemoveMaquiagem_Click(object sender, EventArgs e)
        {
            int linha = dgMaquiagem.CurrentRow.Index;
            int id = Convert.ToInt32(
                     dgMaquiagem.Rows[linha].Cells["idmaquiagem"].Value.ToString());
            DialogResult resp = MessageBox.Show("Tem certeza que deseja excluir?",
                "Remove Maquiagem", MessageBoxButtons.OKCancel);
            if (resp == DialogResult.OK)
            {
                ConectaBanco con = new ConectaBanco();
                bool retorno = con.deleteMaquiagem(id);
                if (retorno == true)
                {
                    MessageBox.Show("Maquiagem excluida com sucesso!");
                    lista_gridMaquiagem();
                }// fim if retorno true
                else
                    MessageBox.Show(con.mensagem);
            }// fim do if Ok cancela
            else
                MessageBox.Show("Exclusão cancela");
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            int linha = dgMaquiagem.CurrentRow.Index; //pega a linha selecionada
            idAlterar = Convert.ToInt32(
                     dgMaquiagem.Rows[linha].Cells["idmaquiagem"].Value.ToString());
            txtAlteraNome.Text = 
                dgMaquiagem.Rows[linha].Cells["nome"].Value.ToString();
            cbAlteraMarca.Text =
                dgMaquiagem.Rows[linha].Cells["marca"].Value.ToString();
            txtAlteraQuantidade.Text = 
                dgMaquiagem.Rows[linha].Cells["quantidade"].Value.ToString();
            txtAlteraEstoque.Text =
                dgMaquiagem.Rows[linha].Cells["estoque"].Value.ToString();
            tabControl1.SelectedTab = tabAlterar; //muda aba

        }

         private void btnConfirmaAlteracao_Click(object sender, EventArgs e)
        {
            ConectaBanco con = new ConectaBanco();
            Maquiagem novaMaquiagem = new Maquiagem();
            novaMaquiagem.NomeMaquiagem = txtAlteraNome.Text;
            novaMaquiagem.QuantidadeMaquiagem = Convert.ToInt32(txtAlteraQuantidade.Text);
            novaMaquiagem.EstoqueMaquiagem = Convert.ToInt32(txtAlteraEstoque.Text);
            novaMaquiagem.MarcaMaquiagem = cbAlteraMarca.SelectedValue.ToString();
            bool retorno = con.alteraMaquiagem(novaMaquiagem, idAlterar);
            if (retorno == false)
                MessageBox.Show(con.mensagem);
            else 
                MessageBox.Show("Alteração realizada com sucesso!");

                lista_gridMaquiagem();


        }

        private void bntAddMarca_Click(object sender, EventArgs e)
        {
            //FrmAddMarca formMarca = new FrmAddMarca();
           // this.Hide();
           // formMarca.ShowDialog();



        }

        void limpaCampos()
        {
            txtnome.Clear();
            cbMarca.Text = "";
            txtEstoque.Clear();
            txtQuantidade.Clear();
            txtnome.Focus();
        }


        private void BtnConfirmaCadastro_Click(object sender, EventArgs e)
        {
            ConectaBanco con = new ConectaBanco();
            Maquiagem novaMaquiagem = new Maquiagem();
            novaMaquiagem.NomeMaquiagem = txtnome.Text;
            novaMaquiagem.QuantidadeMaquiagem = Convert.ToInt32(txtQuantidade.Text);
            novaMaquiagem.EstoqueMaquiagem = Convert.ToInt32(txtEstoque.Text);
            novaMaquiagem.MarcaMaquiagem = cbMarca.SelectedValue.ToString();
            bool retorno = con.insereMaquiagem(novaMaquiagem);
            if (retorno == false) 
                MessageBox.Show(con.mensagem);

            limpaCampos();
            lista_gridMaquiagem();


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tabCadastrar_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void cbMarca_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

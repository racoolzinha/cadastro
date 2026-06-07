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

namespace cadastro
{
    public partial class FormCadastro : Form
    {
        string caminhoFoto = "";

        public FormCadastro()
        {
            InitializeComponent();
        }

        private void FormCadastro_Load(object sender, EventArgs e)
        {

        }
        //salvar foto
                    private void btnFoto_Click(object sender, EventArgs e)
                    {


                            OpenFileDialog foto = new OpenFileDialog();

                            foto.Filter = "Imagens|*.jpg;*.jpeg;*.png";

                            if (foto.ShowDialog() == DialogResult.OK)
                            {
                                caminhoFoto = foto.FileName;

                                MessageBox.Show("Foto selecionada com sucesso!");

                                pictureBox1.Image = Image.FromFile(caminhoFoto);
                            }
                     }

                     private void chkObtida_CheckedChanged(object sender, EventArgs e)
                      {

                      }

                      private void chkDesejada_CheckedChanged(object sender, EventArgs e)
                      {

                      }


                      private void btnSalvar_Click(object sender, EventArgs e)
                      {
                            if (string.IsNullOrWhiteSpace(txtNome.Text))
                            {
                                MessageBox.Show("Preencha o nome.");
                                return;
                            }

                            if (string.IsNullOrWhiteSpace(txtSelecao.Text))
                            {
                                MessageBox.Show("Preencha a seleção.");
                                return;
                            }

                            if (cmbTipo.SelectedIndex == -1)
                            {
                                MessageBox.Show("Selecione o tipo da figurinha.");
                                return;
                            }

                            if (!chkObtida.Checked && !chkDesejada.Checked)
                            {
                                MessageBox.Show("Marque Obtida ou Desejada.");
                                return;
                            }

                            if (caminhoFoto == "")
                            {
                                MessageBox.Show("Selecione uma foto.");
                                return;
                            }

                            try
                            {
                                string linha =
                                    txtNome.Text + ";" +
                                    txtSelecao.Text + ";" +
                                    cmbTipo.Text + ";" +
                                    chkObtida.Checked + ";" +
                                    chkDesejada.Checked + ";" +
                                    caminhoFoto;

                                File.AppendAllText(
                                    "figurinhas.txt",
                                    linha + Environment.NewLine);

                                MessageBox.Show("Figurinha cadastrada com sucesso!");

                                txtNome.Clear();
                                txtSelecao.Clear();

                                cmbTipo.SelectedIndex = -1;

                                chkObtida.Checked = false;
                                chkDesejada.Checked = false;

                                pictureBox1.Image = null;

                                caminhoFoto = "";
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Erro ao salvar: " + ex.Message);
                            }
                       }

                       private void label3_Click(object sender, EventArgs e)
                       {

                       }

                       private void pictureBox1_Click(object sender, EventArgs e)
                       {

                       }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        // Dados gravados no formato:
        // Nome;Selecao;Tipo;Obtida;Desejada;Foto
    }

}

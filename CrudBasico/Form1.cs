using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace CrudBasico
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection sqlCon = null;

        private string strCon = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=CRUD";
        private string strSql = string.Empty;

        private void Form1_Load(object sender, EventArgs e)
        {
            tsbNovo.Enabled = true;
            tsbSalvar.Enabled = false;
            tsbAlterar.Enabled = false;
            tsbCancelar.Enabled = false;
            tsbExcluir.Enabled = false;
            tsbBuscar.Enabled = true;
            tsbPesquisa.Enabled = true;
            txtIdBuscar.Enabled = false;
            txtNome.Enabled = false;
            txtEndereco.Enabled = false;
            txtCEP.Enabled = false;
            txtBairro.Enabled = false;
            txtCidade.Enabled = false;
            txtUF.Enabled = false;
            txtTelefone.Enabled = false;

            
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void tsbSalvar_Click(object sender, EventArgs e)
        {
            strSql = "insert into Funcionarios(id, Nome, Endereco, CEP, Bairro, Cidade, UF, Telefone) values(@id, @Nome, @Endereco, @CEP, @Bairro, @Cidade, @UF, @Telefone)";
            sqlCon = new SqlConnection(strCon);
            SqlCommand comando = new SqlCommand(strSql, sqlCon);


            comando.Parameters.Add("@Id", SqlDbType.Int).Value = textID.Text;
            comando.Parameters.Add("@Nome", SqlDbType.VarChar).Value = txtNome.Text;
            comando.Parameters.Add("@Endereco", SqlDbType.VarChar).Value = txtEndereco.Text;
            comando.Parameters.Add("@CEP", SqlDbType.VarChar).Value = txtCEP.Text;
            comando.Parameters.Add("@Bairro", SqlDbType.VarChar).Value = txtBairro.Text;
            comando.Parameters.Add("@Cidade", SqlDbType.VarChar).Value = txtCidade.Text;
            comando.Parameters.Add("@UF", SqlDbType.VarChar).Value = txtUF.Text;
            comando.Parameters.Add("@Telefone", SqlDbType.VarChar).Value = txtTelefone.Text ;

            try
            {
                sqlCon.Open();
                comando.ExecuteNonQuery();
                MessageBox.Show("Cadastro realizado com sucesso!");
                 
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                sqlCon.Close();
            }

            tsbNovo.Enabled = true;
            tsbSalvar.Enabled = false;
            tsbAlterar.Enabled = false;
            tsbCancelar.Enabled = false;
            tsbExcluir.Enabled = false;
            tsbBuscar.Enabled = true;
            tsbPesquisa.Enabled = true;
            textID.Enabled = false;
            txtIdBuscar.Enabled = true;
            txtNome.Enabled = false;
            txtEndereco.Enabled = false;
            txtCEP.Enabled = false;
            txtBairro.Enabled = false;
            txtCidade.Enabled = false;
            txtUF.Enabled = false;
            txtTelefone.Enabled = false;

            txtIdBuscar.Text = "";
            txtNome.Text = "";
            txtEndereco.Text = "";
            txtCEP.Text = "";
            txtBairro.Text = "";
            txtCidade.Text = "";
            txtUF.Text = "";
            txtTelefone.Text = "";




        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void txtTelefone_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void tsbBuscar_Click(object sender, EventArgs e)
        {
            strSql = "select * from Funcionarios where Id=@Id";
            sqlCon = new SqlConnection(strCon);
            SqlCommand comando = new SqlCommand(strSql, sqlCon);

            comando.Parameters.Add("@Id", SqlDbType.Int).Value = tsbPesquisa.Text;

            try
            {
                if (tsbPesquisa.Text == string.Empty)
                {
                    throw new Exception("Você precisa digitar uma ID");
                }
                sqlCon.Open();

                SqlDataReader dr = comando.ExecuteReader();

                if(dr.HasRows == false)
                {
                    throw new Exception("ID não cadastrada");
                }

                dr.Read();

                textID.Text = Convert.ToString(dr["Id"]);
                txtNome.Text = Convert.ToString(dr["Nome"]);
                txtEndereco.Text = Convert.ToString(dr["Endereco"]);
                txtCEP.Text = Convert.ToString(dr["CEP"]);
                txtBairro.Text = Convert.ToString(dr["Bairro"]);
                txtCidade.Text = Convert.ToString(dr["Cidade"]);
                txtUF.Text = Convert.ToString(dr["UF"]);
                txtTelefone.Text = Convert.ToString(dr["Telefone"]);
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }

            tsbNovo.Enabled = false;
            tsbSalvar.Enabled = false;
            tsbAlterar.Enabled = true;
            tsbCancelar.Enabled = true;
            tsbExcluir.Enabled = true;
            tsbBuscar.Enabled = true;
            tsbPesquisa.Enabled = true;
            txtIdBuscar.Enabled = true;
            textID.Enabled = false;
            txtNome.Enabled = true;
            txtEndereco.Enabled = true;
            txtCEP.Enabled = true;
            txtBairro.Enabled = true;
            txtCidade.Enabled = true;
            txtUF.Enabled = true;
            txtTelefone.Enabled = true;

            txtNome.Focus();
        }

        private void tsbAlterar_Click(object sender, EventArgs e)
        {

            strSql = "update Funcionarios set Id=@Id, Nome=@Nome, Endereco=@Endereco, CEP=@CEP, Bairro=@Bairro, Cidade=@Cidade, UF=@UF, Telefone=@Telefone where Id=@IdBuscar ";
            sqlCon = new SqlConnection(strCon);
            SqlCommand comando = new SqlCommand(strSql, sqlCon);

            

            comando.Parameters.Add("@IdBuscar", SqlDbType.Int).Value = tsbPesquisa.Text;

            comando.Parameters.Add("@Id", SqlDbType.Int).Value = textID.Text;
            comando.Parameters.Add("@Nome", SqlDbType.VarChar).Value = txtNome.Text;
            comando.Parameters.Add("@Endereco", SqlDbType.VarChar).Value = txtEndereco.Text;
            comando.Parameters.Add("@CEP", SqlDbType.VarChar).Value = txtCEP.Text;
            comando.Parameters.Add("@Bairro", SqlDbType.VarChar).Value = txtBairro.Text;
            comando.Parameters.Add("@Cidade", SqlDbType.VarChar).Value = txtCidade.Text;
            comando.Parameters.Add("@UF", SqlDbType.VarChar).Value = txtUF.Text;
            comando.Parameters.Add("@Telefone", SqlDbType.VarChar).Value = txtTelefone.Text;

            try
            {
                sqlCon.Open();
                comando.ExecuteNonQuery();
                MessageBox.Show("Cadastro atualizado com sucesso!");

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }

            tsbNovo.Enabled = true;
            tsbSalvar.Enabled = false;
            tsbAlterar.Enabled = false;
            tsbCancelar.Enabled = false;
            tsbExcluir.Enabled = false;
            tsbBuscar.Enabled = true;
            tsbPesquisa.Enabled = true;
            textID.Enabled = false;
            txtIdBuscar.Enabled = true;
            txtNome.Enabled = false;
            txtEndereco.Enabled = false;
            txtCEP.Enabled = false;
            txtBairro.Enabled = false;
            txtCidade.Enabled = false;
            txtUF.Enabled = false;
            txtTelefone.Enabled = false;

            
            txtNome.Text = "";
            txtEndereco.Text = "";
            txtCEP.Text = "";
            txtBairro.Text = "";
            txtCidade.Text = "";
            txtUF.Text = "";
            txtTelefone.Text = "";
        }

        private void tsbExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja excluir este funcionario?", "Cuidado", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)== DialogResult.No)
            {
                MessageBox.Show("Operação cancelada!");
            }
            else
            {
                strSql = "delete from Funcionarios where Id=@Id";
                sqlCon = new SqlConnection(strCon);
                SqlCommand comando = new SqlCommand(strSql, sqlCon);

                comando.Parameters.Add("@id", SqlDbType.Int).Value = tsbPesquisa.Text;



                try
                {
                    sqlCon.Open();
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Funcionario deletado com sucesso!!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sqlCon.Close();
                }

                tsbNovo.Enabled = true;
                tsbSalvar.Enabled = false;
                tsbAlterar.Enabled = false;
                tsbCancelar.Enabled = false;
                tsbExcluir.Enabled = false;
                tsbBuscar.Enabled = true;
                tsbPesquisa.Enabled = true;
                txtIdBuscar.Enabled = true;
                txtNome.Enabled = false;
                txtEndereco.Enabled = false;
                txtCEP.Enabled = false;
                txtBairro.Enabled = false;
                txtCidade.Enabled = false;
                txtUF.Enabled = false;
                txtTelefone.Enabled = false;

                txtIdBuscar.Text = "";
                txtEndereco.Text = "";
                txtCEP.Text = "";
                txtBairro.Text = "";
                txtCidade.Text = "";
                txtUF.Text = "";
                txtTelefone.Text = "";
            }


        }

        private void tsbNovo_Click(object sender, EventArgs e)
        {
            tsbNovo.Enabled = false;
            tsbSalvar.Enabled = true;
            tsbAlterar.Enabled = false;
            tsbCancelar.Enabled = true;
            tsbExcluir.Enabled = false;
            tsbBuscar.Enabled = false;
            tsbPesquisa.Enabled = false;
            txtIdBuscar.Enabled = true;
            txtNome.Enabled = true;
            txtEndereco.Enabled = true;
            txtCEP.Enabled = true;
            txtBairro.Enabled = true;
            txtCidade.Enabled = true;
            txtUF.Enabled = true;
            txtTelefone.Enabled = true;
        }

        private void tsbCancelar_Click(object sender, EventArgs e)
        {
            tsbNovo.Enabled = true;
            tsbSalvar.Enabled = false;
            tsbAlterar.Enabled = false;
            tsbCancelar.Enabled = false;
            tsbExcluir.Enabled = false;
            tsbBuscar.Enabled = true;
            tsbPesquisa.Enabled = true;
            txtIdBuscar.Enabled = true;
            txtNome.Enabled = false;
            txtEndereco.Enabled = false;
            txtCEP.Enabled = false;
            txtBairro.Enabled = false;
            txtCidade.Enabled = false;
            txtUF.Enabled = false;
            txtTelefone.Enabled = false;

            
            txtNome.Text = "";
            txtEndereco.Text = "";
            txtCEP.Text = "";
            txtBairro.Text = "";
            txtCidade.Text = "";
            txtUF.Text = "";
            txtTelefone.Text = "";

        }
    }
}

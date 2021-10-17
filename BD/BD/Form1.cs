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
namespace Cadastro
{
    public partial class Form1 : Form
    {
        SqlConnection conexao =
        new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\banco.mdf;Integrated
Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                conexao.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na conexão " + ex.Message);
            }
        }
    }

    private void btnInserir_Click(object sender, EventArgs e)
    {
        string sql;
        int retorno;
        try
        {
            sql = "insert into alunos ( id,nome,curso) values ( " + txtId.Text + ", '" + txtNome.Text + "','" + txtCurso.Text + "')";
            cmd = new SqlCommand(sql, conexao);
            retorno = cmd.ExecuteNonQuery();
            if (retorno > 0)
            {
                MessageBox.Show("Cadastro efetuado");
            }
            else
            {
                MessageBox.Show("Cadastro não realizado");
            }
            txtCurso.Text = "";
            txtId.Text = "";
            txtNome.Text = "";
            cmd.Dispose();
        }
        catch (SqlException ex)
        {
            MessageBox.Show("Erro no comando sql" + ex.Message);
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            string sql;
            try
            {
                sql = "select * from alunos where id = " + txtId.Text;
                cmd = new SqlCommand(sql, conexao);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    txtNome.Text = dr["nome"].ToString();
                    txtCurso.Text = dr["curso"].ToString();
                }
                else
                {
                    MessageBox.Show("Registro não encontrado");
                }
                dr.Close();
                cmd.Dispose();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro no comando sql" + ex.Message);
            }

            private void btnAlterar_Click(object sender, EventArgs e)
            {
                string sql;
                int retorno;
                try
                {
                    sql = "update alunos set nome='" + txtNome.Text + "',curso='" + txtCurso.Text + "' where id=" + txtId.Text;
                    cmd = new SqlCommand(sql, conexao);
                    retorno = cmd.ExecuteNonQuery();
                    if (retorno > 0)
                    {
                        MessageBox.Show("Alteração realizada");
                    }
                    else
                    {
                        MessageBox.Show("Alteração não realizada");
                    }
                    txtCurso.Text = "";
                    txtId.Text = "";
                    txtNome.Text = "";
                    cmd.Dispose();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("ERRO:" + ex.Message);
                }
            }

            private void btnExcluir_Click(object sender, EventArgs e)
            {
                string sql;
                int retorno;
                try
                {
                    sql = "delete alunos where id = " + txtId.Text;
                    cmd = new SqlCommand(sql, conexao);
                    retorno = cmd.ExecuteNonQuery();
                    if (retorno > 0)
                    {
                        MessageBox.Show("Registro excluído");
                    }
                    else
                    {
                        MessageBox.Show("Registro não excluído");
                    }
                    txtCurso.Text = "";
                    txtId.Text = "";
                    txtNome.Text = "";
                    cmd.Dispose();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("ERRO:" + ex.Message);
                }
            }

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
    public partial class frmAlunosCadastrados : Form
    {
        SqlConnection conexao = new
            SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Aula.mdf;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        public frmAlunosCadastrados()
        {
            InitializeComponent();
        }

        private void frmAlunosCadastrados_Load(object sender, EventArgs e)
        {
            string sql;
            try
            {
                conexao.Open();
                sql = "select id from alunos";
                cmd = new SqlCommand(sql, conexao);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lbxDados.Items.Add(dr["id"].ToString());
                }
                cmd.Dispose();
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO " + ex.Message);
            }

        }

        private void lbxDados_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql;
            sql = "select * from alunos where id=" + lbxDados.SelectedItem;
            try
            {
                cmd = new SqlCommand(sql, conexao);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    txtID.Text = dr["id"].ToString();
                    txtNome.Text = dr["nome"].ToString();
                    txtCurso.Text = dr["curso"].ToString();
                }
                cmd.Dispose();
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO " + ex.Message);
            }

        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

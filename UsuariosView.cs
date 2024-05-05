using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UsuariosMVC
{
    public partial class UsuariosView : Form, IUsuariosView
    {
        UsuariosController controller;
        public UsuariosView()
        {
            InitializeComponent();
        }

        #region Implementação da interface IUsuariosView
        public string Id
        {
            get { return txtID.Text; }
            set { txtID.Text = value; }
        }
        public string Nome
        {
            get { return txtNome.Text; }
            set { txtNome.Text = value; }
        }
        public string Sexo
        {
            get
            {
                if (rdMasculino.Checked)
                {
                    return "Masculino";
                }
                else if (rdFeminino.Checked)
                {
                    return "Feminino";
                }
                else
                {
                    return string.Empty;
                };
            }
        }
        public string Departamento
        {
            get { return txtDepartamento.Text; }
            set { txtDepartamento.Text = value; }
        }
        public string Sobrenome
        {
            get { return txtSobrenome.Text; }
            set { txtSobrenome.Text = value; }
        }
        public DataGridView UsuariosConsulta
        {
            get { return grdUsuarios; }
            set { grdUsuarios = value; }
        }
        public RadioButton RbMasculino
        {
            get { return rdMasculino; }
            set { rdMasculino = value; }
        }
        public RadioButton RbFeminino
        {
            get { return rdFeminino; }
            set { rdFeminino = value; }
        }
        #endregion

        private void btnNovo_Click(object sender, EventArgs e)
        {
            controller.Limpar();
        }
        void IUsuariosView.SetController(UsuariosController _controller)
        {
            controller = _controller;
        }
        private void btnGravar_Click(object sender, EventArgs e)
        {
            controller.InserirUsuario();
            controller.Limpar();
        }
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            UsuariosConsulta = controller.ListarUsuarios();
        }
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            controller.ExcluirUsuario();
        }
    }
}

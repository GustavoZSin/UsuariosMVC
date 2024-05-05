using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace UsuariosMVC
{
    internal class UsuariosController
    {
        IUsuariosView usuariosView;
        UsuariosModel usuariosModel;

        public UsuariosController(IUsuariosView view, UsuariosModel model)
        {
            usuariosView = view;
            usuariosModel = model;
            usuariosView.SetController(this);
        }
        public void InserirUsuario()
        {
            if (ValidaInputs())
            {
                Usuario usuario = new Usuario();
                usuario.Id = usuariosView.Id;
                usuario.Nome = usuariosView.Nome;
                usuario.Sexo = usuariosView.Sexo;
                usuario.Departamento = usuariosView.Departamento;
                usuario.Sobrenome = usuariosView.Sobrenome;

                usuariosModel.InserirUsuario(usuario);
            }
        }
        public void ExcluirUsuario()
        {
            if (usuariosView.UsuariosConsulta.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow linha in usuariosView.UsuariosConsulta.SelectedRows)
                {
                    var usuarioTag = linha.Tag;
                    if (usuarioTag != null)
                    {
                        Usuario usuario = (Usuario)usuarioTag;
                        usuariosModel.ExcluirUsuario(usuario);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione um usuário para excluir");
            }
        }
        public DataGridView ListarUsuarios()
        {
            if (usuariosView.UsuariosConsulta.Rows.Count > 0)
                usuariosView.UsuariosConsulta.Rows.Clear();

            List<Usuario> usuarios = usuariosModel.ListarUsuarios();

            foreach (Usuario usuario in usuarios)
            {
                int indiceNovaLinha = usuariosView.UsuariosConsulta.Rows.Add();
                DataGridViewRow novaLinha = usuariosView.UsuariosConsulta.Rows[indiceNovaLinha];
                novaLinha.Cells["id"].Value = usuario.Id.ToString();
                novaLinha.Cells["nome"].Value = usuario.Nome.ToString();
                novaLinha.Cells["sexo"].Value = usuario.Sexo.ToString();
                novaLinha.Cells["departamento"].Value = usuario.Departamento.ToString();
                novaLinha.Cells["sobrenome"].Value = usuario.Sobrenome.ToString();
                novaLinha.Tag = usuario;
            }

            return usuariosView.UsuariosConsulta;
        }
        private bool ValidaInputs()
        {
            string mensagemErro = "Campo(s) [] deve(m) ser preenchido(s). Tente novamente.";
            List<string> camposComErro = new List<string>();

            if(string.IsNullOrEmpty(usuariosView.Id))
                camposComErro.Add("ID");
            if(string.IsNullOrEmpty(usuariosView.Nome))
                camposComErro.Add("Nome");
            if(string.IsNullOrEmpty(usuariosView.Departamento))
                camposComErro.Add("Departamento");
            if(string.IsNullOrEmpty(usuariosView.Sobrenome))
                camposComErro.Add("Sobrenome");
            if (string.IsNullOrEmpty(usuariosView.Sexo))
                camposComErro.Add("Sexo");

            if (camposComErro.Any())
            {
                MessageBox.Show(mensagemErro.Replace("[]", $"[{string.Join(", ", camposComErro)}]"));
                return false;
            }

            return true;
        }
        internal void Limpar()
        {
            usuariosView.Id = "";
            usuariosView.Nome = "";
            usuariosView.RbMasculino.Checked = false;
            usuariosView.RbFeminino.Checked = false;
            usuariosView.Departamento = "";
            usuariosView.Sobrenome = "";
        }
    }
}
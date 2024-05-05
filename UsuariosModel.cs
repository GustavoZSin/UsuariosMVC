using System.Collections.Generic;

namespace UsuariosMVC
{
    internal class UsuariosModel
    {
        private List<Usuario> usuarios = new List<Usuario>();
        public void InserirUsuario(Usuario usuario)
        {
            usuarios.Add(usuario);
        }
        public void ExcluirUsuario(Usuario usuario)
        {
            usuarios.Remove(usuario);
        }
        public List<Usuario> ListarUsuarios()
        {
            return usuarios;
        }
    }
}

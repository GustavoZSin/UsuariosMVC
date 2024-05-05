using System.Windows.Forms;

namespace UsuariosMVC
{
    internal interface IUsuariosView
    {
        void SetController(UsuariosController controller);
        string Id { get; set; }
        string Nome { get; set; }
        string Sexo { get; }
        string Departamento { get; set; }
        string Sobrenome { get; set; }
        RadioButton RbMasculino { get; set; }
        RadioButton RbFeminino { get; set; }
        DataGridView UsuariosConsulta { get; set; }
    }
}

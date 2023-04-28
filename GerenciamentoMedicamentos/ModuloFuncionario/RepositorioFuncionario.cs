using GerenciamentoMedicamentos.ModuloCompartilhado;

namespace GerenciamentoMedicamentos.ModuloFuncionario
{
    public class RepositorioFuncionario : RepositorioBase
    {
        public RepositorioFuncionario()
        {

        }

        public override Funcionario EncontrarRegistro(int id)
        {
            return (Funcionario)base.EncontrarRegistro(id);
        }
    }
}

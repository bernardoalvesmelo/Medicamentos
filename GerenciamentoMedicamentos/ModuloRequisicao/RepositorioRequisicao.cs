using System.Collections;
using GerenciamentoMedicamentos.ModuloCompartilhado;

namespace GerenciamentoMedicamentos.ModuloFornecedor
{
    public class RepositorioFornecedor : RepositorioBase
    {
        public RepositorioFornecedor()
        {

        }

        public override Fornecedor EncontrarRegistro(int id)
        {
            return (Fornecedor)base.EncontrarRegistro(id);
        }
    }
}
